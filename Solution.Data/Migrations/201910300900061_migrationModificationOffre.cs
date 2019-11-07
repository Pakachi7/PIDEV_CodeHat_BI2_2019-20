namespace Solution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrationModificationOffre : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Offers", "Offer_Contract_Type", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Offers", "Offer_Contract_Type", c => c.Int(nullable: false));
        }
    }
}
