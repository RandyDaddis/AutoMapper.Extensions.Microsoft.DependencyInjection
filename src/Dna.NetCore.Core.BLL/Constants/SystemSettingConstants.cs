namespace Dna.NetCore.Core.BLL.Constants
{
    public class SystemSettingConstants
    {
        #region Constants

        public const string Issuer = "http://daddis.net";
        public const string MiddlewareScheme = "Cookie";
        public const string CompanyClaimType = "https://schemas.daddis.net/identity/claims/Company";

        // Accounts Receivable
        public const string AccountsReceivable_CustomerIsActive = "AccountsReceivable.Customer.IsActive";
        public const string AccountsReceivable_CustomerIsApproved = "AccountsReceivable.Customer.IsApproved";
        public const string AccountsReceivable_CustomerAddressIsActive = "AccountsReceivable.CustomerAddress.IsActive";
        public const string AccountsReceivable_CustomerCommentIsActive = "AccountsReceivable.CustomerComment.IsActive";
        public const string AccountsReceivable_CustomerCommentIsApproved = "AccountsReceivable.CustomerComment.IsApproved";
        public const string AccountsReceivable_CustomerPhoneNumberIsActive = "AccountsReceivable.CustomerPhoneNumber.IsActive";
        public const string AccountsReceivable_CustomerStatusSystemName = "AccountsReceivable.CustomerStatus.SystemName";
        public const string AccountsReceivable_CustomerStatusIsActive = "AccountsReceivable.CustomerStatus.IsActive";
        public const string AccountsReceivable_CustomerTypeSystemName = "AccountsReceivable.CustomerType.SystemName";
        public const string AccountsReceivable_CustomerTypeIsActive = "AccountsReceivable.CustomerType.IsActive";
        public const string AccountsReceivable_InvoiceIsTaxable = "AccountsReceivable.Invoice.IsTaxable";
        public const string AccountsReceivable_InvoiceNumberIsCustomFormat = "AccountsReceivable.Invoice.Number.IsCustomFormat";
        public const string AccountsReceivable_InvoiceShippingIsFree = "AccountsReceivable.Invoice.Shipping.IsFree";
        public const string AccountsReceivable_InvoiceShippingPriceIsTaxable = "AccountsReceivable.Invoice.ShippingPrice.IsTaxable";
        public const string AccountsReceivable_InvoiceCommentIsActive = "AccountsReceivable.InvoiceComment.IsActive";
        public const string AccountsReceivable_InvoiceCommentIsApproved = "AccountsReceivable.InvoiceComment.IsApproved";
        public const string AccountsReceivable_InvoiceNumberNext = "AccountsReceivable.Invoice.Number.Next";
        public const string AccountsReceivable_InvoiceStatusSystemName = "AccountsReceivable.InvoiceStatus.SystemName";
        public const string AccountsReceivable_InvoiceStatusIsActive = "AccountsReceivable.InvoiceStatus.IsActive";
        public const string AccountsReceivable_SalesAssociateUserName = "AccountsReceivable.SalesAssociate.UserName";
        // Advertising
        public const string Advertising_SalesAssociateClaimSystemName = "Advertising.Sales.Associate.Claim.SystemName";
        public const string Advertising_SalesAssociateUserName = "Advertising.Sales.Associate.UserName";
        // Core 
        public const string Core_AddressTypeSystemName = "Core.AddressType.SystemName";
        public const string Core_BasePathForDataFiles = "Core.Base.Path.For.Data.Files";
        public const string Core_ClaimTypes_Tenant = "Core.ClaimTypes.Tenant";
        public const string Core_CityDisplayName = "Core.City.DisplayName";
        public const string Core_CountyDisplayName = "Core.County.DisplayName";
        public const string Core_CountryAbbreviation = "Core.Country.Abbreviation";
        public const string Core_CurrencyCode = "Core.Currency.Code";
        public const string Core_IsActive = "Core.IsActive";
        public const string Core_IsDeleteEntityPermanent = "Core.IsDeleteEntityPermanent";
        public const string Core_LocaleLcidDecimal = "Core.Locale.LcidDecimal";
        public const string Core_MaximumUIErrorMessageLength = "Core.Maximum.User.Interface.Error.Message.Length";
        public const string Core_MimeTypeSystemName = "Core.MimeType.SystemName";
        public const string Core_MimeTypeGroup_ApplicationSystemName = "Core.MimeTypeGroup.Application.SystemName";
        public const string Core_MimeTypeGroup_ImageSystemName = "Core.MimeTypeGroup.Image.SystemName";
        public const string Core_MimeTypeGroup_TextSystemName = "Core.MimeTypeGroup.Text.SystemName";
        public const string Core_PhoneNumberTypeSystemName = "Core.PhoneNumberType.SystemName";
        public const string Core_PhoneNumber_CountryCode = "Core.PhoneNumber.CountryCode";
        public const string Core_SmtpMailMessageDefaultRecipient = "SMTP.MailMessage.DefaultRecipient";
        public const string Core_SmtpHost1 = "SMTP.Host1";
        public const string Core_SmtpHost1Port = "SMTPHost1.Port";
        public const string Core_SmtpPickupDirectoryLocation = "SMTP.PickupDirectoryLocation";
        public const string Core_SmtpUseDefaultCredentials = "SMTP.UseDefaultCredentials";
        public const string Core_SmtpUserName = "SMTP.UserName";
        public const string Core_SmtpUserNamePassword = "SMTP.UserName.Password";
        public const string Core_SmtpWriteAsFile = "SMTP.WriteAsFile";
        public const string Core_SmtpWriteAsFileLocation = "SMTP.WriteAsFileLocation";
        public const string Core_SslIsEnabled = "Core.Ssl.IsEnabled";
        public const string Core_SSLUrl = "Core.Ssl.Url";
        public const string Core_SystemSettingIsActive = "Core.SystemSetting.IsActive";
        //public const string Core_TimeZone = "Core.Default.TimeZone";
        public const string Core_TimeZoneInfoId = "Core.TimeZone.InfoId";
        public const string Core_US_DefaultState = "Core.Us.State";
        public const string Core_Us_ShippingIsAllowed = "Core.US.Shipping.IsAllowed";
        public const string Core_US_Taxes_NJ_SalesTaxRate = "Core.US.Taxes.NJ.SalesTax.Rate";
        public const string Core_US_Taxes_NY_SalesTaxRate = "Core.US.Taxes.NY.SalesTax.Rate";
        public const string Core_US_Taxes_PA_SalesTaxRate = "Core.US.Taxes.PA.SalesTax.Rate";
        public const string Core_US_Taxes_SalesTaxState = "Core.US.Taxes.SalesTax.State";
        public const string Core_US_Taxes_VatIsEnabled = "Core.US.Taxes.Vat.IsEnabled";
        public const string Core_UserName = "Core.UserName";
        // Inventory
        public const string Inventory_ProductSystemName = "Inventory.Product.SystemName";
        public const string Inventory_ProductBrandSystemName = "Inventory.ProductBrand.SystemName";
        public const string Inventory_ProductCategorySystemName = "Inventory.ProductCategory.SystemName";
        public const string Inventory_ProductPriceTierSystemName = "Inventory.ProductPriceTier.SystemName";
        public const string Inventory_ProductTypeSystemName = "Inventory.ProductType.SystemName";
        // Inventory - Automotive
        public const string Inventory_Automotive_VehicleCommentIsActive = "Inventory.Automotive.VehicleComment.IsActive";
        public const string Inventory_Automotive_VehicleCommentIsApproved = "Inventory.Automotive.VehicleComment.IsApproved";
        public const string Inventory_Automotive_VehicleIsActive = "Inventory.Automotive.Vehicle.IsActive";
        public const string Inventory_Automotive_VehicleIsPublished = "Inventory.Automotive.Vehicle.IsPublished";
        public const string Inventory_Automotive_VehiclePictureFileIsActive = "Inventory.Automotive.VehiclePictureFile.IsActive";
        public const string Inventory_Automotive_VehiclePictureFileIsPublished = "Inventory.Automotive.VehiclePictureFile.IsPublished";
        public const string Inventory_Automotive_VehiclePictureIsActive = "Inventory.Automotive.VehiclePicture.IsActive";
        public const string Inventory_Automotive_VehiclePictureIsPublished = "Inventory.Automotive.VehiclePicture.IsPublished";
        public const string Inventory_Automotive_VehicleStatusSystemName = "Inventory.Automotive.VehicleStatus.SystemName";
        public const string Inventory_Automotive_VehicleStatusIsActive = "Inventory.Automotive.VehicleStatus.IsActive";
        public const string Inventory_Automotive_VehicleTitleTypeStateOrProvince = "Inventory.Automotive.VehicleTitleType.StateOrProvince";
        // Payments
        public const string Payments_CreditCardNumberIsPersisted = "Payments.CreditCard.Number.IsPersisted";
        public const string Payments_CreditCardTypeSystemName = "Payments.CreditCardType.SystemName";
        public const string Payments_CreditCardTypeIsActive = "Payments.CreditCardType.IsActive";
        public const string Payments_PaymentCommentIsActive = "Payments.PaymentComment.IsActive";
        public const string Payments_PaymentCommentIsApproved = "Payments.PaymentComment.IsApproved";
        public const string Payments_PaymentDiscountTypeSystemName = "Payments.Payment.DiscountType.SystemName";
        public const string Payments_PaymentDiscountTypeIsActive = "Payments.PaymentDiscountType.IsActive";
        public const string Payments_PaymentProviderSystemName = "Payments.PaymentProvider.SystemName";
        public const string Payments_PaymentProvider_PayPal = "Payments.PaymentProvider.PayPal";
        public const string Payments_PaymentStatusSystemName = "Payments.PaymentStatus.SystemName";
        public const string Payments_PaymentStatusIsActive = "Payments.PaymentStatus.IsActive";
        public const string Payments_PaymentTermSystemName = "Payments.PaymentTerm.SystemName";
        public const string Payments_PaymentTermIsActive = "Payments.PaymentTerm.IsActive";
        public const string Payments_PaymentTypeSystemName = "Payments.PaymentType.SystemName";
        public const string Payments_PaymentTypeIsActive = "Payments.PaymentType.IsActive";
        // Sales Discounts
        public const string SalesDiscount_SalesDiscountTermSystemName = "SalesDiscounts.SalesDiscountTerm.SystemName";
        public const string SalesDiscount_SalesDiscountTermIsActive = "SalesDiscounts.SalesDiscountTerm.IsActive";
        public const string SalesDiscount_SalesDiscountTypeSystemName = "SalesDiscounts.SalesDiscountType.SystemName";
        public const string SalesDiscount_SalesDiscountTypeIsActive = "SalesDiscounts.SalesDiscountType.IsActive";
        // Sales Orders
        public const string SalesOrders_OrderCommentIsActive = "SalesOrders.OrderComment.IsActive";
        public const string SalesOrders_OrderCommentIsApproved = "SalesOrders.OrderComment.IsApproved";
        public const string SalesOrders_OrderNumberNext = "SalesOrders.Order.Number.Next";
        public const string SalesOrders_OrderStatusSystemName = "SalesOrders.OrderStatus.SystemName";
        public const string SalesOrders_OrderStatusIsActive = "SalesOrders.OrderStatus.IsActive";

        #endregion

    }
}
