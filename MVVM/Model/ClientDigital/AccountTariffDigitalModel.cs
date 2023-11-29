namespace ContractManagment.Client.MVVM.Model.ClientDigital
{
    public class AccountTariffDigitalModel
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int TariffId { get; set; }
        public TariffDigitalModel? Tariff { get; set; }
        public int IsDeleted { get; set; }
    }
}
