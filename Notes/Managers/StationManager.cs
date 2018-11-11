using System;
using System.IO;
using System.Windows;
using Notes.Models;
using Notes.Tools;

namespace Notes.Managers
{
    public static class StationManager
    {

        internal static User CurrentUser { get; set; }

        // serialize and add user to appdata folder
        // to automatic SignIn next time
        internal static void AddCurrentUserToCache()
        {
            SerializationManager.Serialize<User>(CurrentUser, FileFolderHelper.LastUserFilePath);
            Logger.Log($"\t{CurrentUser.ToString()} was added to auto sign in");
        }

        // loading user from appdata folder
        // and deserialize it
        internal static void LoadCurrentUserFromCache()
        {
            if (FileFolderHelper.FileExists(FileFolderHelper.LastUserFilePath)) { }
            CurrentUser = SerializationManager.Deserialize<User>(FileFolderHelper.LastUserFilePath);
            if (CurrentUser != null)
                Logger.Log($"\t{CurrentUser.ToString()} succssesfuly auto sign in");
        }

        // delete serialized user from appdata folder
        // after SignOut
        internal static void RemoveCurrentUserFromCache()
        {
            FileFolderHelper.CheckAndDeleteFile(FileFolderHelper.LastUserFilePath);
            Logger.Log($"\t{CurrentUser.ToString()} was removed from auto sign in");
            CurrentUser = null;
        }

        internal static void UpdateCurrentUserInCache()
        {
            FileFolderHelper.CheckAndDeleteFile(FileFolderHelper.LastUserFilePath);
            if (FileFolderHelper.FileExists(FileFolderHelper.LastUserFilePath)) { }
            CurrentUser = SerializationManager.Deserialize<User>(FileFolderHelper.LastUserFilePath);
            if (CurrentUser != null)
                Logger.Log($"\t{CurrentUser.ToString()} succssesfuly updated");

        }


        internal static void CloseApp()
        {
            MessageBox.Show("ShutDown");
            Environment.Exit(1);
        }
    }
}