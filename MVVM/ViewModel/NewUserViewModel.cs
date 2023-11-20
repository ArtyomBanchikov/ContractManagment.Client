using ContractManagment.Client.Commands.User;
using ContractManagment.Client.Core;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ContractManagment.Client.MVVM.ViewModel
{
    public class NewUserViewModel : ViewModelBase
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
        public ICommand AddUserCommand { get; set; }
        public NewUserViewModel()
        {
            AddUserCommand = new AddUserCommandAsync(this);
            Roles = new ObservableCollection<string> { "admin", "user" };
        }
    }
}
