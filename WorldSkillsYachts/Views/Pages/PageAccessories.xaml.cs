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
using WorldSkillsYachts.Models;
using WorldSkillsYachts.Utils;

namespace WorldSkillsYachts.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAccessories.xaml
    /// </summary>
    public partial class PageAccessories : Page
    {
        public PageAccessories()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAddAccessory(new Accessory()));
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Подтвердите удаление", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Accessory accessory = AccessoryGrid.SelectedItem as Accessory;
                AppData.db.Accessories.Remove(accessory);
                AppData.db.SaveChanges();
                GetAccessories();
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Accessory accessory = AccessoryGrid.SelectedItem as Accessory;
            NavigationService.Navigate(new PageAddAccessory(accessory));
        }

        private void GetAccessories()
        {
            List<Accessory> accessories = AppData.db.Accessories.ToList();
            AccessoryGrid.ItemsSource = accessories;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            GetAccessories();
        }
    }
}
