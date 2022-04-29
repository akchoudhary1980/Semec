namespace Semec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DealersModel3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DealersModels", "CP4", c => c.String());
            AddColumn("dbo.DealersModels", "CP5", c => c.String());
            AddColumn("dbo.DealersModels", "MobileCP4", c => c.String());
            AddColumn("dbo.DealersModels", "MobileCP5", c => c.String());
            AddColumn("dbo.DealersModels", "EmailC4", c => c.String());
            AddColumn("dbo.DealersModels", "EmailCP5", c => c.String());
            AddColumn("dbo.DealersModels", "DesginationID1", c => c.Int(nullable: false));
            AddColumn("dbo.DealersModels", "DesginationID2", c => c.Int(nullable: false));
            AddColumn("dbo.DealersModels", "DesginationID3", c => c.Int(nullable: false));
            AddColumn("dbo.DealersModels", "DesginationID4", c => c.Int(nullable: false));
            AddColumn("dbo.DealersModels", "DesginationID5", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DealersModels", "DesginationID5");
            DropColumn("dbo.DealersModels", "DesginationID4");
            DropColumn("dbo.DealersModels", "DesginationID3");
            DropColumn("dbo.DealersModels", "DesginationID2");
            DropColumn("dbo.DealersModels", "DesginationID1");
            DropColumn("dbo.DealersModels", "EmailCP5");
            DropColumn("dbo.DealersModels", "EmailC4");
            DropColumn("dbo.DealersModels", "MobileCP5");
            DropColumn("dbo.DealersModels", "MobileCP4");
            DropColumn("dbo.DealersModels", "CP5");
            DropColumn("dbo.DealersModels", "CP4");
        }
    }
}
