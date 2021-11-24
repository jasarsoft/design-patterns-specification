using System.Collections.Generic;
using System.Windows;
using Logic.Movies;
using UI.Common;

namespace UI.Movies
{
    public class MovieListViewModel : ViewModel
    {
        private readonly MovieRepository _repository;

        public Command SearchCommand { get; }
        public Command<long> BuyTicketCommand { get; }
        public IReadOnlyList<Movie> Movies { get; private set; }

        public MovieListViewModel()
        {
            _repository = new MovieRepository();

            SearchCommand = new Command(Search);
            BuyTicketCommand = new Command<long>(BuyTicket);
        }

        private void BuyTicket(long movieId)
        {
            MessageBox.Show("You've bought a ticket", "Success",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Search()
        {
            Movies = _repository.GetList();
            Notify(nameof(Movies));
        }
    }
}
