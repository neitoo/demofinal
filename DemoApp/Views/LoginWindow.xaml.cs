using DemoApp.Classes;
using DemoApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DemoApp.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        List<Users> users;
        Auth auth;
        public LoginWindow()
        {
            try
            {
                users = DataEntity.Instance.demo.Users.ToList();
                auth = new Auth(users);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                this.Close();
            }

            
            InitializeComponent();
        }

        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            bool isAuth = auth.SignIn(LoginBox.Text, PasswordBox.Password);
            if (isAuth) { 
                ManagerWindow managerWindow = new ManagerWindow(auth.user);
                managerWindow.Show();

                this.Close();
            }
        }
    }
}
