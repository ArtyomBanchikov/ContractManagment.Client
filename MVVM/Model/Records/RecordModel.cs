using System;
using System.Collections.Generic;

namespace ContractManagment.Client.MVVM.Model.Records
{
    public class RecordModel
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public List<RecordKeyModel> RecordKeys { get; set; }
    }
}
