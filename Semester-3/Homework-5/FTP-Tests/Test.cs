using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;

using Client;
using Server;

namespace Test
{
    /// <summary>
    /// FTP unit tests class
    /// </summary>
    public class FtpTests
    {
        private const int port = 8888;
        private const string hostname = "localhost";
        private const int maxConnections = 15;

        private FtpServer server;

        private async void SendWrongCommand(TcpClient client)
        {
            var writer = new StreamWriter(client.GetStream());
            await writer.WriteAsync("Do you even test bro?");
            writer.Flush();
        }

        private void ForceDisconnect(TcpClient client)
        {
            this.SendWrongCommand(client);
            client.Close();
        }

        private async Task<List<EntityInfo>> CreateDirectory(string dirName)
        {
            var result = new List<EntityInfo>();
            result.Add(new EntityInfo("subDirectory", true));
            result.Add(new EntityInfo("hugeFile.txt", false));
            for (int i = 1; i <= 4; ++i)
            {
                result.Add(new EntityInfo($"smallFile{i}.txt", false));
            }

            Directory.CreateDirectory(dirName);
            await File.WriteAllTextAsync(
                Path.Combine(Path.GetFullPath(dirName), "hugeFile.txt"),
                        "This is a big test file");
            for (int i = 1; i <= 4; ++i)
            {
                await File.WriteAllTextAsync(
                        Path.Combine(Path.GetFullPath(dirName), $"smallFile{i}.txt"),
                        "This is a smaller test file");
            }
            Directory.CreateDirectory(Path.Combine(dirName, "subDirectory"));

            return result;
        }

        [OneTimeSetUp]
        public void Setup()
        {
            this.server = new FtpServer(maxConnections, port);
            server.Start();
        }

        [Test]
        public void ServerConnectsCorrectlyTest()
        {
            var client = new TcpClient(hostname, port);

            Assert.IsTrue(client.Connected);

            this.ForceDisconnect(client);
        }

        [Test]
        public async Task ServerDoesNotComputeWrongCommandsTest()
        {
            var client = new TcpClient(hostname, port);
            var reader = new StreamReader(client.GetStream());

            this.SendWrongCommand(client);
            var data = await reader.ReadToEndAsync();

            if (data != string.Empty)
            {
                this.ForceDisconnect(client);
                Assert.Fail();
            }
            else
            {
                client.Close();
            }
        }

        [Test]
        public async Task ClientDisconnectDuringHandlingIsFineTest()
        {
            using (var client = new TcpClient(hostname, port))
            {
                var writer = new StreamWriter(client.GetStream());
                var reader = new StreamReader(client.GetStream());

                await writer.WriteLineAsync("1 WHATEVERPATH");
            }
        }

        [Test]
        public async Task ClientShouldReceiveCorrectFileTest()
        {
            var filePath = Path.GetFileName(Path.GetTempFileName());
            var savePath = Path.GetTempFileName();

            using (var client = new FtpClient(hostname, port))
            {
                var answer = await client.ReceiveFileData(filePath, savePath);
                Assert.IsTrue(answer);

                var testFileContent = await new StreamReader(File.OpenRead(Path.GetTempPath() + filePath)).ReadToEndAsync();
                var receivedFileContent = await new StreamReader(File.OpenRead(savePath)).ReadToEndAsync();

                Assert.AreEqual(testFileContent, receivedFileContent);
            }
        }

        [Test]
        public async Task ClientShouldReceiveCorrectFileListTest()
        {
            var path = ".test_dir";
            var fullpath = Path.Combine(Path.GetTempPath() + path);
            var actualFileList = this.CreateDirectory(fullpath);

            using (var client = new FtpClient(hostname, port))
            {
                var files = await client.ReceiveDirContents(path);

                Comparison<EntityInfo> comparison =
                    (item1, item2) =>
                    {
                        if (item1.IsDirectory == item2.IsDirectory)
                        {
                            return String.Compare(
                                    item1.Name, item2.Name, StringComparison.Ordinal);
                        }
                        else
                        {
                            return (item1.IsDirectory ? -1 : 1);
                        }
                    };

                Assert.That(files, Is.EquivalentTo(actualFileList.Result).Using(comparison));
            }
        }
    }
}