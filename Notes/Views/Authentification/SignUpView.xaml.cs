using Notes.ViewModels.Authentication;

namespace Notes.Views.Authentication
{
    internal partial class SignUpView
    {
        #region Constructor
        internal SignUpView()
        {
            InitializeComponent();
            var signUpViewModel = new SignUpViewModel();
            DataContext = signUpViewModel;
        }
        #endregion
    }
}