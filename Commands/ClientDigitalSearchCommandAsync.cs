using ContractManagment.Client.MVVM.Model.ClientDigital;
using ContractManagment.Client.MVVM.Model.Records;
using ContractManagment.Client.MVVM.ViewModel;
using ContractManagment.Client.Services;
using ContractManagment.Client.State.WebClients;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ContractManagment.Client.Commands
{
    public class ClientDigitalSearchCommandAsync : AsyncBaseCommand
    {
        private ClientDigitalViewModel _clientDigitalVM;

        public ClientDigitalSearchCommandAsync(ClientDigitalViewModel clientDigitalVM)
        {
            _clientDigitalVM = clientDigitalVM;
        }

        protected async override Task ExecuteAsync(object parameter)
        {
            if (string.IsNullOrEmpty(_clientDigitalVM.AccountSearch))
            {
                MessageBox.Show("Введите номер счёта");
            }
            else
            {
                try
                {
                    int account = Convert.ToInt32(_clientDigitalVM.AccountSearch);
                    IReadClient<ClientDigitalModel> clientDigitalClient = ServiceProviderFactory.ServiceProvider.GetRequiredService<IReadClient<ClientDigitalModel>>();
                    ClientDigitalModel clientDigital = await clientDigitalClient.GetById(account);
                    if (clientDigital == null)
                    {
                        MessageBox.Show("Клиент не найден");
                    }
                    else
                    {
                        _clientDigitalVM.RecordKeys.Clear();
                        IReadClient<ClientDigitalAddParamModel> clientDigitalAddParamClient = ServiceProviderFactory.ServiceProvider.GetRequiredService<IReadClient<ClientDigitalAddParamModel>>();
                        IReadClient<DigitalAddParamModel> digitalAddParamClient = ServiceProviderFactory.ServiceProvider.GetRequiredService<IReadClient<DigitalAddParamModel>>();
                        List<DigitalAddParamModel> digitalAddParams = await digitalAddParamClient.GetAll();
                        List<ClientDigitalAddParamModel> clientDigitalAddParams = (await clientDigitalAddParamClient.GetAll()).Where(param => param.ClientId == clientDigital.Id).ToList();

                        _clientDigitalVM.RecordKeys.Add(new RecordKeyModel { Key = "KeyFIOClient", Name = "Абонент", Value = clientDigital.FullName });
                        _clientDigitalVM.RecordKeys.Add(new RecordKeyModel { Key = "KeyClientPassportSmallNumber", Name = "Паспорт", Value = clientDigital.Passport });
                        _clientDigitalVM.RecordKeys.Add(new RecordKeyModel { Key = "KeyIdContract", Name = "Номер соглашения", Value = clientDigital.Account.ToString() });
                        _clientDigitalVM.RecordKeys.Add(new RecordKeyModel { Key = "KeyClientMobilePhone", Name = "Моб.тел", Value = clientDigital.MobilePhone });
                        _clientDigitalVM.RecordKeys.Add(new RecordKeyModel { Key = "KeyClientHomePhone", Name = "Дом.тел", Value = clientDigital.HomePhone });
                        _clientDigitalVM.RecordKeys.Add(new RecordKeyModel { Key = "KeyInstallStreet", Name = "Улица установки", Value = clientDigital.Street });
                        _clientDigitalVM.RecordKeys.Add(new RecordKeyModel { Key = "KeyInstallBuilding", Name = "Дом установки", Value = clientDigital.Building });
                        _clientDigitalVM.RecordKeys.Add(new RecordKeyModel { Key = "KeyInstallPorch", Name = "Подъезд", Value = clientDigital.Entrance });
                        _clientDigitalVM.RecordKeys.Add(new RecordKeyModel { Key = "KeyInstallStorey", Name = "Этаж", Value = clientDigital.Floor });
                        _clientDigitalVM.RecordKeys.Add(new RecordKeyModel { Key = "KeyInstallApartment", Name = "Квартира установки", Value = clientDigital.Flat });

                        foreach (ClientDigitalAddParamModel clientDigitalParam in clientDigitalAddParams)
                        {
                            if (!string.IsNullOrEmpty(clientDigitalParam.Value))
                            {
                                DigitalAddParamModel addParam = digitalAddParams.FirstOrDefault(addP => addP.Id == clientDigitalParam.ParamId);
                                if (addParam != null)
                                {
                                    RecordKeyModel newRecordKey = new();
                                    if (addParam.Name == "propiska")
                                    {
                                        newRecordKey.Value = clientDigitalParam.Value;
                                        newRecordKey.Key = "RegistrationAddress";
                                        newRecordKey.Name = "Адрес регистрации";
                                    }
                                    else
                                    {
                                        newRecordKey.Value = clientDigitalParam.Value;
                                        newRecordKey.Key = addParam.Name;
                                        newRecordKey.Name = addParam.DisplayName;
                                    }
                                    _clientDigitalVM.RecordKeys.Add(newRecordKey);
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
