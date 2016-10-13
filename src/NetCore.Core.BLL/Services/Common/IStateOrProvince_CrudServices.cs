using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.DataTransferObjects.Common;
using Dna.NetCore.Core.Common;
using System.Collections.Generic;

namespace Dna.NetCore.Core.BLL.Services.Common
{
    public interface IStateOrProvince_CrudServices
	{
        void Add(StateOrProvinceCmd cmd, string userName, out CustomMessage customMessage);
        void Delete(StateOrProvinceDto dto, string userName, out CustomMessage customMessage);
        void Update(StateOrProvinceCmd cmd, string userName, out CustomMessage customMessage);

        StateOrProvinceCmd Cmd_Create(string userName, out CustomMessage customMessage);

        StateOrProvinceCmd Cmd_SetPropertyValues(StateOrProvinceCmd cmd,
                                                            string abbreviation, string displayName,
                                                            decimal salesTaxRate = 0,
                                                            int countryId = 0, string countryAbbeviation = "",
                                                            ICollection<TimeZoneCmd> timeZones = null,
                                                            List<CountyCmd> counties = null,
                                                            List<CityCmd> cities = null,
                                                            bool isShippingAllowed = true,
                                                            bool isActive = true);
    }
}
