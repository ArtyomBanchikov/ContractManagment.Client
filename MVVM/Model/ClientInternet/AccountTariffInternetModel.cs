namespace ContractManagment.Client.MVVM.Model.ClientInternet
{
    public class AccountTariffInternetModel
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int TariffId { get; set; }
        public TariffInternetModel? Tariff { get; set; }
        public int IsDeleted { get; set; }
    }
}
