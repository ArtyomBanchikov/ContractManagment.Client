using ContractManagment.Client.MVVM.Model;
using ContractManagment.Client.MVVM.Model.Client;
using ContractManagment.Client.MVVM.Model.Post;
using ContractManagment.Client.MVVM.Model.Records;
using ContractManagment.Client.MVVM.Model.User;
using ContractManagment.Client.MVVM.ViewModel;
using ContractManagment.Client.MVVM.ViewModel.Contract;
using ContractManagment.Client.Services;
using ContractManagment.Client.State.Authenticators;
using ContractManagment.Client.State.Navigators;
using ContractManagment.Client.State.WebClients;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;

namespace ContractManagment.Client.Commands
{
    public class UpdateCurrentViewModelCommandAsync : AsyncBaseCommand
    {
        private INavigator _navigator;
        public UpdateCurrentViewModelCommandAsync(INavigator navigator)
        {
            _navigator = navigator;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            if(parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;
                switch (viewType)
                {
                    case ViewType.Contracts:
                        _navigator.CurrentViewModel = ServiceProviderFactory.ServiceProvider.GetRequiredService<ContractViewModel>();
                        if (((ContractViewModel)_navigator.CurrentViewModel).Contracts == null)
                        {
                            IReadWriteClient<ContractModel> contractClient = ServiceProviderFactory.ServiceProvider.GetRequiredService<IReadWriteClient<ContractModel>>();
                            ((ContractViewModel)_navigator.CurrentViewModel).Contracts = new ObservableCollection<ContractModel>();
                            ((ContractViewModel)_navigator.CurrentViewModel).ContractsNames = new ObservableCollection<string>();
                            List<ContractModel> contracts = await contractClient.GetAll();
                            contracts.ForEach(contract => ((ContractViewModel)_navigator.CurrentViewModel).Contracts.Add(contract));
                            contracts.ForEach(contract => ((ContractViewModel)_navigator.CurrentViewModel).ContractsNames.Add(contract.Name));
                        }
                        break;

                    case ViewType.NewContract:
                        {
                            _navigator.CurrentViewModel = ServiceProviderFactory.ServiceProvider.GetRequiredService<NewContractViewModel>();
                            IReadWriteClient<KeyModel> keyClient = ServiceProviderFactory.ServiceProvider.GetRequiredService<IReadWriteClient<KeyModel>>();
                            ((NewContractViewModel)_navigator.CurrentViewModel).Keys = new ObservableCollection<KeyModel>();
                            List<KeyModel> keys = await keyClient.GetAll();
                            keys.ForEach(key => ((NewContractViewModel)_navigator.CurrentViewModel).Keys.Add(key));
                            break;
                        }
                    case ViewType.Users:
                        _navigator.CurrentViewModel = ServiceProviderFactory.ServiceProvider.GetRequiredService<UserViewModel>();
                        if(((UserViewModel)_navigator.CurrentViewModel).Users == null)
                        {
                            IReadWriteClient<UserModel> userClient = ServiceProviderFactory.ServiceProvider.GetRequiredService<IReadWriteClient<UserModel>>();
                            ((UserViewModel)_navigator.CurrentViewModel).Users = new ObservableCollection<UserModel>();
                            List<UserModel> users = await userClient.GetAll();
                            string currentUserName = ServiceProviderFactory.ServiceProvider.GetRequiredService<IAuthenticator>().CurrentUser.Name;
                            foreach(UserModel user in users)
                            {
                                if (user.Name != currentUserName)
                                    ((UserViewModel)_navigator.CurrentViewModel).Users.Add(user);
                            }
                        }
                        _navigator.CurrentViewModel = ServiceProviderFactory.ServiceProvider.GetRequiredService<UserViewModel>();
                        break;

                    case ViewType.NewUser:
                        _navigator.CurrentViewModel = ServiceProviderFactory.ServiceProvider.GetRequiredService<NewUserViewModel>();
                        break;

                    case ViewType.Keys:
                        _navigator.CurrentViewModel = ServiceProviderFactory.ServiceProvider.GetRequiredService<KeyViewModel>();
                        if(((KeyViewModel)_navigator.CurrentViewModel).Keys == null)
                        {
                            IReadWriteClient<KeyModel> keyClient = ServiceProviderFactory.ServiceProvider.GetRequiredService<IReadWriteClient<KeyModel>>();
                            ((KeyViewModel)_navigator.CurrentViewModel).Keys = new ObservableCollection<KeyModel>();
                            List<KeyModel> keys = await keyClient.GetAll();
                            keys.ForEach(key => ((KeyViewModel)_navigator.CurrentViewModel).Keys.Add(key));
                        }
                        break;

                    case ViewType.NewKey:
                        _navigator.CurrentViewModel = ServiceProviderFactory.ServiceProvider.GetRequiredService<NewKeyViewModel>();
                        break;

                    case ViewType.Clients:
                        _navigator.CurrentViewModel = ServiceProviderFactory.ServiceProvider.GetRequiredService<ClientViewModel>();
                        break;

                    case ViewType.Requests:
                        RecordsViewModel requestsVM = ServiceProviderFactory.ServiceProvider.GetRequiredService<RecordsViewModel>();
                        _navigator.CurrentViewModel = requestsVM;
                        requestsVM.FullRecords.Clear();
                        IReadClient<PostModel> postClient = ServiceProviderFactory.ServiceProvider.GetRequiredService<IReadClient<PostModel>>();
                        IReadClient<PostMetaModel> postMetaClient = ServiceProviderFactory.ServiceProvider.GetRequiredService<IReadClient<PostMetaModel>>();
                        List<PostModel> posts = await postClient.GetAll();
                        List<PostMetaModel> postsMeta = await postMetaClient.GetAll();
                        foreach(PostModel post in posts)
                        {
                            List<PostMetaModel> postMeta = postsMeta.Where(postM => postM.PostId == post.Id).ToList();
                            if (postMeta.Any())
                            {
                                post.Meta = postMeta;
                                FullRecordModel fullRecord = new FullRecordModel();
                                fullRecord.Record = new RecordModel { RecordKeys = new List<RecordKeyModel>() };
                                fullRecord.Value = $"{post.Date}";

                                PostMetaModel nameMeta = postMeta.FirstOrDefault(nameM => nameM.Key == "_user_name");
                                if (nameMeta != null && !string.IsNullOrEmpty(nameMeta.Value))
                                {
                                    fullRecord.Value += $", {nameMeta.Value}";
                                    fullRecord.Record.RecordKeys.Add(new RecordKeyModel { Key= "KeyFIOClient", Name= "Абонент", Value=nameMeta.Value });
                                }

                                PostMetaModel streetMeta = postMeta.FirstOrDefault(streetM => streetM.Key == "_user_street");
                                if (streetMeta != null && !string.IsNullOrEmpty(streetMeta.Value))
                                {
                                    fullRecord.Value += $", {streetMeta.Value}";
                                    fullRecord.Record.RecordKeys.Add(new RecordKeyModel { Key = "KeyInstallStreet", Name = "Улица установки", Value = streetMeta.Value });
                                }

                                PostMetaModel houseMeta = postMeta.FirstOrDefault(houseM => houseM.Key == "_user_home_number");
                                if (houseMeta != null && !string.IsNullOrEmpty(houseMeta.Value))
                                {
                                    fullRecord.Value += $", д. {houseMeta.Value}";
                                    fullRecord.Record.RecordKeys.Add(new RecordKeyModel { Key = "KeyInstallBuilding", Name = "Дом установки", Value = houseMeta.Value });
                                }

                                PostMetaModel flatMeta = postMeta.FirstOrDefault(flatM => flatM.Key == "_user_flat_number");
                                if (flatMeta != null && !string.IsNullOrEmpty(flatMeta.Value))
                                {
                                    fullRecord.Value += $", кв. {flatMeta.Value}";
                                    fullRecord.Record.RecordKeys.Add(new RecordKeyModel { Key = "KeyInstallApartment", Name = "Квартира установки", Value = flatMeta.Value });
                                }

                                PostMetaModel porchMeta = postMeta.FirstOrDefault(porchM => porchM.Key == "_user_entrance_number");
                                if (porchMeta != null && !string.IsNullOrEmpty(porchMeta.Value))
                                {
                                    fullRecord.Value += $", под. {porchMeta.Value}";
                                    fullRecord.Record.RecordKeys.Add(new RecordKeyModel { Key = "KeyInstallPorch", Name = "Подъезд", Value = porchMeta.Value });
                                }

                                PostMetaModel floorMeta = postMeta.FirstOrDefault(floorM => floorM.Key == "_user_floor_number");
                                if (floorMeta != null && !string.IsNullOrEmpty(floorMeta.Value))
                                {
                                    fullRecord.Value += $", этаж {floorMeta.Value}";
                                    fullRecord.Record.RecordKeys.Add(new RecordKeyModel { Key = "KeyInstallStorey", Name = "Этаж", Value = floorMeta.Value });
                                }

                                PostMetaModel mobPhoneMeta = postMeta.FirstOrDefault(mobPhoneM => mobPhoneM.Key == "_user_mobile_phone");
                                if (mobPhoneMeta != null && !string.IsNullOrEmpty(mobPhoneMeta.Value))
                                    fullRecord.Record.RecordKeys.Add(new RecordKeyModel { Key = "KeyClientMobilePhone", Name = "Моб.тел", Value = mobPhoneMeta.Value });

                                PostMetaModel homePhoneMeta = postMeta.FirstOrDefault(homePhoneM => homePhoneM.Key == "_user_home_phone");
                                if (homePhoneMeta != null && !string.IsNullOrEmpty(homePhoneMeta.Value))
                                    fullRecord.Record.RecordKeys.Add(new RecordKeyModel { Key = "KeyClientHomePhone", Name = "Дом.тел", Value = homePhoneMeta.Value });

                                PostMetaModel regMeta = postMeta.FirstOrDefault(regM => regM.Key == "_user_reg_address");
                                if (regMeta != null && !string.IsNullOrEmpty(regMeta.Value))
                                    fullRecord.Record.RecordKeys.Add(new RecordKeyModel { Key = "RegistrationAddress", Name = "Адрес регистрации", Value = regMeta.Value });

                                PostMetaModel passMeta = postMeta.FirstOrDefault(passM => passM.Key == "_user_passport_number");
                                if (passMeta != null && !string.IsNullOrEmpty(passMeta.Value))
                                    fullRecord.Record.RecordKeys.Add(new RecordKeyModel { Key = "KeyClientPassportSmallNumber", Name = "Паспорт", Value = passMeta.Value });

                                PostMetaModel idMeta = postMeta.FirstOrDefault(idM => idM.Key == "_user_id_number");
                                if (idMeta != null && !string.IsNullOrEmpty(idMeta.Value))
                                    fullRecord.Record.RecordKeys.Add(new RecordKeyModel { Key = "KeyClientPassportFullNumber", Name = "Личный номер", Value = idMeta.Value });

                                PostMetaModel organMeta = postMeta.FirstOrDefault(organM => organM.Key == "_user_passport_organ");
                                PostMetaModel passportDateMeta = postMeta.FirstOrDefault(passDateM => passDateM.Key == "_user_date_passport");
                                if (organMeta != null && !string.IsNullOrEmpty(organMeta.Value))
                                {
                                    fullRecord.Record.RecordKeys.Add(new RecordKeyModel { Key = "KeyClientPassportIssued", Name = "Выдан", Value = organMeta.Value });
                                    if (passportDateMeta != null && !string.IsNullOrEmpty(passportDateMeta.Value))
                                        fullRecord.Record.RecordKeys.Add(new RecordKeyModel { Key = "KeyClientPassportIssued", Name = "Выдан", Value = $"{organMeta.Value} {passportDateMeta.Value}" });
                                    else
                                        fullRecord.Record.RecordKeys.Add(new RecordKeyModel { Key = "KeyClientPassportIssued", Name = "Выдан", Value = organMeta.Value});
                                }
                                else if(passportDateMeta != null && !string.IsNullOrEmpty(passportDateMeta.Value))
                                    fullRecord.Record.RecordKeys.Add(new RecordKeyModel { Key = "KeyClientPassportIssued", Name = "Выдан", Value = passportDateMeta.Value });

                                PostMetaModel rateMeta = postMeta.FirstOrDefault(rateM => rateM.Key == "_user_rate_title");
                                if (rateMeta != null && !string.IsNullOrEmpty(rateMeta.Value))
                                    fullRecord.Record.RecordKeys.Add(new RecordKeyModel { Key = "KeyTariff", Name = "Тариф", Value = rateMeta.Value });

                                requestsVM.FullRecords.Add(fullRecord);
                            }
                        }
                        break;

                    case ViewType.History:
                        RecordsViewModel historyVM = ServiceProviderFactory.ServiceProvider.GetRequiredService<RecordsViewModel>();
                        _navigator.CurrentViewModel = historyVM;
                        historyVM.FullRecords.Clear();
                        IReadWriteClient<RecordModel> recordClient = ServiceProviderFactory.ServiceProvider.GetRequiredService<IReadWriteClient<RecordModel>>();
                        IReadWriteClient<RecordKeyModel> recordKeyClient = ServiceProviderFactory.ServiceProvider.GetRequiredService<IReadWriteClient<RecordKeyModel>>();
                        List<RecordModel> records = await recordClient.GetAll();
                        List<RecordKeyModel> recordKeyList = await recordKeyClient.GetAll();
                        foreach(RecordModel record in records)
                        {
                            List<RecordKeyModel> recordKeys = recordKeyList.Where(recordKey => recordKey.RecordId == record.Id).ToList();
                            if(recordKeys.Any())
                            {
                                record.RecordKeys = recordKeys;
                                FullRecordModel fullRecord = new FullRecordModel();
                                fullRecord.Record = record;
                                fullRecord.Value = $"{record.Time}";

                                RecordKeyModel accountKey = recordKeys.FirstOrDefault(accKey => accKey.Key == "KeyIdContract");
                                if(accountKey != null)
                                    fullRecord.Value += $", {accountKey.Value}";

                                RecordKeyModel nameKey = recordKeys.FirstOrDefault(nameK => nameK.Key == "KeyFIOClient");
                                if (nameKey != null)
                                    fullRecord.Value += $", {nameKey.Value}";

                                RecordKeyModel streetKey = recordKeys.FirstOrDefault(streetK => streetK.Key == "KeyInstallStreet");
                                if (streetKey != null)
                                    fullRecord.Value += $", {streetKey.Value}";

                                RecordKeyModel houseKey = recordKeys.FirstOrDefault(houseK => houseK.Key == "KeyInstallBuilding");
                                if (houseKey != null)
                                    fullRecord.Value += $", д. {houseKey.Value}";

                                RecordKeyModel flatKey = recordKeys.FirstOrDefault(flatK => flatK.Key == "KeyInstallApartment");
                                if (flatKey != null)
                                    fullRecord.Value += $", кв. {flatKey.Value}";

                                RecordKeyModel porchKey = recordKeys.FirstOrDefault(porchK => porchK.Key == "KeyInstallPorch");
                                if (porchKey != null)
                                    fullRecord.Value += $", под. {porchKey.Value}";

                                RecordKeyModel floorKey = recordKeys.FirstOrDefault(floorK => floorK.Key == "KeyInstallStorey");
                                if (floorKey != null)
                                    fullRecord.Value += $", этаж {floorKey.Value}";

                                historyVM.FullRecords.Add(fullRecord);
                            }
                        }
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
