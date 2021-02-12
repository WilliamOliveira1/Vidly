namespace Vidly1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateBrithday : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthday = '05/03/1986' WHERE Id = 1");
        }
        
        public override void Down()
        {
        }
    }
}
