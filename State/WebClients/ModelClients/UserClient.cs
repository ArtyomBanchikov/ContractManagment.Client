using ContractManagment.Client.MVVM.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients.ModelClients
{
    public class UserClient : IReadWriteClient<UserModel>
    {
        public IWebClient Client { get; set; }

        public UserClient(IWebClient client)
        {
            Client = client;
        }

        public void Create(UserModel obj)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<UserModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(UserModel obj)
        {
            throw new NotImplementedException();
        }
    }
}
