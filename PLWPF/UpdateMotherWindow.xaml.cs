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
using BE;
using System.Text.RegularExpressions;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for UpdateMotherWindow.xaml
    /// </summary>
    public partial class UpdateMotherWindow : Window
    {
        IBL bl;
        Mother mother;
        String id;
        public UpdateMotherWindow()
        {
            InitializeComponent();
            bl = FactoryBL.getBL();
            mother = new Mother();
            this.grid1.DataContext = mother;
            this.iDComboBox.ItemsSource =from z in bl.GetMothers()
                                          select z.ID;
        }
        public void idCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                id = iDComboBox.SelectedValue.ToString();
                mother = this.bl.GetMotherByID(id);
                this.grid1.DataContext = mother;
                

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
        private void UpdateMotherButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BL.FactoryBL.getBL().UpdateMother(mother);
                MessageBox.Show(mother.ToString());
                mother = new BE.Mother();
                DataContext = mother;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            AvailableTime availableTime = new AvailableTime(mother.Workhours);
            bool? result = availableTime.ShowDialog();
            if (result != false)
            {
                mother.Workhours = availableTime.Mystuff;
            }
        }
        private void updateAddress_Click(object sender, RoutedEventArgs e)
        {
            Address address = new Address();
            BE.Address myaddress = mother.address;
            address.DataContext = myaddress;
            bool? result = address.ShowDialog();
            if (result != false)
            {
                mother.address = address.myaddress;
            }
        }
        private void updateBAddress_Click(object sender, RoutedEventArgs e)
        {
            Address address = new Address();
            BE.Address myaddress = mother.BabbySitterAdress;
            address.DataContext = myaddress;
            bool? result = address.ShowDialog();
            if (result != false)
            {
                mother.BabbySitterAdress = address.myaddress;
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
