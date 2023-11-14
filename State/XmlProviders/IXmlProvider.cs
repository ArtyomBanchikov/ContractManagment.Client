namespace ContractManagment.Client.State.XmlProviders
{
    public interface IXmlProvider
    {
        string Token { get; set; }
        string IsRemember {  get; set; }
        string ServerAddress { get; set; }
    }
}
