using Clone_MovieMVC_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clone_MovieMVC_Data
{
    public class UsersRepository:Repository<User>, IUserRepository
    {
        public UsersRepository(CloneMovieShopDbContext cloneMovieShopDbContext) : base(cloneMovieShopDbContext)
        { 
        }
    }

    public interface IUserRepository:IRepository<User>
    { 
    }
}
