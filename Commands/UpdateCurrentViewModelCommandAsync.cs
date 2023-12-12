using ContractManagment.Client.MVVM.Model;
using ContractManagment.Client.MVVM.Model.Records;
using ContractManagment.Client.MVVM.Model.User;
using ContractManagment.Client.MVVM.ViewModel;
using ContractManagment.Client.MVVM.ViewModel.Contract;
using ContractManagment.Client.Services;
using ContractManagment.Client.State.Authenticators;
using ContractManagment.Client.State.Navigators;
using ContractManagment.Client.State.WebClients;
using ContractManagment.Client.State.WebClients.ModelClients.Post;
using ContractManagment.Client.State.WebClients.ModelClients.Record;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

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
                        if (((UserViewModel)_navigator.CurrentViewModel).Users == null)
                        {
                            IReadWriteClient<UserModel> userClient = ServiceProviderFactory.ServiceProvider.GetRequiredService<IReadWriteClient<UserModel>>();
                            ((UserViewModel)_navigator.CurrentViewModel).Users = new ObservableCollection<UserModel>();
                            List<UserModel> users = await userClient.GetAll();
                            string currentUserName = ServiceProviderFactory.ServiceProvider.GetRequiredService<IAuthenticator>().CurrentUser.Name;
                            foreach (UserModel user in users)
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
                        if (((KeyViewModel)_navigator.CurrentViewModel).Keys == null)
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

                    case ViewType.ClientsInternet:
                        _navigator.CurrentViewModel = ServiceProviderFactory.ServiceProvider.GetRequiredService<ClientInternetViewModel>();
                        break;

                    case ViewType.ClientsDigital:
                        _navigator.CurrentViewModel = ServiceProviderFactory.ServiceProvider.GetRequiredService<ClientDigitalViewModel>();
                        break;

                    case ViewType.Requests:
                        {
                            PostsViewModel postVM = ServiceProviderFactory.ServiceProvider.GetRequiredService<PostsViewModel>();
                            _navigator.CurrentViewModel = postVM;
                            postVM.FullRecords.Clear();
                            postVM.SearchString = string.Empty;

                            IPostClient postClient = ServiceProviderFactory.ServiceProvider.GetRequiredService<IPostClient>();
                            IReadWriteClient<KeyModel> keyClient = ServiceProviderFactory.ServiceProvider.GetRequiredService<IReadWriteClient<KeyModel>>();
                            List<KeyModel> keys = await keyClient.GetAll();
                            postVM.KeyNames.Clear();
                            postVM.SelectedKeyName = null;
                            keys.ForEach(key => postVM.KeyNames.Add(key.Name));
                            List<LongRecordModel> records = await postClient.GetAll();
                            records.ForEach(record => postVM.FullRecords.Add(record));
                            break;
                        }
                    case ViewType.History:
                        {
                            //RecordsViewModel historyVM = ServiceProviderFactory.ServiceProvider.GetRequiredService<RecordsViewModel>();
                            HistoryViewModel historyVM = ServiceProviderFactory.ServiceProvider.GetRequiredService<HistoryViewModel>();
                            _navigator.CurrentViewModel = historyVM;
                            historyVM.FullRecords.Clear();
                            historyVM.SearchString = string.Empty;

                            IRecordClient recordClient = ServiceProviderFactory.ServiceProvider.GetRequiredService<IRecordClient>();
                            IReadWriteClient<KeyModel> keyClient = ServiceProviderFactory.ServiceProvider.GetRequiredService<IReadWriteClient<KeyModel>>();
                            List<KeyModel> keys = await keyClient.GetAll();
                            historyVM.KeyNames.Clear();
                            historyVM.SelectedKeyName = null;
                            keys.ForEach(key => historyVM.KeyNames.Add(key.Name));
                            List<LongRecordModel> records = await recordClient.GetAll();
                            records.ForEach(record => historyVM.FullRecords.Add(record));
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
}
