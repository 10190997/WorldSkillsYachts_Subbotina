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

namespace WorldSkillsYachts.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAdminTasks.xaml
    /// </summary>
    public partial class PageAdminTasks : Page
    {
        public PageAdminTasks()
        {
            InitializeComponent();
        }

        private void ButtonBoats_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageBoats());
        }

        private void ButtonAccessory_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageAccessories());
        }

        private void ButtonUsers_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageUsers());
        }
    }
}
