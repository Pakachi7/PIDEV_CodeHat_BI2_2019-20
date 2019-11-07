namespace Solution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConnectionString_Presentation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Companies", "NumberOfEmployees", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Companies", "NumberOfEmployees", c => c.Int(nullable: false));
        }
    }
}
