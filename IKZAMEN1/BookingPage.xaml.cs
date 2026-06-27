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
    /// Логика взаимодействия для BookingPage.xaml
    /// </summary>
    public partial class BookingPage : Page
    {
        private User _currentUser;
        private Movy _selectedMovie;

        public BookingPage(User user, Movy movie)
        {
            InitializeComponent();
            _currentUser = user;
            _selectedMovie = movie;
            tbMovieTitle.Text = movie.Title;
            dpDate.SelectedDate = DateTime.Today;
        }

        private void dpDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dpDate.SelectedDate == null) return;

            var screening = Core.Context.Screenings
                .FirstOrDefault(s => s.MovieId == _selectedMovie.Id
                                  && s.ScreeningDate == dpDate.SelectedDate.Value);

            if (screening == null)
            {
                dgSeats.ItemsSource = null;
                MessageBox.Show("На эту дату сеансов нет");
                return;
            }

            dgSeats.ItemsSource = Core.Context.Seats
                .Where(s => s.ScreeningId == screening.Id)
                .ToList();
        }

        private void BtnBook_Click(object sender, RoutedEventArgs e)
        {
            if (dgSeats.SelectedItem == null)
            {
                MessageBox.Show("Выберите место");
                return;
            }

            var seat = dgSeats.SelectedItem as Seat;

            if (seat.IsBooked == true)
            {
                MessageBox.Show("Место уже занято");
                return;
            }

            var booking = new Booking
            {
                UserId = _currentUser.Id,
                SeatId = seat.Id,
                BookingDate = DateTime.Now
            };

            seat.IsBooked = true;

            Core.Context.Bookings.Add(booking);
            Core.Context.SaveChanges();

            MessageBox.Show("Готово! Место забронировано.");
            NavigationService.GoBack();
        }
    }
}
