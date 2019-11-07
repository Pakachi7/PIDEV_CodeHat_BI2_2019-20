﻿namespace Solution.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrationModificationOffer2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "Company_Address", c => c.String());
            AlterColumn("dbo.Offers", "Offer_Level_Of_Expertise", c => c.Int(nullable: false));
            DropColumn("dbo.Companies", "Address_City");
            DropColumn("dbo.Companies", "Address_StreetAddress");
            DropColumn("dbo.Companies", "Address_ZipCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Companies", "Address_ZipCode", c => c.String());
            AddColumn("dbo.Companies", "Address_StreetAddress", c => c.String());
            AddColumn("dbo.Companies", "Address_City", c => c.String());
            AlterColumn("dbo.Offers", "Offer_Level_Of_Expertise", c => c.String());
            DropColumn("dbo.Companies", "Company_Address");
        }
    }
}
