using ContractManagment.Client.Commands.User;
using ContractManagment.Client.Core;
using ContractManagment.Client.MVVM.Model.User;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ContractManagment.Client.MVVM.ViewModel.User
{
    public class EditUserViewModel : ViewModelBase
    {
        public ObservableCollection<string> Roles { get; set; }
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        private string _role;
        public string Role
        {
            get { return _role; }
            set
            {
                _role = value;
                OnPropertyChanged(nameof(Role));
            }
        }

        private string _fio;
        public string FIO
        {
            get { return _fio; }
            set
            {
                _fio = value;
                OnPropertyChanged(nameof(FIO));
            }
        }
        public int Id { get; set; }
        public UserModel User { get; set; }
        public ICommand UpdateUserCommand { get; set; }

        public EditUserViewModel()
        {
            Roles = new ObservableCollection<string> { "user", "manager", "admin" };
            UpdateUserCommand = new UpdateUserCommandAsync(this);
        }
    }
}
