using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dna.NetCore.Core.BLL.Entities.Common
{
    [Table("Money", Schema = "dbo")]
//#if NET462
//    [MetadataType(typeof(Money_Dao_Metadata))]
//#endif
    public partial class Money : IEquatable<Money>
	{

		#region Private Fields

		private readonly decimal amount;
		private readonly string currencyCode;

		#endregion

		#region Ctor

        public Money()
        {
        }

        public Money(decimal amount, string currencyCode)
		{
			if (string.IsNullOrEmpty(currencyCode))
			{
				throw new ArgumentException("The currency cannot be null or empty.", "currencyCode");
			}

			this.amount = amount;
			this.currencyCode = currencyCode;
		}

        #endregion

        #region Public Properties

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        public virtual decimal Amount
		{
			get { return this.amount; }
		}

		public virtual string CurrencyCode
		{
			get { return this.currencyCode; }
		}

		#endregion

		#region Methods

		public Money Add(decimal amount)
		{
			return new Money(this.Amount + amount, this.CurrencyCode);
		}

		//public Money ConvertTo(Currency currency)
		//{
		//	if (currency == null)
		//	{
		//		throw new ArgumentNullException("currency");
		//	}

		//	var exchangeRate =
		//		currency.GetExchangeRateFor(this.CurrencyCode);
		//	return new Money(this.Amount * exchangeRate,
		//		currency.Code);
		//}

		public override bool Equals(object obj)
		{
			var m = obj as Money;
			if (m != null)
			{
				return this.Equals(m);
			}
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return this.Amount.GetHashCode() ^ this.CurrencyCode.GetHashCode();
		}

		public Money Multiply(decimal multiplier)
		{
			return new Money(this.Amount * multiplier, this.CurrencyCode);
		}

		public override string ToString()
		{
			return string.Format("{0:F} {1}", this.Amount, this.CurrencyCode);
		}

		#endregion

		#region IEquatable<Money> Methods

		public bool Equals(Money other)
		{
			if (other == null)
			{
				return false;
			}
			return this.Amount == other.Amount && this.CurrencyCode == other.CurrencyCode;
		}

		#endregion
	}
}
