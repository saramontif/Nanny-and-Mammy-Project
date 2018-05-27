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
using System.Windows.Shapes;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for ContractWindow.xaml
    /// </summary>
    public partial class ContractWindow : Window
    {
        IBL bl;
        public ContractWindow()
        {
            InitializeComponent();
            bl = FactoryBL.getBL();
        }
        private void AddContractButton_Click(object sender, RoutedEventArgs e)
        {
            Window AddContractWindow = new AddContractWindow();
            AddContractWindow.Show();
        }
        private void UpdateContractButton_Click(object sender, RoutedEventArgs e)
        {
            new UpdateContractWindow().Show();
        }
        private void DeleteContractButton_Click(object sender, RoutedEventArgs e)
        {
            new DeleteContractWindow().ShowDialog();
        }
            private void ShowAllContractsButton_Click(object sender, RoutedEventArgs e)
        {
            new ShowAllContracts().ShowDialog();
        }
    }
}
