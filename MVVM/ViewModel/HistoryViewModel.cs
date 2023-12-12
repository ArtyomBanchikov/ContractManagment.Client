using ContractManagment.Client.Commands;
using ContractManagment.Client.Core;
using ContractManagment.Client.State.Navigators;
using System.Windows.Input;

namespace ContractManagment.Client.MVVM.ViewModel
{
    public class HistoryViewModel : RecordsViewModelBase
    {
        public ICommand HistoryOpenCommand { get; set; }
        public ICommand HistorySearchCommand { get; set; }
        public HistoryViewModel(INavigator navigator) : base()
        {
            HistoryOpenCommand = new RecordOpenCommandAsync(this, navigator);
            HistorySearchCommand = new HistorySearchCommandAsync(this);
        }
    }
}
