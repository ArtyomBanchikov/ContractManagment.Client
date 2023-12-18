using ContractManagment.Client.Services;
using ContractManagment.Client.Services.DialogServices;
using Microsoft.Extensions.DependencyInjection;
using Word = Microsoft.Office.Interop.Word;
using System;
using System.Windows;
using System.Windows.Input;
using System.IO;
using ContractManagment.Client.MVVM.Model;
using System.Text.RegularExpressions;
using System.Linq;
using ContractManagment.Client.MVVM.ViewModel.Contract;

namespace ContractManagment.Client.Commands.Contract
{
    public class ChooseContractFileCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private NewContractViewModel _viewModel;
        private IDialogService _dialogService;

        public ChooseContractFileCommand(NewContractViewModel viewModel)
        {
            _viewModel = viewModel;
            _dialogService = ServiceProviderFactory.ServiceProvider.GetRequiredService<IDialogService>();
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            try
            {
                if(_dialogService.OpenFileDialog())
                {
                    byte[] docData;
                    using (FileStream fs = new FileStream(_dialogService.FilePath, FileMode.Open))
                    {
                        docData = new byte[fs.Length];
                        fs.Read(docData, 0, docData.Length);
                    }
                    _viewModel.NewDocData = docData;
                    Word.Application app = new Word.Application();
                    _viewModel.NewDocPath = _dialogService.FilePath;
                    _viewModel.NewDoc = app.Documents.Open(_dialogService.FilePath);
                    string text = _viewModel.NewDoc.Range().Text;
                    Regex regex = new Regex(@"\[\S{1,30}\]", RegexOptions.Singleline);
                    MatchCollection matches = regex.Matches(text);
                    matches.DistinctBy(i => i.Value);
                    _viewModel.FindedKeys.Clear();
                    _viewModel.UnfindedKeys.Clear();
                    foreach (Match match in matches)
                    {
                        KeyModel key = _viewModel.FindedKeys.FirstOrDefault(k => k.Key == match.Value[1..^1]);

                        if (!_viewModel.UnfindedKeys.Contains(match.Value) && key== null)
                        {
                            KeyModel findedKey = _viewModel.Keys.FirstOrDefault(k => $"[{k.Key}]" == match.Value);
                            if (findedKey != null)
                            {
                                _viewModel.FindedKeys.Add(findedKey);
                            }
                            else
                            {
                                _viewModel.UnfindedKeys.Add(match.Value);
                            }
                        }
                    }
                    _viewModel.NewDoc.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
