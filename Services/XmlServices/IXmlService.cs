namespace ContractManagment.Client.Services.XmlServices
{
    public interface IXmlService
    {
        string Token { get; set; }
        bool IsRemember { get; set; }
        string ServerAddress { get; set; }
        string LastLogin { get; set; }
        int Width { get; set; }
        int Height { get; set; }
    }
}
