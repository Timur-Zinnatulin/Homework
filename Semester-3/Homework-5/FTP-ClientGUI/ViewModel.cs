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

        private List<ItemInfo> ItemListGetter()
            => this.model.IsConnected ? this.model.GetItemsInDirectory().Result : null;

        public List<ItemInfo> ItemList
            => this.ItemListGetter();

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

        public void UpdateControlsState(string changedProperty)
        {
            this.PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(null));
        }

    }
}
