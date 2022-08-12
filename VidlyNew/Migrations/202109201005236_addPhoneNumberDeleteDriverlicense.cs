namespace VidlyNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPhoneNumberDeleteDriverlicense : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "phoneNumberCus", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.AspNetUsers", "DrivingLicense");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "DrivingLicense", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.AspNetUsers", "phoneNumberCus");
        }
    }
}
