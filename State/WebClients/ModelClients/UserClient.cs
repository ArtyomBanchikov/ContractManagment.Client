using ContractManagment.Client.MVVM.Model.User;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients.ModelClients
{
    public class UserClient : IReadWriteClient<UserModel>
    {
        private IWebClient _webClient;

        public UserClient(IWebClient webClient)
        {
            _webClient = webClient;
        }

        public async Task Create(UserModel obj)
        {
            await _webClient.Client.PostAsJsonAsync("/User", obj);
        }

        public async Task DeleteById(int id)
        {
            await _webClient.Client.DeleteAsync($"/User/{id}");
        }

        public async Task<List<UserModel>> GetAll()
        {
            List<UserModel> list = await _webClient.Client.GetFromJsonAsync<List<UserModel>>("/User");
            return list;
        }

        public Task<UserModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(UserModel obj)
        {
            throw new NotImplementedException();
        }
    }
}
