namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedMovieGenre : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into Genres (Id, Name) Values (1, 'Action')");
            Sql("Insert Into Genres (Id, Name) Values (2, 'Comedy')");
            Sql("Insert Into Genres (Id, Name) Values (3, 'Drama')");
            Sql("Insert Into Genres (Id, Name) Values (4, 'Family')");
            Sql("Insert Into Genres (Id, Name) Values (5, 'Fantasy')");
            Sql("Insert Into Genres (Id, Name) Values (6, 'Horror')");
            Sql("Insert Into Genres (Id, Name) Values (7, 'Romance')");
            Sql("Insert Into Genres (Id, Name) Values (8, 'Sci-Fi')");
        }

        public override void Down()
        {
        }
    }
}
