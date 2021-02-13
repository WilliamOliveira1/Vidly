namespace Vidly1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovies1 : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Customers (Name,Birthday,IsSubscribedToNewsLetter, MenbershipTypeId, MembershipType_Id) values ('William Oliveira', '1986-03-05', 1, 1,1)");
            Sql("insert into Customers (Name,Birthday,IsSubscribedToNewsLetter, MenbershipTypeId, MembershipType_Id) values ('Jaqueline Latance', '1987-10-17', 1, 2,2)");
            Sql("insert into Customers (Name,Birthday,IsSubscribedToNewsLetter, MenbershipTypeId, MembershipType_Id) values ('Giovana Oliveira', '2011-10-27', 0, 3,3)");
            Sql("insert into Customers (Name,Birthday,IsSubscribedToNewsLetter, MenbershipTypeId, MembershipType_Id) values ('Gabriela Oliveira', '2017-12-23', 0, 4,3)");
        }
        
        public override void Down()
        {
        }
    }
}
