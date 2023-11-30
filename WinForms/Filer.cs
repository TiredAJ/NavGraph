using NavGraphTools;
using System.IO.Compression;

namespace WinForms.Tools
{
    public static class Filer
    {
        /// <summary>
        /// Holds the filepaths of all temporary directories
        /// </summary>
        static List<string> TempDirectories = new List<string>();

        #region Exporting
        /// <summary>
        /// For exporting a NavGraph suitable for final app
        /// </summary>
        /// <param name="_DataStream">Stream to save the file to</param>
        /// <param name="_NG">NavGraph object to extract data from</param>
        public static void ExportToApp(Stream _DataStream, NavGraph _NG)
        { _NG.Serialise(_DataStream, NGSerialiseOptions.SerialiseForApp); }

        /// <summary>
        /// For exporting a NavGraph with admin-level data
        /// </summary>
        /// <param name="_DataStream">Stream to save the file to</param>
        /// <param name="_NG">NavGraph object to extract data from</param>
        public static void ExportToAdmin(Stream _DataStream, NavGraph _NG)
        { _NG.Serialise(_DataStream, NGSerialiseOptions.IncludeMetadata); }

        /// <summary>
        /// For exporting a NavGraph into both forms, zipped
        /// </summary>
        /// <param name="_DataStream">Stream where the ZIP'll go</param>
        /// <param name="_NG">NavGraph object to extract data from</param>
        public static void ExportToZipped(Stream _DataStream, NavGraph _NG)
        {
            string? NewDir = CreateLocalFolder();

            if (NewDir == null)
            { throw new ArgumentNullException("NewDir was null!"); }

            using (FileStream FS = new FileStream(Path.Combine(NewDir, "AdminNavGraph.apjson"), FileMode.CreateNew))
            { ExportToAdmin(FS, _NG); }

            using (FileStream FS = new FileStream(Path.Combine(NewDir, "AppNavGraph.ajson"), FileMode.CreateNew))
            { ExportToApp(FS, _NG); }

            using (_DataStream)
            { ZipFile.CreateFromDirectory(NewDir, _DataStream); }

            CloseLocalFolder(NewDir);
        }
        #endregion

        #region Import
        /// <summary>
        /// Converts file to data
        /// </summary>
        /// <param name="_DataStream">.apjson file</param>
        /// <param name="_NG">NavGraph to write into</param>
        public static void ImportFromAdmin(Stream _DataStream, NavGraph _NG)
        { _NG.Deserialise(_DataStream); }

        /// <summary>
        /// Extracts zip file and saves data from files inside
        /// </summary>
        /// <param name="_DataStream">.apjson.zip file</param>
        /// <param name="_NG">NavGraph to write into</param>
        public static void ImportFromZipped(Stream _DataStream, NavGraph _NG)
        {
            using (FileStream F = _DataStream as FileStream)
            {
                if (F == null || !F.Name.Contains(".ajson.zip"))
                {
                    MessageBox.Show("Wrong kinda zip file buddy");
                    return;
                }

                string? NewDir = CreateLocalFolder();

                if (NewDir == null)
                { throw new ArgumentNullException("NewDir was null!"); }

                ZipFile.ExtractToDirectory(F.Name, NewDir);

                var T = Directory.GetFiles(NewDir, "*.apjson");

                if (T != null)
                { ImportFromAdmin(new FileStream(T.First(), FileMode.Open), _NG); }
                //think about an else using potential combination
            }
        }
        #endregion

        #region Misc
        /// <summary>
        /// Creates a temporary local folder
        /// </summary>
        /// <returns>File-path to folder, or null if it fails</returns>
        private static string? CreateLocalFolder()
        {
            string NewDir = Path.Combine
                (Environment.CurrentDirectory, $"Temp {DateTime.Now.ToString("HH-mm-ss")}");

            var T = Directory.CreateDirectory(NewDir);

            if (T == null)
            { return null; }

            DirectoryInfo DirInfo = T;

            TempDirectories.Add(DirInfo.FullName);

            return DirInfo.FullName;
        }

        /// <summary>
        /// Closes all local folders
        /// </summary>
        public static void CloseLocalFolders()
        {
            foreach (var Dir in TempDirectories)
            { Directory.Delete(Dir); }

            TempDirectories.Clear();
        }

        /// <summary>
        /// Closes a space
        /// </summary>
        /// <param name="_Folder"></param>
        private static void CloseLocalFolder(string _Folder)
        {
            Directory.Delete(_Folder, true);
            TempDirectories.Remove(_Folder);
        }
        #endregion
    }
}
