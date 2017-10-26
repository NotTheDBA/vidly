namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedTables : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate, Name) Values (1, 0, 0, 0,'Pay As You Go')");
            Sql("Insert Into MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate, Name) Values (2, 30, 1, 10,'Monthly')");
            Sql("Insert Into MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate, Name) Values (3, 90, 3, 15,'Quarterly')");
            Sql("Insert Into MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate, Name) Values (4, 300, 12, 20,'Annually')");


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
            Sql("DELETE FROM MembershipTypes WHERE Id = 1");
            Sql("DELETE FROM MembershipTypes WHERE Id = 2");
            Sql("DELETE FROM MembershipTypes WHERE Id = 3");
            Sql("DELETE FROM MembershipTypes WHERE Id = 4");

            Sql("DELETE FROM Genres WHERE Id = 1");
            Sql("DELETE FROM Genres WHERE Id = 2");
            Sql("DELETE FROM Genres WHERE Id = 3");
            Sql("DELETE FROM Genres WHERE Id = 4");
            Sql("DELETE FROM Genres WHERE Id = 5");
            Sql("DELETE FROM Genres WHERE Id = 6");
            Sql("DELETE FROM Genres WHERE Id = 7");
            Sql("DELETE FROM Genres WHERE Id = 8");
        }
    }
}
