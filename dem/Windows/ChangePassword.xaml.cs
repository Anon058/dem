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
    /// Логика взаимодействия для ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Window
    {
        public Users user = new Users();
        DBEntities db = new DBEntities();
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void BtnEditPassword_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TbOldPassword.Text))
            {
                MessageBox.Show("Введите старый пароль");
                TbOldPassword.Focus();
                return;
            }
            if (string.IsNullOrEmpty(TbNewPassword.Text))
            {
                MessageBox.Show("Введите новый пароль");
                TbNewPassword.Focus();
                return;
            }
            if (string.IsNullOrEmpty(TbConfirmPassword.Text))
            {
                MessageBox.Show("Подтвердите новый пароль");
                return;
            }
            if(TbOldPassword.Text != user.Password.Trim())
            {
                MessageBox.Show("Введен неверный пароль");
                TbNewPassword.Focus();
                return;
            }
            if(TbNewPassword.Text != TbConfirmPassword.Text)
            {
                MessageBox.Show("Пароли не совпадают");
                TbConfirmPassword.Focus();
                return;
            }
            else
            {
                user.Password = TbNewPassword.Text;
                user.PasswordChanged = true;
                db.SaveChanges();
                MessageBox.Show("Теперь вы можете войти с новым паролем");
                this.Close();
            }
        }
    }
}
