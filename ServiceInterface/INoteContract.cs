using System;
using System.Collections.Generic;
using System.ServiceModel;
using Notes.DBModels;

namespace WCF.Notes.ServiceInterface
{
    [ServiceContract]
    public interface INoteContract
    {
        [OperationContract]
        bool UserExists(string login);
        [OperationContract]
        User GetUserByLogin(string login);
        [OperationContract]
        User GetUserByGuid(Guid guid);
        [OperationContract]
        List<User> GetAllUsers(Guid NoteGuid);
        [OperationContract]
        void AddUser(User user);
        [OperationContract]
        void AddNote(Note Note);
        [OperationContract]
        void SaveNote(Note Note);
        [OperationContract]
        void DeleteNote(Note selectedNote);
    }
}
