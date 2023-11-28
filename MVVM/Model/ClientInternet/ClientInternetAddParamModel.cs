namespace ContractManagment.Client.MVVM.Model.ClientInternet
{
    public class ClientInternetAddParamModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public ClientInternetModel Client { get; set; }
        public int ParamId { get; set; }
        public InternetAddParamModel? Parameter { get; set; }
        public string Value { get; set; }
    }
}
