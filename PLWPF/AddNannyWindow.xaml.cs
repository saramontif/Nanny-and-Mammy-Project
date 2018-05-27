using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for addNannyWindow.xaml
    /// </summary>
    public partial class AddNannyWindow : Window
    {
        IBL bl;
        string bank_name;
        int bank_branch;
        BE.Nanny nanny = new BE.Nanny();
        public AddNannyWindow()
        {
            InitializeComponent();
            bl = FactoryBL.getBL();
            this.grid1.DataContext = nanny;
            nanny.AvailableTime = new Dictionary<DayOfWeek, KeyValuePair<int, int>>();


            List<String> name = (from z in bl.GetBankBranchs()
                        select z.BankName).ToList();
            this.BankNameComboBox.ItemsSource = name.Select(x => x=x.Trim('\n')).Distinct();
         
        }
        public void BankNameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                bank_name = BankNameComboBox.SelectedValue.ToString();
                List<string> name = (from z in bl.GetBankBranchs()
                                     where z.BankName== bank_name
                                  select ((z.BankBranch)+","+z.BankAdress)).ToList();

                this.BankBranchComboBox.SelectedValue = "";
                this.BankBranchComboBox.ItemsSource = (name.Distinct()).OrderBy(s => s.Split(',')[1]);
                //set bank account for nanny
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
        public void BankBranchComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string bankBranchAndAddress = BankBranchComboBox.SelectedValue.ToString();
                bank_branch = int.Parse(bankBranchAndAddress.Split(',')[0]);
                string bank_address = bankBranchAndAddress.Split(',')[1];
                //set bank account for nanny
                BankAccount bank = bl.GetBankBranchs().Find(z=>z.BankName == bank_name && z.BankBranch == bank_branch && z.BankAdress==bank_address);

                nanny.NannyBank = bank;
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
        private void AddNannyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (nanny.address.ToString() == "")
                    throw new Exception("please enter your address");
                BL.FactoryBL.getBL().AddNanny(nanny);
                MessageBox.Show(nanny.ToString());
                nanny = new BE.Nanny();
                DataContext = nanny;
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
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            AvailableTime availableTime = new AvailableTime();
            bool? result = availableTime.ShowDialog();
            if (result != false)
            {
                nanny.AvailableTime = availableTime.Mystuff;
            }
        }

        private void AddAddress_Click(object sender, RoutedEventArgs e)
        {
            Address address = new Address();
            bool? result = address.ShowDialog();
            if (result != false)
            {
                nanny.address = address.myaddress;
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void TextValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z]");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
