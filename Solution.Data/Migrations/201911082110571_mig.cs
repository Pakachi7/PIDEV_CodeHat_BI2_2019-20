namespace Solution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Certifications", new[] { "CandidateId" });
            DropIndex("dbo.Diplomata", new[] { "CandidateId" });
            DropIndex("dbo.Skills", new[] { "CandidateId" });
            AlterColumn("dbo.Certifications", "CandidateId", c => c.Int());
            AlterColumn("dbo.Diplomata", "CandidateId", c => c.Int());
            AlterColumn("dbo.Skills", "CandidateId", c => c.Int());
            CreateIndex("dbo.Certifications", "CandidateId");
            CreateIndex("dbo.Diplomata", "CandidateId");
            CreateIndex("dbo.Skills", "CandidateId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Skills", new[] { "CandidateId" });
            DropIndex("dbo.Diplomata", new[] { "CandidateId" });
            DropIndex("dbo.Certifications", new[] { "CandidateId" });
            AlterColumn("dbo.Skills", "CandidateId", c => c.Int(nullable: false));
            AlterColumn("dbo.Diplomata", "CandidateId", c => c.Int(nullable: false));
            AlterColumn("dbo.Certifications", "CandidateId", c => c.Int(nullable: false));
            CreateIndex("dbo.Skills", "CandidateId");
            CreateIndex("dbo.Diplomata", "CandidateId");
            CreateIndex("dbo.Certifications", "CandidateId");
        }
    }
}
