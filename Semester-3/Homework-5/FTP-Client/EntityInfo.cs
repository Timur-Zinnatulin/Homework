namespace Client
{
    /// <summary>
    /// Provides basic info about file/directory
    /// </summary>
    public class EntityInfo
    {
        public EntityInfo(string name, bool isDirectory)
        {
            this.Name = name;
            this.IsDirectory = isDirectory;
        }

        /// <summary>
        /// File/Directory name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Indicator of whether it is a file or a directory
        /// </summary>
        public bool IsDirectory { get; }
    }
}