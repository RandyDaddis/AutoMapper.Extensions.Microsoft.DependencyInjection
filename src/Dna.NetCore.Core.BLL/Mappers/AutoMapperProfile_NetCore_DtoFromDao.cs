﻿using AutoMapper;
using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using Dna.NetCore.Core.BLL.Entities.Common;

namespace Dna.NetCore.Core.BLL.Mappers
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