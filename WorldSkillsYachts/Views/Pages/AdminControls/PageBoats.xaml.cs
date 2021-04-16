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
using WorldSkillsYachts.Views.Windows;

namespace WorldSkillsYachts.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageBoats.xaml
    /// </summary>
    public partial class PageBoats : Page
    {
        List<Boat> boats;
        public PageBoats()
        {
            InitializeComponent();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Boat boat = BoatGrid.SelectedItem as Boat;
            NavigationService.Navigate(new PageAddBoat(boat));
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Подтвердите удаление", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Boat boat = BoatGrid.SelectedItem as Boat;
                AppData.db.Boats.Remove(boat);
                AppData.db.SaveChanges();
                GetBoats();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            GetBoats();
        }
        
        private void GetBoats()
        {
            boats = AppData.db.Boats.ToList();
            BoatGrid.ItemsSource = boats;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAddBoat(new Boat()));
        }

        private void ChangePriceButton_Click(object sender, RoutedEventArgs e)
        {
            WindowChangePrice windowChangePrice = new WindowChangePrice(boats);
            windowChangePrice.ShowDialog();
            GetBoats();
        }
    }
}
