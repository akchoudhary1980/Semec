namespace Semec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TenderSearchModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TenderSearchLinkModels", "DepartmentID", c => c.Int(nullable: false));
            DropColumn("dbo.TenderSearchLinkModels", "DepartmentName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TenderSearchLinkModels", "DepartmentName", c => c.String(nullable: false));
            DropColumn("dbo.TenderSearchLinkModels", "DepartmentID");
        }
    }
}
