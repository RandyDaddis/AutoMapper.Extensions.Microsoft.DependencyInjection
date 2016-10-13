using Dna.NetCore.Core.BLL.EntityMetadata.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dna.NetCore.Core.BLL.Entities.Common
{
    //[Table("Core_Person", Schema = "dbo")]
#if NET462
    [MetadataType(typeof(PersonBase_Dao_Metadata))]
#endif
    public abstract partial class PersonBase : BaseEntity
	{
        // DEVNOTE: I moved Person to \Security to eliminate conflicts with Address & Comment when referencing Dna.NetCore.Core.BLL.Entities.Common
        #region Ctor

        public PersonBase() { } // required for proxy classes to work when a ctor exists that takes parameters ( cRef Programming EF p.350 )

        #endregion

        #region Public Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        public virtual string UserName { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string LastName { get; set; }

        //[NotMapped]
        //public virtual string FullName
        //{
        //    get
        //    {
        //        return string.Format(CultureInfo.CurrentUICulture,
        //                              "{2}, {0} {1}", this.FirstName, this.MiddleName, this.LastName);
        //    }
        //}

        public virtual string EmailPrimary { get; set; }
        public virtual string UrlPrimary { get; set; }
        public virtual string LastIpAddress { get; set; }
        public virtual DateTime? LastLoginDate { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual bool IsApproved { get; set; }

        //// <summary>Gets or sets the Primary Address. </summary>
        //[NotMapped]
        //public Address AddressPrimary
        //{
        //    get { return Addresses.FirstOrDefault(a => a.IsPrimary); }
        //    set
        //    {
        //        //if (value.StaffingResource != this)
        //        //    throw new InvalidOperationException("Address is not associated with this StaffingResource.");

        //        Addresses.Where(a => a.IsPrimary).ForEach(a => a.IsPrimary = false);
        //        value.IsPrimary = true;
        //    }
        //}

        //// <summary>Gets or sets the Primary Phone Number. </summary>
        //[NotMapped]
        //public PhoneNumber PhoneNumberPrimary
        //{
        //    get { return PhoneNumbers.FirstOrDefault(a => a.IsPrimary); }
        //    set
        //    {
        //        PhoneNumbers.Where(p => p.IsPrimary).ForEach(p => p.IsPrimary = false);
        //        value.IsPrimary = true;
        //    }
        //}

        public virtual int CurrencyId { get; set; }
        public virtual int LocaleId { get; set; }
        public virtual int TimeZoneId { get; set; }

        //public virtual int PersonTypeId { get; set; }

        //public virtual int? ParentId { get; set; }

        //public virtual int AddressPrimaryId { get; set; }

        #endregion

        #region Navigation Fields

        //public virtual PersonType PersonType { get; set; }

        //public virtual Person Parent { get; set; }

        //private ICollection<Address> _addresses;
        //public virtual ICollection<Address> Addresses
        //{
        //    get { return _addresses ?? (_addresses = new List<Address>()); }
        //    set { _addresses = value; }
        //}

        //private ICollection<Comment> _comments;
        //public virtual ICollection<Comment> Comments
        //{
        //    get { return _comments ?? (_comments = new List<Comment>()); }
        //    set { _comments = value; }
        //}

        //private ICollection<PhoneNumber> _phoneNumbers;
        //public virtual ICollection<PhoneNumber> PhoneNumbers
        //{
        //    get { return _phoneNumbers ?? (_phoneNumbers = new List<PhoneNumber>()); }
        //    set { _phoneNumbers = value; }
        //}

        #endregion
    }
}
