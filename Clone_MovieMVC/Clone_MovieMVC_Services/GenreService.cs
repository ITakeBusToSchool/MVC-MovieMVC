using Clone_MovieMVC_Data;
using Clone_MovieMVC_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clone_MovieMVC_Services
{
    public class GenreService:IGenreService
    {
        //Dependency injection
        private readonly IGenreRepository _genreRepository;
        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        public IEnumerable<Genre> GetAll()
        {
            return _genreRepository.GetAllGenre();
        }

        public Genre GetById(int id)
        {
            return _genreRepository.GetByGenreId(id);
        }
        public Genre GetByName(string name)
        {
            return _genreRepository.GetByGenreName(name);
        }

    }

    public interface IGenreService
    {
        Genre GetById(int id);
        Genre GetByName(string name);

        IEnumerable<Genre> GetAll();
    }
}
