namespace Vidly1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovies : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Movies (Name,GenreId,DateAdded, ReleaseDate,NumberInStock) values ('Matrix', 6,'2021-02-12','1999-03-31', 1)");
            Sql("insert into Movies (Name,GenreId,DateAdded, ReleaseDate,NumberInStock) values ('Interstellar', 6,'2021-02-12','2014-11-06', 2)");
            Sql("insert into Movies (Name,GenreId,DateAdded, ReleaseDate,NumberInStock) values ('Donnie Darko', 6,'2021-02-12','2001-10-26', 3)");
            Sql("insert into Movies (Name,GenreId,DateAdded, ReleaseDate,NumberInStock) values ('Mr. Nobody', 6,'2021-02-12','2010-06-16', 4)");
            Sql("insert into Movies (Name,GenreId,DateAdded, ReleaseDate,NumberInStock) values ('The Butterfly Effect', 6,'2021-02-12','2004-01-23', 5)");
            Sql("insert into Movies (Name,GenreId,DateAdded, ReleaseDate,NumberInStock) values ('Shrek', 5,'2021-02-12','2001-05-18', 6)");
        }
        
        public override void Down()
        {
        }
    }
}
