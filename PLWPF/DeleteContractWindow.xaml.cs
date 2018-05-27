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
using BE;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for DeleteContractWindow.xaml
    /// </summary>
    public partial class DeleteContractWindow : Window
    {
        IBL bl;
        BE.Contract contract = new BE.Contract();
        public DeleteContractWindow()
        {
            InitializeComponent();
            contract = new Contract();
            bl = FactoryBL.getBL();
            this.grid1.DataContext = contract;
            this.contractIDComboBox.ItemsSource = from z in bl.GetContract()
                                               select z.NumberOfContract;
        }

        public void idCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int id = (int)contractIDComboBox.SelectedValue;
                contract = this.bl.GetContractByID(id);
                MessageBox.Show(contract.ToString());
            }
            catch (FormatException)
            {
                MessageBox.Show("Incorrect input");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteContractButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BL.FactoryBL.getBL().DeleteContract(contract);
                MessageBox.Show("the Contract is deleted");
                contract = new BE.Contract();
                DataContext = contract.NumberOfContract;
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Incorrect input");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

