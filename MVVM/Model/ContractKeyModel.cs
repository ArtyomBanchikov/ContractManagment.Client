using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractManagment.Client.MVVM.Model
{
    public class ContractKeyModel
    {
        public int ContractId { get; set; }
        public ContractModel Contract { get; set; }
        public int KeyId { get; set; }
        public KeyModel Key { get; set; }
    }
}
