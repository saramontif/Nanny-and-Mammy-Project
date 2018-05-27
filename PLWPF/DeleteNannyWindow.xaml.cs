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
    /// Interaction logic for DeleteNannyWindow.xaml
    /// </summary>
    public partial class DeleteNannyWindow : Window
    {
        IBL bl;
        BE.Nanny nanny = new BE.Nanny();
        public DeleteNannyWindow()
        {
            InitializeComponent();
            bl = FactoryBL.getBL();
            this.grid1.DataContext = nanny;
            this.NannyIDComboBox.ItemsSource = from z in bl.GetNannys()
                                                  select z.ID;
        }
        public void idCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string id = NannyIDComboBox.SelectedValue.ToString();
                nanny = this.bl.GetNannyByID(id);
                MessageBox.Show(nanny.ToString());
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

        private void DeleteNannyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                nanny = BL.FactoryBL.getBL().GetNannyByID(nanny.ID);
                BL.FactoryBL.getBL().DeleteNanny(nanny);
                MessageBox.Show("the nanny is deleted");
                nanny = new BE.Nanny();
                DataContext = nanny.ID;
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

