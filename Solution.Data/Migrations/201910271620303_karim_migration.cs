namespace Solution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class karim_migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Availabilities", "Availability_Date_Begin", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Availabilities", "Availability_Date_End", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            DropColumn("dbo.Availabilities", "Availability_Date");
            DropColumn("dbo.Availabilities", "Quiz_Result_Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Availabilities", "Quiz_Result_Status", c => c.String());
            AddColumn("dbo.Availabilities", "Availability_Date", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            DropColumn("dbo.Availabilities", "Availability_Date_End");
            DropColumn("dbo.Availabilities", "Availability_Date_Begin");
        }
    }
}
