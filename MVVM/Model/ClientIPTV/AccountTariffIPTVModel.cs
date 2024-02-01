namespace ContractManagment.Client.MVVM.Model.ClientIPTV
{
    public class AccountTariffIPTVModel
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int TariffId { get; set; }
        public TariffIPTVModel? Tariff { get; set; }
        public int IsDeleted { get; set; }
    }
}
