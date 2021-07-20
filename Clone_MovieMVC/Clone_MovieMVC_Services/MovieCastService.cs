using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clone_MovieMVC_Services
{
    public class MovieCastService : IMovieCastService
    {
        //Dependency Interface
        private readonly IMovieCastService _movieCastService;
        public MovieCastService(IMovieCastService movieCastService)
        {
            _movieCastService = movieCastService;
        }
          
    }
    public interface IMovieCastService
    { 
    }
}
