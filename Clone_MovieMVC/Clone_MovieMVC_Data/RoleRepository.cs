using Clone_MovieMVC_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clone_MovieMVC_Data
{
    public class RoleRepository:Repository<Role>, IRoleRepository
    {
        public RoleRepository(CloneMovieShopDbContext cloneMovieShopDbContext):base(cloneMovieShopDbContext)
        { 
        }
    }

    public interface IRoleRepository : IRepository<Role> 
    { }
}
