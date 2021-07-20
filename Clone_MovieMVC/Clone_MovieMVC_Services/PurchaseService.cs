using Clone_MovieMVC_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clone_MovieMVC_Services
{
    public class PurchaseService : IPurchaseService
    {
        //Dependency Injection
        private readonly IPurchaseRepository _purchaseRepository;
        public PurchaseService(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }
    }

    public interface IPurchaseService
    { }
}
