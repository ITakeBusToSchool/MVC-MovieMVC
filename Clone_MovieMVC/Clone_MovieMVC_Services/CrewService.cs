using Clone_MovieMVC_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clone_MovieMVC_Services
{
    public class CrewService:ICrewService
    {
        //Dependency Injection
        private readonly ICrewRepository _crewRepository;
        public CrewService(ICrewRepository crewRepository)
        {
            _crewRepository = crewRepository;
        }
    }
    public interface ICrewService
    { }
}
