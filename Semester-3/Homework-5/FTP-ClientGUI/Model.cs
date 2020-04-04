using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Server;
using Client;

using FTP_ClientGUI.FileExplorer;
using FTP_ClientGUI.DownloadStatus;

namespace FTP_ClientGUI
{
    /// <summary>
    /// SimpleFTP MVVM Model
    /// </summary>
    public class Model
    {
        public const string DefaultFolder = "~";

        /// <summary>
        /// Folder that puts you one level above
        /// </summary>
        public const string LevelUpFolder = "...";

        private string hostname;

        private int port;

        private Stack<string> Path = new Stack<string>();

        /// <summary>
        /// Currently observed directory
        /// </summary>
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

        public bool IsConnected = false;

        public Model()
        {
        }

        /// <summary>
        /// Goes to a subfolder of current folder
        /// </summary>
        public void GoToSubfolder(string subfolderName)
        {
            if (subfolderName == LevelUpFolder)
            {
                this.GoLevelUp();
                return;
            }

            this.Path.Push(subfolderName);
        }

        /// <summary>
        /// Goes oe level above current folder
        /// </summary>
        public string GoLevelUp()
        {
            if (this.Path.Count == 0)
            {
                return DefaultFolder;
            }

            return this.Path.Pop();
        }

        /// <summary>
        /// Connects to server to perform operation
        /// </summary>
        public void ReconnectToServer(string hostname, int port)
        {
            this.hostname = hostname;
            this.port = port;
            this.IsConnected = true;
        }

        /// <summary>
        /// Downloads selected files to a folder of your choice
        /// </summary>
        /// <param name="files">Files selected for download</param>
        /// <param name="folderToSaveTo">Folder selected to download files to</param>
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

            var tasks = new List<Task>();
            Parallel.ForEach(statusWindow.Items, async (file) => 
                {
                    await statusWindow.Dispatcher.InvokeAsync((Action)(() => file.SetItemStatus(ItemStatus.InProgress)));

                    string filePath = string.Empty;
                    if (this.CurrentDirectory != DefaultFolder)
                    {
                        filePath = this.CurrentDirectory + '\\';
                    }

                    bool isReceived = false;
                    isReceived = await this.Client.ReceiveFileData(
                        filePath + file.ItemName,
                        folderToSaveTo + '\\' + file.ItemName).ConfigureAwait(false);

                    await statusWindow.Dispatcher.InvokeAsync((Action)(() => file.SetItemStatus(
                        isReceived ? ItemStatus.Downloaded : ItemStatus.Failed)));
                });
        }

        /// <summary>
        /// Receive a list of items in curent directory
        /// </summary>
        /// <returns>List of items</returns>
        public async Task<List<ItemInfo>> GetItemsInDirectory()
        {
            var items = await this.Client.ReceiveDirContents(this.CurrentDirectory).ConfigureAwait(false);

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
