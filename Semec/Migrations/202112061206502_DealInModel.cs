namespace Semec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DealInModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DealInModels", "ItemName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DealInModels", "ItemName");
        }
    }
}
