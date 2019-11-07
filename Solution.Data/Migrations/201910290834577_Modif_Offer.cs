namespace Solution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modif_Offer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Offers", "Offer_Contract_Type", c => c.Int(nullable: false));
            DropColumn("dbo.Offers", "Validity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Offers", "Validity", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Offers", "Offer_Contract_Type", c => c.String());
        }
    }
}
