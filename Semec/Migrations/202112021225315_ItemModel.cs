namespace Semec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemModels",
                c => new
                    {
                        ItemID = c.Int(nullable: false),
                        ItemName = c.String(),
                    })
                .PrimaryKey(t => t.ItemID);
            
            AddColumn("dbo.DealInModels", "ItemID", c => c.Int(nullable: false));
            DropColumn("dbo.DealInModels", "Product");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DealInModels", "Product", c => c.Int(nullable: false));
            DropColumn("dbo.DealInModels", "ItemID");
            DropTable("dbo.ItemModels");
        }
    }
}
