using Clone_MovieMVC_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clone_MovieMVC_Data
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(CloneMovieShopDbContext cloneMovieShopDbContext) : base(cloneMovieShopDbContext)
        { }
    }

    public interface IReviewRepository : IRepository<Review> 
    { }
}
