namespace VidlyNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddandPopulateRentalPriceColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "RentalPrice", c => c.Int(nullable: false));
           
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "RentalPrice");
        }
    }
}
