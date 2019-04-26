namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtablerole : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        Detail = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.users", "RoleID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.users", "RoleID");
            DropTable("dbo.Role");
        }
    }
}
