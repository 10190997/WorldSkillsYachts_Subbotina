using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using WorldSkillsYachts.Models;
using WorldSkillsYachts.Utils;

namespace WorldSkillsYachts.Views.Pages
{
    /// <summary>
    /// Interaction logic for PageManager.xaml
    /// </summary>
    public partial class PageManager : Page
    {
        public Detail NewDetail { get; set; }
        public Contract NewContract { get; set; }
        public Invoice NewInvoice { get; set; }
        public Order NewOrder { get; set; }

        public PageManager()
        {
            InitializeComponent();
            NewDetail = new Detail();
            NewContract = new Contract();
            NewInvoice = new Invoice();
            NewOrder = new Order();
        }

        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            cbCustomer.ItemsSource = AppData.db.Customers.ToList();
            cbSalesperson.ItemsSource = AppData.db.Salespersons.ToList();
            cbBoat.ItemsSource = AppData.db.Boats.ToList();
            lbAcc.ItemsSource = GetFit(cbBoat.SelectedItem.ToString());
        }

        private void cbBoat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbAcc.ItemsSource = GetFit(cbBoat.SelectedItem.ToString());
        }

        private string[] GetFit(string boatModel)
        {
            int boatID = AppData.db.Boats.Where(x => x.Model == boatModel).FirstOrDefault().boat_ID;
            List<Fit> fits = AppData.db.Fits.Where(x => x.Boat_ID == boatID).ToList();
            string[] accessories = new string[fits.Count];
            for (int i = 0; i < fits.Count; i++)
            {
                accessories[i] = fits[i].Accessory.AccName;
            }
            return accessories;
        }

        private void btnSave_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            AddOrder(cbCustomer.Text, cbSalesperson.Text, cbBoat.Text, tbAddress.Text, tbCity.Text);
            string[] accs = new string[lbAcc.Items.Count];
            int i = 0;
            foreach (var item in lbAcc.Items)
            {
                accs[i] = item.ToString();
                i++;
            }
            AddDetail(accs);
        }

        private void AddOrder(string customer, string salesperson, string boat, string address, string city)
        {
            NewOrder.Date = DateTime.Today;
            NewOrder.Salesperson_ID = AppData.db.Salespersons.Where(x => salesperson.Contains(x.FirstName) &&
            salesperson.Contains(x.FamilyName)).FirstOrDefault().SalesPerson_ID;
            NewOrder.Customer_ID = AppData.db.Customers.Where(x => customer.Contains(x.FistName) &&
            customer.Contains(x.FamilyName)).FirstOrDefault().Customer_ID;
            NewOrder.Boat_ID = AppData.db.Boats.Where(x => x.Model == boat).FirstOrDefault().boat_ID;
            NewOrder.DeliveryAddress = address;
            NewOrder.City = city;
            AppData.db.Orders.Add(NewOrder);
            AppData.db.SaveChanges();
        }

        private void AddContract(decimal deposit)
        {
            NewContract.Date = DateTime.Today;
            NewContract.DepositPayed = deposit;
            NewContract.Order_ID = NewOrder.Order_ID;
            NewContract.ContractTotalPrice = 0;
            NewContract.ContracTotalPrice_inclVAT = 0;
            NewContract.ProductionProcess = "";
            AppData.db.Contracts.Add(NewContract);
            AppData.db.SaveChanges();
        }

        private void AddInvoice(decimal sum, bool settled, decimal sumVAT)
        {
            NewInvoice.Contract_ID = NewContract.Contract_ID;
            NewInvoice.Settled = settled;
            NewInvoice.Sum = sum;
            NewInvoice.Sum_inclVAT = sumVAT;
            NewInvoice.Date = DateTime.Today;
        }

        private void AddDetail(string[] accessory)
        {
            int[] IDs = new int[accessory.Length];
            int i = 0;
            foreach (var a in accessory)
            {
                IDs[i] = AppData.db.Accessories.Where(x => x.AccName == a).FirstOrDefault().Accessory_ID;
                i++;
            }
            foreach (var id in IDs)
            {
                NewDetail.Accessory_ID = id;
                NewDetail.Order_ID = NewOrder.Order_ID;
                AppData.db.Details.Add(NewDetail);
                AppData.db.SaveChanges();
            }
            
            
        }
    }
}