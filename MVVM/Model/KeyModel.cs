using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractManagment.Client.MVVM.Model
{
    public class KeyModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Key { get; set; } = null!;
        public List<ContractModel> Contracts { get; set; }
    }
}
