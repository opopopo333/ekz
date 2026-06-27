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
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        private User _currentUser;

        public ProfilePage(User user)
        {
            InitializeComponent();
            _currentUser = user;

            // Автовставка данных
            tbFullName.Text = "Имя: " + user.FullName;
            tbEmail.Text = "Email: " + user.Email;
            tbLogin.Text = "Логин: " + user.Login;

            // Мои брони
            dgBookings.ItemsSource = Core.Context.Bookings
                .Where(b => b.UserId == user.Id)
                .ToList();
        }
    }
}
