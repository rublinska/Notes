using System.ComponentModel;
using System.Windows;

namespace Notes.Tools
{
    internal interface ILoaderOwner : INotifyPropertyChanged
    {
        Visibility LoaderVisibility { get; set; }
        bool IsEnabled { get; set; }
    }
}