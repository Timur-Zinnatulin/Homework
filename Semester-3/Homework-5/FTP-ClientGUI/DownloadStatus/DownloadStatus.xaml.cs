using System.Collections.Generic;
using System.Windows;
using System.ComponentModel;
using System.Collections.ObjectModel;


namespace FtpClientGUI.DownloadStatus
{
    /// <summary>
    /// Логика взаимодействия для DownloadStatus.xaml
    /// </summary>
    public partial class DownloadStatusWindow : Window
    {
        /// <summary>
        /// Initializes DownloadStatus
        /// </summary>
        public DownloadStatusWindow(IEnumerable<string> names)
        {
            InitializeComponent();

            this.DataContext = this;

            foreach(var item in names)
            {
                var newItem = new ItemStatusInfo(item);

                this.Items.Add(newItem);
            }
        }

        public ObservableCollection<ItemStatusInfo> Items { get; private set; } =
            new ObservableCollection<ItemStatusInfo>();
    }
}
