namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovieDates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false, defaultValueSql: "01/01/1970"));
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false, defaultValueSql: "GetDate()"));
            AddColumn("dbo.Movies", "NumberInStock", c => c.Byte(nullable: false, defaultValueSql: "0"));
        }

        public override void Down()
        {
            DropColumn("dbo.Movies", "NumberInStock");
            DropColumn("dbo.Movies", "DateAdded");
            DropColumn("dbo.Movies", "ReleaseDate");
        }
    }
}
