namespace VidlyNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveNumberAvailColumn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "NumberAvailbility");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "NumberAvailbility", c => c.Byte(nullable: false));
        }
    }
}
