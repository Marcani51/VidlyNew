namespace VidlyNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRentalPriceOnRentalDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rentals", "RentalPrice", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rentals", "RentalPrice");
        }
    }
}
