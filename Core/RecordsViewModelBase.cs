using ContractManagment.Client.MVVM.Model.Records;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractManagment.Client.Core
{
    public class RecordsViewModelBase : ViewModelBase
    {
        public ObservableCollection<string> KeyNames { get; set; }
        public ObservableCollection<LongRecordModel> FullRecords { get; set; }

        private LongRecordModel _selectedFullRecord;
        public LongRecordModel SelectedFullRecord
        {
            get { return _selectedFullRecord; }
            set
            {
                _selectedFullRecord = value;
                OnPropertyChanged(nameof(SelectedFullRecord));
            }
        }

        private string _selectedKeyName;
        public string SelectedKeyName
        {
            get { return _selectedKeyName; }
            set
            {
                _selectedKeyName = value;
                OnPropertyChanged(nameof(SelectedKeyName));
            }
        }
        private string _searchString;
        public string SearchString
        {
            get { return _searchString; }
            set
            {
                _searchString = value;
                OnPropertyChanged(nameof(SearchString));
            }
        }
        public RecordsViewModelBase()
        {
            KeyNames = new ObservableCollection<string>();
            FullRecords = new ObservableCollection<LongRecordModel>();
        }
    }
}
