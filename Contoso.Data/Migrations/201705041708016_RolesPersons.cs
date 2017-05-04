namespace Contoso.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RolesPersons : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false),
                        Description = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonRoles",
                c => new
                    {
                        Person_Id = c.Int(nullable: false),
                        Role_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Person_Id, t.Role_Id })
                .ForeignKey("dbo.People", t => t.Person_Id, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.Role_Id, cascadeDelete: true)
                .Index(t => t.Person_Id)
                .Index(t => t.Role_Id);
            
            AlterColumn("dbo.People", "Email", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.People", "Password", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonRoles", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.PersonRoles", "Person_Id", "dbo.People");
            DropIndex("dbo.PersonRoles", new[] { "Role_Id" });
            DropIndex("dbo.PersonRoles", new[] { "Person_Id" });
            AlterColumn("dbo.People", "Password", c => c.String(maxLength: 20));
            AlterColumn("dbo.People", "Email", c => c.String(maxLength: 150));
            DropTable("dbo.PersonRoles");
            DropTable("dbo.Roles");
        }
    }
}
