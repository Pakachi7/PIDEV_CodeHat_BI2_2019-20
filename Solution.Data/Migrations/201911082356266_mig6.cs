namespace Solution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contacts", "CandidateId", "dbo.Candidates");
            DropIndex("dbo.Contacts", new[] { "CandidateId" });
            CreateTable(
                "dbo.contact",
                c => new
                    {
                        CandidateId = c.Int(nullable: false),
                        ContactId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CandidateId, t.ContactId })
                .ForeignKey("dbo.Candidates", t => t.CandidateId)
                .ForeignKey("dbo.Candidates", t => t.ContactId)
                .Index(t => t.CandidateId)
                .Index(t => t.ContactId);
            
            DropTable("dbo.Contacts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        CarrierId = c.Int(nullable: false),
                        CandidateId = c.Int(),
                    })
                .PrimaryKey(t => t.ContactId);
            
            DropForeignKey("dbo.contact", "ContactId", "dbo.Candidates");
            DropForeignKey("dbo.contact", "CandidateId", "dbo.Candidates");
            DropIndex("dbo.contact", new[] { "ContactId" });
            DropIndex("dbo.contact", new[] { "CandidateId" });
            DropTable("dbo.contact");
            CreateIndex("dbo.Contacts", "CandidateId");
            AddForeignKey("dbo.Contacts", "CandidateId", "dbo.Candidates", "CandidateId", cascadeDelete: true);
        }
    }
}
