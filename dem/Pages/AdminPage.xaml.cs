using dem.Data.Model;
using dem.Windows;
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

namespace dem.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        DBEntities db = new DBEntities();
        public AdminPage()
        {
            InitializeComponent();
            DtGrid.ItemsSource = db.Users.ToList();
        }

        private void BtnAddUser_Click(object sender, RoutedEventArgs e)
        {
            new AddUser().ShowDialog();
        }

        private void BtnEditUser_Click(object sender, RoutedEventArgs e)
        {
            Users user = DtGrid.SelectedItem as Users;
            EditUser editUser = new EditUser();
            editUser.user = user;
            editUser.ShowDialog();
        }

        private void BtnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if(StaticObjects.users.UserID == (DtGrid.SelectedItem as Users).UserID)
            {
                MessageBox.Show("Перед удалением данного пользователя необходимо войти в систему по другим пользователем");
            }
            else
            {
                if(MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Users user = DtGrid.SelectedItem as Users;
                    db.Users.Remove(user);
                    db.SaveChanges();
                    DtGrid.ItemsSource = db.Users.ToList();
                }
            }
        }
    }
}
