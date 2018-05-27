using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for AddContractWindow.xaml
    /// </summary>
    public partial class AddContractWindow : Window
    {
        string id;
        IBL bl;
        Mother mother;
        Child child ;
        Nanny nanny ;
        Contract contract;
        bool monthPayment;
        public AddContractWindow()
        {
            InitializeComponent();
            contract = new Contract();
            contract.IsInterview = true;
            bl = FactoryBL.getBL();
            DataContext = contract;
            this.motherIDComboBox.ItemsSource = from z in bl.GetMothers()
                                                select z.ID;
        }
        public void motherIDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                id = motherIDComboBox.SelectedValue.ToString();
                mother = this.bl.GetMotherByID(id);
                childIDComboBox.SelectedValue = "";
                //nunnyIDComboBox.SelectedValue = "";

                this.childIDComboBox.ItemsSource = from z in bl.GetChildsByMother(mother)
                                                   select z.ChildID;
                contract.MotherID = id;
                monthPayment = mother.MonthPayment;
                contract.WorkTime = mother.Workhours;
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

        public void childIDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                id = childIDComboBox.SelectedValue.ToString();
                child = this.bl.GetChildByID(id);
                nunnyIDComboBox.Text = "";


                List<object> args = new List<object> { mother };

                BackgroundWorker myWorker = new BackgroundWorker();
                myWorker.DoWork += myWorker_DoWork;
                myWorker.RunWorkerCompleted += myWorker_RunWorkerCompleted;
                myWorker.RunWorkerAsync(args);

                //List<Nanny> list1 = bl.DistanceNannys(mother);
                //List<Nanny> list2 = bl.AvailableNannys(mother, child);
                //List<Nanny> list3 = (list1.Intersect(list2)).ToList();
                /*this.nunnyIDComboBox.ItemsSource = from z in bl.GetNannys()
                                                   select z.ID;*/
                contract.ChildID = id;
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

        public void nunnyIDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                id = nunnyIDComboBox.SelectedValue.ToString();
               // if (e.AddedItems[0].ToString()=="")
                //    return;
                nanny = this.bl.GetNannyByID(id);
                MessageBox.Show(nanny.ToString());
                contract.NunnyID = id;
                contract.RateforHour = nanny.RateforHour;
                contract.RateforMonth = nanny.RateforMonth;
                /*if (monthPayment)
                {
                    contract.RateforHour = 0;
                    contract.RateforMonth =nanny.RateforMonth;
                }
                else
                {
                    contract.RateforHour = nanny.RateforHour;
                    contract.RateforMonth = 0;
                }*/
                DataContext = contract;

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

        private void AddContractButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BL.FactoryBL.getBL().AddContract(contract);
                MessageBox.Show(contract.ToString());
                contract = new BE.Contract();
                DataContext = contract;
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

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void myWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<Nanny> list1 = (List<Nanny>)e.Result;
            List<Nanny> list2 = bl.AvailableNannys(mother, child);
            
           // List<Nanny> list3 = (list1.Intersect(list2)).ToList();
            this.nunnyIDComboBox.ItemsSource = (from z in list1
                                               where ((list2.Find(n=>n.ID==z.ID))!=null)
                                               select z.ID );
        }

        private void myWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<object> args = e.Argument as List<object>;

            Mother m = args[0] as Mother;

            List < Nanny > result = bl.DistanceNannys(m);
            e.Result = result;
        }
    }
}
