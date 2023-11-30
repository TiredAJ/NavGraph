using NavGraphTools;

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
            //maybe use 7zip?
        }

        public static void ImportFromAdmin(Stream _File, NavGraph _NG)
        {
            _NG.Deserialise(_File);
        }

        public static void ImportFromZipped(Stream _File, NavGraph _NG)
        {
            using (FileStream F = _File as FileStream)
            {
                if (F == null || !F.Name.Contains(".ajson.zip"))
                {
                    MessageBox.Show("Wrong kinda zip file buddy");
                    return;
                }


            }

            //ImportFromAdmin();
        }

        private static string? CreateLocalFolder()
        {
            string NewDir = Path.Combine(Environment.CurrentDirectory, "Temp");

            var T = Directory.CreateDirectory(NewDir);

            if (T == null)
            { return null; }

            DirectoryInfo DirInfo = T;

            TempDirectories.Add(DirInfo.FullName);

            return DirInfo.FullName;
        }

        public static void CloseLocalFolders()
        {
            foreach (var Dir in TempDirectories)
            { Directory.Delete(Dir, true); }
        }
    }
}
