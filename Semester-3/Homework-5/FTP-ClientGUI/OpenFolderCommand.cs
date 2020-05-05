using System;
using System.Windows.Input;


namespace FtpClientGUI
{
    /// <summary>
    /// Command which opens given folder on the server
    /// </summary>
    public class OpenFolderCommand : ICommand
    {
        private ViewModel viewModel;

        private Model model;

        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Initializes the command
        /// </summary>
        public OpenFolderCommand(ViewModel viewModel, Model model)
        {
            this.viewModel = viewModel;
            this.model = model;
        }

        public bool CanExecute(object o)
        {
            return viewModel != null;
        }

        /// <summary>
        /// Executes the command
        /// </summary>
        public void Execute(object o)
        {
            if (this.viewModel.SelectedForHandling != null
                && this.viewModel.SelectedForHandling[0].IsDirectory)
            {
                var requestedSubfolder = this.viewModel.SelectedForHandling[0].Name;
                this.model.GoToSubfolder(requestedSubfolder);
            }
        }
    }
}