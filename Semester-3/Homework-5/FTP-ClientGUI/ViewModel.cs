using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Input;

using FTP_ClientGUI.FileExplorer;

namespace FTP_ClientGUI
{
    /// <summary>
    /// SimpleFTP ViewModel
    /// </summary>
    public class ViewModel : INotifyPropertyChanged
    {
        private Model model = new Model();

        private ConnectCommand connectCommand;

        private DownloadFilesCommand downloadFilesCommand;

        private OpenFolderCommand openFolderCommand;

        public List<ItemInfo> ItemList
        {
            get => this.model.IsConnected ? this.model.GetItemsInDirectory() : null;
        }

        public List<ItemInfo> SelectedForHandling { get; set; }

        public string IP { get; set; }

        public string Port { get; set; }

        public ICommand Connect => this.connectCommand;

        public ICommand DownloadFiles => this.downloadFilesCommand;

        public ICommand OpenFolder => this.openFolderCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModel()
        {
            this.connectCommand = new ConnectCommand(this, model);
            this.downloadFilesCommand = new DownloadFilesCommand(this, model);
            this.openFolderCommand = new OpenFolderCommand(this, model);
        }

        public void UpdateControlsState(string ChangedProperty)
        {
            this.PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(null));
        }

    }
}
