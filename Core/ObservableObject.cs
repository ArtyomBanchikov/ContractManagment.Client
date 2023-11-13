using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ContractManagment.Client.Core
{
    public class ObservableObject
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
