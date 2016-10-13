using Dna.NetCore.Core.Common;
using Dna.NetCore.Core.BLL.Entities.Common;
using System.Collections.Generic;

namespace Dna.NetCore.Core.BLL.Services.Common
{
    public interface ISystemSetting_CrudServices
    {
        void Add(List<SystemSetting> list, out CustomMessage customMessage);
        void Add(SystemSetting dao, out CustomMessage customMessage);
        SystemSetting Create(string userName, out CustomMessage customMessage);

        bool GetSystemSettingBooleanValue(string systemName);
        decimal GetSystemSettingDecimalValue(string systemName);
        int GetSystemSettingIntegerValue(string systemName);
        string GetSystemSettingStringValue(string systemName);
        bool HasSystemSetting(string systemName);
        SystemSetting SetAddPropertyValues(SystemSetting dao, string userName);
        SystemSetting SetDeletePropertyValues(SystemSetting dao, string userName);
        SystemSetting SetUpdatePropertyValues(SystemSetting dao, string userName);
        SystemSetting SetDefaultPropertyValues(SystemSetting dao, string userName);
        SystemSetting SetPropertyValues(SystemSetting dao,
                                        int pluginId,
                                        string systemName, string displayName,
                                        string description = "", string stringValue = "",
                                        bool booleanValue = false, decimal decimalValue = 0M,
                                        int integerValue = 0,
                                        bool isActive = true);
    }
}