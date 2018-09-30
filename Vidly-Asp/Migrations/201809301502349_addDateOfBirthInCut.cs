namespace Vidly_Asp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDateOfBirthInCut : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "DateOfBirth", c => c.DateTime(nullable: false));
            DropColumn("dbo.Customers", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "MyProperty", c => c.DateTime(nullable: false));
            DropColumn("dbo.Customers", "DateOfBirth");
        }
    }
}
