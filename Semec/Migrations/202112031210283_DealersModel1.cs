namespace Semec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DealersModel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DealersModels", "DealIn", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DealersModels", "DealIn");
        }
    }
}
