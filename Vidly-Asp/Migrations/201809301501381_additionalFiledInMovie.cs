namespace Vidly_Asp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class additionalFiledInMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "MyProperty", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "NumberInStock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NumberInStock");
            DropColumn("dbo.Movies", "DateAdded");
            DropColumn("dbo.Movies", "ReleaseDate");
            DropColumn("dbo.Customers", "MyProperty");
        }
    }
}
