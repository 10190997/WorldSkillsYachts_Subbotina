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
    /// Логика взаимодействия для PageAddUser.xaml
    /// </summary>
    public partial class PageAddUser : Page
    {
        User NewUser { get; set; }
        public PageAddUser(User user)
        {
            InitializeComponent();
            NewUser = user;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            cbRole.ItemsSource = AppData.db.Roles.ToList();
            if (NewUser == null)
            {
                NewUser = new User();
                NavigationService.Navigate(new PageAddUser(NewUser));
            }
            if (NewUser.User_ID != 0)
            {
                tbLogin.Text = NewUser.Login;
                tbPassword.Text = NewUser.Password;
                cbRole.SelectedIndex = (int)NewUser.Role_ID;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            NewUser.Login = tbLogin.Text;
            NewUser.Password = tbPassword.Text;
            NewUser.Role_ID = cbRole.SelectedIndex;
            NewUser.RegisteredDate = DateTime.Today;
            if (NewUser.User_ID == 0)
            {
                AppData.db.Users.Add(NewUser);
            }
            AppData.db.SaveChanges();

            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }
    }
}
