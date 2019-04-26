namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateproduct : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.products", "name", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.products", "name", c => c.String(maxLength: 1));
        }
    }
}
