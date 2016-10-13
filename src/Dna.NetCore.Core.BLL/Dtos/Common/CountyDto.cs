using Dna.NetCore.Core.BLL.EntityMetadata.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using Dna.i18n.Model.Shipping; // DEVNOTE: use for restricting shipping to certain countries

namespace Dna.NetCore.Core.BLL.DataTransferObjects.Common
{
#if NET462
    [MetadataType(typeof(County_Metadata))]
#endif
    public partial class CountyDto : BaseDataTransferObject
	{
        #region Public Properties

        public virtual int Id { get; set; }

        public virtual string DisplayName { get; set; }
        public virtual bool IsActive { get; set; }

        public virtual int StateOrProvinceId { get; set; }
        public virtual string StateOrProvinceAbbreviation { get; set; }  //used by child entities
        public IEnumerable<StateOrProvince_Summary> StateOrProvinceSummaries { get; set; }  // used by SelectItems

        #endregion

		#region Navigation Fields

        //public virtual StateOrProvinceDto StateOrProvince { get; set; }

        private ICollection<CountyCityDto> _countiesCities;
        public virtual ICollection<CountyCityDto> CountiesCities
        {
            get { return _countiesCities ?? (_countiesCities = new List<CountyCityDto>()); }
            set { _countiesCities = value; }
        }


        #endregion
    }
}
