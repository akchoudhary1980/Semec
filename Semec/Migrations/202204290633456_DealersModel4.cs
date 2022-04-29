namespace Semec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DealersModel4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DealersModels", "EmailCP4", c => c.String());
            DropColumn("dbo.DealersModels", "EmailC4");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DealersModels", "EmailC4", c => c.String());
            DropColumn("dbo.DealersModels", "EmailCP4");
        }
    }
}
