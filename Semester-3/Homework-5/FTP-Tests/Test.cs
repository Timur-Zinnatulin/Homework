using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;

using Client;
using Server;

namespace Test
{
    /// <summary>
    /// FTP unit tests class
    /// </summary>
    public class FTP_Tests
    {
        private const int port = 8888;
        private const string hostname = "localhost";
        private const int maxConnections = 15;

        private FTP_Server server;

        private void SendWrongCommand(TcpClient client)
        {
            var writer = new StreamWriter(client.GetStream());
            writer.Write("Do you even test bro?");
            writer.Flush();
        }

        private void ForceDisconnect(TcpClient client)
        {
            this.SendWrongCommand(client);
            client.Close();
        }

        private List<EntityInfo> CreateDirectory(string dirName)
        {
            var result = new List<EntityInfo>();
            result.Add(new EntityInfo("subDirectory", true));
            result.Add(new EntityInfo("hugeFile.txt", false));
            for (int i = 1; i <= 4; ++i)
            {
                result.Add(new EntityInfo($"smallFile{i}.txt", false));
            }

            Directory.CreateDirectory(dirName);
            File.WriteAllText(
                Path.Combine(Path.GetFullPath(dirName), "hugeFile.txt"),
                        "This is a big test file");
            for (int i = 1; i <= 4; ++i)
            {
                File.WriteAllText(
                        Path.Combine(Path.GetFullPath(dirName), $"smallFile{i}.txt"),
                        "This is a smaller test file");
            }
            Directory.CreateDirectory(Path.Combine(dirName, "subDirectory"));

            return result;
        }

        [OneTimeSetUp]
        public void Setup()
        {
            this.server = new FTP_Server(maxConnections, port);
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
        public void ServerDoesNotComputeWrongCommandsTest()
        {
            var client = new TcpClient(hostname, port);
            var reader = new StreamReader(client.GetStream());

            this.SendWrongCommand(client);
            var data = reader.ReadToEnd();

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
        public void ClientDisconnectDuringHandlingIsFineTest()
        {
            var client = new TcpClient(hostname, port);

            var writer = new StreamWriter(client.GetStream());
            var reader = new StreamReader(client.GetStream());

            writer.WriteLine("1 WHATEVERPATH");

            client.Close();
        }

        [Test]
        public void ClientShouldReceiveCorrectFileTest()
        {
            var filePath = Path.GetFileName(Path.GetTempFileName());
            var savePath = Path.GetTempFileName();

            var client = new FTP_Client(hostname, port);

            Assert.IsTrue(client.ReceiveFileData(filePath, savePath));

            var testFileContent = new StreamReader(File.OpenRead(Path.GetTempPath() + filePath)).ReadToEnd();
            var receivedFileContent = new StreamReader(File.OpenRead(savePath)).ReadToEnd();

            Assert.AreEqual(testFileContent, receivedFileContent);
        }

        [Test]
        public void ClientShouldReceiveCorrectFileListTest()
        {
            var path = ".test_dir";
            var fullpath = Path.Combine(Path.GetTempPath() + path);
            var actualFileList = this.CreateDirectory(fullpath);

            var client = new FTP_Client(hostname, port);
            var files = client.ReceiveDirContents(path);

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

            Assert.That(files, Is.EquivalentTo(actualFileList).Using(comparison));
        }
    }
}