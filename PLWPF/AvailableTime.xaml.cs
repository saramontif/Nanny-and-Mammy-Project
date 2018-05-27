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
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for AvailableTime.xaml
    /// </summary>
    public partial class AvailableTime : Window
    {
        private Dictionary<DayOfWeek, KeyValuePair<int, int>> mystuff;
        public Dictionary<DayOfWeek, KeyValuePair<int, int>> Mystuff { get { return mystuff; } }


        public AvailableTime()
        {
            InitializeComponent();
            mystuff = new Dictionary<DayOfWeek, KeyValuePair<int, int>>();
            mystuff.Add(DayOfWeek.Sunday, new KeyValuePair<int, int>(0, 0));
            mystuff.Add(DayOfWeek.Monday, new KeyValuePair<int, int>(0, 0));
            mystuff.Add(DayOfWeek.Tuesday, new KeyValuePair<int, int>(0, 0));
            mystuff.Add(DayOfWeek.Wednesday, new KeyValuePair<int, int>(0, 0));
            mystuff.Add(DayOfWeek.Thursday, new KeyValuePair<int, int>(0, 0));
            mystuff.Add(DayOfWeek.Friday, new KeyValuePair<int, int>(0, 0));
        }
        public AvailableTime(Dictionary<DayOfWeek, KeyValuePair<int, int>> AT)
        {
            InitializeComponent();
            mystuff = AT;
            this.checkSun.IsChecked = true;
            SanStart.Text = mystuff[DayOfWeek.Sunday].Key.ToString();
            SanEnd.Text= mystuff[DayOfWeek.Sunday].Value.ToString();
            this.checkMon.IsChecked = true;
            MonStart.Text = mystuff[DayOfWeek.Monday].Key.ToString();
            MonEnd.Text = mystuff[DayOfWeek.Monday].Value.ToString();
            this.checkTue.IsChecked = true;
            TueStart.Text = mystuff[DayOfWeek.Tuesday].Key.ToString();
            TueEnd.Text = mystuff[DayOfWeek.Tuesday].Value.ToString();
            this.checkWed.IsChecked = true;
            WedStart.Text = mystuff[DayOfWeek.Wednesday].Key.ToString();
            WedEnd.Text = mystuff[DayOfWeek.Wednesday].Value.ToString();
            this.checkThu.IsChecked = true;
            ThuStart.Text = mystuff[DayOfWeek.Thursday].Key.ToString();
            ThuEnd.Text = mystuff[DayOfWeek.Thursday].Value.ToString();
            this.checkFri.IsChecked = true;
            FriStart.Text = mystuff[DayOfWeek.Friday].Key.ToString();
            FriEnd.Text = mystuff[DayOfWeek.Friday].Value.ToString();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.checkSun.IsChecked == true)
            {
                mystuff[DayOfWeek.Sunday] = new KeyValuePair<int, int>(Int32.Parse(SanStart.Text), Int32.Parse(SanEnd.Text));
            }
            if (this.checkMon.IsChecked == true)
            {
                mystuff[DayOfWeek.Monday] = new KeyValuePair<int, int>(Int32.Parse(MonStart.Text), Int32.Parse(MonEnd.Text));
            }
            if (this.checkTue.IsChecked == true)
            {
                mystuff[DayOfWeek.Tuesday] = new KeyValuePair<int, int>(Int32.Parse(TueStart.Text), Int32.Parse(TueEnd.Text));
            }
            if (this.checkWed.IsChecked == true)
            {
                mystuff[DayOfWeek.Wednesday] = new KeyValuePair<int, int>(Int32.Parse(WedStart.Text), Int32.Parse(WedEnd.Text));
            }
            if (this.checkThu.IsChecked == true)
            {
                mystuff[DayOfWeek.Thursday] = new KeyValuePair<int, int>(Int32.Parse(ThuStart.Text), Int32.Parse(ThuEnd.Text));
            }
            if (this.checkFri.IsChecked == true)
            {
                mystuff[DayOfWeek.Friday] = new KeyValuePair<int, int>(Int32.Parse(FriStart.Text), Int32.Parse(FriEnd.Text));
            }
            this.DialogResult = true;
            this.Close();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }
       
    }

}
