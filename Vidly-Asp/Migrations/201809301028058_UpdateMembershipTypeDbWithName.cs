namespace Vidly_Asp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipTypeDbWithName : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'Pay as you go' WHERE DurationInMonth = 0; ");
            Sql("UPDATE MembershipTypes SET Name = 'Monthly' WHERE DurationInMonth = 1; ");
            Sql("UPDATE MembershipTypes SET Name = 'Quarterly' WHERE DurationInMonth = 3; ");
            Sql("UPDATE MembershipTypes SET Name = 'Annual' WHERE DurationInMonth = 12; ");
        }
        
        public override void Down()
        {
        }
    }
}
