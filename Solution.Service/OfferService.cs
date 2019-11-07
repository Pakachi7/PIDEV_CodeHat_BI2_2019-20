using Service.Pattern;
using Solution.Data.Infrastructure;
using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Service
{
    public class OfferService : Service<Offer>, IOfferService
    {
        static IDataBaseFactory factory = new DataBaseFactory();
        static IUnitOfWork UTK = new UnitOfWork(factory);

        public OfferService() : base(UTK)
        {
            //Service = new OfferService();
            //ServiceCompany = new CompanyService();
        }
    }
}
