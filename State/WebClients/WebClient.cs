using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ContractManagment.Client.State.WebClients
{
    public class WebClient : IWebClient
    {
        public HttpClient client => throw new NotImplementedException();

        public string Token { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public WebClient()
        {
            
        }

        public T Get(T obj)
        {

        }
    }
}
