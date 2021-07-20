using Clone_MovieMVC_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clone_MovieMVC_Services
{
    public class MovieCrewService:IMovieCrewService
    {
        //Dependency Injection
        private readonly IMovieCrewRepository _movieCrewRepository;
        public MovieCrewService(IMovieCrewRepository movieCrewRepository)
        {
            _movieCrewRepository = movieCrewRepository;
        }
    }

    public interface IMovieCrewService
    { 
    }
}
