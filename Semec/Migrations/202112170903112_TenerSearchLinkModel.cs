namespace Semec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TenerSearchLinkModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TenderSearchLinkModels", "TenderSearchWebsite", c => c.String(nullable: false));
            AddColumn("dbo.TenderSearchLinkModels", "Remark", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TenderSearchLinkModels", "Remark");
            DropColumn("dbo.TenderSearchLinkModels", "TenderSearchWebsite");
        }
    }
}
