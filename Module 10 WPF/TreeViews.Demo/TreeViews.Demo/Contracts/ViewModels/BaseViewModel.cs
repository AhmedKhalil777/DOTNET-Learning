using PropertyChanged;
using System.ComponentModel;

namespace TreeViews.Demo.Contracts.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
        
    }
}
