using ContractManagment.Client.MVVM.Model.Records;
using ContractManagment.Client.MVVM.ViewModel.Contract;
using ContractManagment.Client.Services;
using ContractManagment.Client.State.WebClients;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using word = Microsoft.Office.Interop.Word;

namespace ContractManagment.Client.Commands.Contract
{
    public class GenerateContractCommandAsync : AsyncBaseCommand
    {
        private ContractViewModel _contractVM;

        public GenerateContractCommandAsync(ContractViewModel contractVM)
        {
            _contractVM = contractVM;
        }

        protected async override Task ExecuteAsync(object parameter)
        {
            if (_contractVM.SelectedContract==null)
            {
                MessageBox.Show("Выберите документ");
            }
            else
            {
                var tmpFile = Path.GetTempFileName();
                word.Application app = new word.Application();
                File.WriteAllBytes(tmpFile, _contractVM.SelectedContract.Value);
                word.Document doc = app.Documents.Open(tmpFile);
                app.Visible = true;
                RecordModel record = new RecordModel();
                record.Time = DateTime.Now;
                record.RecordKeys = new List<RecordKeyModel>();
                foreach (RecordKeyModel key in _contractVM.RecordKeys)
                {
                    if(!string.IsNullOrEmpty(key.Value))
                    {
                        FindAndReplace(app, $"[{key.Key}]", key.Value);
                        record.RecordKeys.Add(key);
                    }
                }
                IReadWriteClient<RecordModel> recordClient = ServiceProviderFactory.ServiceProvider.GetRequiredService<IReadWriteClient<RecordModel>>();
                await recordClient.Create(record);
            }
        }
        private void FindAndReplace(word.Application doc, object findText, object replaceWithText)
        {
            //options
            object matchCase = false;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundsLike = false;
            object matchAllWordForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiacritics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;
            //execute find and replace
            doc.Selection.Find.Execute(ref findText, ref matchCase, ref matchWholeWord,
                ref matchWildCards, ref matchSoundsLike, ref matchAllWordForms, ref forward, ref wrap, ref format, ref replaceWithText, ref replace,
                ref matchKashida, ref matchDiacritics, ref matchAlefHamza, ref matchControl);
        }
    }
}
