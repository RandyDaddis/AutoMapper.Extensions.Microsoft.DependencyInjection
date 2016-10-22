﻿using Dna.NetCore.Core.BLL.Entities.Common;
using Dna.NetCore.Core.BLL.Repositories.Common;
using Dna.NetCore.Core.Common;
using System.Collections.Generic;

namespace Dna.NetCore.Core.DAL.EFCore.Repositories.Common
{
    public class SystemSettingRepository : RepositoryBase<SystemSetting>, ISystemSettingRepository
    {
        public SystemSettingRepository(CoreEFContext context)
            : base(context)
        {
        }
        public virtual SystemSetting Create(out CustomMessage customMessage)
        {
            CustomMessage customMessage1 = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            // TODO: refactor back to RepositoryBase_CM_T when EF Core supports create()
            SystemSetting dao = new SystemSetting();
            customMessage = customMessage1;
            return dao;
        }
    }
}
