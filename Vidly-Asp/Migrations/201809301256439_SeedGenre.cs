namespace Vidly_Asp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedGenre : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Genres (Id, Name) values (1, 'Comedy')");
            Sql("Insert into Genres (Id, Name) values (3, 'Drama')");
            Sql("Insert into Genres (Id, Name) values (4, 'Adventure')");
            Sql("Insert into Genres (Id, Name) values (2,'Action')");
        }
        
        public override void Down()
        {
        }
    }
}
