namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sua_isale_default_valuegjhjh : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.products", "isSale", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.products", "isSale", c => c.Boolean());
        }
    }
}
