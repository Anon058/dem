using dem.Data.Model;
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

namespace dem.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        DBEntities db = new DBEntities();
        public AddUser()
        {
            InitializeComponent();
            CmbxRole.ItemsSource = db.Roless.ToList();
            CmbxRole.DisplayMemberPath = "RoleName";
            CmbxRole.SelectedValuePath = "RoleId";
        }

        private void BtnAddUser_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TbLogin.Text) || string.IsNullOrEmpty(TbPassword.Text) || string.IsNullOrEmpty(CmbxRole.Text))
            {
                MessageBox.Show("Одно или несколько полей не заполнены");
            }
            else if(db.Users.Where(u => u.Login == TbLogin.Text).ToList().Count > 0)
                {
                    MessageBox.Show("Пользователь с таким логином уже существует");
                    return;
                
            }
            else
            {
                db.Users.Add(new Users
                {
                    Login = TbLogin.Text,
                    Password = TbPassword.Text,
                    RoleID = Convert.ToInt32(CmbxRole.SelectedValue),
                    PasswordChanged = (bool)ChkbxPasswordChanged.IsChecked,
                    Blocked = (bool)ChkbxBlocked.IsChecked
                });
            }

            StaticObjects.desktopFrame.Refresh();
            this.Close();
        }
    }
}
