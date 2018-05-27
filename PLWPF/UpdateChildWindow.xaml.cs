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
    /// Interaction logic for UpdateChildWindow.xaml
    /// </summary>
    public partial class UpdateChildWindow : Window
    {
        IBL bl;
        Child child;
        String id;
        public UpdateChildWindow()
        {
            InitializeComponent();
            bl = FactoryBL.getBL();
            child = new Child();
            this.grid1.DataContext = child;
            this.childIDComboBox.ItemsSource = from z in bl.GetChilds()
                                          select z.ChildID;
            this.motherIDComboBox.ItemsSource = from z in bl.GetMothers()
                                                select z.ID;
        }
        public void idCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                id = childIDComboBox.SelectedValue.ToString();
                child = this.bl.GetChildByID(id);
                this.grid1.DataContext = child;
                motherIDComboBox.SelectedItem = child.MotherID;
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

        public void mothrerIdCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
        private void UpdateChildButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BL.FactoryBL.getBL().UpdateChild(child);
                MessageBox.Show(child.ToString());
                child = new BE.Child();
                DataContext = child;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void TextValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z]");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
