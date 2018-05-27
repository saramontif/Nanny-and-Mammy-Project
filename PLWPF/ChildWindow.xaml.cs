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
    /// Interaction logic for ChildWindow.xaml
    /// </summary>
    public partial class ChildWindow : Window
    {
        IBL bl;
        public ChildWindow()
        {
            InitializeComponent();
            bl = FactoryBL.getBL();
        }
        private void AddChildButton_Click(object sender, RoutedEventArgs e)
        {
            Window AddChildWindow = new AddChildWindow();
            AddChildWindow.Show();
        }
        private void UpdateChildButton_Click(object sender, RoutedEventArgs e)
        {
            new UpdateChildWindow().Show();
        }
        private void DeleteChildButton_Click(object sender, RoutedEventArgs e)
        {
            new DeleteChildWindow().ShowDialog();
        }
        
        private void ShowAllChildsButton_Click(object sender, RoutedEventArgs e)
        {
            new ShowAllChilds().ShowDialog();
        }
    }
}


