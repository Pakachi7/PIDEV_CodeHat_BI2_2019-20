using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Data.Configurations
{
    class CandidateConfiguration : EntityTypeConfiguration<Candidate>
    {
        public CandidateConfiguration()
        {

            HasMany(prod => prod.languages).WithMany(cat => cat.Candidates).Map(M =>
            {
                M.ToTable("Knowledge");
                M.MapRightKey("Candidate");//le nom de la clé dans la tab de relation est Product
                M.MapLeftKey("Language");
            });


            HasMany<Experience>(c => c.Experiences)
                    .WithRequired(e=>e.Candidate)
                    .HasForeignKey(e => e.CandidateId);


            HasMany(prod => prod.Diplomas).WithMany(cat => cat.Candidates).Map(M =>
            {
        M.ToTable("DiplomaOfCandidate");
        M.MapRightKey("Candidate");//le nom de la clé dans la tab de relation est Product
        M.MapLeftKey("Diploma");
    });

        
HasMany(prod => prod.Offers).WithMany(cat => cat.Candidates).Map(M =>
            {
    M.ToTable("OffresOfCandidate");
    M.MapRightKey("Candidate");//le nom de la clé dans la tab de relation est Product
    M.MapLeftKey("Offres");
});

        
 HasMany(prod => prod.Certifications).WithMany(cat => cat.Candidates).Map(M =>
            {
    M.ToTable("CertificationOfCandidate");
    M.MapRightKey("Candidate");//le nom de la clé dans la tab de relation est Product
    M.MapLeftKey("Certification");
});

       
 HasMany(prod => prod.Companies).WithMany(cat => cat.Candidates).Map(M =>
            {
    M.ToTable("Subscribers");
    M.MapRightKey("Candidate");//le nom de la clé dans la tab de relation est Product
    M.MapLeftKey("Company");
});

            HasMany(cand => cand.Interviews).
                          WithRequired(inter => inter.candidate).//prop nav
                          HasForeignKey(inter => inter.Candidat_Id).//prop nav
                          WillCascadeOnDelete(false);
        }

}
}
