using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using Dna.NetCore.Core.BLL.EntityMetadata.Common;
using Dna.NetCore.Core.Commands;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dna.NetCore.Core.BLL.Commands.Common
{
#if NET462
    [MetadataType(typeof(County_Metadata))]
#endif
    public partial class CountyCmd : BaseCommand, ICommand
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

        //public virtual StateOrProvinceCmd StateOrProvince { get; set; }

        private ICollection<CountyCityCmd> _countiesCities;
        public virtual ICollection<CountyCityCmd> CountiesCities
        {
            get { return _countiesCities ?? (_countiesCities = new List<CountyCityCmd>()); }
            set { _countiesCities = value; }
        }

        #endregion
    }
}
