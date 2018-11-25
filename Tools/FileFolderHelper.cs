using System;
using System.IO;

namespace Notes.Tools
{
    public static class FileFolderHelper
    {
        private static readonly string AppDataPath =
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        internal static readonly string ClientFolderPath =
            Path.Combine(AppDataPath, "Notes");

        internal static readonly string LogFolderPath =
            Path.Combine(ClientFolderPath, "Log");

        internal static readonly string LogFilepath = Path.Combine(LogFolderPath,
            "App_" + DateTime.Now.ToString("YYYY_MM_DD") + ".txt");

        public static readonly string StorageFilePath =
            Path.Combine(ClientFolderPath, "Storage.walsim");

        public static readonly string LastUserFilePath =
            Path.Combine(ClientFolderPath, "LastUser.walsim");

        public static void CheckAndCreateFile(string filePath)
        {
            try
            {
                FileInfo file = new FileInfo(filePath);
                if (!file.Directory.Exists)
                {
                    file.Directory.Create();
                }
                if (!file.Exists)
                {
                    file.Create().Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal static bool FileExists(string path)
        {
            FileInfo file = new FileInfo(path);
            return file.Exists;
        }

        public static void CheckAndDeleteFile(string path)
        {
            try
            {
                FileInfo file = new FileInfo(path);
                if (file.Exists)
                {
                    file.Delete();
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"RemoveCurrentUser failure: {path}", ex);
                throw;
            }
        }
    }
}