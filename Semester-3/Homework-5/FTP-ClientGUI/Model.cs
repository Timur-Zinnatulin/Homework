using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Server;
using Client;

using FTP_ClientGUI.FileExplorer;
using FTP_ClientGUI.DownloadStatus;

namespace FTP_ClientGUI
{
    /// <summary>
    /// SimpleFTP Model
    /// </summary>
    public class Model
    {
        public const string DefaultFolder = "~";

        public const string LevelUpFolder = "...";

        private string hostname;

        private int port;

        private Stack<string> Path = new Stack<string>();

        public string CurrentDirectory
        {
            get
            {
                if (this.Path.Count == 0)
                {
                    return DefaultFolder;
                }

                string result = string.Empty;

                foreach (var e in this.Path)
                {
                    result = $"{e}/{result}";
                }

                return result;
            }
        }

        private FtpClient Client
        {
            get => new FtpClient(this.hostname, this.port);
        }

        public bool IsConnected => true;

        public Model()
        {
        }

        public void GoToSubfolder(string subfolderName)
        {
            if (subfolderName == LevelUpFolder)
            {
                this.GoLevelUp();
                return;
            }

            this.Path.Push(subfolderName);
        }

        public string GoLevelUp()
        {
            if (this.Path.Count == 0)
            {
                return DefaultFolder;
            }

            return this.Path.Pop();
        }

        public void ReconnectToServer(string hostname, int port)
        {
            this.hostname = hostname;
            this.port = port;
        }

        public void DownloadSelectedFiles(
            IEnumerable<ItemInfo> files,
            string folderToSaveTo,
            bool showStatus = true)
        {
            var statusWindow = new DownloadStatusWindow(
                files.Where(a => !a.IsDirectory).Select(a => a.Name));

            if (showStatus)
            {
                statusWindow.Show();
            }

            foreach(var file in statusWindow.Items)
            {
                var task = new Task(() =>
                {
                    statusWindow.Dispatcher.Invoke((Action)(() => file.SetItemStatus(ItemStatus.InProgress)));

                    string filePath = string.Empty;
                    if (this.CurrentDirectory != DefaultFolder)
                    {
                        filePath = this.CurrentDirectory + '\\';
                    }

                    bool isReceived = false;
                    isReceived = this.Client.ReceiveFileData(
                        filePath + file.ItemName,
                        folderToSaveTo + '\\' + file.ItemName).Result;

                    statusWindow.Dispatcher.Invoke((Action)(() => file.SetItemStatus(
                        isReceived ? ItemStatus.Downloaded : ItemStatus.Failed)));
                });

                task.Start();
            }
        }

        public List<ItemInfo> GetItemsInDirectory()
        {
            var items = this.Client.ReceiveDirContents(this.CurrentDirectory).Result;

            var result = new List<ItemInfo>();

            if (this.Path.Count != 0)
            {
                result.Add(new ItemInfo() { Name = "...", IsDirectory = true});
            }

            foreach (var item in items)
            {
                result.Add(new ItemInfo() { Name = item.Name, IsDirectory = item.IsDirectory });
            }

            return result;
        }
    }
}
