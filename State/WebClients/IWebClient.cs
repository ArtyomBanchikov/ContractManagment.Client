using ContractManagment.Client.MVVM.Model.User;
using System.Net.Http;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients
{
    public interface IWebClient
    {
        HttpClient Client { get; }
        string Token { get; }
        Task<LoginUserModel> TokenInfo(string token);
        Task<LoginUserModel> Login(ShortUserModel user);
        void Logout();
    }
}
