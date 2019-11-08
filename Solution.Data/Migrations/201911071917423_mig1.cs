namespace Solution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Experiences", "Designation", c => c.String());
            AddColumn("dbo.Experiences", "Description", c => c.String());
            AddColumn("dbo.Experiences", "StartDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Experiences", "EndDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            DropColumn("dbo.Experiences", "Nbr");
            DropColumn("dbo.Experiences", "field");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Experiences", "field", c => c.String());
            AddColumn("dbo.Experiences", "Nbr", c => c.Int(nullable: false));
            DropColumn("dbo.Experiences", "EndDate");
            DropColumn("dbo.Experiences", "StartDate");
            DropColumn("dbo.Experiences", "Description");
            DropColumn("dbo.Experiences", "Designation");
        }
    }
}
