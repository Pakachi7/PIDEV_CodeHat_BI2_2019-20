namespace Solution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "CarrierCandidate_CandidateId", c => c.Int());
            AlterColumn("dbo.Contacts", "CarrierId", c => c.Int());
            CreateIndex("dbo.Contacts", "CarrierCandidate_CandidateId");
            AddForeignKey("dbo.Contacts", "CarrierCandidate_CandidateId", "dbo.Candidates", "CandidateId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "CarrierCandidate_CandidateId", "dbo.Candidates");
            DropIndex("dbo.Contacts", new[] { "CarrierCandidate_CandidateId" });
            AlterColumn("dbo.Contacts", "CarrierId", c => c.Int(nullable: false));
            DropColumn("dbo.Contacts", "CarrierCandidate_CandidateId");
        }
    }
}
