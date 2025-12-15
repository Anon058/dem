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

namespace dem.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditUser.xaml
    /// </summary>
    public partial class EditUser : Window
    {
        public Users user;
        public EditUser()
        {
            InitializeComponent();
        }

        private void BtnEditUser_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
