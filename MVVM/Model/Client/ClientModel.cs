using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractManagment.Client.MVVM.Model.Client
{
    public class ClientModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Passport { get; set; }
        public int Account { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public string Flat { get; set; }
        public string Entrance { get; set; }
        public string Building { get; set; }
        public List<ClientAddParamModel> Params { get; set; }
    }
}
