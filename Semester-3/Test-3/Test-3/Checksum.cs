using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Linq;

namespace Test_3
{
    /// <summary>
    /// MD5 checksum class
    /// </summary>
    public static class CheckSum
    {
        /// <summary>
        /// Calculates checksum for a single file
        /// </summary>
        private static string calculateFileMD5(string pathToFile)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(pathToFile))
                {
                    return md5.ComputeHash(stream).ToString();
                }
            }
        }

        /// <summary>
        /// Calculates checksum for a directory and its subdirectories and files
        /// </summary>
        public static string CalculateMD5(string path)
        {
            string code = null;
            var md5 = MD5.Create();

            var attribute = File.GetAttributes(path);
            if ((attribute & FileAttributes.Directory) == FileAttributes.Directory)
            {
                var dir = new DirectoryInfo(path);
                var bytes = Encoding.ASCII.GetBytes(dir.FullName);
                code += md5.ComputeHash(bytes).ToString();
                
                var unsortedDirs = dir.EnumerateDirectories();

                var directories = from d in unsortedDirs
                                  orderby d.Name 
                                  select d;

                foreach (var selectedDir in directories)
                {
                    code += CalculateMD5(selectedDir.FullName);
                }

                var unsortedFiles = dir.EnumerateFiles();

                var files = from f in unsortedFiles
                                    orderby f.Name
                                    select f;

                foreach (var file in files)
                {
                    code += calculateFileMD5(file.FullName);
                }
            }
            
            return code;
        }
    }
}
