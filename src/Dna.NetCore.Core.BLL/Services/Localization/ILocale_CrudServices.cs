using Dna.NetCore.Core.BLL.Commands.Localization;
using Dna.NetCore.Core.BLL.DataTransferObjects.Localization;
using Dna.NetCore.Core.Common;

namespace Dna.NetCore.Core.BLL.Services.Localization
{
    public interface ILocale_CrudServices
    {
        void Add(LocaleCmd cmd, string userName, out CustomMessage customMessage);
        void Delete(LocaleDto dto, string userName, out CustomMessage customMessage);
        void Update(LocaleCmd cmd, string userName, out CustomMessage customMessage);

        LocaleCmd Cmd_Create(string userName, out CustomMessage customMessage);
        LocaleCmd Cmd_SetDefaultPropertyValues(LocaleCmd cmd, string userName);
    }
}
