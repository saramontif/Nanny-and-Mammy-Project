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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for addMotherWindow.xaml
    /// </summary>
    public partial class AddMotherWindow : Window
    {
        BE.Mother mother = new BE.Mother();
        public AddMotherWindow()
        {
            InitializeComponent();
            DataContext = mother;
            mother.Workhours = new Dictionary<DayOfWeek, KeyValuePair<int, int>>();
        }

        private void AddMotherButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (mother.address.ToString()=="")
                    throw new Exception("please enter your address");
                BL.FactoryBL.getBL().AddMother(mother);
                MessageBox.Show(mother.ToString());
                mother = new BE.Mother();
                DataContext = mother;
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
                mother.Workhours = availableTime.Mystuff;
            }
        }
        private void AddAddress_Click(object sender, RoutedEventArgs e)
        {
            Address address = new Address();
            bool? result = address.ShowDialog();
            if (result != false)
            {
                mother.address = address.myaddress;
            }
        }
        private void AddBAddress_Click(object sender, RoutedEventArgs e)
        {
            Address address = new Address();
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