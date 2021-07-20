using Clone_MovieMVC_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clone_MovieMVC_Data
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(CloneMovieShopDbContext cloneMovieShopDbContext) : base(cloneMovieShopDbContext) 
        { }

        public Movie GetByMovieId(int id)
        {
            var q = _cloneMovieShopDbContext.Movies.Where(m => m.Id.Equals(id)).FirstOrDefault();
            return q;
        }
        public Movie GetMovieByName(string Name)
        {
            var q = _cloneMovieShopDbContext.Movies.Where(m => m.Title.Equals(Name)).FirstOrDefault();
            return q;

        }
        public IEnumerable<Movie> GetFavorMovie()
        {
            var movieFavorited = _cloneMovieShopDbContext.Favorites.GroupBy(f => f.MovieId)
                                                     .Select(mf => new { MovieId = mf.Key, Count = mf.Count() })
                                                     .OrderByDescending(mf1 => mf1.Count).Take(20).ToList();

            var movieList = new List<Movie>();
            foreach (var movie in movieFavorited)
            {
                movieList.Add(_cloneMovieShopDbContext.Movies.Where(m => m.Id == movie.MovieId).FirstOrDefault());

            }
            return movieList;
        }

        public IEnumerable<Movie> GetMovieByGenreId(int id)
        {
            var movies =_cloneMovieShopDbContext.Movies.Where(m => m.Genres.Any(a => a.Id == id)).ToList();
            return movies;

        }


        public IEnumerable<Movie> GetTopPurchaseMovie()
        {
            var moviePurchase = from p in _cloneMovieShopDbContext.Purchases
                                group p by p.MovieId into mp
                                select new
                                {
                                    MovieID = mp.Key,
                                    AvgTotalPurchase = mp.Average(p => p.TotalPrice)
                                };

            var movieList = _cloneMovieShopDbContext.Movies.ToList();
            foreach (var myPurchase in moviePurchase)
            {
                movieList.Where(m => m.Id == myPurchase.MovieID).FirstOrDefault().AvgPurchase = myPurchase.AvgTotalPurchase;
            }
            var topPurchaseMovie = movieList.OrderByDescending(m => m.AvgPurchase).Take(20).Where(r => r.AvgPurchase != null).ToList();
            return topPurchaseMovie;
        }

        public IEnumerable<Movie> GetTopRevenueMovies()
        {
            var movies = _cloneMovieShopDbContext.Movies.OrderByDescending(m => m.Revenue).Take(20).ToList();
            return movies;
        }

        public IEnumerable<Movie> GetTopReviewsMovie()
        {
            var movieReview = from r in _cloneMovieShopDbContext.Reviews
                              group r by r.MovieId into mr
                              select new
                              {
                                  MovieID = mr.Key,
                                  AvgReview = mr.Average(r => r.Rating)
                              };
            var movieList = _cloneMovieShopDbContext.Movies.ToList();

            foreach (var mvRating in movieReview)
            {
                movieList.Where(m => m.Id == mvRating.MovieID).FirstOrDefault().AvgRating = mvRating.AvgReview;
            }

            var topMovieRating = movieList.OrderByDescending(m => m.AvgRating).Take(20).Where(r => r.AvgRating != null).ToList();

            return topMovieRating;
        }
    }

    public interface IMovieRepository : IRepository<Movie> 
    {
        IEnumerable<Movie> GetTopRevenueMovies();
        Movie GetByMovieId(int id);
        Movie GetMovieByName(string Name);
        IEnumerable<Movie> GetMovieByGenreId(int id);
        IEnumerable<Movie> GetTopReviewsMovie();
        IEnumerable<Movie> GetTopPurchaseMovie();
        IEnumerable<Movie> GetFavorMovie();
    }
}
