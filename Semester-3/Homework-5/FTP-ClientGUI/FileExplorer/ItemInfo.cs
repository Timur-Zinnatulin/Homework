using System;

namespace FTP_ClientGUI.FileExplorer
{
    /// <summary>
    /// Information about items in FileExplorer
    /// </summary>
    public class ItemInfo
    {
        /// <summary>
        /// Item name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Is item a directory or a file
        /// </summary>
        public bool IsDirectory { get; set; }
    }
}
