namespace ContractManagment.Client.MVVM.Model.ClientIPTV
{
    public class ClientIPTVAddParamModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public ClientIPTVModel Client { get; set; }
        public int ParamId { get; set; }
        public IPTVAddParamModel? Parameter { get; set; }
        public string Value { get; set; }
    }
}
