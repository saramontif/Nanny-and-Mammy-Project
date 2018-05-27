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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for DeleteMotherWindow.xaml
    /// </summary>
    
    public partial class DeleteMotherWindow : Window
    {
        IBL bl;
        BE.Mother mother;
        public DeleteMotherWindow()
        {
            InitializeComponent();
            mother = new Mother();
            bl = FactoryBL.getBL();
            this.grid1.DataContext = mother;
            this.IDComboBox.ItemsSource = from z in bl.GetMothers()
                                               select z.ID;
            
        }

        public void idCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string id = IDComboBox.SelectedValue.ToString();
                mother = this.bl.GetMotherByID(id);
                MessageBox.Show(mother.ToString());

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

        private void DeleteMotherButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mother = BL.FactoryBL.getBL().GetMotherByID(mother.ID);
                BL.FactoryBL.getBL().DeleteMother(mother);
                MessageBox.Show("the mother is deleted");
                mother = new BE.Mother();
                DataContext = mother.ID;
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
