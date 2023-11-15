﻿using ContractManagment.Client.MVVM.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients
{
    public interface IWebClient
    {
        HttpClient Client { get; }
        string Token { get; }
        LoginUserModel TokenInfo(string token);
        LoginUserModel Login(ShortUserModel user);
        Task<bool> Logout();
    }
}
