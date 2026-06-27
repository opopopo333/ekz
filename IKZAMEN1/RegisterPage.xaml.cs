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

namespace IKZAMEN1
{
    /// <summary>
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbLogin.Text) || string.IsNullOrEmpty(pbPassword.Password))
            {
                MessageBox.Show("Заполните логин и пароль");
                return;
            }

            var exists = Core.Context.Users
                .Any(u => u.Login == tbLogin.Text);

            if (exists)
            {
                MessageBox.Show("Такой логин уже занят");
                return;
            }

            var newUser = new User
            {
                Login = tbLogin.Text,
                Password = pbPassword.Password,
                FullName = tbFullName.Text,
                Email = tbEmail.Text
            };

            Core.Context.Users.Add(newUser);
            Core.Context.SaveChanges();

            MessageBox.Show("Готово! Теперь войдите.");
            NavigationService.Navigate(new LoginPage());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
        }
    }
}
