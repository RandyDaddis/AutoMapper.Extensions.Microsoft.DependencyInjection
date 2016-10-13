using AutoMapper;
using NetCore.Core.BLL.DataTransferObjects;
using NetCore.Core.BLL.Entities;

namespace NetCore.Core.BLL.Mappers
{
    public class AutoMapperProfile_NetCore_DtoFromDao : Profile
    {
        #region ctor

        public AutoMapperProfile_NetCore_DtoFromDao()
        {
            CreateMaps();
        }

        #endregion

        #region Methods

        protected void CreateMaps()
        {
            if (Mapper.Configuration.FindTypeMapFor(typeof(AddressType), typeof(AddressTypeDto)) == null)
                CreateMap<AddressType, AddressTypeDto>();

            Mapper.Configuration.AssertConfigurationIsValid();
        }
        #endregion
    }
}
