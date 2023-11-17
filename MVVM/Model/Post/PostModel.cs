using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractManagment.Client.MVVM.Model.Post
{
    public class PostModel
    {
        public int Id { get; set; }
        public string Type { get; set; } = null!;
        public List<PostMetaModel> Meta { get; set; } = null!;
        public DateTime Date { get; set; }
    }
}
