namespace Semec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DealersModel2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DealersModels", "Company", c => c.String(nullable: false));
            AlterColumn("dbo.DealersModels", "CP1", c => c.String(nullable: false));
            AlterColumn("dbo.DealersModels", "MobileCP1", c => c.String(nullable: false));
            AlterColumn("dbo.DealersModels", "EmailCP1", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DealersModels", "EmailCP1", c => c.String());
            AlterColumn("dbo.DealersModels", "MobileCP1", c => c.String());
            AlterColumn("dbo.DealersModels", "CP1", c => c.String());
            AlterColumn("dbo.DealersModels", "Company", c => c.String());
        }
    }
}
