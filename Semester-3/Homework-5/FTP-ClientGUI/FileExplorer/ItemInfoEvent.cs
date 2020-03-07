using System;

namespace FTP_ClientGUI.FileExplorer
{
    /// <summary>
    /// EventArgs for requested item
    /// </summary>
    public class ItemInfoEvent : EventArgs
    {
        /// <summary>
        /// New instance of ItemInfoEvent
        /// </summary>
        public ItemInfoEvent(ItemInfo itemInfo)
        {
            this.ItemInfo = itemInfo;
        }

        /// <summary>
        /// Item info
        /// </summary>
        public ItemInfo ItemInfo { get; }
    }
}
