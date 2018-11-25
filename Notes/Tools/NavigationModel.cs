using System;
using Notes.Managers;
using Notes.ViewModels;
using Notes.ViewModels.Authentication;
using Notes.Views;
using Notes.Views.Authentication;
using SignUpView = Notes.Views.Authentication.SignUpView;

namespace Notes.Tools
{
    internal enum ModesEnum
    {
        SignIn,
        SingUp,
        Main
    }

    internal class NavigationModel
    {
        private readonly IContentWindow _contentWindow;
        private SignInView _signInView;
        private SignUpView _signUpView;
        private MainView _mainView;

        internal NavigationModel(IContentWindow contentWindow)
        {
            _contentWindow = contentWindow;
        }

        internal void Navigate(ModesEnum mode)
        {
            switch (mode)
            {
                case ModesEnum.SignIn:
                    _contentWindow.ContentControl.Content = _signInView = new SignInView();
                    SignInViewModel signInViewModel = _signInView.DataContext as SignInViewModel;
                    if (signInViewModel != null)
                    {
                        if (StationManager.CurrentUser != null)
                        {
                            signInViewModel.Login = StationManager.CurrentUser.Login;
                        }
                        signInViewModel.Password = string.Empty;
                    }
                    break;
                case ModesEnum.SingUp:
                    _contentWindow.ContentControl.Content = _signUpView = new SignUpView();
                    break;
                case ModesEnum.Main:
                    _contentWindow.ContentControl.Content = _mainView = new MainView();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }

    }
}