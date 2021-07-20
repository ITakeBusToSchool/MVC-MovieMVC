using Clone_MovieMVC_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clone_MovieMVC_Data
{
    public class CrewRepository:Repository<Crew>, ICrewRepository
    {
        public CrewRepository(CloneMovieShopDbContext cloneMovieShopDbContext) : base(cloneMovieShopDbContext) 
        { }
    }

    public interface ICrewRepository : IRepository<Crew>
    { }
}
