using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Input;
using System.Threading.Tasks;

using FTP_ClientGUI.FileExplorer;

namespace FTP_ClientGUI
{
    /// <summary>
    /// SimpleFTP MVVM ViewModel
    /// </summary>
    public class ViewModel : INotifyPropertyChanged
    {
        private Model model = new Model();

        private ConnectCommand connectCommand;

        private DownloadFilesCommand downloadFilesCommand;

        private OpenFolderCommand openFolderCommand;

        /// <summary>
        /// Gets the list of items in directory from server
        /// </summary>
        private List<ItemInfo> ItemListGetter()
            => this.model.IsConnected ? this.model.GetItemsInDirectory().Result : null;

        /// <summary>
        /// List of items in current directory
        /// </summary>
        public List<ItemInfo> ItemList
            => this.ItemListGetter();

        /// <summary>
        /// Items selected for download
        /// </summary>
        public List<ItemInfo> SelectedForHandling { get; set; }

        /// <summary>
        /// Server IP
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// Server port
        /// </summary>
        public string Port { get; set; }

        public ICommand Connect => this.connectCommand;

        public ICommand DownloadFiles => this.downloadFilesCommand;

        public ICommand OpenFolder => this.openFolderCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Initializes the ViewModel
        /// </summary>
        public ViewModel()
        {
            this.connectCommand = new ConnectCommand(this, model);
            this.downloadFilesCommand = new DownloadFilesCommand(this, model);
            this.openFolderCommand = new OpenFolderCommand(this, model);
        }

        /// <summary>
        /// Updates the state of controls
        /// </summary>
        public void UpdateControlsState(string changedProperty)
        {
            this.PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(null));
        }

    }
}
