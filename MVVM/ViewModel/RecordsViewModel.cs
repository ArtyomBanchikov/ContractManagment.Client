using ContractManagment.Client.Commands;
using ContractManagment.Client.Core;
using ContractManagment.Client.MVVM.Model.Records;
using ContractManagment.Client.State.Navigators;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ContractManagment.Client.MVVM.ViewModel
{
    public class RecordsViewModel : ViewModelBase
    {
        public ICommand RecordOpenCommand { get; set; }
        public ObservableCollection<FullRecordModel> FullRecords { get; set; }
        private FullRecordModel _selectedFullRecord;
        public FullRecordModel SelectedFullRecord
        {
            get { return _selectedFullRecord; }
            set
            {
                _selectedFullRecord = value;
                OnPropertyChanged(nameof(SelectedFullRecord));
            }
        }
        public RecordsViewModel(INavigator navigator)
        {
            FullRecords = new ObservableCollection<FullRecordModel>();
            RecordOpenCommand = new RecordOpenCommandAsync(this, navigator);
        }
    }
}
