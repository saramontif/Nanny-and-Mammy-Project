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
    /// Interaction logic for MotherWindow.xaml
    /// </summary>
    /// 
    public partial class MotherWindow : Window
    {
        IBL bl;
        public MotherWindow()
        {
            InitializeComponent();
            bl = FactoryBL.getBL();
        }
        private void AddMotherButton_Click(object sender, RoutedEventArgs e)
        {
            Window AddMotherWindow = new AddMotherWindow();
            AddMotherWindow.Show();
        }
        private void UpdateMotherButton_Click(object sender, RoutedEventArgs e)
        {
            new UpdateMotherWindow().Show();
        }
        private void DeleteMotherButton_Click(object sender, RoutedEventArgs e)
        {
            new DeleteMotherWindow().ShowDialog();
        }
        private void ShowAllMothersButton_Click(object sender, RoutedEventArgs e)
        {
            new ShowAllMothers().ShowDialog();
        }
    }
}
