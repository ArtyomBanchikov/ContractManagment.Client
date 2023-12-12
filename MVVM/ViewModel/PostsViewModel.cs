using ContractManagment.Client.Commands;
using ContractManagment.Client.Core;
using ContractManagment.Client.State.Navigators;
using System.Windows.Input;

namespace ContractManagment.Client.MVVM.ViewModel
{
    public class PostsViewModel : RecordsViewModelBase
    {
        public ICommand PostOpenCommand { get; set; }
        public ICommand PostSearchCommand { get; set; }
        public PostsViewModel(INavigator navigator) : base()
        {
            PostOpenCommand = new RecordOpenCommandAsync(this, navigator);
            PostSearchCommand = new PostSearchCommandAsync(this);
        }
    }
}
