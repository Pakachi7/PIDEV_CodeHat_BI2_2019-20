using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Data.Configurations
{
    class CompanyConfiguration : EntityTypeConfiguration<Company>
    {

        public CompanyConfiguration()
        {




            //0..Many with offer
            HasMany(company => company.Offers).
                           WithOptional(offre => offre.Company).//prop nav
                           HasForeignKey(offre => offre.CompanyId).//prop nav
                           WillCascadeOnDelete(false);


            //0..Many with event
            HasMany(company => company.Events).
                WithOptional(ev => ev.Company).
                HasForeignKey(ev => ev.CompanyId).
                WillCascadeOnDelete(false);



        }



    }
}
