using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Threading.Tasks;

using FtpClientGUI.FileExplorer;

using Ookii.Dialogs.Wpf;

namespace FtpClientGUI
{
    /// <summary>
    /// Command which handles the download request
    /// </summary>
    public class DownloadFilesCommand : ICommand
    {
        private ViewModel viewModel;

        private Model model;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object o)
        {
            return this.viewModel != null;
        }

        /// <summary>
        /// Executes the command
        /// </summary>
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
            var folderChooser = new VistaFolderBrowserDialog();
            folderChooser.ShowNewFolderButton = true;

            folderChooser.ShowDialog();

            return folderChooser.SelectedPath;
        }

        /// <summary>
        /// Initializes the command
        /// </summary>
        public DownloadFilesCommand(ViewModel viewModel, Model model)
        {
            this.viewModel = viewModel;
            this.model = model;
        }
    }
}
