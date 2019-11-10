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
  public  class SkillService : Service<Skill>, ISkillService
    {


        static IDataBaseFactory factory = new DataBaseFactory();

        static UnitOfWork UTK = new UnitOfWork(factory);
        public SkillService() : base(UTK)
        {

    }
    }
}
