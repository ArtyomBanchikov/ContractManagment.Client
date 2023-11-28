namespace ContractManagment.Client.MVVM.Model.ClientDigital
{
    public class ClientDigitalAddParamModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public ClientDigitalModel Client { get; set; }
        public int ParamId { get; set; }
        public DigitalAddParamModel? Parameter { get; set; }
        public string Value { get; set; }
    }
}
