using ContractManagment.Client.MVVM.ViewModel.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ContractManagment.Client.MVVM.View.Contract
{
    /// <summary>
    /// Логика взаимодействия для ContractsView.xaml
    /// </summary>
    public partial class ContractsView : UserControl
    {
        public ContractsView()
        {
            InitializeComponent();
        }

        private void Contracts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(DataContext != null && ((ContractViewModel)DataContext).ComboboxChangedTrigger)
            {
                ((ContractViewModel)DataContext).SelectContractCommand.Execute(this);
            }
        }

        private void ComboBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
