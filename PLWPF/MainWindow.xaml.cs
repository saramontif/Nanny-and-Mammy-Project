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
    public partial class MainWindow : Window
    {
        IBL bl;
        public MainWindow()
        {
            InitializeComponent();
            bl = FactoryBL.getBL();
            //initFordebugs();
        }

        private void initFordebugs()
        {
            bl.AddMother(new BE.Mother
            {
                ID = "123",
                Lastname = "Sarah",
                FirstName = "Imeinu",
                Tel = "01233477",
                address = new BE.Address { City = "Jerusalem", Country = "Israel", Number = 11, Street = "Beit Ha-Defus", ZipCode = "208" },
                HomePhone = "67767678",
                BabbySitterAdress = new BE.Address { City = "Jerusalem", Country = "Israel", Number = 7, Street = "Beit Ha-Defus", ZipCode = "208" },
                Workhours = new Dictionary<DayOfWeek, KeyValuePair<int, int>>
                {
                    {DayOfWeek.Sunday,new KeyValuePair<int,int> (0700,1900) },
                    {DayOfWeek.Monday,new KeyValuePair<int,int> (0700,1900) },
                    {DayOfWeek.Tuesday,new KeyValuePair<int,int> (0700,1900) },
                    {DayOfWeek.Wednesday,new KeyValuePair<int,int> (0700,1900) },
                    {DayOfWeek.Thursday,new KeyValuePair<int,int> (0700,1900) },
                    {DayOfWeek.Friday,new KeyValuePair<int,int> (0700,1900) },
                },
                MonthPayment = false
            });
            bl.AddNanny(new BE.Nanny
            {
                ID = "208493965",
                Lastname = "bar",
                FirstName = "chaya",
                Tel = "025800856",
                address = new BE.Address { City = "Jerusalem", Country = "Israel", Number = 7, Street = "Beit Ha-Defus", ZipCode = "208" },
                NannyD_of_B = new DateTime(1988, 2, 2),
                IsElevator = true,
                YearsOfExperience = 3,
                MaxKids = 5,
                MinimunmAge = 3,
                MaximumAge = 24,
                RateforHour = 30,
                RateforMonth = 5000,
                AvailableTime = new Dictionary<DayOfWeek, KeyValuePair<int, int>>
                {
                    {DayOfWeek.Sunday,new KeyValuePair<int,int> (0600,1900) },
                    {DayOfWeek.Monday,new KeyValuePair<int,int> (0600,1900) },
                    {DayOfWeek.Tuesday,new KeyValuePair<int,int> (0700,1900) },
                    {DayOfWeek.Wednesday,new KeyValuePair<int,int> (0700,2000) },
                    {DayOfWeek.Thursday,new KeyValuePair<int,int> (0700,1900) },
                    {DayOfWeek.Friday,new KeyValuePair<int,int> (0700,1900) },
                },
                IsBasedonTMTorEdu = true,
                Recommendation = "good",
                NannyBank = new BE.BankAccount
                {
                     BankAdress="jerusalem"
                }
            });
            bl.AddChild(new BE.Child
            {
                 ChildID="6789",
                  ChildName="chanan",
                   DateOfBirth=new DateTime(2017, 8,1),
                    IsSpacialNeeds=false,
                     MotherID= "123"
            });
            bl.AddContract(new BE.Contract
            {
                NunnyID = "208493965",
                MotherID = "123",
                ChildID = "6789",
                IsInterview = true,
                IsContract = true,
                RateforHour = 35,
                RateforMonth = 4500,
                IsMorechilds = false,
                WorkTime = new Dictionary<DayOfWeek, KeyValuePair<int, int>>
                {
                    {DayOfWeek.Sunday,new KeyValuePair<int,int> (0700,1900) },
                    {DayOfWeek.Monday,new KeyValuePair<int,int> (0700,1900) },
                    {DayOfWeek.Tuesday,new KeyValuePair<int,int> (0700,1900) },
                    {DayOfWeek.Wednesday,new KeyValuePair<int,int> (0700,1900) },
                    {DayOfWeek.Thursday,new KeyValuePair<int,int> (0700,1900) },
                    {DayOfWeek.Friday,new KeyValuePair<int,int> (0700,1900) },
                },
                DateStart = new DateTime(2017, 07, 21),
                DateEnd = new DateTime(2017, 09, 21),
                HoursOfContractMonth = 50
            });
        }

        private void AboutNannyButton_Click(object sender, RoutedEventArgs e)
        {
            Window NannyWindow = new NannyWindow();
            NannyWindow.Show();
        }
        private void AboutMotherButton_Click(object sender, RoutedEventArgs e)
        {
            Window MotherWindow = new MotherWindow();
            MotherWindow.Show();
        }
        private void AboutChildButton_Click(object sender, RoutedEventArgs e)
        {
            Window ChildWindow = new ChildWindow();
            ChildWindow.Show();
        }
        private void AboutContractButton_Click(object sender, RoutedEventArgs e)
        {
            Window ContractWindow = new ContractWindow();
            ContractWindow.Show();
        }
        private void GroupingButton_Click(object sender, RoutedEventArgs e)
        {
            Window Grouping = new Grouping();
            Grouping.Show();
        }
    }
}
