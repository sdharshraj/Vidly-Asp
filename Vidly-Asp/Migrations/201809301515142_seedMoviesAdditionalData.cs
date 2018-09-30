namespace Vidly_Asp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedMoviesAdditionalData : DbMigration
    {
        public override void Up()
        {
            Sql("Delete from Movies");

            Sql("Insert into Movies ( Name, GenreId, ReleaseDate, DateAdded, NumberInStock) values ( 'Avenger', 2, '03/24/2016', '04/25/2016',5)");
            Sql("Insert into Movies ( Name, GenreId, ReleaseDate, DateAdded, NumberInStock) values ( 'IronMan', 1, '05/14/2016', '07/21/2016',3)");
            Sql("Insert into Movies ( Name, GenreId, ReleaseDate, DateAdded, NumberInStock) values ( 'DDLJ', 3, '06/22/2016', '02/19/2016',8)");
            Sql("Insert into Movies ( Name, GenreId, ReleaseDate, DateAdded, NumberInStock) values ( 'Batman', 4, '08/29/2016', '03/25/2016',9)");
        }      
        public override void Down()
        {

        }
    }
}
