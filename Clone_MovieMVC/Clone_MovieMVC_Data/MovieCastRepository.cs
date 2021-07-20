using Clone_MovieMVC_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clone_MovieMVC_Data
{
    public class MovieCastRepository:Repository<MovieCast>
    {
        public MovieCastRepository(CloneMovieShopDbContext cloneMovieShopDbContext):base(cloneMovieShopDbContext)
        { }
    }

    public interface IMovieCastRepository : IRepository<MovieCast>
    { 
    }
}
