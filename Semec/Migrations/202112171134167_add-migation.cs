namespace Semec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BrowserModels",
                c => new
                    {
                        BrowserID = c.Int(nullable: false),
                        BrowserName = c.String(nullable: false),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.BrowserID);
            
            CreateTable(
                "dbo.DigitalSignatureModels",
                c => new
                    {
                        DigitalSignatureID = c.Int(nullable: false),
                        DigitalSignatureName = c.String(nullable: false),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.DigitalSignatureID);
            
            CreateTable(
                "dbo.TenderQuoteLinkModels",
                c => new
                    {
                        TenderQuoteLinkID = c.Int(nullable: false),
                        DepartmentID = c.Int(nullable: false),
                        DepartmentCategoryID = c.Int(nullable: false),
                        TenderQuoteWebsite = c.String(nullable: false),
                        TenderQuoteLink = c.String(nullable: false),
                        Remark = c.String(),
                        Address = c.String(),
                        State = c.String(),
                        City = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        DSCName = c.String(),
                        DSCPassword = c.String(),
                        BrowserName = c.String(),
                        Logo = c.String(),
                    })
                .PrimaryKey(t => t.TenderQuoteLinkID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TenderQuoteLinkModels");
            DropTable("dbo.DigitalSignatureModels");
            DropTable("dbo.BrowserModels");
        }
    }
}
