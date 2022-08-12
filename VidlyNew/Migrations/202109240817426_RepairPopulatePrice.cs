namespace VidlyNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RepairPopulatePrice : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Movies SET RentalPrice= 10000 WHERE Id = 26");
            Sql("UPDATE Movies SET RentalPrice= 20000 WHERE Id = 30");
            Sql("UPDATE Movies SET RentalPrice= 15000 WHERE Id = 34");
            Sql("UPDATE Movies SET RentalPrice= 7000 WHERE Id = 36");
            Sql("UPDATE Movies SET RentalPrice= 9000 WHERE Id = 37");
            Sql("UPDATE Movies SET RentalPrice= 6000 WHERE Id = 40");
        }
        
        public override void Down()
        {
        }
    }
}
