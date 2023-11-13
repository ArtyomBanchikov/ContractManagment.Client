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
        HttpClient client { get; }
        string Token { get; set; }

    }
}
