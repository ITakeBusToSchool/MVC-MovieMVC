using Clone_MovieMVC_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clone_MovieMVC_Data
{
    public class GenreRepository:Repository<Genre>, IGenreRepository
    {
        public GenreRepository(CloneMovieShopDbContext cloneMovieShopDbContext) : base(cloneMovieShopDbContext)
        { }

        public IEnumerable<Genre> GetAllGenre()
        {
            //return GetAll();
            return GetAll();
        }

        public Genre GetByGenreId(int id)
        {
            //var q = cloneMovieShopDbContext.Genres.Where(g => g.Id.Equals(id)).FirstOrDefault();
            var q = _cloneMovieShopDbContext.Genres.Where(g => g.Id.Equals(id)).FirstOrDefault();
            return q;
        }

        public Genre GetByGenreName(string name)
        {
            var q = _cloneMovieShopDbContext.Genres.Where(g => g.Name.Equals(name)).FirstOrDefault();
            return q;
        }
    }

    public interface IGenreRepository : IRepository<Genre>
    {
        Genre GetByGenreId(int id);
        Genre GetByGenreName(string name);
        IEnumerable<Genre> GetAllGenre();
    }
}
