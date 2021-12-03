namespace Semec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DealersModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DealersModels", "Company", c => c.String());
            AlterColumn("dbo.DealersModels", "Logo", c => c.String());
            AlterColumn("dbo.DealersModels", "Brand", c => c.String());
            AlterColumn("dbo.DealersModels", "State", c => c.String());
            AlterColumn("dbo.DealersModels", "City", c => c.String());
            AlterColumn("dbo.DealersModels", "Address", c => c.String());
            AlterColumn("dbo.DealersModels", "CP1", c => c.String());
            AlterColumn("dbo.DealersModels", "CP2", c => c.String());
            AlterColumn("dbo.DealersModels", "CP3", c => c.String());
            AlterColumn("dbo.DealersModels", "MobileCP1", c => c.String());
            AlterColumn("dbo.DealersModels", "MobileCP2", c => c.String());
            AlterColumn("dbo.DealersModels", "MobileCP3", c => c.String());
            AlterColumn("dbo.DealersModels", "EmailCP1", c => c.String());
            AlterColumn("dbo.DealersModels", "EmailCP2", c => c.String());
            AlterColumn("dbo.DealersModels", "EmailCP3", c => c.String());
            AlterColumn("dbo.DealersModels", "Website", c => c.String());
            AlterColumn("dbo.DealersModels", "Cataloge", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DealersModels", "Cataloge", c => c.Int(nullable: false));
            AlterColumn("dbo.DealersModels", "Website", c => c.Int(nullable: false));
            AlterColumn("dbo.DealersModels", "EmailCP3", c => c.Int(nullable: false));
            AlterColumn("dbo.DealersModels", "EmailCP2", c => c.Int(nullable: false));
            AlterColumn("dbo.DealersModels", "EmailCP1", c => c.Int(nullable: false));
            AlterColumn("dbo.DealersModels", "MobileCP3", c => c.Int(nullable: false));
            AlterColumn("dbo.DealersModels", "MobileCP2", c => c.Int(nullable: false));
            AlterColumn("dbo.DealersModels", "MobileCP1", c => c.Int(nullable: false));
            AlterColumn("dbo.DealersModels", "CP3", c => c.Int(nullable: false));
            AlterColumn("dbo.DealersModels", "CP2", c => c.Int(nullable: false));
            AlterColumn("dbo.DealersModels", "CP1", c => c.Int(nullable: false));
            AlterColumn("dbo.DealersModels", "Address", c => c.Int(nullable: false));
            AlterColumn("dbo.DealersModels", "City", c => c.Int(nullable: false));
            AlterColumn("dbo.DealersModels", "State", c => c.Int(nullable: false));
            AlterColumn("dbo.DealersModels", "Brand", c => c.Int(nullable: false));
            AlterColumn("dbo.DealersModels", "Logo", c => c.Int(nullable: false));
            AlterColumn("dbo.DealersModels", "Company", c => c.Int(nullable: false));
        }
    }
}
