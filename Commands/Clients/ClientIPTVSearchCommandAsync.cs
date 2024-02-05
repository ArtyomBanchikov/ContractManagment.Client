using ContractManagment.Client.MVVM.Model.ClientIPTV;
using ContractManagment.Client.MVVM.Model.Records;
using ContractManagment.Client.MVVM.ViewModel.Clients;
using ContractManagment.Client.Services;
using ContractManagment.Client.State.WebClients;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ContractManagment.Client.Commands.Clients
{
    public class ClientIPTVSearchCommandAsync : AsyncBaseCommand
    {
        private ClientIPTVViewModel _clientIPTVVM;

        public ClientIPTVSearchCommandAsync(ClientIPTVViewModel clientVM)
        {
            _clientIPTVVM = clientVM;
        }
        protected async override Task ExecuteAsync(object parameter)
        {
            if (string.IsNullOrEmpty(_clientIPTVVM.AccountSearch))
            {
                MessageBox.Show("Введите номер счёта");
            }
            else
            {
                try
                {
                    int account = Convert.ToInt32(_clientIPTVVM.AccountSearch);
                    IReadClient<ClientIPTVModel> clientIPTVClient = ServiceProviderFactory.ServiceProvider.GetRequiredService<IReadClient<ClientIPTVModel>>();
                    ClientIPTVModel clientIPTV = await clientIPTVClient.GetById(account);
                    if (clientIPTV == null)
                    {
                        MessageBox.Show("Клиент не найден");
                    }
                    else
                    {
                        _clientIPTVVM.RecordKeys.Clear();

                        IReadClient<ClientIPTVAddParamModel> clientIPTVAddParamClient = ServiceProviderFactory.ServiceProvider.GetRequiredService<IReadClient<ClientIPTVAddParamModel>>();
                        IReadClient<IPTVAddParamModel> IPTVAddParamClient = ServiceProviderFactory.ServiceProvider.GetRequiredService<IReadClient<IPTVAddParamModel>>();
                        IReadClient<AccountTariffIPTVModel> accountTariffIPTVClient = ServiceProviderFactory.ServiceProvider.GetRequiredService<IReadClient<AccountTariffIPTVModel>>();
                        IReadClient<TariffIPTVModel> tariffIPTVClient = ServiceProviderFactory.ServiceProvider.GetRequiredService<IReadClient<TariffIPTVModel>>();

                        List<IPTVAddParamModel> IPTVAddParams = await IPTVAddParamClient.GetAll();
                        List<ClientIPTVAddParamModel> clientIPTVAddParams = (await clientIPTVAddParamClient.GetAll()).Where(param => param.ClientId == clientIPTV.Id).ToList();

                        _clientIPTVVM.RecordKeys.Add(new RecordKeyModel { Key = "KeyFIOClient", Name = "Абонент", Value = clientIPTV.FullName });
                        _clientIPTVVM.RecordKeys.Add(new RecordKeyModel { Key = "KeyClientPassportSmallNumber", Name = "Паспорт", Value = clientIPTV.Passport });
                        _clientIPTVVM.RecordKeys.Add(new RecordKeyModel { Key = "KeyIdContract", Name = "Номер соглашения", Value = clientIPTV.Account.ToString() });
                        _clientIPTVVM.RecordKeys.Add(new RecordKeyModel { Key = "KeyClientMobilePhone", Name = "Моб.тел", Value = clientIPTV.MobilePhone });
                        _clientIPTVVM.RecordKeys.Add(new RecordKeyModel { Key = "KeyClientHomePhone", Name = "Дом.тел", Value = clientIPTV.HomePhone });
                        _clientIPTVVM.RecordKeys.Add(new RecordKeyModel { Key = "KeyInstallStreet", Name = "Улица установки", Value = clientIPTV.Street });
                        _clientIPTVVM.RecordKeys.Add(new RecordKeyModel { Key = "KeyInstallBuilding", Name = "Дом установки", Value = clientIPTV.Building });
                        _clientIPTVVM.RecordKeys.Add(new RecordKeyModel { Key = "KeyInstallPorch", Name = "Подъезд", Value = clientIPTV.Entrance });
                        _clientIPTVVM.RecordKeys.Add(new RecordKeyModel { Key = "KeyInstallStorey", Name = "Этаж", Value = clientIPTV.Floor });
                        _clientIPTVVM.RecordKeys.Add(new RecordKeyModel { Key = "KeyInstallApartment", Name = "Квартира установки", Value = clientIPTV.Flat });
                        _clientIPTVVM.RecordKeys.Add(new RecordKeyModel { Key = "date-connect", Name = "Дата подключения", Value = DateOnly.FromDateTime(clientIPTV.ConnectDate).ToString() });

                        AccountTariffIPTVModel accountTariff = (await accountTariffIPTVClient.GetAll()).FirstOrDefault(accountTariff => accountTariff.AccountId == clientIPTV.Account);
                        if (accountTariff != null)
                        {
                            TariffIPTVModel tariffIPTV = await tariffIPTVClient.GetById(accountTariff.TariffId);
                            if (tariffIPTV != null && tariffIPTV.IsDeleted == 0)
                            {
                                _clientIPTVVM.RecordKeys.Add(new RecordKeyModel { Key = "KeyTariff", Name = "Тариф", Value = tariffIPTV.Name });
                            }
                        }

                        foreach (ClientIPTVAddParamModel IPTVClientParam in clientIPTVAddParams)
                        {
                            if (!string.IsNullOrEmpty(IPTVClientParam.Value))
                            {
                                IPTVAddParamModel addParam = IPTVAddParams.FirstOrDefault(addP => addP.Id == IPTVClientParam.ParamId);
                                if (addParam != null)
                                {
                                    RecordKeyModel newRecordKey = new();
                                    if (addParam.Name == "propiska")
                                    {
                                        newRecordKey.Value = IPTVClientParam.Value;
                                        newRecordKey.Key = "RegistrationAddress";
                                        newRecordKey.Name = "Адрес регистрации";
                                    }
                                    else
                                    {
                                        newRecordKey.Value = IPTVClientParam.Value;
                                        newRecordKey.Key = addParam.Name;
                                        newRecordKey.Name = addParam.DisplayName;
                                    }
                                    _clientIPTVVM.RecordKeys.Add(newRecordKey);
                                }
                            }
                        }
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Неправильный ввод счёта");
                }
            }
        }
    }
}
