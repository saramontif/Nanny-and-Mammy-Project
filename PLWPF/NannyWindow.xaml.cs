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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BL;
namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class NannyWindow :Window
    {
        IBL bl;
        public NannyWindow()
        {
            InitializeComponent();
            bl = FactoryBL.getBL();
        }
        private void AddNannyButton_Click(object sender, RoutedEventArgs e)
        {
            Window AddNannyWindow = new AddNannyWindow();
            AddNannyWindow.Show();
        }
        private void UpdateNannyButton_Click(object sender, RoutedEventArgs e)
        {
            new UpdateNannyWindow().Show();
        }
        private void DeleteNannyButton_Click(object sender, RoutedEventArgs e)
        {
            new DeleteNannyWindow().ShowDialog();
        }
        
            private void ShowAllNannysButton_Click(object sender, RoutedEventArgs e)
        {
            new ShowAllNannys().ShowDialog();
        }
    }
}
