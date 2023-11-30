using NavGraphTools;
using System.IO.Compression;

namespace WinForms.Tools
{
    public static class Filer
    {
        static List<string> TempDirectories = new List<string>();

        public static void ExportToApp(Stream _DataStream, NavGraph _NG)
        { _NG.Serialise(_DataStream, NGSerialiseOptions.SerialiseForApp); }

        public static void ExportToAdmin(Stream _DataStream, NavGraph _NG)
        { _NG.Serialise(_DataStream, NGSerialiseOptions.IncludeMetadata); }

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

        public static void ImportFromAdmin(Stream _DataStream, NavGraph _NG)
        { _NG.Deserialise(_DataStream); }

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

        public static void CloseLocalFolders()
        { TempDirectories.Clear(); }

        private static void CloseLocalFolder(string _Folder)
        { TempDirectories.Remove(_Folder); }
    }
}
