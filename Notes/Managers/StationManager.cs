﻿using System;
using System.IO;
using System.Windows;
using Notes.DBModels;
using Notes.Tools;

namespace Notes.Managers
{
    public static class StationManager
    {

        internal static User CurrentUser { get; set; }

        static StationManager()
        {
            GetLastUserFromCache();
        }

        private static void GetLastUserFromCache()
        {
            User userCandidate;
            try
            {
                userCandidate = SerializationManager.Deserialize<User>(Path.Combine(FileFolderHelper.LastUserFilePath));
            }
            catch (Exception ex)
            {
                userCandidate = null;
                Logger.Log("Failed to Deserialize last user", ex);
            }
            if (userCandidate == null)
            {
                Logger.Log("User was not deserialized");
                return;
            }
            userCandidate = DBManager.CheckCachedUser(userCandidate);
            if (userCandidate == null)
                Logger.Log("Failed to relogin last user");
            else
                CurrentUser = userCandidate;
        }

        internal static void AddCurrentUserToCache(User currentUser)
        {
            CurrentUser = currentUser;
            SerializationManager.Serialize<User>(CurrentUser, FileFolderHelper.LastUserFilePath);
            Logger.Log($"\t{CurrentUser.ToString()} successfuly cached on this PC");
        }
        internal static void DeleteCurrentUserFromCache()
        {
            FileFolderHelper.CheckAndDeleteFile(FileFolderHelper.LastUserFilePath);
            FileFolderHelper.CheckAndDeleteFile(FileFolderHelper.StorageFilePath);
            Logger.Log($"\t{CurrentUser.ToString()} successfuly deleted from cach on this PC");
            CurrentUser = null;
        }

        internal static void CloseApp()
        {
            MessageBox.Show("ShutDown");
            Environment.Exit(1);
        }
    }
}