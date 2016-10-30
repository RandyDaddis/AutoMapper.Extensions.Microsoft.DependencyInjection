using System;
using Dna.NetCore.Core.BLL.Entities.Common;
using Dna.NetCore.Core.BLL.Repositories.Common;
using System.Linq.Expressions;
using System.Linq;
using Dna.NetCore.Core.BLL.Constants;

namespace Dna.NetCore.Core.BLL.Services.Common
{
    public partial class SystemSetting_Queries : ISystemSetting_Queries
    {
        #region Private Fields

        private readonly ISystemSettingRepository _repository;

        #endregion

        #region ctor

        public SystemSetting_Queries(ISystemSettingRepository repository
                                    )
        {
            _repository = repository;
        }

        #endregion

        #region Methods

        public virtual SystemSetting Get(int id)
        {
            if (id < 1)
                return null;

            SystemSetting dao = _repository.Get(a => a.Id == id);

            return dao;
        }

        public virtual SystemSetting Get(string systemName)
        {
            SystemSetting dao = _repository.Get(a => a.SystemName == systemName);

            return dao;
        }

        public virtual SystemSetting Get(Expression<Func<SystemSetting, bool>> wherePredicate)
        {
            if (wherePredicate == null)
                return null;

            SystemSetting dao = _repository.Get(wherePredicate);

            return dao;
        }

        public virtual IQueryable<SystemSetting> GetList(Expression<Func<SystemSetting, bool>> wherePredicate)
        {
            if (wherePredicate == null)
                return null;

            IQueryable<SystemSetting> daos = _repository.GetWhere(wherePredicate);
                                                        //.OrderBy(a => a.SystemName) ;
            return daos;
        }

        //public virtual int GetDefaultSystemSettingId(string systemName)
        //{
        //    int id = 0;
        //    string name = "";

        //    switch (systemName)
        //    {
        //        case "addressType":
        //            name = CoreDefaultAddressType;
        //            break;
        //        case "currency":
        //            name = CoreDefaultCurrencyCode;
        //            break;
        //        case "locale":
        //            name = SystemSettingConstants.CoreDefaultLocale;
        //            break;
        //        case "personType":
        //            name = "Core.Default.PersonType";
        //            break;
        //        case "phoneNumberType":
        //            name = CoreDefaultPhoneNumberType;
        //            break;
        //        case "timeZone":
        //            name = CoreDefaultTimeZone;
        //            break;
        //        // AccountsReceivable
        //        case "customerStatus":
        //            name = AccountsReceivableDefaultCustomerStatus;
        //            break;
        //        case "customerType":
        //            name = AccountsReceivableDefaultCustomerType;
        //            break;
        //        case "invoiceStatus":
        //            name = AccountsReceivableDefaultInvoiceStatus;
        //            break;
        //        // Inventory
        //        case "productBrand":
        //            name = InventoryDefaultProductBrand;
        //            break;
        //        case "productCategory":
        //            name = InventoryDefaultProductCategory;
        //            break;
        //        case "productType":
        //            name = InventoryDefaultProductType;
        //            break;
        //        // Payments
        //        case "creditCardType":
        //            name = PaymentsDefaultCreditCardType;
        //            break;
        //        case "paymentStatus":
        //            name = PaymentsDefaultPaymentStatus;
        //            break;
        //        case "paymentTerm":
        //            name = PaymentsDefaultPaymentTerm;
        //            break;
        //        case "paymentType":
        //            name = PaymentsDefaultPaymentType;
        //            break;
        //        // Sales Orders
        //        case "orderStatus":
        //            name = SalesOrdersDefaultOrderStatus;
        //            break;
        //        default:
        //            break;
        //    }

        //    if (!string.IsNullOrEmpty(name))
        //        id = _repository.Get(a => a.SystemName == name).Id;

        //    return id;
        //}

        public virtual bool IsDeleteEntityPermanent()
        {
            bool isDeleteEntityPermanent = _repository.Get(a => a.SystemName == SystemSettingConstants.Core_IsDeleteEntityPermanent).BooleanValue;

            return isDeleteEntityPermanent;
        }


        #endregion

    }
}
