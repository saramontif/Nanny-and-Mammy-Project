using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for Grouping.xaml
    /// </summary>
    public partial class Grouping : Window
    {
        IBL bl;
        ContractDistance cd;
        public Grouping()
        {
            InitializeComponent();
            bl = FactoryBL.getBL();
        }
        private void GroupContByDistanceButton_Click(object sender, RoutedEventArgs e)
        {
                try
                {
                    ContractDistance cd = new ContractDistance();

                    BackgroundWorker myWorker = new BackgroundWorker();
                    myWorker.DoWork += myWorker_DoWork;
                    myWorker.RunWorkerCompleted += myWorker_RunWorkerCompleted;
                    myWorker.RunWorkerAsync();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        private void myWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //cd.Source = (List<IGrouping<int, Contract>>)e.Result;
            //this.page.Content = cd; 
            ContractDistance cd = new ContractDistance();

            cd.Source = (List<IGrouping<int, Contract>>)e.Result;

            this.page.Content = cd;
        }

        private void myWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            e.Result =bl.GroupContractsByDistance();
      
        }

        private void GroupNannyByAddressButton_Click(object sender, RoutedEventArgs e)

        {
            try
            {
                NannyByAddress na = new NannyByAddress();
                na.Source = bl.GroupNannysByAddress();
                this.page.Content = na;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GroupRangeChildAgeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RangeChildAge ra = new RangeChildAge();
                ra.Source = bl.GroupNannysByRangeChildAge();
                this.page.Content = ra;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GroupNannyWithTMTButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NannyWithTMT nTMT = new NannyWithTMT();
                nTMT.Source = bl.NannysWithTMT();

                this.page.Content = nTMT;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

