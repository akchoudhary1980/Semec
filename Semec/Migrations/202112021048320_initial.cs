namespace Semec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankModels",
                c => new
                    {
                        BankID = c.Int(nullable: false),
                        BankName = c.Int(nullable: false),
                        Branch = c.Int(nullable: false),
                        IFSCCode = c.Int(nullable: false),
                        CityName = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BankID);
            
            CreateTable(
                "dbo.BinModels",
                c => new
                    {
                        BinID = c.Int(nullable: false),
                        BinName = c.String(nullable: false),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.BinID);
            
            CreateTable(
                "dbo.BrandModels",
                c => new
                    {
                        BrandID = c.Int(nullable: false),
                        BrandName = c.String(nullable: false),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.BrandID);
            
            CreateTable(
                "dbo.CategoryModels",
                c => new
                    {
                        CategoryID = c.Int(nullable: false),
                        CategoryName = c.String(nullable: false),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.CautionModels",
                c => new
                    {
                        CautionID = c.Int(nullable: false),
                        CautionMessage = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CautionID);
            
            CreateTable(
                "dbo.CityModels",
                c => new
                    {
                        CityID = c.Int(nullable: false),
                        CityName = c.String(nullable: false),
                        StateID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CityID);
            
            CreateTable(
                "dbo.ColorModels",
                c => new
                    {
                        ColorID = c.Int(nullable: false),
                        ColorName = c.String(nullable: false),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.ColorID);
            
            CreateTable(
                "dbo.CompanyModels",
                c => new
                    {
                        CompanyID = c.Int(nullable: false),
                        CompanyName = c.String(nullable: false),
                        CompanyAddress = c.String(),
                        CompanyCity = c.String(),
                        CompanyState = c.String(),
                        OnwerName = c.String(),
                        ContactPerson = c.String(),
                        CompanyMobile = c.String(),
                        CompanyWhatsup = c.String(),
                        CompanyEmail = c.String(),
                        DateofRegistration = c.DateTime(),
                        GST = c.String(),
                        InvoicePrefix = c.String(),
                        InvoiceNumber = c.Int(nullable: false),
                        QuotationNumber = c.Int(nullable: false),
                        PurchaseNumber = c.Int(nullable: false),
                        CompanyPicture = c.String(),
                        SealPicture = c.String(),
                        BeneficiaryName = c.String(),
                        BankName = c.String(),
                        BranchName = c.String(),
                        AccountNumber = c.String(),
                        AccountType = c.String(),
                        AccountIFSCCode = c.String(),
                        AccountMICRCode = c.String(),
                    })
                .PrimaryKey(t => t.CompanyID);
            
            CreateTable(
                "dbo.ContactModels",
                c => new
                    {
                        EnquiryID = c.Int(nullable: false),
                        CustomerName = c.String(nullable: false),
                        Mobile = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        State = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Address = c.String(),
                        Message = c.String(nullable: false),
                        MessageDate = c.DateTime(),
                        IsRead = c.Boolean(nullable: false),
                        EnquiryStatus = c.String(),
                    })
                .PrimaryKey(t => t.EnquiryID);
            
            CreateTable(
                "dbo.CountryModels",
                c => new
                    {
                        CountryID = c.Int(nullable: false),
                        CountryName = c.String(nullable: false),
                        Region = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CountryID);
            
            CreateTable(
                "dbo.CustomerModels",
                c => new
                    {
                        CustomerID = c.Int(nullable: false),
                        CustomerName = c.String(nullable: false),
                        CustomerType = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        Mobile = c.String(nullable: false, maxLength: 10),
                        Whatsup = c.String(maxLength: 10),
                        Birthday = c.DateTime(),
                        Anniversary = c.DateTime(),
                        Email = c.String(),
                        ProfessionID = c.Int(nullable: false),
                        GSTNo = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.CustomerPaymentModels",
                c => new
                    {
                        PaymentID = c.Int(nullable: false),
                        PaymentType = c.String(),
                        PaymentMode = c.String(),
                        TransactionDate = c.DateTime(),
                        Amount = c.Double(nullable: false),
                        Remark = c.String(),
                        PaymentMethod = c.String(),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentID);
            
            CreateTable(
                "dbo.DealersModels",
                c => new
                    {
                        DealersID = c.Int(nullable: false),
                        Company = c.Int(nullable: false),
                        Logo = c.Int(nullable: false),
                        Brand = c.Int(nullable: false),
                        State = c.Int(nullable: false),
                        City = c.Int(nullable: false),
                        Address = c.Int(nullable: false),
                        CP1 = c.Int(nullable: false),
                        CP2 = c.Int(nullable: false),
                        CP3 = c.Int(nullable: false),
                        MobileCP1 = c.Int(nullable: false),
                        MobileCP2 = c.Int(nullable: false),
                        MobileCP3 = c.Int(nullable: false),
                        EmailCP1 = c.Int(nullable: false),
                        EmailCP2 = c.Int(nullable: false),
                        EmailCP3 = c.Int(nullable: false),
                        Website = c.Int(nullable: false),
                        Cataloge = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DealersID);
            
            CreateTable(
                "dbo.DealInModels",
                c => new
                    {
                        DealInID = c.Int(nullable: false),
                        Product = c.Int(nullable: false),
                        DealersID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DealInID);
            
            CreateTable(
                "dbo.DesginationModels",
                c => new
                    {
                        DesginationID = c.Int(nullable: false),
                        DesginationName = c.String(nullable: false),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.DesginationID);
            
            CreateTable(
                "dbo.EmailSetupModels",
                c => new
                    {
                        EmailSetupID = c.Int(nullable: false),
                        EmailProvider = c.String(),
                        SmtpHost = c.String(),
                        SmtpPort = c.String(),
                        EmailFrom = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.EmailSetupID);
            
            CreateTable(
                "dbo.EmailTempleteModels",
                c => new
                    {
                        EmailTempleteID = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Heading = c.String(nullable: false),
                        Message = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EmailTempleteID);
            
            CreateTable(
                "dbo.EmailTransModels",
                c => new
                    {
                        EmailTransID = c.Int(nullable: false),
                        EmailDate = c.DateTime(nullable: false),
                        EmailTime = c.Time(nullable: false, precision: 7),
                        CustomerID = c.Int(nullable: false),
                        EmailTo = c.String(),
                        EmailTitle = c.String(),
                        EmailMessage = c.String(),
                        AttachedFile = c.String(),
                        Device = c.String(),
                        Browser = c.String(),
                        DeviceIP = c.String(),
                        PropertyType = c.String(),
                        PropertyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmailTransID);
            
            CreateTable(
                "dbo.EMDCancelModels",
                c => new
                    {
                        EMDCancelID = c.Int(nullable: false),
                        CancelDate = c.DateTime(),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.EMDCancelID);
            
            CreateTable(
                "dbo.EMDCreatModels",
                c => new
                    {
                        EmdCreateID = c.Int(nullable: false),
                        EMDDocumentsTypeID = c.Int(nullable: false),
                        CreateDate = c.DateTime(),
                        IsRefundable = c.Boolean(nullable: false),
                        BankID = c.Int(nullable: false),
                        OrganisationID = c.Int(nullable: false),
                        EmdFor = c.String(),
                        DocumentNo = c.String(),
                        EmdAmount = c.Double(nullable: false),
                        EmdCharges = c.Double(nullable: false),
                        DocumentStatus = c.String(),
                        SoftCopy = c.String(),
                        XeroxLocation = c.String(),
                        FromDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.EmdCreateID);
            
            CreateTable(
                "dbo.EMDDocumentsTypeModels",
                c => new
                    {
                        EMDDocumentsTypeID = c.Int(nullable: false),
                        DocumentsType = c.Int(nullable: false),
                        Remark = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EMDDocumentsTypeID);
            
            CreateTable(
                "dbo.EMDExtendedModels",
                c => new
                    {
                        EMDExtendedID = c.Int(nullable: false),
                        ExtendedDate = c.DateTime(),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.EMDExtendedID);
            
            CreateTable(
                "dbo.EMDIssueModels",
                c => new
                    {
                        EMDIssueID = c.Int(nullable: false),
                        IssueDate = c.DateTime(),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.EMDIssueID);
            
            CreateTable(
                "dbo.EMDReceiptModels",
                c => new
                    {
                        EMDReceiptID = c.Int(nullable: false),
                        ReceiptDate = c.DateTime(),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.EMDReceiptID);
            
            CreateTable(
                "dbo.EmployeeModels",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false),
                        EmployeeName = c.String(nullable: false),
                        NicName = c.String(),
                        Gender = c.String(nullable: false),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Mobile = c.String(nullable: false, maxLength: 10),
                        Whatup = c.String(maxLength: 10),
                        Email = c.String(nullable: false),
                        DateofBirth = c.DateTime(),
                        DateofJoining = c.DateTime(),
                        Salary = c.Double(nullable: false),
                        Qualification = c.String(),
                        Picture = c.String(),
                        DesignationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeID);
            
            CreateTable(
                "dbo.EmployeePaymentModels",
                c => new
                    {
                        PaymentID = c.Int(nullable: false),
                        PaymentType = c.String(),
                        PaymentMode = c.String(),
                        TransactionDate = c.DateTime(),
                        Amount = c.Double(nullable: false),
                        Remark = c.String(),
                        PaymentMethod = c.String(),
                        EmployeeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentID);
            
            CreateTable(
                "dbo.GodownModels",
                c => new
                    {
                        GodownID = c.Int(nullable: false),
                        GodownName = c.String(nullable: false),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.GodownID);
            
            CreateTable(
                "dbo.GroupModels",
                c => new
                    {
                        GroupID = c.Int(nullable: false),
                        GroupName = c.String(nullable: false),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.GroupID);
            
            CreateTable(
                "dbo.GSTSlabModels",
                c => new
                    {
                        GSTSlabID = c.Int(nullable: false),
                        GSTSlabName = c.String(nullable: false),
                        PercentValue = c.Double(nullable: false),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.GSTSlabID);
            
            CreateTable(
                "dbo.MaterialCenterModels",
                c => new
                    {
                        MaterialCenterID = c.Int(nullable: false),
                        MaterialCenterName = c.String(nullable: false),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.MaterialCenterID);
            
            CreateTable(
                "dbo.OnlineCustomerModels",
                c => new
                    {
                        CustomerID = c.Int(nullable: false),
                        CustomerName = c.String(nullable: false),
                        Address = c.String(),
                        AddressType = c.String(),
                        DeliveryTime = c.String(),
                        Area = c.String(),
                        Pin = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        Mobile = c.String(nullable: false, maxLength: 10),
                        AlternetMobile = c.String(maxLength: 10),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Birthday = c.DateTime(),
                        Unniversary = c.DateTime(),
                        ProfessionID = c.Int(nullable: false),
                        ProfileComplete = c.Double(nullable: false),
                        ProfilePicture = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.OnlinePaymentModels",
                c => new
                    {
                        PaymentID = c.Int(nullable: false),
                        PaymentMode = c.String(),
                        RecieptDate = c.DateTime(nullable: false),
                        Amount = c.Double(nullable: false),
                        yPaymentGetwayName = c.String(),
                        GetwayPaymentID = c.String(),
                        PaymentStatus = c.String(),
                        OrderID = c.String(),
                        TransactionID = c.String(),
                        CustomerID = c.Int(nullable: false),
                        SaleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentID);
            
            CreateTable(
                "dbo.OnlineProductArrangeModels",
                c => new
                    {
                        ProductArrangeID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        OrderNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductArrangeID);
            
            CreateTable(
                "dbo.OnlineProductModels",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        ProductCode = c.String(nullable: false),
                        HSNCode = c.String(),
                        ProductName = c.String(nullable: false),
                        ShortDescription = c.String(),
                        FullDescription = c.String(),
                        BrandID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        UnitID = c.Int(nullable: false),
                        GSTSlabID = c.Int(nullable: false),
                        GSTInclusive = c.Boolean(nullable: false),
                        MRP = c.Double(nullable: false),
                        Rate = c.Double(nullable: false),
                        Price = c.Double(nullable: false),
                        DeliveryCharge = c.Double(nullable: false),
                        DisplayOn = c.String(),
                        StockQty = c.Double(nullable: false),
                        AlertStockQty = c.Double(nullable: false),
                        IsNew = c.Boolean(nullable: false),
                        IsSeal = c.Boolean(nullable: false),
                        View = c.Int(nullable: false),
                        Like = c.Int(nullable: false),
                        DisLike = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        Picture = c.String(),
                        Picture1 = c.String(),
                        Picture2 = c.String(),
                        Picture3 = c.String(),
                        Picture4 = c.String(),
                    })
                .PrimaryKey(t => t.ProductID);
            
            CreateTable(
                "dbo.OnlineProductPackingModels",
                c => new
                    {
                        ProductPackingID = c.Int(nullable: false),
                        ProductSize = c.String(),
                        UnitID = c.Int(nullable: false),
                        GSTSlabID = c.Int(nullable: false),
                        GSTInclusive = c.Boolean(nullable: false),
                        MRP = c.Double(nullable: false),
                        Rate = c.Double(nullable: false),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductPackingID);
            
            CreateTable(
                "dbo.OnlineSalesModels",
                c => new
                    {
                        SalesID = c.Int(nullable: false),
                        SerialNo = c.String(),
                        OrderNo = c.String(),
                        SalesDate = c.DateTime(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        SaleValue = c.Double(nullable: false),
                        DeliveryValue = c.Double(nullable: false),
                        SaleGST = c.Double(nullable: false),
                        SaleTotal = c.Double(nullable: false),
                        SaleMode = c.String(),
                        PaymentStatus = c.String(),
                        DeliveryStatus = c.String(),
                        SaleState = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SalesID);
            
            CreateTable(
                "dbo.OnlineSalesTransModels",
                c => new
                    {
                        SalesTransID = c.Int(nullable: false),
                        ProductSerNo = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Double(nullable: false),
                        UnitID = c.Int(nullable: false),
                        Rate = c.Double(nullable: false),
                        Amount = c.Double(nullable: false),
                        GSTSlab = c.Double(nullable: false),
                        GSTAmount = c.Double(nullable: false),
                        DeliveryCharge = c.Double(nullable: false),
                        SalesID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SalesTransID);
            
            CreateTable(
                "dbo.OrganisationModels",
                c => new
                    {
                        OrganisationID = c.Int(nullable: false),
                        OrganisationName = c.String(nullable: false),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        GSTNo = c.String(),
                        Website = c.String(),
                        ContactPerson = c.String(nullable: false),
                        Mobile = c.String(nullable: false, maxLength: 10),
                        Whatsup = c.String(maxLength: 10),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.OrganisationID);
            
            CreateTable(
                "dbo.PaymentInitiateModels",
                c => new
                    {
                        PaymentInitiateID = c.Int(nullable: false),
                        CustomerID = c.String(),
                        Name = c.String(),
                        Email = c.String(),
                        ContactNumber = c.String(),
                        Address = c.String(),
                        Amount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentInitiateID);
            
            CreateTable(
                "dbo.ProductModels",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        ProductName = c.String(nullable: false),
                        Description = c.String(),
                        ProductCode = c.String(),
                        HSNCode = c.String(),
                        CategoryID = c.Int(nullable: false),
                        GroupID = c.Int(nullable: false),
                        BrandID = c.Int(nullable: false),
                        ColorID = c.Int(nullable: false),
                        UnitID = c.Int(nullable: false),
                        GSTSlabID = c.Int(nullable: false),
                        MRPRate = c.Double(nullable: false),
                        Rate = c.Double(nullable: false),
                        Price = c.Double(nullable: false),
                        GSTInclusive = c.Boolean(nullable: false),
                        Picture = c.String(),
                        MaterialCenterID = c.Int(nullable: false),
                        GodownID = c.Int(nullable: false),
                        RoomNoID = c.Int(nullable: false),
                        RackNoID = c.Int(nullable: false),
                        SelfNoID = c.Int(nullable: false),
                        BinNoID = c.Int(nullable: false),
                        Location = c.String(),
                        StockMinimumLevel = c.Double(nullable: false),
                        StockMaximumLevel = c.Double(nullable: false),
                        OpeningStock = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID);
            
            CreateTable(
                "dbo.ProfessionModels",
                c => new
                    {
                        ProfessionID = c.Int(nullable: false),
                        ProfessionName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ProfessionID);
            
            CreateTable(
                "dbo.ProposalModels",
                c => new
                    {
                        ProposalID = c.Int(nullable: false),
                        SerialNo = c.Int(nullable: false),
                        ProposalDate = c.DateTime(),
                        ReminderDate = c.DateTime(),
                        ProjectName = c.String(),
                        OfficeName = c.String(),
                        CustomerID = c.Int(nullable: false),
                        Remark = c.String(),
                        ProposalValue = c.Double(nullable: false),
                        ProposalGST = c.Double(nullable: false),
                        ProposalTotal = c.Double(nullable: false),
                        DiscountValue = c.Double(nullable: false),
                        DiscountPercent = c.Double(nullable: false),
                        Discount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ProposalID);
            
            CreateTable(
                "dbo.ProposalTransModels",
                c => new
                    {
                        ProposalTransID = c.Int(nullable: false),
                        ProposalID = c.Int(nullable: false),
                        ProductSerNo = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Double(nullable: false),
                        UnitID = c.Int(nullable: false),
                        Rate = c.Double(nullable: false),
                        Amount = c.Double(nullable: false),
                        GSTSlab = c.Double(nullable: false),
                        GSTAmount = c.Double(nullable: false),
                        ItemType = c.String(),
                    })
                .PrimaryKey(t => t.ProposalTransID);
            
            CreateTable(
                "dbo.PurchaseModels",
                c => new
                    {
                        PurchaseID = c.Int(nullable: false),
                        SerialNo = c.Int(nullable: false),
                        PurchaseState = c.Boolean(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false),
                        VenderID = c.Int(nullable: false),
                        InvoiceNo = c.String(),
                        InvoiceDate = c.DateTime(nullable: false),
                        TransportName = c.String(),
                        DocNo = c.String(),
                        MaterialCenterID = c.Int(nullable: false),
                        GodownID = c.Int(nullable: false),
                        Remark = c.String(),
                        PurchaseValue = c.Double(nullable: false),
                        PurchaseGST = c.Double(nullable: false),
                        PurchaseTotal = c.Double(nullable: false),
                        DiscountValue = c.Double(nullable: false),
                        DiscountPercent = c.Double(nullable: false),
                        Discount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseID);
            
            CreateTable(
                "dbo.PurchaseRetrunModels",
                c => new
                    {
                        PurchaseRetrunID = c.Int(nullable: false),
                        SerialNo = c.Int(nullable: false),
                        PurchaseRefNo = c.String(),
                        PurchaseRetrunDate = c.DateTime(),
                        VenderID = c.String(),
                        InvoiceNo = c.String(),
                        InvoiceDate = c.DateTime(),
                        TransportName = c.String(),
                        DocNo = c.String(),
                        Remark = c.String(),
                        PurchaseValue = c.Double(nullable: false),
                        PurchaseGST = c.Double(nullable: false),
                        PurchaseTotal = c.Double(nullable: false),
                        DiscountValue = c.Double(nullable: false),
                        DiscountPercent = c.Double(nullable: false),
                        Discount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseRetrunID);
            
            CreateTable(
                "dbo.PurchaseRetrunTransModels",
                c => new
                    {
                        PurchaseReturnTransID = c.Int(nullable: false),
                        ProductSerNo = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Double(nullable: false),
                        UnitID = c.Int(nullable: false),
                        Rate = c.Double(nullable: false),
                        Amount = c.Double(nullable: false),
                        GSTSlab = c.Double(nullable: false),
                        GSTAmount = c.Double(nullable: false),
                        ItemType = c.String(),
                        PurchaseRetrunID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseReturnTransID);
            
            CreateTable(
                "dbo.PurchaseTransModels",
                c => new
                    {
                        PurchaseTransID = c.Int(nullable: false),
                        PurchaseID = c.Int(nullable: false),
                        ProductSerNo = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Double(nullable: false),
                        UnitID = c.Int(nullable: false),
                        Rate = c.Double(nullable: false),
                        Amount = c.Double(nullable: false),
                        GSTSlab = c.Double(nullable: false),
                        GSTAmount = c.Double(nullable: false),
                        ItemType = c.String(),
                    })
                .PrimaryKey(t => t.PurchaseTransID);
            
            CreateTable(
                "dbo.QuotationModels",
                c => new
                    {
                        QuotationID = c.Int(nullable: false),
                        SerialNo = c.Int(nullable: false),
                        RefNo = c.String(),
                        QuotationState = c.Boolean(nullable: false),
                        QuotationDate = c.DateTime(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        QuotationValue = c.Double(nullable: false),
                        QuotationGST = c.Double(nullable: false),
                        QuotationTotal = c.Double(nullable: false),
                        DiscountValue = c.Double(nullable: false),
                        DiscountPercent = c.Double(nullable: false),
                        Discount = c.Double(nullable: false),
                        ExpactedDate = c.DateTime(),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.QuotationID);
            
            CreateTable(
                "dbo.QuotationTransModels",
                c => new
                    {
                        QuotationTransID = c.Int(nullable: false),
                        ProductSerNo = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Double(nullable: false),
                        UnitID = c.Int(nullable: false),
                        Rate = c.Double(nullable: false),
                        Amount = c.Double(nullable: false),
                        GSTSlab = c.Double(nullable: false),
                        GSTAmount = c.Double(nullable: false),
                        ItemType = c.String(),
                        QuotationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuotationTransID);
            
            CreateTable(
                "dbo.RackModels",
                c => new
                    {
                        RackID = c.Int(nullable: false),
                        RackName = c.String(nullable: false),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.RackID);
            
            CreateTable(
                "dbo.RoomModels",
                c => new
                    {
                        RoomID = c.Int(nullable: false),
                        RoomName = c.String(nullable: false),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.RoomID);
            
            CreateTable(
                "dbo.SalesModels",
                c => new
                    {
                        SalesID = c.Int(nullable: false),
                        SerialNo = c.Int(nullable: false),
                        RefNo = c.String(),
                        SaleState = c.Boolean(nullable: false),
                        SalesDate = c.DateTime(nullable: false),
                        AutoNoAuto = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        SaleValue = c.Double(nullable: false),
                        SaleGST = c.Double(nullable: false),
                        SaleTotal = c.Double(nullable: false),
                        DiscountValue = c.Double(nullable: false),
                        DiscountPercent = c.Double(nullable: false),
                        Discount = c.Double(nullable: false),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.SalesID);
            
            CreateTable(
                "dbo.SalesRetrunTransModels",
                c => new
                    {
                        SalesReturnTransID = c.Int(nullable: false),
                        ProductSerNo = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Double(nullable: false),
                        UnitID = c.Int(nullable: false),
                        Rate = c.Double(nullable: false),
                        Amount = c.Double(nullable: false),
                        GSTSlab = c.Double(nullable: false),
                        GSTAmount = c.Double(nullable: false),
                        ItemType = c.String(),
                        SalesReturnID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SalesReturnTransID);
            
            CreateTable(
                "dbo.SalesReturnModels",
                c => new
                    {
                        SalesReturnID = c.Int(nullable: false),
                        SerialNo = c.Int(nullable: false),
                        RefNo = c.String(),
                        RetrunDate = c.DateTime(nullable: false),
                        CustomerID = c.String(),
                        SaleValue = c.Double(nullable: false),
                        SaleGST = c.Double(nullable: false),
                        SaleTotal = c.Double(nullable: false),
                        DiscountValue = c.Double(nullable: false),
                        DiscountPercent = c.Double(nullable: false),
                        Discount = c.Double(nullable: false),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.SalesReturnID);
            
            CreateTable(
                "dbo.SalesTransModels",
                c => new
                    {
                        SalesTransID = c.Int(nullable: false),
                        ProductSerNo = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Double(nullable: false),
                        UnitID = c.Int(nullable: false),
                        Rate = c.Double(nullable: false),
                        Amount = c.Double(nullable: false),
                        GSTSlab = c.Double(nullable: false),
                        GSTAmount = c.Double(nullable: false),
                        ItemType = c.String(),
                        SalesID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SalesTransID);
            
            CreateTable(
                "dbo.SelfModels",
                c => new
                    {
                        SelfID = c.Int(nullable: false),
                        SelfName = c.String(nullable: false),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.SelfID);
            
            CreateTable(
                "dbo.ServiceModels",
                c => new
                    {
                        ServiceID = c.Int(nullable: false),
                        ServiceName = c.String(nullable: false),
                        Description = c.String(),
                        Service = c.String(),
                        SAC = c.String(),
                        CategoryID = c.Int(nullable: false),
                        GroupID = c.Int(nullable: false),
                        UnitID = c.Int(nullable: false),
                        GSTSlabID = c.Int(nullable: false),
                        Charge = c.Double(nullable: false),
                        ServiceCharge = c.Double(nullable: false),
                        GSTInclusive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceID);
            
            CreateTable(
                "dbo.SettingModels",
                c => new
                    {
                        SettingID = c.Int(nullable: false),
                        SmsPasswordRecoveryOTP = c.Boolean(nullable: false),
                        SmsMobileVerificationOTP = c.Boolean(nullable: false),
                        SmsOrderConfirm = c.Boolean(nullable: false),
                        SmsOnlinePaymentConfirm = c.Boolean(nullable: false),
                        SmsOfflinePaymentConfirm = c.Boolean(nullable: false),
                        SmsWorkProgressUpdate = c.Boolean(nullable: false),
                        SmsMaunalPaymentReminder = c.Boolean(nullable: false),
                        SmsAutoPaymentReminder = c.Boolean(nullable: false),
                        SmsDirectToCustomer = c.Boolean(nullable: false),
                        SmsNoticToEmployee = c.Boolean(nullable: false),
                        SmsMultipleMarketing = c.Boolean(nullable: false),
                        SmsTestingPurpose = c.Boolean(nullable: false),
                        EmailPasswordRecoveryOTP = c.Boolean(nullable: false),
                        EmailMobileVerificationOTP = c.Boolean(nullable: false),
                        EmailOrderConfirm = c.Boolean(nullable: false),
                        EmailOnlinePaymentConfirm = c.Boolean(nullable: false),
                        EmailOfflinePaymentConfirm = c.Boolean(nullable: false),
                        EmailWorkProgressUpdate = c.Boolean(nullable: false),
                        EmailMaunalPaymentReminder = c.Boolean(nullable: false),
                        EmailAutoPaymentReminder = c.Boolean(nullable: false),
                        EmailDirectToCustomer = c.Boolean(nullable: false),
                        EmailNoticToEmployee = c.Boolean(nullable: false),
                        EmailMultipleMarketing = c.Boolean(nullable: false),
                        EmailTestingPurpose = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SettingID);
            
            CreateTable(
                "dbo.ShoppingTransModels",
                c => new
                    {
                        ShoppingTransID = c.Int(nullable: false),
                        ProductSerNo = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Double(nullable: false),
                        UnitID = c.Int(nullable: false),
                        Rate = c.Double(nullable: false),
                        Amount = c.Double(nullable: false),
                        GSTSlab = c.Double(nullable: false),
                        GSTAmount = c.Double(nullable: false),
                        ItemType = c.String(),
                        SalesID = c.Int(nullable: false),
                        SessionID = c.String(),
                    })
                .PrimaryKey(t => t.ShoppingTransID);
            
            CreateTable(
                "dbo.SliderModels",
                c => new
                    {
                        SliderID = c.Int(nullable: false),
                        SliderTitle = c.String(nullable: false),
                        Description = c.String(),
                        IsDisplay = c.Boolean(nullable: false),
                        Picture = c.String(),
                    })
                .PrimaryKey(t => t.SliderID);
            
            CreateTable(
                "dbo.SMSSetupModels",
                c => new
                    {
                        SmsSetupID = c.Int(nullable: false),
                        SMSProviderName = c.String(),
                        Sender = c.String(),
                        RequestID = c.String(),
                        RouteID = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        SMSType = c.String(),
                    })
                .PrimaryKey(t => t.SmsSetupID);
            
            CreateTable(
                "dbo.SMSTempleteModels",
                c => new
                    {
                        SMSTempleteID = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Message = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SMSTempleteID);
            
            CreateTable(
                "dbo.SMSTransModels",
                c => new
                    {
                        SMSTransID = c.Int(nullable: false),
                        SMSDate = c.DateTime(nullable: false),
                        SMSTime = c.Time(nullable: false, precision: 7),
                        CustomerID = c.Int(nullable: false),
                        Mobile = c.String(),
                        SMSMessage = c.String(),
                        Device = c.String(),
                        Browser = c.String(),
                        DeviceIP = c.String(),
                        SMSCount = c.Int(nullable: false),
                        PropertyType = c.String(),
                        PropertyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SMSTransID);
            
            CreateTable(
                "dbo.StateModels",
                c => new
                    {
                        StateID = c.Int(nullable: false),
                        StateName = c.String(nullable: false),
                        StateType = c.String(nullable: false),
                        CountryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StateID);
            
            CreateTable(
                "dbo.StockTransferModels",
                c => new
                    {
                        StockTransferID = c.Int(nullable: false),
                        SerialNo = c.Int(nullable: false),
                        PurchaseState = c.Boolean(nullable: false),
                        TransferDate = c.DateTime(nullable: false),
                        MaterialCenterID = c.Int(nullable: false),
                        GodownID = c.Int(nullable: false),
                        Remark = c.String(),
                        PurchaseValue = c.Double(nullable: false),
                        PurchaseGST = c.Double(nullable: false),
                        PurchaseTotal = c.Double(nullable: false),
                        DiscountValue = c.Double(nullable: false),
                        DiscountPercent = c.Double(nullable: false),
                        Discount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.StockTransferID);
            
            CreateTable(
                "dbo.StockTransferTransModels",
                c => new
                    {
                        StockTransferTransID = c.Int(nullable: false),
                        ProductSerNo = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Double(nullable: false),
                        UnitID = c.Int(nullable: false),
                        Rate = c.Double(nullable: false),
                        Amount = c.Double(nullable: false),
                        GSTSlab = c.Double(nullable: false),
                        GSTAmount = c.Double(nullable: false),
                        ItemType = c.String(),
                        StockTransferID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StockTransferTransID);
            
            CreateTable(
                "dbo.SupplyOrderModels",
                c => new
                    {
                        SupplyOrderID = c.Int(nullable: false),
                        SerialNo = c.Int(nullable: false),
                        RefNo = c.String(),
                        SupplyOrderDate = c.DateTime(),
                        DueDate = c.DateTime(),
                        CustomerID = c.String(),
                        Remark = c.String(),
                        SupplyOrderValue = c.Double(nullable: false),
                        SupplyOrderGST = c.Double(nullable: false),
                        SupplyOrderTotal = c.Double(nullable: false),
                        DiscountValue = c.Double(nullable: false),
                        DiscountPercent = c.Double(nullable: false),
                        Discount = c.Double(nullable: false),
                        Progress = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.SupplyOrderID);
            
            CreateTable(
                "dbo.SupplyOrderTransModels",
                c => new
                    {
                        SupplyOrderTransID = c.Int(nullable: false),
                        ProductSerNo = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Double(nullable: false),
                        UnitID = c.Int(nullable: false),
                        Rate = c.Double(nullable: false),
                        Amount = c.Double(nullable: false),
                        GSTSlab = c.Double(nullable: false),
                        GSTAmount = c.Double(nullable: false),
                        ItemType = c.String(),
                        SupplyOrderID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SupplyOrderTransID);
            
            CreateTable(
                "dbo.TestimonialModels",
                c => new
                    {
                        TestimonialID = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Testimonial = c.String(),
                        QuoteBy = c.String(),
                        Picture = c.String(),
                    })
                .PrimaryKey(t => t.TestimonialID);
            
            CreateTable(
                "dbo.TOrderModels",
                c => new
                    {
                        TOrderID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        OrderNo = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.TOrderID);
            
            CreateTable(
                "dbo.TOrderTransModels",
                c => new
                    {
                        TOrderTransID = c.Int(nullable: false),
                        ProductSerNo = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Double(nullable: false),
                        UnitID = c.Int(nullable: false),
                        Rate = c.Double(nullable: false),
                        Amount = c.Double(nullable: false),
                        GSTSlab = c.Double(nullable: false),
                        GSTAmount = c.Double(nullable: false),
                        DeliveryCharge = c.Double(nullable: false),
                        TOrderID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TOrderTransID);
            
            CreateTable(
                "dbo.UnitModels",
                c => new
                    {
                        UnitID = c.Int(nullable: false),
                        UnitName = c.String(nullable: false),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.UnitID);
            
            CreateTable(
                "dbo.UserModels",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 10),
                        Password = c.String(nullable: false),
                        DisplayName = c.String(),
                        Email = c.String(),
                        Mobile = c.String(nullable: false, maxLength: 10),
                        UserType = c.String(),
                        ReadRights = c.Boolean(nullable: false),
                        WrightRights = c.Boolean(nullable: false),
                        UserCreateRights = c.Boolean(nullable: false),
                        SettingRights = c.Boolean(nullable: false),
                        AccountStatus = c.String(),
                        UserPicture = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.VenderModels",
                c => new
                    {
                        VenderID = c.Int(nullable: false),
                        VenderName = c.String(nullable: false),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Mobile = c.String(nullable: false, maxLength: 10),
                        Whatsup = c.String(maxLength: 10),
                        Email = c.String(),
                        GSTNo = c.String(),
                    })
                .PrimaryKey(t => t.VenderID);
            
            CreateTable(
                "dbo.VenderPaymentModels",
                c => new
                    {
                        PaymentID = c.Int(nullable: false),
                        PaymentType = c.String(),
                        PaymentMode = c.String(),
                        TransactionDate = c.DateTime(),
                        Amount = c.Double(nullable: false),
                        Remark = c.String(),
                        PaymentMethod = c.String(),
                        VenderID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentID);
            
            CreateTable(
                "dbo.VisiterModels",
                c => new
                    {
                        VisiterID = c.Int(nullable: false),
                        SessionID = c.String(),
                        VisitDate = c.DateTime(),
                        StartTime = c.Time(precision: 7),
                        EndTime = c.Time(precision: 7),
                        Duration = c.Time(precision: 7),
                        DeviceName = c.String(),
                        ComputerName = c.String(),
                        ComputerIP = c.String(),
                        Location = c.String(),
                        IsRead = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.VisiterID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VisiterModels");
            DropTable("dbo.VenderPaymentModels");
            DropTable("dbo.VenderModels");
            DropTable("dbo.UserModels");
            DropTable("dbo.UnitModels");
            DropTable("dbo.TOrderTransModels");
            DropTable("dbo.TOrderModels");
            DropTable("dbo.TestimonialModels");
            DropTable("dbo.SupplyOrderTransModels");
            DropTable("dbo.SupplyOrderModels");
            DropTable("dbo.StockTransferTransModels");
            DropTable("dbo.StockTransferModels");
            DropTable("dbo.StateModels");
            DropTable("dbo.SMSTransModels");
            DropTable("dbo.SMSTempleteModels");
            DropTable("dbo.SMSSetupModels");
            DropTable("dbo.SliderModels");
            DropTable("dbo.ShoppingTransModels");
            DropTable("dbo.SettingModels");
            DropTable("dbo.ServiceModels");
            DropTable("dbo.SelfModels");
            DropTable("dbo.SalesTransModels");
            DropTable("dbo.SalesReturnModels");
            DropTable("dbo.SalesRetrunTransModels");
            DropTable("dbo.SalesModels");
            DropTable("dbo.RoomModels");
            DropTable("dbo.RackModels");
            DropTable("dbo.QuotationTransModels");
            DropTable("dbo.QuotationModels");
            DropTable("dbo.PurchaseTransModels");
            DropTable("dbo.PurchaseRetrunTransModels");
            DropTable("dbo.PurchaseRetrunModels");
            DropTable("dbo.PurchaseModels");
            DropTable("dbo.ProposalTransModels");
            DropTable("dbo.ProposalModels");
            DropTable("dbo.ProfessionModels");
            DropTable("dbo.ProductModels");
            DropTable("dbo.PaymentInitiateModels");
            DropTable("dbo.OrganisationModels");
            DropTable("dbo.OnlineSalesTransModels");
            DropTable("dbo.OnlineSalesModels");
            DropTable("dbo.OnlineProductPackingModels");
            DropTable("dbo.OnlineProductModels");
            DropTable("dbo.OnlineProductArrangeModels");
            DropTable("dbo.OnlinePaymentModels");
            DropTable("dbo.OnlineCustomerModels");
            DropTable("dbo.MaterialCenterModels");
            DropTable("dbo.GSTSlabModels");
            DropTable("dbo.GroupModels");
            DropTable("dbo.GodownModels");
            DropTable("dbo.EmployeePaymentModels");
            DropTable("dbo.EmployeeModels");
            DropTable("dbo.EMDReceiptModels");
            DropTable("dbo.EMDIssueModels");
            DropTable("dbo.EMDExtendedModels");
            DropTable("dbo.EMDDocumentsTypeModels");
            DropTable("dbo.EMDCreatModels");
            DropTable("dbo.EMDCancelModels");
            DropTable("dbo.EmailTransModels");
            DropTable("dbo.EmailTempleteModels");
            DropTable("dbo.EmailSetupModels");
            DropTable("dbo.DesginationModels");
            DropTable("dbo.DealInModels");
            DropTable("dbo.DealersModels");
            DropTable("dbo.CustomerPaymentModels");
            DropTable("dbo.CustomerModels");
            DropTable("dbo.CountryModels");
            DropTable("dbo.ContactModels");
            DropTable("dbo.CompanyModels");
            DropTable("dbo.ColorModels");
            DropTable("dbo.CityModels");
            DropTable("dbo.CautionModels");
            DropTable("dbo.CategoryModels");
            DropTable("dbo.BrandModels");
            DropTable("dbo.BinModels");
            DropTable("dbo.BankModels");
        }
    }
}
