using Notes.ViewModels;

namespace Notes.Views.Note
{
    public partial class NoteConfigView
    {
        public NoteConfigView(Models.Note notes)
        {
            InitializeComponent();
            var notesModel = new NoteConfigViewModel(notes);
            DataContext = notesModel;
        }
    }
}