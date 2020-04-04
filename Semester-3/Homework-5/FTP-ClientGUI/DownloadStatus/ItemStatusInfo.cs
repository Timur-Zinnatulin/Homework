using System.Windows.Media;
using System.ComponentModel;

namespace FTP_ClientGUI.DownloadStatus
{
    /// <summary>
    /// File downloading states
    /// </summary>
    public enum ItemStatus { Neutral, InProgress, Downloaded, Failed };

    /// <summary>
    /// Information about item class
    /// </summary>
    public class ItemStatusInfo : INotifyPropertyChanged
    {
        public string ItemName { get; private set; }

        public Brush ColorStatus { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ItemStatusInfo(string itemName, ItemStatus itemStatus = ItemStatus.Neutral)
        {
            this.ItemName = itemName;
            this.SetItemStatus(itemStatus);
        }

        public void SetItemStatus(ItemStatus status)
        {
            switch(status)
            {
                case ItemStatus.Downloaded:
                    {
                        this.ColorStatus = Brushes.Green;
                        break;
                    }
                case ItemStatus.Failed:
                    {
                        this.ColorStatus = Brushes.Red;
                        break;
                    }
                case ItemStatus.InProgress:
                    {
                        this.ColorStatus = Brushes.Yellow;
                        break;
                    }
                case ItemStatus.Neutral:
                    {
                        this.ColorStatus = Brushes.Transparent;
                        break;
                    }
                default:
                    {
                        this.ColorStatus = Brushes.PaleTurquoise;
                        break;
                    }
            }
            this.PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(null));
        }
    }
}
