using Clone_MovieMVC_Data;
using Clone_MovieMVC_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clone_MovieMVC_Services
{
    public class MovieService:IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public IEnumerable<Movie> GetFavorMovie()
        {
            return _movieRepository.GetFavorMovie();
        }

        //Finished
        public Movie GetMovieById(int id)
        {
            return _movieRepository.GetByMovieId(id);
        }

        //Finished
        public Movie GetMovieByName(string name)
        {
            return _movieRepository.GetMovieByName(name);
        }

        public IEnumerable<Movie> GetMoviesByGenreId(int GenreId)
        {
            return _movieRepository.GetMovieByGenreId(GenreId);
        }

        public IEnumerable<Movie> GetTopGrossingMovies()
        {
            return _movieRepository.GetTopRevenueMovies();
        }

        public IEnumerable<Movie> GetTopPurchaseMovie()
        {
            return _movieRepository.GetTopPurchaseMovie();
        }

        public IEnumerable<Movie> GetTopRatedMovies()
        {

            return _movieRepository.GetTopReviewsMovie();
        }

    }

    public interface IMovieService
    {
        IEnumerable<Movie> GetTopGrossingMovies();
        Movie GetMovieById(int id);
        Movie GetMovieByName(string name);

        //Create junction table here
        IEnumerable<Movie> GetMoviesByGenreId(int GenreId);
        IEnumerable<Movie> GetTopRatedMovies();
        IEnumerable<Movie> GetTopPurchaseMovie();
        IEnumerable<Movie> GetFavorMovie();
    }
}
