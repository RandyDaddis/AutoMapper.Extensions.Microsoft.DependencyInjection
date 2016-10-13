using Dna.NetCore.Core.BLL.Commands.Localization;
using Dna.NetCore.Core.BLL.DataTransferObjects.Localization;
using Dna.NetCore.Core.BLL.Entities.Localization;
using Dna.NetCore.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dna.NetCore.Core.BLL.Services.Localization
{
    public interface ILanguage_Services
    {
        Dictionary<string, string> Add(LanguageCmd cmd, string userName);
        Dictionary<string, string> Delete(LanguageDto dto, string userName);
        Dictionary<string, string> Update(LanguageCmd cmd, string userName);

        LanguageDto Get(int id);
        LanguageDto Get(Expression<Func<Language, bool>> wherePredicate);

        LanguageCmd GetCmd(int id);

        int GetId(string displayName);

        IEnumerable<LanguageDto> GetList(bool isActive = true);
        IEnumerable<LanguageDto> GetList(Expression<Func<Language, bool>> wherePredicate);

        IEnumerable<LanguageSummary> GetSummaryList(Expression<Func<Language, bool>> wherePredicate);
        IPagedList<LanguageSummary> GetSummaryPagedList(Expression<Func<Language, bool>> wherePredicate, int pageIndex = 0, int pageSize = 10);

        LanguageCmd Cmd_Create(string userName);
        LanguageCmd Cmd_SetDefaultProperties(LanguageCmd cmd, string userName);

        bool HasAbbreviation(string name);
        bool HasName(string name);

    }
}
