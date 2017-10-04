namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedMembershipName : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes SET Name = 'Pay As You Go' WHERE DurationInMonths = 0");
            Sql("Update MembershipTypes SET Name = 'Monthly' WHERE DurationInMonths = 1");
            Sql("Update MembershipTypes SET Name = 'Quarterly' WHERE DurationInMonths = 3");
            Sql("Update MembershipTypes SET Name = 'Annually' WHERE DurationInMonths = 12");
        }

        public override void Down()
        {
        }
    }
}
