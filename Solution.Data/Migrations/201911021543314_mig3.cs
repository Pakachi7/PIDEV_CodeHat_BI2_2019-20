namespace Solution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Candidates", "Address", c => c.String());
            DropColumn("dbo.Candidates", "Address_City");
            DropColumn("dbo.Candidates", "Address_StreetAddress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Candidates", "Address_StreetAddress", c => c.String());
            AddColumn("dbo.Candidates", "Address_City", c => c.String());
            DropColumn("dbo.Candidates", "Address");
        }
    }
}
