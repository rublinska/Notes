using Notes.ViewModels;
using Notes.Models;

namespace Notes.Views.Note
{
    public partial class NoteConfigView
    {
        public NoteConfigView(NoteUIModel notes)
        {
            InitializeComponent();
            var notesModel = new NoteConfigViewModel(notes);
            DataContext = notesModel;
        }
    }
}