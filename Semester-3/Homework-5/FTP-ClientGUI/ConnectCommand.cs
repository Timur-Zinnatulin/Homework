using System;
using System.Windows.Input;

namespace FtpClientGUI
{
    /// <summary>
    /// Command which handles Connect request
    /// </summary>
    public class ConnectCommand : ICommand
    {
        private ViewModel viewModel;

        private Model model;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object o)
            => viewModel != null;

        /// <summary>
        /// Executes the command
        /// </summary>
        public void Execute(object o)
        {
            var isPortConnected = int.TryParse(this.viewModel.Port, out int port);

            if (viewModel.IP != null && isPortConnected)
            {
                this.model.ReconnectToServer(this.viewModel.IP, port);
                this.viewModel.UpdateControlsState();
            }
        }

        /// <summary>
        /// Initializes the command
        /// </summary>
        public ConnectCommand(ViewModel viewModel, Model model)
        {
            this.viewModel = viewModel;
            this.model = model;
        }
    }
}
