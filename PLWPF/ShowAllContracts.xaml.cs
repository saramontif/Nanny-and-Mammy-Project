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
    /// Interaction logic for ShowAllContracts.xaml
    /// </summary>
    public partial class ShowAllContracts : Window
    {
        IBL bl;
        public ShowAllContracts()
        {
            InitializeComponent();
            bl = FactoryBL.getBL();
            this.listView.ItemsSource = bl.GetContract();
        }
        private void list_view_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
