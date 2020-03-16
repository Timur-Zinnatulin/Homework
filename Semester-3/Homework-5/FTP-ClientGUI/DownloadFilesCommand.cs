using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Input;

using FTP_ClientGUI.FileExplorer;

namespace FTP_ClientGUI
{
    public class DownloadFilesCommand : ICommand
    {
        private ViewModel viewModel;

        private Model model;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object o)
        {
            return this.viewModel != null;
        }

        public void Execute(object o)
        {
            IList<ItemInfo> filesToDownload;
            if ((string)o == "Selected")
            {
                filesToDownload = this.viewModel.SelectedForHandling;
            }
            else
            {
                filesToDownload = this.viewModel.ItemList;
            }

            if (this.model.IsConnected && filesToDownload != null)
            {
                var savePath = this.GetDestinationPath();
                this.model.DownloadSelectedFiles(filesToDownload, savePath);
            }
        }

        private string GetDestinationPath()

        {
            var folderChooser = new FolderBrowserDialog();
            folderChooser.ShowDialog();

            return folderChooser.SelectedPath;
        }

        public DownloadFilesCommand(ViewModel viewModel, Model model)
        {
            this.viewModel = viewModel;
            this.model = model;
        }
    }
}
