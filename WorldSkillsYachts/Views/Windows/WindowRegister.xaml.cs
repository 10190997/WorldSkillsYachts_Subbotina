using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using WorldSkillsYachts.Models;
using WorldSkillsYachts.Utils;

namespace WorldSkillsYachts.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для WindowRegister.xaml
    /// </summary>
    public partial class WindowRegister : Window
    {
        public WindowRegister()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private bool Register(string login, string password, int roleID)
        {
            List<User> users = AppData.db.Users.ToList();
            foreach (var u in users)
            {
                if (login == u.Login)
                {
                    return false;
                }
            }
            User user = new User
            {
                Login = login,
                Password = password,
                Role_ID = roleID,
                RegisteredDate = DateTime.Today
            };
            AppData.db.Users.Add(user);
            AppData.db.SaveChanges();
            return true;
        }

        private void RegisterManagerButton_Click(object sender, RoutedEventArgs e)
        {
            if (PassBox.Password == RepeatPassBox.Password)
            {
                if (Register(LoginBox.Text, PassBox.Password, 2))
                {
                    MessageBox.Show("Регистрация прошла успешно", "", MessageBoxButton.OK);
                    User.CheckUsers();
                    Close();
                }
                else
                {
                    MessageBox.Show("Такой логин уже существует!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Пароли не совпадают!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                PassBox.Password = string.Empty;
                RepeatPassBox.Password = string.Empty;
            }
        }

        private void RegisterAdminButton_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.IsAdmin)
            {
                Register(LoginBox.Text, PassBox.Password, 1);
            }
            else
            {
                if (MessageBox.Show("Регистрировать администраторов может только администратор. Перейти на форму авторизации?",
                    "", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.ShowDialog();
                    return;
                }
            }

        }
    }
}