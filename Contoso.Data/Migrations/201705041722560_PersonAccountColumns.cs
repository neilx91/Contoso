namespace Contoso.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonAccountColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "IsLocked", c => c.Boolean(nullable: false));
            AddColumn("dbo.People", "LastLockedDateTime", c => c.DateTime());
            AddColumn("dbo.People", "FailedAttempts", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "FailedAttempts");
            DropColumn("dbo.People", "LastLockedDateTime");
            DropColumn("dbo.People", "IsLocked");
        }
    }
}
