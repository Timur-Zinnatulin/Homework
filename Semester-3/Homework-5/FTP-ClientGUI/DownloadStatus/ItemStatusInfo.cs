using System.Windows.Media;
using System.ComponentModel;

namespace FtpClientGUI.DownloadStatus
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
        /// <summary>
        /// Downloaded item name
        /// </summary>
        public string ItemName { get; private set; }

        /// <summary>
        /// Color indicating download status of the item
        /// </summary>
        public Brush ColorStatus { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ItemStatusInfo(string itemName, ItemStatus itemStatus = ItemStatus.Neutral)
        {
            this.ItemName = itemName;
            this.SetItemStatus(itemStatus);
        }

        /// <summary>
        /// Sets a different background color for an item
        /// </summary>
        public void SetItemStatus(ItemStatus status)
        {
            this.ColorStatus = status switch
            {
                ItemStatus.Downloaded => Brushes.Green,
                ItemStatus.Failed => Brushes.Red,
                ItemStatus.InProgress => Brushes.Yellow,
                ItemStatus.Neutral => Brushes.Transparent,
                _ => Brushes.PaleTurquoise,
            };
            this.PropertyChanged?.Invoke
                (this, new PropertyChangedEventArgs("ColorStatus"));
        }

    }
}
