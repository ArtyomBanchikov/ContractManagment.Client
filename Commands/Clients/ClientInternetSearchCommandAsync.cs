﻿using ContractManagment.Client.MVVM.Model.ClientInternet;
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
    public class ClientInternetSearchCommandAsync : AsyncBaseCommand
    {
        private ClientInternetViewModel _clientInternetVM;

        public ClientInternetSearchCommandAsync(ClientInternetViewModel clientVM)
        {
            _clientInternetVM = clientVM;
        }

        protected async override Task ExecuteAsync(object parameter)
        {
            if(string.IsNullOrEmpty(_clientInternetVM.AccountSearch))
            {
                MessageBox.Show("Введите номер счёта");
            }
            else
            {
                try
                {
                    int account = Convert.ToInt32(_clientInternetVM.AccountSearch);
                    IReadClient<ClientInternetModel> clientInternetClient = ServiceProviderFactory.ServiceProvider.GetRequiredService<IReadClient<ClientInternetModel>>();
                    ClientInternetModel clientInternet = await clientInternetClient.GetById(account);
                    if(clientInternet == null)
                    {
                        MessageBox.Show("Клиент не найден");
                    }
                    else
                    {
                        _clientInternetVM.RecordKeys.Clear();

                        IReadClient<ClientInternetAddParamModel> clientInternetAddParamClient = ServiceProviderFactory.ServiceProvider.GetRequiredService<IReadClient<ClientInternetAddParamModel>>();
                        IReadClient<InternetAddParamModel> internetAddParamClient = ServiceProviderFactory.ServiceProvider.GetRequiredService<IReadClient<InternetAddParamModel>>();
                        IReadClient<AccountTariffInternetModel> accountTariffInternetClient = ServiceProviderFactory.ServiceProvider.GetRequiredService<IReadClient<AccountTariffInternetModel>>();
                        IReadClient<TariffInternetModel> tariffInternetClient = ServiceProviderFactory.ServiceProvider.GetRequiredService<IReadClient<TariffInternetModel>>();

                        List<InternetAddParamModel> internetAddParams = await internetAddParamClient.GetAll();
                        List<ClientInternetAddParamModel> clientInternetAddParams = (await clientInternetAddParamClient.GetAll()).Where(param => param.ClientId == clientInternet.Id).ToList();

                        _clientInternetVM.RecordKeys.Add(new RecordKeyModel { Key = "KeyFIOClient", Name = "Абонент", Value = clientInternet.FullName });
                        _clientInternetVM.RecordKeys.Add(new RecordKeyModel { Key = "KeyClientPassportSmallNumber", Name = "Паспорт", Value = clientInternet.Passport });
                        _clientInternetVM.RecordKeys.Add(new RecordKeyModel { Key = "KeyIdContract", Name = "Номер соглашения", Value = clientInternet.Account.ToString() });
                        _clientInternetVM.RecordKeys.Add(new RecordKeyModel { Key = "KeyClientMobilePhone", Name = "Моб.тел", Value = clientInternet.MobilePhone });
                        _clientInternetVM.RecordKeys.Add(new RecordKeyModel { Key = "KeyClientHomePhone", Name = "Дом.тел", Value = clientInternet.HomePhone });
                        _clientInternetVM.RecordKeys.Add(new RecordKeyModel { Key = "KeyInstallStreet", Name = "Улица установки", Value = clientInternet.Street });
                        _clientInternetVM.RecordKeys.Add(new RecordKeyModel { Key = "KeyInstallBuilding", Name = "Дом установки", Value = clientInternet.Building });
                        _clientInternetVM.RecordKeys.Add(new RecordKeyModel { Key = "KeyInstallPorch", Name = "Подъезд", Value = clientInternet.Entrance });
                        _clientInternetVM.RecordKeys.Add(new RecordKeyModel { Key = "KeyInstallStorey", Name = "Этаж", Value = clientInternet.Floor });
                        _clientInternetVM.RecordKeys.Add(new RecordKeyModel { Key = "KeyInstallApartment", Name = "Квартира установки", Value = clientInternet.Flat });
                        _clientInternetVM.RecordKeys.Add(new RecordKeyModel { Key = "date-connect", Name = "Дата подключения", Value = DateOnly.FromDateTime(clientInternet.ConnectDate).ToString() });

                        AccountTariffInternetModel accountTariff = (await accountTariffInternetClient.GetAll()).FirstOrDefault(accountTariff => accountTariff.AccountId == clientInternet.Account);
                        if (accountTariff != null)
                        {
                            TariffInternetModel tariffInternet = await tariffInternetClient.GetById(accountTariff.TariffId);
                            if (tariffInternet != null && tariffInternet.IsDeleted == 0)
                            {
                                _clientInternetVM.RecordKeys.Add(new RecordKeyModel { Key = "KeyTariff", Name = "Тариф", Value = tariffInternet.Name });
                            }
                        }

                        foreach (ClientInternetAddParamModel internetClientParam in clientInternetAddParams)
                        {
                            if (!string.IsNullOrEmpty(internetClientParam.Value))
                            {
                                InternetAddParamModel addParam = internetAddParams.FirstOrDefault(addP => addP.Id == internetClientParam.ParamId);
                                if (addParam != null)
                                {
                                    RecordKeyModel newRecordKey = new();
                                    if (addParam.Name == "propiska")
                                    {
                                        newRecordKey.Value = internetClientParam.Value;
                                        newRecordKey.Key = "RegistrationAddress";
                                        newRecordKey.Name = "Адрес регистрации";
                                    }
                                    else
                                    {
                                        newRecordKey.Value = internetClientParam.Value;
                                        newRecordKey.Key = addParam.Name;
                                        newRecordKey.Name = addParam.DisplayName;
                                    }
                                    _clientInternetVM.RecordKeys.Add(newRecordKey);
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
