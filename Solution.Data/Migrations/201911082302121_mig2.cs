namespace Solution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        CandidateId = c.Int(),
                    })
                .PrimaryKey(t => t.ContactId)
                .ForeignKey("dbo.Candidates", t => t.CandidateId, cascadeDelete: true)
                .Index(t => t.CandidateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "CandidateId", "dbo.Candidates");
            DropIndex("dbo.Contacts", new[] { "CandidateId" });
            DropTable("dbo.Contacts");
        }
    }
}
