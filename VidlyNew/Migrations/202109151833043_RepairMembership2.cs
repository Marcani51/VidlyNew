namespace VidlyNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RepairMembership2 : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM MembershipTypes WHERE Id = 0");
        }
        
        public override void Down()
        {
        }
    }
}
