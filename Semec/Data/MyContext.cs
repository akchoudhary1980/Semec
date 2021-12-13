using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Entity;
using System.Threading.Tasks;
using Semec.Areas.CommonManage.Model;
using Semec.Areas.AdminManage.Model;
using Semec.Areas.EmdManage.Model;
using Semec.Areas.InvoiceManage.Model;
using Semec.Areas.DealersManage.Model;
using Semec.Areas.TenderSearchManage.Model;

namespace Semec
{
    public class MyContext : DbContext
    {
        public MyContext() : base("byEntity") { }

        // Common Modules Class
        public DbSet<CompanyModel> CompanyModels { get; set; }
        public DbSet<CategoryModel> CategoryModels { get; set; }        
        public DbSet<GroupModel> GroupModels { get; set; }
        public DbSet<BrandModel> BrandModels { get; set; }
        public DbSet<UnitModel> UnitModels { get; set; }
        public DbSet<GSTSlabModel> GSTSlabModels { get; set; }

        public DbSet<CountryModel> CountryModels { get; set; }
        public DbSet<StateModel> StateModels { get; set; }
        public DbSet<CityModel> CityModels { get; set; }

        public DbSet<DesginationModel> DesginationModels { get; set; }
        public DbSet<ProfessionModel> ProfessionModels { get; set; }

        public DbSet<EmailSetupModel> EmailSetupModels { get; set; }
        public DbSet<EmailTempleteModel> EmailTempleteModels { get; set; }
        public DbSet<EmailTransModel> EmailTransModels { get; set; }
       
        public DbSet<SMSSetupModel> SMSSetupModels { get; set; }
        public DbSet<SMSTempleteModel> SMSTempleteModels { get; set; }
        public DbSet<SMSTransModel> SMSTransModels { get; set; }

        public DbSet<SettingModel> SettingModels { get; set; }
        public DbSet<SliderModel> SliderModels { get; set; }
        public DbSet<UserModel> UserModels { get; set; }

        // Online Modules Class
        public DbSet<CautionModel> CautionModels { get; set; }
        public DbSet<ContactModel> ContactModel { get; set; }
        public DbSet<VisiterModel> VisiterModels { get; set; }
        public DbSet<TestimonialModel> TestimonialModels { get; set; }

        public DbSet<OnlineCustomerModel> OnlineCustomerModels { get; set; }
        public DbSet<OnlinePaymentModel> OnlinePaymentModels { get; set; }

        public DbSet<OnlineProductModel> OnlineProductModels { get; set; }
        public DbSet<OnlineProductPackingModel> OnlineProductPackingModels { get; set; }
        public DbSet<OnlineProductArrangeModel> OnlineProductArrangeModels { get; set; }

        public DbSet<OnlineSalesModel> OnlineSalesModels { get; set; }
        public DbSet<OnlineSalesTransModel> OnlineSalesTransModels { get; set; }
        public DbSet<PaymentInitiateModel> PaymentInitiateModels { get; set; }
        public DbSet<TOrderModel> TOrderModel { get; set; }
        public DbSet<TOrderTransModel> TOrderTransModel { get; set; }
        public DbSet<ShoppingTransModel> ShoppingTransModels { get; set; }

        // EMD Modules Class        
        public DbSet<BankModel> BankModels { get; set; }
        public DbSet<OrganisationModel> OrganisationModels { get; set; }
        public DbSet<EMDDocumentsTypeModel> EMDDocumentsTypeModels { get; set; }        
        public DbSet<EMDCreatModel> EMDCreatModels { get; set; }
        public DbSet<EMDCancelModel> EMDCancelModels { get; set; }
        public DbSet<EMDIssueModel> EMDIssueModels { get; set; }
        public DbSet<EMDExtendedModel> EMDextendedModel { get; set; }
        public DbSet<EMDReceiptModel> EMDReceiptModels { get; set; }


        // Dealers Manaage App
        public DbSet<DealersModel> DealersModels { get; set; }
        public DbSet<DealInModel> DealInModels { get; set; }
        public DbSet<ItemModel> ItemModels { get; set; }

        // Tender Search App 
        public DbSet<TenderSearchLinkModel> TenderSearchLinkModels { get; set; }
        public DbSet<DepartmentCategoryModel> DepartmentCategoryModels { get; set; }
        public DbSet<DepartmentModel> DepartmentModels { get; set; }

        // Invoice Modules Class 

        public DbSet<ProductModel> ProductModels { get; set; }
        public DbSet<ServiceModel> ServiceModels { get; set; }


        public DbSet<MaterialCenterModel> MaterialCenterModels { get; set; }
        public DbSet<GodownModel> GodownModels { get; set; }
        public DbSet<RoomModel> RoomModels { get; set; }
        public DbSet<RackModel> RackModels { get; set; }
        public DbSet<SelfModel> SelfModels { get; set; }
        public DbSet<BinModel> BinModel { get; set; }
        public DbSet<ColorModel> ColorModel { get; set; }
       
       

        public DbSet<CustomerModel> CustomerModels { get; set; }
        public DbSet<CustomerPaymentModel> CustomerPaymentModels { get; set; }
        public DbSet<EmployeeModel> EmployeeModels { get; set; }
        public DbSet<EmployeePaymentModel> EmployeePaymentModels { get; set; }
        public DbSet<VenderModel> VenderModels { get; set; }
        public DbSet<VenderPaymentModel> VenderPaymentModels { get; set; }

        public DbSet<ProposalModel> ProposalModels { get; set; }
        public DbSet<ProposalTransModel> ProposalTransModels { get; set; }

        public DbSet<QuotationModel> QuotationModels { get; set; }
        public DbSet<QuotationTransModel> QuotationTransModels { get; set; }

        public DbSet<PurchaseModel> PurchaseModels { get; set; }
        public DbSet<PurchaseTransModel> PurchaseTransModels { get; set; }

        public DbSet<PurchaseRetrunModel> PurchaseRetrunModels { get; set; }
        public DbSet<PurchaseRetrunTransModel> PurchaseRetrunTransModel { get; set; }

        public DbSet<SupplyOrderModel> SupplyOrderModels { get; set; }
        public DbSet<SupplyOrderTransModel> SupplyOrderTransModels { get; set; }

        public DbSet<SalesModel> SalesModels { get; set; }
        public DbSet<SalesTransModel> SalesTransModels { get; set; }

        public DbSet<SalesReturnModel> SalesReturnModels { get; set; }
        public DbSet<SalesRetrunTransModel> SalesRetrunTransModels { get; set; }

        public DbSet<StockTransferModel> StockTransferModels { get; set; }
        public DbSet<StockTransferTransModel> StockTransferTransModels { get; set; }

        /// Store procudures 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //// configures one-to-many relationship
            //modelBuilder.Entity<Book>()
            //    .HasRequired<CheeseCategory>(a => a.Author)
            //    .WithMany(g => g.Books)
            //    .HasForeignKey<int>(s => s.AuthorId);        
        }       
    }
}
