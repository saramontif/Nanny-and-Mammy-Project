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
using System.Text.RegularExpressions;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for AddChildWindow.xaml
    /// </summary>

    public partial class AddChildWindow : Window
    {
        BE.Child child = new BE.Child();
        IBL bl;
        public AddChildWindow()
        {
            InitializeComponent();
            DataContext = child;
            bl = FactoryBL.getBL();
            this.motherIDComboBox.ItemsSource = from z in bl.GetMothers()
                                               select z.ID;
        }

        public void idCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string id = motherIDComboBox.SelectedValue.ToString();
                child.MotherID = id;
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

        private void AddChildButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BL.FactoryBL.getBL().AddChild(child);
                MessageBox.Show(child.ToString());
                child = new BE.Child();
                DataContext = child;
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
