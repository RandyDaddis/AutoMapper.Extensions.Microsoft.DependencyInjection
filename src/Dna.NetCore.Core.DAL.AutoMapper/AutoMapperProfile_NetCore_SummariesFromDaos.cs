using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using Dna.NetCore.Core.BLL.Entities.Common;
using AutoMapper;

namespace Dna.NetCore.Core.DAL.AutoMapper
{
    public class AutoMapperProfile_NetCore_SummariesFromDaos : Profile
    {
        #region ctor

        public AutoMapperProfile_NetCore_SummariesFromDaos()
        {
            CreateMaps();
        }

        #endregion

        #region Methods

        protected void CreateMaps()
        {
            if (Mapper.Configuration.FindTypeMapFor(typeof(AddressType), typeof(AddressTypeSummary)) == null)
                CreateMap<AddressType, AddressTypeSummary>();

            Mapper.Configuration.AssertConfigurationIsValid();
        }

        #endregion
    }
}
