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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static User CurrentUser;

        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new LoginPage());
        }

        public void Navigate(System.Windows.Controls.Page page)
        {
            MainFrame.Navigate(page);
        }

        private void BtnMovies_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MoviesPage(CurrentUser));
        }

        private void BtnProfile_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ProfilePage(CurrentUser));
        }

        private void BtnReviews_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ReviewsPage(CurrentUser));
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            CurrentUser = null;
            MainFrame.Navigate(new LoginPage());
        }
    }
}
