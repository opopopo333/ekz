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
    /// Логика взаимодействия для ReviewsPage.xaml
    /// </summary>
    public partial class ReviewsPage : Page
    {
        private User  _currentUser;

        public ReviewsPage(User user)
        {
            InitializeComponent();
            _currentUser = user;

            cbMovies.ItemsSource = Core.Context.Movies.ToList();
            cbMovies.DisplayMemberPath = "Title";

            LoadReviews();
        }

        private void LoadReviews()
        {
            dgReviews.ItemsSource = Core.Context.Reviews
                .Where(r => r.UserId == _currentUser.Id)
                .ToList();
        }

        private void BtnReview_Click(object sender, RoutedEventArgs e)
        {
            if (cbMovies.SelectedItem == null)
            {
                MessageBox.Show("Выберите фильм");
                return;
            }

            var movie = cbMovies.SelectedItem as Movy;

            var review = new Review
            {
                UserId = _currentUser.Id,
                MovieId = movie.Id,
                ScoreStory = int.Parse(tbStory.Text),
                ScoreActing = int.Parse(tbActing.Text),
                ScoreVisuals = int.Parse(tbVisuals.Text),
                Comment = tbComment.Text
            };

            Core.Context.Reviews.Add(review);
            Core.Context.SaveChanges();

            MessageBox.Show("Отзыв сохранён!");
            LoadReviews();
        }
    }
}
