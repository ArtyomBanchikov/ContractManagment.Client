using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractManagment.Client.MVVM.Model.Post
{
    public class PostMetaModel
    {
        public int Id { get; set; }
        public string Key { get; set; } = null!;
        public int PostId { get; set; }
        public PostModel? Post { get; set; }
        public string Value { get; set; } = null!;
    }
}
