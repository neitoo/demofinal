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
    /// Логика взаимодействия для ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        List<TypesTecnhic> typesTecnhics;
        List<Users> users;
        List<StatusesTasks> statuses;
        List<Tasks> tasks;
        Users user;
        public ManagerWindow(Users user)
        {
            InitializeComponent();
            this.user = user;

            FIOUserText.Text = user.fio;
            if(user.type == 1 || user.type == 2) CreateButton.Visibility = Visibility.Hidden;

            tasks = DataEntity.Instance.demo.Tasks.ToList();
            ListTasks.ItemsSource = DataEntity.Instance.demo.Tasks.ToList();

            typesTecnhics = DataEntity.Instance.demo.TypesTecnhic.ToList();
            users = DataEntity.Instance.demo.Users.Where(u => u.type == 2).ToList();
            statuses = DataEntity.Instance.demo.StatusesTasks.ToList();
        }

        public void RefreshData()
        {
            ListTasks.ItemsSource = DataEntity.Instance.demo.Tasks.ToList();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            var message = MessageBox.Show("Вы точно хотите выйти?", "Подтверждение", MessageBoxButton.YesNo);
            LoginWindow loginWindow = new LoginWindow();
            if(message == MessageBoxResult.Yes)
            {
                loginWindow.Show();
                this.Close();
            }
            
        }



        private void QRButton_Click(object sender, RoutedEventArgs e)
        {
            QRWindow qrWindow = new QRWindow();
            qrWindow.Show();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            EditTaskWindow window = new EditTaskWindow(this, typesTecnhics, users, user, statuses);
            window.Title = "Создание заявки";
            window.Show();
        }

        private void TaskEditButton_Click(object sender, RoutedEventArgs e)
        {
            var currentTask = (Tasks)(sender as Button).DataContext;

            EditTaskWindow window = new EditTaskWindow(this, typesTecnhics, users, user, statuses, currentTask);
            window.Show();
        }
    }
}
