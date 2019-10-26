namespace Solution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration2MayssaEvent_Company_Offre_CompanyConfig : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "Company_CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Posts", "Company_CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Users", "Company_CompanyId", "dbo.Companies");
            DropForeignKey("dbo.OffresOfCandidate", "Offres", "dbo.Users");
            DropForeignKey("dbo.OffresOfCandidate", "Candidate", "dbo.Offres");
            DropIndex("dbo.Users", new[] { "Company_CompanyId" });
            DropIndex("dbo.Comments", new[] { "Company_CompanyId" });
            DropIndex("dbo.Posts", new[] { "Company_CompanyId" });
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        Event_Title = c.String(),
                        Event_Description = c.String(),
                        Event_Organizer = c.String(),
                        Event_Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        NumberOfParticipent = c.Int(nullable: false),
                        CompanyId = c.Int(),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Offers",
                c => new
                    {
                        OfferId = c.Int(nullable: false, identity: true),
                        Offer_Title = c.String(),
                        Offer_description = c.String(),
                        Offre_Location = c.String(),
                        Offre_Duration = c.String(),
                        Offre_Salary = c.Single(nullable: false),
                        Offer_Contract_Type = c.String(),
                        Offer_Level_Of_Expertise = c.String(),
                        Offer_DatePublished = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Validity = c.Boolean(nullable: false),
                        Vues = c.Int(nullable: false),
                        CompanyId = c.Int(),
                    })
                .PrimaryKey(t => t.OfferId)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .Index(t => t.CompanyId);
            
            //CreateTable(
            //    "dbo.OffresOfCandidate",
            //    c => new
            //        {
            //            Offres = c.Int(nullable: false),
            //            Candidate = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.Offres, t.Candidate })
            //    .ForeignKey("dbo.Users", t => t.Offres, cascadeDelete: true)
            //    .ForeignKey("dbo.Offers", t => t.Candidate, cascadeDelete: true);
            
            DropColumn("dbo.Users", "Company_CompanyId");
            DropColumn("dbo.Comments", "Company_CompanyId");
            DropColumn("dbo.Posts", "Company_CompanyId");
            DropTable("dbo.Offres");
            DropTable("dbo.OffresOfCandidate");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OffresOfCandidate",
                c => new
                    {
                        Offres = c.Int(nullable: false),
                        Candidate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Offres, t.Candidate });
            
            CreateTable(
                "dbo.Offres",
                c => new
                    {
                        OffreId = c.Int(nullable: false, identity: true),
                        DatePublished = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ExpiredDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        description = c.String(),
                        Validity = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OffreId);
            
            AddColumn("dbo.Posts", "Company_CompanyId", c => c.Int());
            AddColumn("dbo.Comments", "Company_CompanyId", c => c.Int());
            AddColumn("dbo.Users", "Company_CompanyId", c => c.Int());
            DropForeignKey("dbo.OffresOfCandidate", "Candidate", "dbo.Offers");
            DropForeignKey("dbo.OffresOfCandidate", "Offres", "dbo.Users");
            DropForeignKey("dbo.Offers", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Events", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Offers", new[] { "CompanyId" });
            DropIndex("dbo.Events", new[] { "CompanyId" });
            DropTable("dbo.OffresOfCandidate");
            DropTable("dbo.Offers");
            DropTable("dbo.Events");
            CreateIndex("dbo.Posts", "Company_CompanyId");
            CreateIndex("dbo.Comments", "Company_CompanyId");
            CreateIndex("dbo.Users", "Company_CompanyId");
            AddForeignKey("dbo.OffresOfCandidate", "Candidate", "dbo.Offres", "OffreId", cascadeDelete: true);
            AddForeignKey("dbo.OffresOfCandidate", "Offres", "dbo.Users", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Users", "Company_CompanyId", "dbo.Companies", "CompanyId");
            AddForeignKey("dbo.Posts", "Company_CompanyId", "dbo.Companies", "CompanyId");
            AddForeignKey("dbo.Comments", "Company_CompanyId", "dbo.Companies", "CompanyId");
        }
    }
}
