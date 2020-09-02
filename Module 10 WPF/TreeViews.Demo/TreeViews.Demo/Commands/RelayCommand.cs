using System;
using System.Windows.Input;

namespace TreeViews.Demo.Commands
{
    public class RelayCommand : ICommand
    {
        #region Private Members
        private Action _action;
        #endregion

        #region Constructor
        public RelayCommand(Action action)
        {
            _action= action;
        }
        #endregion

        #region Public Properties
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        #endregion

        #region Command Methods

        public bool CanExecute(object parameter) => true; 

        public void Execute(object parameter)=> _action();
        #endregion

        
    }
}
