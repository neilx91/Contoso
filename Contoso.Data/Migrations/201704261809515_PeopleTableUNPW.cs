namespace Contoso.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PeopleTableUNPW : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Password", c => c.String(maxLength: 20));
            AddColumn("dbo.People", "Salt", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "Salt");
            DropColumn("dbo.People", "Password");
        }
    }
}
