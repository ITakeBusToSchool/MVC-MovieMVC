using Clone_MovieMVC_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clone_MovieMVC_Services
{
    public class FavoriteService: IFavoriteService
    {
        //Dependency Injection
        private readonly IFavoriteRepository _favoriteRepository;
        public FavoriteService(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }

    }

    public interface IFavoriteService
    { }
}
