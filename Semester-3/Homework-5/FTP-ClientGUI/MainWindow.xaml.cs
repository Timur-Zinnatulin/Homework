using System;
using System.Windows;

namespace FtpClientGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the folder opening event
        /// </summary>
        private void UserRequestedFolderOpening(object sender, EventArgs e)
        {
            var viewModel = this.DataContext as ViewModel;
            if (viewModel.OpenFolder.CanExecute(null))
            {
                viewModel.OpenFolder.Execute(null);
                viewModel.UpdateControlsState();
            }
        }
    }
}
