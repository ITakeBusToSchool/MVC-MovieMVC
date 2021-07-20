using Clone_MovieMVC_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clone_MovieMVC_Data
{
    public class FavoriteRepository : Repository<Favorite>, IFavoriteRepository
    {
        public FavoriteRepository(CloneMovieShopDbContext cloneMovieShopDbContext) : base(cloneMovieShopDbContext)
        { 
        }
    }
    public interface IFavoriteRepository : IRepository<Favorite>
    { 
    }
}
