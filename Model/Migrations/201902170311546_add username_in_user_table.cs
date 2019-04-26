namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addusername_in_user_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.bill_detail",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        id_bill = c.Int(),
                        id_product = c.Int(),
                        quantity = c.Int(),
                        unit_price = c.Single(),
                        created_at = c.DateTime(),
                        updated_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.bills",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        id_customer = c.Long(),
                        date_order = c.DateTime(),
                        total = c.Single(),
                        note = c.String(maxLength: 500),
                        created_at = c.DateTime(),
                        updated_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.customer",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        name = c.String(maxLength: 100),
                        gender = c.Boolean(),
                        email = c.String(maxLength: 50),
                        address = c.String(maxLength: 100),
                        phone_number = c.String(maxLength: 20, fixedLength: true, unicode: false),
                        created_at = c.DateTime(),
                        updated_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.news",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        title = c.String(maxLength: 200),
                        content = c.String(unicode: false, storeType: "text"),
                        image = c.String(maxLength: 100),
                        create_at = c.DateTime(),
                        update_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.products",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        name = c.String(maxLength: 1),
                        id_type = c.Int(),
                        description = c.String(unicode: false, storeType: "text"),
                        unit_price = c.Single(),
                        promotion_price = c.Double(),
                        image = c.String(maxLength: 255, fixedLength: true, unicode: false),
                        isSale = c.Boolean(),
                        viewCount = c.Long(),
                        created_at = c.DateTime(),
                        updated_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.slide",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        link = c.String(maxLength: 100),
                        image = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.type_products",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        name = c.String(maxLength: 100),
                        description = c.String(unicode: false, storeType: "text"),
                        image = c.String(maxLength: 255),
                        created_at = c.DateTime(),
                        updated_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.users",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        username = c.String(maxLength: 255),
                        full_name = c.String(maxLength: 255),
                        email = c.String(maxLength: 255),
                        password = c.String(maxLength: 255),
                        created_at = c.DateTime(),
                        updated_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.users");
            DropTable("dbo.type_products");
            DropTable("dbo.slide");
            DropTable("dbo.products");
            DropTable("dbo.news");
            DropTable("dbo.customer");
            DropTable("dbo.bills");
            DropTable("dbo.bill_detail");
        }
    }
}
