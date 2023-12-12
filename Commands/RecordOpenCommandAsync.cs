using ContractManagment.Client.Core;
using ContractManagment.Client.MVVM.Model.Records;
using ContractManagment.Client.MVVM.ViewModel;
using ContractManagment.Client.Services;
using ContractManagment.Client.State.Navigators;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ContractManagment.Client.Commands
{
    public class RecordOpenCommandAsync : ICommand
    {
        private RecordsViewModelBase _recordsVM;
        private INavigator _navigator;

        public RecordOpenCommandAsync(RecordsViewModelBase recordsVM, INavigator navigator)
        {
            _navigator = navigator;
            _recordsVM = recordsVM;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (_recordsVM.SelectedFullRecord == null)
            {
                MessageBox.Show("Выберите элемент из списка");
            }
            else
            {
                RecordViewModel recordVM = ServiceProviderFactory.ServiceProvider.GetRequiredService<RecordViewModel>();
                _navigator.CurrentViewModel = recordVM;
                recordVM.RecordKeys.Clear();
                foreach (RecordKeyModel recordKey in _recordsVM.SelectedFullRecord.Record.RecordKeys)
                {
                    recordVM.RecordKeys.Add(recordKey);
                }
            }
        }
    }
}
