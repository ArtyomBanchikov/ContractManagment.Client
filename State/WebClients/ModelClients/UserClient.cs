﻿using ContractManagment.Client.MVVM.Model.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients.ModelClients
{
    public class UserClient : IReadWriteClient<UserModel>
    {
        public Task Create(UserModel obj)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserModel>> GetAll()
        {
            throw new NotImplementedException();
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
