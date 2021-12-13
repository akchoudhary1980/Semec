namespace Semec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UnitModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DepartmentCategoryModels",
                c => new
                    {
                        DepartmentCategoryID = c.Int(nullable: false),
                        DepartmentCategoryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentCategoryID);
            
            CreateTable(
                "dbo.DepartmentModels",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false),
                        DepartmentName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
            CreateTable(
                "dbo.TenderSearchLinkModels",
                c => new
                    {
                        TenderSearchLinkID = c.Int(nullable: false),
                        DepartmentName = c.String(nullable: false),
                        DepartmentCategoryID = c.Int(nullable: false),
                        TenderSearchLink = c.String(nullable: false),
                        Address = c.String(),
                        State = c.String(),
                        City = c.String(),
                        Logo = c.String(),
                    })
                .PrimaryKey(t => t.TenderSearchLinkID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TenderSearchLinkModels");
            DropTable("dbo.DepartmentModels");
            DropTable("dbo.DepartmentCategoryModels");
        }
    }
}
