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
using dem.Data.Model;
using dem.Pages;

namespace dem.Windows
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Window
    {
        DBEntities db = new DBEntities();
        int attempCount = 0;
        public Autorization()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TbLogin.Text))
            {
                MessageBox.Show("Вы не ввели логин");
                TbLogin.Focus();
            }
            else if (string.IsNullOrEmpty(TbPassword.Text))
            {
                MessageBox.Show("Вы не ввели логин");
                TbPassword.Focus();
            }
            else
            {
                Users user = db.Users.Where(u => u.Login == TbLogin.Text).FirstOrDefault();
                if (user == null)
                {
                    MessageBox.Show("Такого логина нет");
                    return;
                }
                if (attempCount >= 3)
                {
                    user.Blocked = true;
                    db.SaveChanges();
                    MessageBox.Show("Попытки входа исчерпаны, пользователь заблокирован");
                    return;
                }
                if(user.Blocked == true)
                {
                    MessageBox.Show("Пользователь заблокирован");
                    return;
                }
                if (user.Password.Trim() == TbPassword.Text.Trim())
                {
                    StaticObjects.users = user;
                    if(!user.PasswordChanged)
                    {
                        ChangePassword changePassword = new ChangePassword();
                        changePassword.user = user;
                        changePassword.ShowDialog();
                    }
                    else
                    {
                        db.SaveChanges();
                        MessageBox.Show("Вы успешно авторизовались");
                        if(StaticObjects.users.RoleID == 1)
                        {
                            StaticObjects.desktopFrame.Navigate(new AdminPage());
                            this.Close();
                        }
                        else if(StaticObjects.users.RoleID == 2)
                        {
                            StaticObjects.desktopFrame.Navigate(new ManagerPage());
                            this.Close();
                        }
                    }
                }
                else
                {
                    attempCount++;
                    MessageBox.Show($"Вы ввели неверный пароль. Осталось попыток {3 - attempCount}");
                    return;
                }
            }
        }
    }
}
