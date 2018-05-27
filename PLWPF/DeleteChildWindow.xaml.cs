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
    /// Interaction logic for DeleteChildWindow.xaml
    /// </summary>
    public partial class DeleteChildWindow : Window
    {
        IBL bl;
        BE.Child child = new BE.Child();
        public DeleteChildWindow()
        {
            InitializeComponent();
            child = new Child();
            bl = FactoryBL.getBL();
            this.grid1.DataContext = child;
            this.childIDComboBox.ItemsSource = from z in bl.GetChilds()
                                               select z.ChildID;
        }

        public void idCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string id = childIDComboBox.SelectedValue.ToString();
                child = this.bl.GetChildByID(id);
                MessageBox.Show(child.ToString());

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

        private void DeleteChildButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BL.FactoryBL.getBL().DeleteChild(child);
                MessageBox.Show("the Child is deleted");
                child = new BE.Child();
                DataContext = child.ChildID;
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
