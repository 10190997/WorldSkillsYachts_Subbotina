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
    /// Логика взаимодействия для PageUsers.xaml
    /// </summary>
    public partial class PageUsers : Page
    {
        public PageUsers()
        {
            InitializeComponent();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            User user = UserGrid.SelectedItem as User;
            NavigationService.Navigate(new PageAddUser(user));
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            User user = UserGrid.SelectedItem as User;
            AppData.db.Users.Remove(user);
            AppData.db.SaveChanges();
            GetUsers();
        }

        private void GetUsers()
        {
            List<User> users = AppData.db.Users.ToList();
            UserGrid.ItemsSource = users;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            GetUsers();
        }
    }
}
