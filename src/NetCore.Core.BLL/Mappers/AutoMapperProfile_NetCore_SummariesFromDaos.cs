using NetCore.Core.BLL.Dtos.Common;
using NetCore.Core.BLL.Entities.Common;
using AutoMapper;

namespace NetCore.Core.BLL.Mappers
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
