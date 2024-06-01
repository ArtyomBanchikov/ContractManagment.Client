using System.Threading.Tasks;

namespace ContractManagment.Client.Services.StartServices
{
    public interface IStartService
    {
        void Start();
        Task WindowOpen();
    }
}
