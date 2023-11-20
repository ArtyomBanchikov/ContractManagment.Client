namespace ContractManagment.Client.MVVM.Model.Records
{
    public class RecordKeyModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public int RecordId { get; set; }
        public RecordModel Record { get; set; }
    }
}
