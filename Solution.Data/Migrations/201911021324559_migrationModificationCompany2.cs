namespace Solution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrationModificationCompany2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Companies", "NumberOfEmployees", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Companies", "NumberOfEmployees", c => c.Int(nullable: false));
        }
    }
}
