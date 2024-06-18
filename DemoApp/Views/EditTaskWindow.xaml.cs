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
    /// Логика взаимодействия для EditTaskWindow.xaml
    /// </summary>
    public partial class EditTaskWindow : Window
    {
        List<TypesTecnhic> typesTecnhics;
        List<Users> users;
        List<StatusesTasks> statuses;
        Users user;

        Tasks task;
        ManagerWindow window;
        bool isAdd;


        public EditTaskWindow(
            ManagerWindow managerWindow, 
            List<TypesTecnhic> typesTecnhics, 
            List<Users> users, 
            Users user,
            List<StatusesTasks> statuses, 
            Tasks tasks = null)
        {
            this.typesTecnhics = typesTecnhics; 
            this.users = users;
            this.user = user;
            this.statuses = statuses;

            if (tasks == null)
            {
                tasks = new Tasks();
                this.isAdd = true;
            }
            else
            {
                this.isAdd = false;
            }
            this.task = tasks;
            this.window = managerWindow;

            InitializeComponent();

            TypeTechnicBox.ItemsSource = typesTecnhics;
            TypeTechnicBox.DisplayMemberPath = "type";
            TypeTechnicBox.SelectedValuePath = "id";

            StatusBox.ItemsSource = statuses;
            StatusBox.DisplayMemberPath = "status";
            StatusBox.SelectedValuePath = "id";

            WorkerBox.ItemsSource = users;
            WorkerBox.DisplayMemberPath = "fio";
            WorkerBox.SelectedValuePath = "userID";


            if (!this.isAdd)
            {
                TypeTechnicBox.SelectedValue = this.task.typeTechnic;
                ModelText.Text = this.task.modelTechnic;
                DescriptionText.Text = this.task.description;
                FIOClientText.Text = this.task.fioClient;
                PhoneText.Text = this.task.phoneClient;
                StatusBox.SelectedValue = this.task.status;
                WorkerBox.SelectedValue = this.task.worker;
            }
            else
            {
                DeleteButton.Visibility = Visibility.Collapsed;
            }

            switch (user.type)
            {
                case 1:
                    typelabel.Visibility = Visibility.Collapsed;
                    modellabel.Visibility = Visibility.Collapsed;
                    descriptionlabel.Visibility = Visibility.Collapsed;
                    fiolabel.Visibility = Visibility.Collapsed;
                    phonelabel.Visibility = Visibility.Collapsed;
                    statuslabel.Visibility = Visibility.Collapsed;
                    TypeTechnicBox.Visibility = Visibility.Collapsed;
                    ModelText.Visibility = Visibility.Collapsed;
                    DescriptionText.Visibility = Visibility.Collapsed;
                    FIOClientText.Visibility = Visibility.Collapsed;
                    PhoneText.Visibility = Visibility.Collapsed;
                    DeleteButton.Visibility = Visibility.Collapsed;
                    break;
                case 2:
                    typelabel.Visibility = Visibility.Collapsed;
                    modellabel.Visibility = Visibility.Collapsed;
                    descriptionlabel.Visibility = Visibility.Collapsed;
                    fiolabel.Visibility = Visibility.Collapsed;
                    phonelabel.Visibility = Visibility.Collapsed;
                    workerlabel.Visibility = Visibility.Collapsed;
                    TypeTechnicBox.Visibility = Visibility.Collapsed;
                    ModelText.Visibility = Visibility.Collapsed;
                    DescriptionText.Visibility = Visibility.Collapsed;
                    FIOClientText.Visibility = Visibility.Collapsed;
                    PhoneText.Visibility = Visibility.Collapsed;
                    WorkerBox.Visibility = Visibility.Collapsed;
                    DeleteButton.Visibility = Visibility.Collapsed;
                    break;
                case 4:
                    statuslabel.Visibility = Visibility.Collapsed;
                    workerlabel.Visibility = Visibility.Collapsed;
                    StatusBox.Visibility = Visibility.Collapsed;
                    WorkerBox .Visibility = Visibility.Collapsed;
                    DeleteButton.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private void AllowButton_Click(object sender, RoutedEventArgs e)
        {
            if(this.isAdd)  task.dateCreate = DateTime.Now;
            task.typeTechnic = (int)TypeTechnicBox.SelectedValue;
            task.modelTechnic = ModelText.Text;
            task.description = DescriptionText.Text;
            task.fioClient = FIOClientText.Text;
            task.phoneClient = PhoneText.Text;
            if (this.isAdd)  task.status = (int)StatusBox.SelectedValue;
            if (this.isAdd)  task.worker = (int)WorkerBox.SelectedValue;
            if ((int)StatusBox.SelectedValue == 4) task.dateEnd = DateTime.Now;

            if(this.isAdd) DataEntity.Instance.demo.Tasks.Add(task);
            DataEntity.Instance.demo.SaveChanges();
            this.window.RefreshData();
            Close();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var message = MessageBox.Show("Вы точно хотите удалить запись?", "Подтверждение", MessageBoxButton.YesNo);
            if (message == MessageBoxResult.Yes)
            {
                DataEntity.Instance.demo.Tasks.Remove(task);
                DataEntity.Instance.demo.SaveChanges();
                this.window.RefreshData();
                Close();
            }
        }
    }
}
