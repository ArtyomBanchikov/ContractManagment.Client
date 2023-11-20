using ContractManagment.Client.MVVM.Model;
using ContractManagment.Client.MVVM.Model.Records;
using ContractManagment.Client.MVVM.ViewModel.Contract;
using ContractManagment.Client.Services;
using ContractManagment.Client.State.WebClients;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ContractManagment.Client.Commands.Contract
{
    class SelectContractCommandAsync : AsyncBaseCommand
    {
        private ContractViewModel _contractVM;

        public SelectContractCommandAsync(ContractViewModel contractVM)
        {
            _contractVM = contractVM;
        }

        protected async override Task ExecuteAsync(object parameter)
        {
            ContractModel contract = _contractVM.SelectedContract;
            if(contract !=  null)
            {
                IReadWriteClient<KeyModel> keyClient = ServiceProviderFactory.ServiceProvider.GetRequiredService<IReadWriteClient<KeyModel>>();
                IReadWriteClient<ContractKeyModel> contractKeyModel = ServiceProviderFactory.ServiceProvider.GetRequiredService<IReadWriteClient<ContractKeyModel>>();
                List<KeyModel> keys = await keyClient.GetAll();
                List<ContractKeyModel> contractKeys = (await contractKeyModel.GetAll()).Where(ck => ck.ContractId == contract.Id).ToList();
                foreach (ContractKeyModel contractKey in contractKeys)
                {
                    KeyModel key = keys.FirstOrDefault(k => k.Id == contractKey.KeyId);
                    if (key != null)
                    {
                        _contractVM.RecordKeys.Add(new RecordKeyModel { Key = key.Key, Name = key.Name });
                    }
                }
            }
        }
    }
}
