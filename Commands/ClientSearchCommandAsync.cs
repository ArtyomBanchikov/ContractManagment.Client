using ContractManagment.Client.MVVM.Model.Client;
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
    public class ClientSearchCommandAsync : AsyncBaseCommand
    {
        private ClientViewModel _clientVM;

        public ClientSearchCommandAsync(ClientViewModel clientVM)
        {
            _clientVM = clientVM;
        }

        protected async override Task ExecuteAsync(object parameter)
        {
            if(string.IsNullOrEmpty(_clientVM.AccountSearch))
            {
                MessageBox.Show("Введите номер счёта");
            }
            else
            {
                try
                {
                    int account = Convert.ToInt32(_clientVM.AccountSearch);
                    IReadClient<ClientModel> clientClient = ServiceProviderFactory.ServiceProvider.GetRequiredService<IReadClient<ClientModel>>();
                    ClientModel client = await clientClient.GetById(account);
                    if(client == null)
                    {
                        MessageBox.Show("Клиент не найден");
                    }
                    else
                    {
                        _clientVM.RecordKeys.Clear();
                        IReadClient<ClientAddParamModel> clientAddParamClient = ServiceProviderFactory.ServiceProvider.GetRequiredService<IReadClient<ClientAddParamModel>>();
                        IReadClient<AdditionalParameterModel> addParamClient = ServiceProviderFactory.ServiceProvider.GetRequiredService<IReadClient<AdditionalParameterModel>>();
                        List<AdditionalParameterModel> addParams = await addParamClient.GetAll();
                        List<ClientAddParamModel> clientAddParams = (await clientAddParamClient.GetAll()).Where(param => param.ClientId == client.Id).ToList();
                        _clientVM.RecordKeys.Add(new RecordKeyModel { Key = "KeyFIOClient", Name = "Абонент", Value = client.FullName });
                        _clientVM.RecordKeys.Add(new RecordKeyModel { Key = "KeyIdContract", Name = "Номер соглашения", Value = client.Account.ToString() });
                        _clientVM.RecordKeys.Add(new RecordKeyModel { Key = "KeyClientMobilePhone", Name = "Моб.тел", Value = client.MobilePhone });
                        _clientVM.RecordKeys.Add(new RecordKeyModel { Key = "KeyClientHomePhone", Name = "Дом.тел", Value = client.HomePhone });
                        _clientVM.RecordKeys.Add(new RecordKeyModel { Key = "KeyInstallStreet", Name = "Улица установки", Value = client.Street });
                        _clientVM.RecordKeys.Add(new RecordKeyModel { Key = "KeyInstallBuilding", Name = "Дом установки", Value = client.Building });
                        _clientVM.RecordKeys.Add(new RecordKeyModel { Key = "KeyInstallPorch", Name = "Подъезд", Value = client.Entrance });
                        _clientVM.RecordKeys.Add(new RecordKeyModel { Key = "KeyInstallStorey", Name = "Этаж", Value = client.Floor });
                        _clientVM.RecordKeys.Add(new RecordKeyModel { Key = "KeyInstallApartment", Name = "Квартира установки", Value = client.Flat });
                        foreach (ClientAddParamModel clientParam in clientAddParams)
                        {
                            if (!string.IsNullOrEmpty(clientParam.Value))
                            {
                                AdditionalParameterModel addParam = addParams.FirstOrDefault(addP => addP.Id == clientParam.ParamId);
                                if (addParam != null)
                                {
                                    RecordKeyModel newRecordKey = new RecordKeyModel();
                                    if (addParam.Name == "propiska")
                                    {
                                        newRecordKey.Value = clientParam.Value;
                                        newRecordKey.Key = "RegistrationAddress";
                                        newRecordKey.Name = "Адрес регистрации";
                                    }
                                    else
                                    {
                                        newRecordKey.Value = clientParam.Value;
                                        newRecordKey.Key = addParam.Name;
                                        newRecordKey.Name = addParam.DisplayName;
                                    }
                                    _clientVM.RecordKeys.Add(newRecordKey);
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
