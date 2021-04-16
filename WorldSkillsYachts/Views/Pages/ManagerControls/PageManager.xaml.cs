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
        public PageManager()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            cbCustomer.ItemsSource = AppData.db.Customers.ToList();
            cbSalesperson.ItemsSource = AppData.db.Salespersons.ToList();
            cbBoat.ItemsSource = AppData.db.Boats.ToList();
            cbAccessory.ItemsSource = AppData.db.Accessories.ToList();
        }

        private void cbBoat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbAccessory.ItemsSource = GetFit();
        }

        private List<Accessory> GetFit()
        {
            List<Accessory> accessories = AppData.db.Accessories.ToList();
            List<Fit> fits = AppData.db.Fits.Where(x => x.Boat_ID == 101).ToList();
            List<Accessory> result = new List<Accessory>();
            foreach (var f in fits)
            {
                foreach (var a in accessories)
                {
                    if (f.Accessory_ID == a.Accessory_ID)
                    {
                        result.Add(a);
                    }
                }
            }
            return result;
        }
    }
}