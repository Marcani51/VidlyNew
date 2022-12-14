namespace VidlyNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNumberAvailbilityInMovieDomain : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NumberAvailbility", c => c.Byte(nullable: false));
            Sql("UPDATE Movies SET NumberAvailbility = NumberInStock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NumberAvailbility");
        }
    }
}
