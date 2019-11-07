namespace Solution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrationModificationCompany3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "Address_City", c => c.String());
            AddColumn("dbo.Companies", "Address_StreetAddress", c => c.String());
            AddColumn("dbo.Companies", "Address_ZipCode", c => c.String());
            AlterColumn("dbo.Companies", "Company_Number", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Companies", "Company_Number", c => c.Int(nullable: false));
            DropColumn("dbo.Companies", "Address_ZipCode");
            DropColumn("dbo.Companies", "Address_StreetAddress");
            DropColumn("dbo.Companies", "Address_City");
        }
    }
}
