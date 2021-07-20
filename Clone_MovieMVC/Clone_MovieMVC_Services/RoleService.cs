using Clone_MovieMVC_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clone_MovieMVC_Services
{
    public class RoleService:IRoleService
    {
        //Dependency Injection
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository) 
        {
            _roleRepository = roleRepository;
        }
    }

    public interface IRoleService 
    { }
}
