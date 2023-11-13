using ContractManagment.Client.State.Navigators;
using System;
using System.Windows.Input;

namespace ContractManagment.Client.Commands
{
    internal class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private INavigator _navigator;

        public UpdateCurrentViewModelCommand(INavigator navigator)
        {
            _navigator = navigator;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if(parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;
                switch (viewType)
                {
                    case ViewType.Contract:
                        break;
                    case ViewType.User:
                        break;
                    case ViewType.Key:
                        break;
                }
            }
        }
    }
}
