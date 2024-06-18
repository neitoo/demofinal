using DemoApp.Data;
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
using System.Windows.Shapes;

namespace DemoApp.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        List<Users> users;
        public LoginWindow()
        {
            try
            {
                users = DataEntity.Instance.demo.Users.ToList();
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
            var user = users.Where(us => us.login == LoginBox.Text && us.password == PasswordBox.Password).FirstOrDefault();
            if (user != null) { 
                ManagerWindow managerWindow = new ManagerWindow(user);
                managerWindow.Show();

                this.Close();
            }
        }
    }
}
