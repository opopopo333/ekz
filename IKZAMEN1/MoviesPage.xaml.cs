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
    /// Логика взаимодействия для MoviesPage.xaml
    /// </summary>
    public partial class MoviesPage : Page
    {
        private User _currentUser;
        private bool _sortAsc = true;

        public MoviesPage(User user)
        {
            InitializeComponent();
            _currentUser = user;
            LoadMovies();
        }

        private void LoadMovies()
        {
            var data = Core.Context.Movies
                .Where(m => m.Title.Contains(tbSearch.Text))
                .ToList();

            dgMovies.ItemsSource = _sortAsc
                ? data.OrderBy(m => m.Price).ToList()
                : data.OrderByDescending(m => m.Price).ToList();
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoadMovies();
        }

        private void BtnSortAsc_Click(object sender, RoutedEventArgs e)
        {
            _sortAsc = true;
            LoadMovies();
        }

        private void BtnSortDesc_Click(object sender, RoutedEventArgs e)
        {
            _sortAsc = false;
            LoadMovies();
        }

        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            if (dgMovies.SelectedItem == null)
            {
                MessageBox.Show("Выберите фильм");
                return;
            }

            var movie = dgMovies.SelectedItem as Movy;
            NavigationService.Navigate(new BookingPage(_currentUser, movie));
        }

    }
}
