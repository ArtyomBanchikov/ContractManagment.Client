using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractManagment.Client.MVVM.Model
{
    public class ContractModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<KeyModel> Keys { get; set; }
        public byte[] Value { get; set; } = null!;
    }
}
