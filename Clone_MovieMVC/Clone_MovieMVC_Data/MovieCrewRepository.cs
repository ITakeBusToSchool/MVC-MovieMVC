using Clone_MovieMVC_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clone_MovieMVC_Data
{
    public class MovieCrewRepository:Repository<MovieCrew>, IMovieCrewRepository
    {
        public MovieCrewRepository(CloneMovieShopDbContext cloneMovieShopDbContext) : base(cloneMovieShopDbContext) 
        { }
    }

    public interface IMovieCrewRepository : IRepository<MovieCrew>
    { }
}
