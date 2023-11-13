using ContractManagment.Client.MVVM.Model.User;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.Authenticators
{
    public interface IAuthenticator
    {
        LoginUserModel CurrentUser { get; }
        bool IsLoggedIn { get; }
        Task<bool> Login(string username, string password);
        void Logout();
    }
}
