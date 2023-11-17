using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractManagment.Client.MVVM.Model.Client
{
    public class ClientAddParamModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public ClientModel Client { get; set; }
        public int ParamId { get; set; }
        public AdditionalParameterModel Parameter { get; set; }
        public string Value { get; set; }
    }
}
