using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.Services.Common;
using Dna.NetCore.Core.BLL.Services.Localization;
using Dna.NetCore.Core.Common;
using Dna.NetCore.Core.Initializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dna.NetCore.Core.BLL.Initializers.Common
{
    // http://en.wikipedia.org/wiki/ISO_3166-1_alpha-2
    public class CountrySeedData_enUS : ISeedData
    {
        #region Private Fields

        private readonly ICity_CrudServices _cityCrudServices;
        private readonly ICity_Queries _cityQueries;
        private readonly ICounty_CrudServices _countyCrudServices;
        private readonly ICounty_Queries _countyQueries;
        private readonly ICountry_CrudServices _countryCrudServices;
        private readonly ICountry_Queries _countryQueries;
        private readonly IStateOrProvince_CrudServices _stateOrProvinceCrudServices;
        private readonly ICurrency_Queries _currencyQueries;
        private readonly ILocale_Queries _localeQueries;
        private readonly ITimeZone_Queries _timeZoneQueries;
        private readonly ITimeZone_CrudServices _timeZoneCrudServices;

        private string _userName;
        private CustomMessage _customMessage;

        #endregion

        #region Ctor

        public CountrySeedData_enUS(ICity_CrudServices cityCrudServices,
                                    ICity_Queries cityQueries,
                                    ICounty_CrudServices countyCrudServices,
                                    ICounty_Queries countyQueries, ICountry_CrudServices countryCrudServices,
                                    ICountry_Queries countryQueries,
                                    IStateOrProvince_CrudServices stateProvinceCrudServices,
                                    ICurrency_Queries currencyQueries,
                                    ILocale_Queries localeQueries,
                                    ITimeZone_CrudServices timeZoneCrudServices,
                                    ITimeZone_Queries timeZoneQueries)
        {
            _cityCrudServices = cityCrudServices;
            _cityQueries = cityQueries;
            _countyCrudServices = countyCrudServices;
            _countyQueries = countyQueries;
            _countryCrudServices = countryCrudServices;
            _countryQueries = countryQueries;
            _stateOrProvinceCrudServices = stateProvinceCrudServices;
            _currencyQueries = currencyQueries;
            _localeQueries = localeQueries;
            _timeZoneCrudServices = timeZoneCrudServices;
            _timeZoneQueries = timeZoneQueries;
        }

        #endregion

        #region Methods

        public CustomMessage Execute(string administratorName)
        {
            _userName = administratorName;

            _customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            GenerateCountries();

            return _customMessage;
        }

        private void GenerateCountries()
        {
            int addSuccessCount = 0;
            int addFailureCount = 0;

            List<CountryCmd> entities = GenerateCountryList();

            foreach (var entity in entities)
            {
                CustomMessage customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

                _countryCrudServices.Add(entity, _userName, out customMessage);

                if (customMessage == null)
                {
                    customMessage = new CustomMessage()
                    {
                        MessageDictionary1 = new Dictionary<string, string>(),
                        MessageDictionary2 = new Dictionary<string, string>(),
                        IsErrorCondition = true,
                        Message = "_countryCrudServices.Add() - null returned"
                    };
                    addFailureCount++;
                }
                else
                {
                    if (customMessage.MessageDictionary1 != null && customMessage.MessageDictionary1.ContainsKey("AddId"))
                        addSuccessCount++;
                    else
                        addFailureCount++;
                    // TODO: refactor for child entity counts
                }
            }

            AddResultCountsToCustomMessage("Countries", addSuccessCount, addFailureCount);
        }

        private CountryCmd GenerateCountry(string abbreviation, string name,
                                            List<StateOrProvinceCmd> stateProvinces,
                                            string phoneNumberCountryCode = "",
                                            string currencyCode = "", int lcidDecimal = 0,
                                            bool isactive = true,
                                            bool isShippingAllowed = true, bool isVatEnabled = false)
        {
            CustomMessage customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            CountryCmd cmd = _countryCrudServices.Cmd_Create(_userName, out customMessage, phoneNumberCountryCode, currencyCode, lcidDecimal);

            if (cmd == null)
                return null;

            cmd.Abbreviation = abbreviation;
            cmd.DisplayName = name;
            cmd.StateOrProvinces = stateProvinces;

            // default values
            cmd.IsActive = isactive;
            cmd.IsShippingAllowed = isShippingAllowed;
            cmd.IsVatEnabled = isVatEnabled;

            return cmd;
        }

        private List<CountryCmd> GenerateCountryList()
        {
            List<CountryCmd> list = new List<CountryCmd>();

            //list.Add(GenerateCountry("xx", "Please Select", new List<StateOrProvinceCmd>()));  // KendoUI <select> will add this option automatically
            list.Add(GenerateCountry("US", "United States of America",
                                        GenerateStateOrProvinceList_US(), "1", "USD", 1033));
            list.Add(GenerateCountry("AF", "Afghanistan", new List<StateOrProvinceCmd>(), "93"));
            list.Add(GenerateCountry("AX", "Aland Islands", new List<StateOrProvinceCmd>(), "358"));
            list.Add(GenerateCountry("AL", "Albania", new List<StateOrProvinceCmd>(), "355"));
            list.Add(GenerateCountry("DZ", "Algeria", new List<StateOrProvinceCmd>(), "213"));
            list.Add(GenerateCountry("AS", "American Samoa", new List<StateOrProvinceCmd>(), "1"));
            list.Add(GenerateCountry("AD", "Andorra", new List<StateOrProvinceCmd>(), "376"));
            list.Add(GenerateCountry("AO", "Angola", new List<StateOrProvinceCmd>(), "244"));

            //TODO: complete hydrating LocaleID

            list.Add(GenerateCountry("AI", "Anguilla", new List<StateOrProvinceCmd>(), "1"));
            list.Add(GenerateCountry("AQ", "Antarctica", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("AG", "Antigua And Barbuda", new List<StateOrProvinceCmd>(), "1-268"));
            list.Add(GenerateCountry("AR", "Argentina", new List<StateOrProvinceCmd>(), "254", "ARS"));
            list.Add(GenerateCountry("AM", "Armenia", new List<StateOrProvinceCmd>(), "374"));
            list.Add(GenerateCountry("AW", "Aruba", new List<StateOrProvinceCmd>(), "297"));
            list.Add(GenerateCountry("AU", "Australia", new List<StateOrProvinceCmd>(), "61", "AUD"));
            list.Add(GenerateCountry("AT", "Austria", new List<StateOrProvinceCmd>(), "43"));
            list.Add(GenerateCountry("AZ", "Azerbaijan", new List<StateOrProvinceCmd>(), "994"));
            list.Add(GenerateCountry("BS", "Bahamas", new List<StateOrProvinceCmd>(), "1-242"));
            list.Add(GenerateCountry("BH", "Bahrain", new List<StateOrProvinceCmd>(), "973"));
            list.Add(GenerateCountry("BD", "Bangladesh", new List<StateOrProvinceCmd>(), "880"));
            list.Add(GenerateCountry("BB", "Barbados", new List<StateOrProvinceCmd>(), "1-246"));
            list.Add(GenerateCountry("BY", "Belarus", new List<StateOrProvinceCmd>(), "375"));
            list.Add(GenerateCountry("BE", "Belgium", new List<StateOrProvinceCmd>(), "32"));
            list.Add(GenerateCountry("BZ", "Belize", new List<StateOrProvinceCmd>(), "501"));
            list.Add(GenerateCountry("BJ", "Benin", new List<StateOrProvinceCmd>(), "229"));
            list.Add(GenerateCountry("BM", "Bermuda", new List<StateOrProvinceCmd>(), "1-411"));
            list.Add(GenerateCountry("BT", "Bhutan", new List<StateOrProvinceCmd>(), "975"));
            list.Add(GenerateCountry("BO", "Bolivia, Plurinational State Of", new List<StateOrProvinceCmd>(), "591"));
            list.Add(GenerateCountry("BQ", "Bonaire, Saint Eustatius And SabaCountry", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("BA", "Bosnia And Herzegovina", new List<StateOrProvinceCmd>(), "387"));
            list.Add(GenerateCountry("BW", "Botswana", new List<StateOrProvinceCmd>(), "267"));
            list.Add(GenerateCountry("BV", "Bouvet IslandBWBW", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("BR", "Brazil", new List<StateOrProvinceCmd>(), "55"));
            list.Add(GenerateCountry("IO", "British Indian Ocean Territory", new List<StateOrProvinceCmd>(), "1-284"));
            list.Add(GenerateCountry("BN", "Brunei Darussalam", new List<StateOrProvinceCmd>(), "673"));
            list.Add(GenerateCountry("BG", "Bulgaria", new List<StateOrProvinceCmd>(), "359"));
            list.Add(GenerateCountry("BF", "Burkina Faso", new List<StateOrProvinceCmd>(), "226"));
            list.Add(GenerateCountry("BI", "Burundi", new List<StateOrProvinceCmd>(), "257"));
            list.Add(GenerateCountry("KH", "Cambodia", new List<StateOrProvinceCmd>(), "855"));
            list.Add(GenerateCountry("CM", "Cameroon", new List<StateOrProvinceCmd>(), "237"));
            list.Add(GenerateCountry("CA", "Canada",
                                        GenerateStateOrProvinceList_CA(), "1", "CAD"));
            list.Add(GenerateCountry("CV", "Cape Verde", new List<StateOrProvinceCmd>(), "238"));
            list.Add(GenerateCountry("KY", "Cayman Islands", new List<StateOrProvinceCmd>(), "1-345"));
            list.Add(GenerateCountry("CF", "Central African Republic", new List<StateOrProvinceCmd>(), "236"));
            list.Add(GenerateCountry("TD", "Chad", new List<StateOrProvinceCmd>(), "235"));
            list.Add(GenerateCountry("CL", "Chile", new List<StateOrProvinceCmd>(), "56"));
            list.Add(GenerateCountry("CN", "China", new List<StateOrProvinceCmd>(), "86", "CNY"));
            list.Add(GenerateCountry("CX", "Christmas Island", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("CC", "Cocos (Keeling) Islands", new List<StateOrProvinceCmd>(), "61"));
            list.Add(GenerateCountry("CO", "Columbia", new List<StateOrProvinceCmd>(), "57"));
            list.Add(GenerateCountry("KM", "Comoros", new List<StateOrProvinceCmd>(), "269"));
            list.Add(GenerateCountry("CG", "Congo", new List<StateOrProvinceCmd>(), "242"));
            list.Add(GenerateCountry("CD", "Congo, The Democratic Republic Of The", new List<StateOrProvinceCmd>(), "243"));
            list.Add(GenerateCountry("CK", "Cook Islands", new List<StateOrProvinceCmd>(), "682"));
            list.Add(GenerateCountry("CR", "Costa Rica", new List<StateOrProvinceCmd>(), "506"));
            list.Add(GenerateCountry("CI", "Cote D'Ivoire", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("HR", "Croatia", new List<StateOrProvinceCmd>(), "385"));
            list.Add(GenerateCountry("CU", "Cuba", new List<StateOrProvinceCmd>(), "53"));
            list.Add(GenerateCountry("CW", "Curacao", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("CY", "Cyprus", new List<StateOrProvinceCmd>(), "357"));
            list.Add(GenerateCountry("CZ", "Czech Republic", new List<StateOrProvinceCmd>(), "420"));
            list.Add(GenerateCountry("DK", "Denmark", new List<StateOrProvinceCmd>(), "45", "DKK"));
            list.Add(GenerateCountry("DJ", "Djubouti", new List<StateOrProvinceCmd>(), "253"));
            list.Add(GenerateCountry("DM", "Dominica", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("DO", "Dominican Republic", new List<StateOrProvinceCmd>(), "1-809"));
            list.Add(GenerateCountry("EC", "Ecuador", new List<StateOrProvinceCmd>(), "593"));
            list.Add(GenerateCountry("EG", "Egypt", new List<StateOrProvinceCmd>(), "20"));
            list.Add(GenerateCountry("SV", "El Salvador", new List<StateOrProvinceCmd>(), "503"));
            list.Add(GenerateCountry("GQ", "Equatorial Guinea", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("ER", "Eritrea", new List<StateOrProvinceCmd>(), "291"));
            list.Add(GenerateCountry("EE", "Estonia", new List<StateOrProvinceCmd>(), "372"));
            list.Add(GenerateCountry("ET", "Ethiopia", new List<StateOrProvinceCmd>(), "251"));
            list.Add(GenerateCountry("FK", "Falkland Islands (Malvinas)", new List<StateOrProvinceCmd>(), "500"));
            list.Add(GenerateCountry("FO", "Faroe Islands", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("FJ", "Fiji", new List<StateOrProvinceCmd>(), "679"));
            list.Add(GenerateCountry("FI", "Finland", new List<StateOrProvinceCmd>(), "358"));
            list.Add(GenerateCountry("FR", "France", new List<StateOrProvinceCmd>(), "33"));
            list.Add(GenerateCountry("GF", "French Guiana", new List<StateOrProvinceCmd>(), "594"));
            list.Add(GenerateCountry("PF", "French Polynesia", new List<StateOrProvinceCmd>(), "689"));
            list.Add(GenerateCountry("TF", "French Southern Territories", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("GA", "Gabon", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("GM", "Gambia", new List<StateOrProvinceCmd>(), "220"));
            list.Add(GenerateCountry("GE", "Georgia", new List<StateOrProvinceCmd>(), "995"));
            list.Add(GenerateCountry("DE", "Germany", new List<StateOrProvinceCmd>(), "49", "EUR"));
            list.Add(GenerateCountry("GH", "Ghana", new List<StateOrProvinceCmd>(), "233"));
            list.Add(GenerateCountry("GI", "Gibraltar", new List<StateOrProvinceCmd>(), "350"));
            list.Add(GenerateCountry("GR", "Greece", new List<StateOrProvinceCmd>(), "30", "EUR"));
            list.Add(GenerateCountry("GL", "Greenland", new List<StateOrProvinceCmd>(), "299"));
            list.Add(GenerateCountry("GD", "Grenada", new List<StateOrProvinceCmd>(), "1-473"));
            list.Add(GenerateCountry("GP", "Guadeloupe", new List<StateOrProvinceCmd>(), "590"));
            list.Add(GenerateCountry("GU", "Guam", new List<StateOrProvinceCmd>(), "1-671"));
            list.Add(GenerateCountry("GT", "Guatemala", new List<StateOrProvinceCmd>(), "502"));
            list.Add(GenerateCountry("GG", "Guernsey", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("GN", "Guinea", new List<StateOrProvinceCmd>(), "224"));
            list.Add(GenerateCountry("GW", "Guinea-Bissau", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("GY", "Guyana", new List<StateOrProvinceCmd>(), "592"));
            list.Add(GenerateCountry("HT", "Haiti", new List<StateOrProvinceCmd>(), "509"));
            list.Add(GenerateCountry("HM", "Heard Island And McDonald Islands", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("VA", "Holy See (Vatican City State)", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("HN", "Honduras", new List<StateOrProvinceCmd>(), "504"));
            list.Add(GenerateCountry("HK", "Hong Kong", new List<StateOrProvinceCmd>(), "852", "HKD"));
            list.Add(GenerateCountry("HU", "Hungary", new List<StateOrProvinceCmd>(), "36"));
            list.Add(GenerateCountry("IS", "Iceland", new List<StateOrProvinceCmd>(), "354"));
            list.Add(GenerateCountry("IN", "India", new List<StateOrProvinceCmd>(), "91"));
            list.Add(GenerateCountry("Id", "Indonesia", new List<StateOrProvinceCmd>(), "IDR"));
            list.Add(GenerateCountry("IR", "Iran, Islamic Republic Of", new List<StateOrProvinceCmd>(), "98"));
            list.Add(GenerateCountry("IQ", "Iraq", new List<StateOrProvinceCmd>(), "964"));
            list.Add(GenerateCountry("IE", "Ireland", new List<StateOrProvinceCmd>(), "353"));
            list.Add(GenerateCountry("IM", "Isle Of Man", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("IL", "Isreal", new List<StateOrProvinceCmd>(), "972"));
            list.Add(GenerateCountry("IT", "Italy", new List<StateOrProvinceCmd>(), "39"));
            list.Add(GenerateCountry("JM", "Jamaica", new List<StateOrProvinceCmd>(), "1-876"));
            list.Add(GenerateCountry("JP", "Japan", new List<StateOrProvinceCmd>(), "81", "JPY"));
            list.Add(GenerateCountry("JE", "Jersey", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("JO", "Jordan", new List<StateOrProvinceCmd>(), "962"));
            list.Add(GenerateCountry("KZ", "Kazakhstan", new List<StateOrProvinceCmd>(), "77"));
            list.Add(GenerateCountry("KE", "Kenya", new List<StateOrProvinceCmd>(), "254"));
            list.Add(GenerateCountry("KI", "Kiribati", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("KP", "Korea, Democratic People's Republic Of", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("KR", "Korea, Republic Of", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("KW", "Kuwait", new List<StateOrProvinceCmd>(), "965"));
            list.Add(GenerateCountry("KG", "Kyrgyzstan", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("LA", "Lao People's Democratic Republic", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("LV", "Latvia", new List<StateOrProvinceCmd>(), "371"));
            list.Add(GenerateCountry("LB", "Lebanon", new List<StateOrProvinceCmd>(), "961"));
            list.Add(GenerateCountry("LS", "Lesotho", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("LR", "Liberia", new List<StateOrProvinceCmd>(), "231"));
            list.Add(GenerateCountry("LY", "Libyan Arab Jamahiriya", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("LI", "Liechtenstein", new List<StateOrProvinceCmd>(), "423"));
            list.Add(GenerateCountry("LT", "Lithuania", new List<StateOrProvinceCmd>(), "370"));
            list.Add(GenerateCountry("LU", "Luxembourg", new List<StateOrProvinceCmd>(), "352"));
            list.Add(GenerateCountry("MO", "Macao", new List<StateOrProvinceCmd>(), "853"));
            list.Add(GenerateCountry("MK", "Macedonia, The Former Yugoslav Republic Of", new List<StateOrProvinceCmd>(), "261"));
            list.Add(GenerateCountry("MG", "Madagascar", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("MW", "Malawi", new List<StateOrProvinceCmd>(), "265"));
            list.Add(GenerateCountry("MY", "Malaysia", new List<StateOrProvinceCmd>(), "60"));
            list.Add(GenerateCountry("MV", "Maldives", new List<StateOrProvinceCmd>(), "960"));
            list.Add(GenerateCountry("ML", "Mali", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("MT", "Malta", new List<StateOrProvinceCmd>(), "356"));
            list.Add(GenerateCountry("MH", "Marshall Islands", new List<StateOrProvinceCmd>(), "692"));
            list.Add(GenerateCountry("MQ", "Martinique", new List<StateOrProvinceCmd>(), "596"));
            list.Add(GenerateCountry("MR", "Mauritania", new List<StateOrProvinceCmd>(), "222"));
            list.Add(GenerateCountry("MU", "Mauritius", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("YT", "Mayotte", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("MX", "Mexico", new List<StateOrProvinceCmd>(), "52"));
            list.Add(GenerateCountry("FM", "Micronesia, Federated States Of", new List<StateOrProvinceCmd>(), "691"));
            list.Add(GenerateCountry("MD", "Moldova, Republic Of", new List<StateOrProvinceCmd>(), "373"));
            list.Add(GenerateCountry("MC", "Monaco", new List<StateOrProvinceCmd>(), "377"));
            list.Add(GenerateCountry("MN", "Mongolia", new List<StateOrProvinceCmd>(), "976"));
            list.Add(GenerateCountry("ME", "Montenegro", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("MS", "Montserrat", new List<StateOrProvinceCmd>(), "1-664"));
            list.Add(GenerateCountry("MA", "Morocco", new List<StateOrProvinceCmd>(), "212"));
            list.Add(GenerateCountry("MZ", "Mozambique", new List<StateOrProvinceCmd>(), "258"));
            list.Add(GenerateCountry("MM", "Myanmar", new List<StateOrProvinceCmd>(), "95"));
            list.Add(GenerateCountry("NA", "Namibia", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("NR", "Nauru", new List<StateOrProvinceCmd>(), "674"));
            list.Add(GenerateCountry("NP", "Nepal", new List<StateOrProvinceCmd>(), "977"));
            list.Add(GenerateCountry("NL", "Netherlands", new List<StateOrProvinceCmd>(), "31"));
            list.Add(GenerateCountry("NC", "New Caledonia", new List<StateOrProvinceCmd>(), "687"));
            list.Add(GenerateCountry("NZ", "New Zealand", new List<StateOrProvinceCmd>(), "64", "NZD"));
            list.Add(GenerateCountry("NI", "Nicaragua", new List<StateOrProvinceCmd>(), "505"));
            list.Add(GenerateCountry("NE", "Niger", new List<StateOrProvinceCmd>(), "227"));
            list.Add(GenerateCountry("NG", "Nigeria", new List<StateOrProvinceCmd>(), "234"));
            list.Add(GenerateCountry("NU", "Niue", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("NF", "Norfold Island", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("MP", "Northern Mariana Islands", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("NO", "Norway", new List<StateOrProvinceCmd>(), "47", "NOK"));
            list.Add(GenerateCountry("OM", "Oman", new List<StateOrProvinceCmd>(), "968"));
            list.Add(GenerateCountry("PK", "Pakistan", new List<StateOrProvinceCmd>(), "92"));
            list.Add(GenerateCountry("PW", "Palau", new List<StateOrProvinceCmd>(), "680"));
            list.Add(GenerateCountry("PS", "Palestinian Territory, Occupied", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("PA", "Panama", new List<StateOrProvinceCmd>(), "507"));
            list.Add(GenerateCountry("PG", "Papua New Guinea", new List<StateOrProvinceCmd>(), "675"));
            list.Add(GenerateCountry("PY", "Paraguay", new List<StateOrProvinceCmd>(), "675"));
            list.Add(GenerateCountry("PE", "Peru", new List<StateOrProvinceCmd>(), "51"));
            list.Add(GenerateCountry("PH", "Philippines", new List<StateOrProvinceCmd>(), "63"));
            list.Add(GenerateCountry("PN", "Pitcairn", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("PL", "Poland", new List<StateOrProvinceCmd>(), "48"));
            list.Add(GenerateCountry("PT", "Portugal", new List<StateOrProvinceCmd>(), "351"));
            list.Add(GenerateCountry("PR", "Puerto Rico", new List<StateOrProvinceCmd>(), "1-787"));
            list.Add(GenerateCountry("QA", "Qatar", new List<StateOrProvinceCmd>(), "974"));
            list.Add(GenerateCountry("RE", "Reunion", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("RO", "Romania", new List<StateOrProvinceCmd>(), "40", "RON"));
            list.Add(GenerateCountry("RU", "Russian Federation", new List<StateOrProvinceCmd>(), "7", "RUB"));
            list.Add(GenerateCountry("RW", "Rwanda", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("BL", "Saint Barthelemy", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("SH", "Saint Helena, Ascension And Tristan Da Cunha", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("KN", "Saint Kitts And Nevis", new List<StateOrProvinceCmd>(), "1-869"));
            list.Add(GenerateCountry("LC", "Saint Lucia", new List<StateOrProvinceCmd>(), "758"));
            list.Add(GenerateCountry("MF", "Saint Martin (French Part)", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("PM", "Saint Pierre And Miquelon", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("VC", "Saint Vincent And The Grenadines", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("WS", "Samoa", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("SM", "San Marino", new List<StateOrProvinceCmd>(), "378"));
            list.Add(GenerateCountry("ST", "Sao Tome And Principe", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("SA", "Saudi Arabia", new List<StateOrProvinceCmd>(), "966", "SAR"));
            list.Add(GenerateCountry("SN", "Senegal", new List<StateOrProvinceCmd>(), "221"));
            list.Add(GenerateCountry("RS", "Serbia", new List<StateOrProvinceCmd>(), "381"));
            list.Add(GenerateCountry("SC", "Seychelles", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("SL", "Sierra Leone", new List<StateOrProvinceCmd>(), "232"));
            list.Add(GenerateCountry("SG", "Singapore", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("SX", "Sint Maarten (Dutch Part)", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("SK", "Slovakia", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("SI", "Slovenia", new List<StateOrProvinceCmd>(), "386"));
            list.Add(GenerateCountry("SB", "Solomon Islands", new List<StateOrProvinceCmd>(), "677"));
            list.Add(GenerateCountry("SO", "Somalia", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("ZA", "South Africa", new List<StateOrProvinceCmd>(), "27", "ZAR"));
            list.Add(GenerateCountry("GS", "South Georgia And The South Sandwich Islands", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("ES", "Spain", new List<StateOrProvinceCmd>(), "34"));
            list.Add(GenerateCountry("LK", "Sri Lanka", new List<StateOrProvinceCmd>(), "94"));
            list.Add(GenerateCountry("SD", "Sudan", new List<StateOrProvinceCmd>(), "249"));
            list.Add(GenerateCountry("SR", "Suriname", new List<StateOrProvinceCmd>(), "597"));
            list.Add(GenerateCountry("SJ", "Svalbard And Jan Mayen", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("SZ", "Swaziland", new List<StateOrProvinceCmd>(), "268"));
            list.Add(GenerateCountry("SE", "Sweden", new List<StateOrProvinceCmd>(), "46", "SEK"));
            list.Add(GenerateCountry("CH", "Switzerland", new List<StateOrProvinceCmd>(), "41", "CHF"));
            list.Add(GenerateCountry("SY", "Syrian Arab Republic", new List<StateOrProvinceCmd>(), "963"));
            list.Add(GenerateCountry("TW", "Taiwan, Province Of China", new List<StateOrProvinceCmd>(), "TWD"));
            list.Add(GenerateCountry("TJ", "Tajikistan", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("TZ", "Tanzania, United Republic Of", new List<StateOrProvinceCmd>(), "255"));
            list.Add(GenerateCountry("TH", "Thailand", new List<StateOrProvinceCmd>(), "66"));
            list.Add(GenerateCountry("TL", "Timor-Leste", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("TG", "Togo", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("TK", "Tokelau", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("TO", "Tonga", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("TT", "Trinidad And Tobago", new List<StateOrProvinceCmd>(), "1-868"));
            list.Add(GenerateCountry("TN", "Tunisia", new List<StateOrProvinceCmd>(), "216"));
            list.Add(GenerateCountry("TR", "Turkey", new List<StateOrProvinceCmd>(), "90", "TRY"));
            list.Add(GenerateCountry("TM", "Turkmenistan", new List<StateOrProvinceCmd>(), "993"));
            list.Add(GenerateCountry("TC", "Turks And Caicos Islands", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("TV", "Tuvalu", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("UG", "Uganda", new List<StateOrProvinceCmd>(), "256"));
            list.Add(GenerateCountry("UA", "Ukraine", new List<StateOrProvinceCmd>(), "380"));
            list.Add(GenerateCountry("AE", "United Arab Emirates", new List<StateOrProvinceCmd>(), "971"));
            list.Add(GenerateCountry("GB", "United Kingdom", new List<StateOrProvinceCmd>(), "44"));
            list.Add(GenerateCountry("UM", "United States Minor Outlying Islands", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("UY", "Uruguay", new List<StateOrProvinceCmd>(), "598"));
            list.Add(GenerateCountry("UZ", "Uzbekistan", new List<StateOrProvinceCmd>(), "998"));
            list.Add(GenerateCountry("VU", "Vanuatu", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("VE", "Venezuela, Bolivarian Republic Of", new List<StateOrProvinceCmd>(), "58"));
            list.Add(GenerateCountry("VN", "Viet Nam", new List<StateOrProvinceCmd>(), "84"));
            list.Add(GenerateCountry("VG", "Virgin Islands, British", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("VI", "Virgin Islands, U.S.", new List<StateOrProvinceCmd>(), "1-370"));
            list.Add(GenerateCountry("WF", "Wallis And Futuna", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("EH", "Western Sahara", new List<StateOrProvinceCmd>(), ""));
            list.Add(GenerateCountry("YE", "Yemen", new List<StateOrProvinceCmd>(), "967"));
            list.Add(GenerateCountry("ZM", "Zambia", new List<StateOrProvinceCmd>(), "260"));
            list.Add(GenerateCountry("ZW", "Zimbabwe", new List<StateOrProvinceCmd>(), "263"));

            return list;
        }

        private StateOrProvinceCmd GenerateStateOrProvince(string abbreviation, string displayName,
                                                            string countryAbbreviation, decimal salesTaxRate,
                                                            ICollection<TimeZoneCmd> timeZones = null,
                                                            List<CountyCmd> countyList = null,
                                                            List<CityCmd> cityList = null,
                                                            bool isShippingAllowed = true,
                                                            bool isActive = true
                                                            )
        {
            CustomMessage customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            StateOrProvinceCmd cmd = _stateOrProvinceCrudServices.Cmd_Create(_userName, out customMessage);

            if (cmd == null)
                return null;

            int countryId = 0;
            cmd = _stateOrProvinceCrudServices.Cmd_SetPropertyValues(cmd, abbreviation, displayName, salesTaxRate, countryId, countryAbbreviation,
                                                                     timeZones, countyList, cityList, isShippingAllowed, isActive);

            return cmd;
        }

        private List<StateOrProvinceCmd> GenerateStateOrProvinceList_CA()
        {
            List<StateOrProvinceCmd> list = new List<StateOrProvinceCmd>();

            list.Add(GenerateStateOrProvince("ON", "Ontario", "CA", 0, null, null, GenerateCityList_CA_ON()));
            list.Add(GenerateStateOrProvince("QC", "Quebec", "CA", 0, null, null, GenerateCityList_CA_QC()));
            list.Add(GenerateStateOrProvince("NS", "Nova Scotia", "CA", 0, null, null, GenerateCityList_CA_NS()));
            list.Add(GenerateStateOrProvince("NB", "New Brunswick", "CA", 0, null, null, GenerateCityList_CA_NB()));
            list.Add(GenerateStateOrProvince("MB", "Manitoba", "CA", 0, null, null, GenerateCityList_CA_MB()));
            list.Add(GenerateStateOrProvince("BC", "British Columbia", "CA", 0, null, null, GenerateCityList_CA_BC()));
            list.Add(GenerateStateOrProvince("PE", "Prince Edward Island", "CA", 0, null, null, GenerateCityList_CA_PE()));
            list.Add(GenerateStateOrProvince("SK", "Saskatchewan", "CA", 0, null, null, GenerateCityList_CA_SK()));
            list.Add(GenerateStateOrProvince("AB", "Alberta", "CA", 0, null, null, GenerateCityList_CA_AB()));
            list.Add(GenerateStateOrProvince("NL", "Newfoundland and Labrador", "CA", 0, null, null, GenerateCityList_CA_NL()));

            return list;
        }

        private List<StateOrProvinceCmd> GenerateStateOrProvinceList_US()
        {
            List<StateOrProvinceCmd> list = new List<StateOrProvinceCmd>();

            // DEVNOTE: some states are split between 2 time zones - in those cases, I arbitrarily selected one for the default
            //list.Add(GenerateStateOrProvince("xx", "Please Select", "US"));   // would end up with duplicate "Please Select" display names for each countries StateOrProvices // KendoUI <select> will add this option automatically
            list.Add(GenerateStateOrProvince("AL", "Alabama", "US", 0, GenerateTimeZoneList(new[] { "(UTC-06:00) Central Time (US & Canada)" })));
            list.Add(GenerateStateOrProvince("AK", "Alaska", "US", 0, GenerateTimeZoneList(new[] { "(UTC-09:00) Alaska" })));
            list.Add(GenerateStateOrProvince("AZ", "Arizona", "US", 0, GenerateTimeZoneList(new[] { "(UTC-07:00) Arizona" })));
            list.Add(GenerateStateOrProvince("AR", "Arkansas", "US", 0, GenerateTimeZoneList(new[] { "(UTC-06:00) Central Time (US & Canada)" })));
            list.Add(GenerateStateOrProvince("CA", "California", "US", 0, GenerateTimeZoneList(new[] { "(UTC-08:00) Pacific Time (US & Canada)" })));
            list.Add(GenerateStateOrProvince("CO", "Colorado", "US", 0, GenerateTimeZoneList(new[] { "(UTC-07:00) Mountain Time (US & Canada)" })));
            list.Add(GenerateStateOrProvince("CT", "Connecticut", "US", 0, GenerateTimeZoneList(new[] { "(UTC-05:00) Eastern Time (US & Canada)" })));
            list.Add(GenerateStateOrProvince("DE", "Delaware", "US", 0, GenerateTimeZoneList(new[] { "(UTC-05:00) Eastern Time (US & Canada)" })));
            list.Add(GenerateStateOrProvince("FL", "Florida", "US", 0, GenerateTimeZoneList(new[] { "(UTC-05:00) Eastern Time (US & Canada)" })));
            list.Add(GenerateStateOrProvince("GA", "Georgia", "US", 0, GenerateTimeZoneList(new[] { "(UTC-05:00) Eastern Time (US & Canada)" })));
            list.Add(GenerateStateOrProvince("HI", "Hawaii", "US", 0, GenerateTimeZoneList(new[] { "(UTC-10:00) Hawaii" })));
            list.Add(GenerateStateOrProvince("Id", "Idaho", "US", 0, GenerateTimeZoneList(new[] { "(UTC-07:00) Mountain Time (US & Canada)" })));
            list.Add(GenerateStateOrProvince("IL", "Illinois", "US", 0, GenerateTimeZoneList(new[] { "(UTC-06:00) Central Time (US & Canada)" })));
            list.Add(GenerateStateOrProvince("IN", "Indiana", "US", 0, GenerateTimeZoneList(new[] { "(UTC-05:00) Indiana (East)" })));
            list.Add(GenerateStateOrProvince("IA", "Iowa", "US", 0, GenerateTimeZoneList(new[] { "(UTC-06:00) Central Time (US & Canada)" })));
            list.Add(GenerateStateOrProvince("KS", "Kansas", "US", 0, GenerateTimeZoneList(new[] { "(UTC-07:00) Mountain Time (US & Canada)" })));
            list.Add(GenerateStateOrProvince("KY", "Kentucky", "US", 0, GenerateTimeZoneList(new[] { "(UTC-06:00) Central Time (US & Canada)" })));
            list.Add(GenerateStateOrProvince("LA", "Louisiana", "US", 0, GenerateTimeZoneList(new[] { "(UTC-06:00) Central Time (US & Canada)" })));
            list.Add(GenerateStateOrProvince("ME", "Maine", "US", 0, GenerateTimeZoneList(new[] { "(UTC-05:00) Eastern Time (US & Canada)" })));
            list.Add(GenerateStateOrProvince("MD", "Maryland", "US", 0, GenerateTimeZoneList(new[] { "(UTC-05:00) Eastern Time (US & Canada)" })));
            list.Add(GenerateStateOrProvince("MA", "Massachusetts", "US", 0, GenerateTimeZoneList(new[] { "(UTC-05:00) Eastern Time (US & Canada)" })));
            list.Add(GenerateStateOrProvince("MI", "Michigan", "US", 0, GenerateTimeZoneList(new[] { "(UTC-06:00) Central Time (US & Canada)" })));
            list.Add(GenerateStateOrProvince("MN", "Minnesota", "US", 0, GenerateTimeZoneList(new[] { "(UTC-06:00) Central Time (US & Canada)" })));
            list.Add(GenerateStateOrProvince("MS", "Mississippi", "US", 0, GenerateTimeZoneList(new[] { "(UTC-06:00) Central Time (US & Canada)" })));
            list.Add(GenerateStateOrProvince("MO", "Missouri", "US", 0, GenerateTimeZoneList(new[] { "(UTC-06:00) Central Time (US & Canada)" })));
            list.Add(GenerateStateOrProvince("MT", "Montana", "US", 0, GenerateTimeZoneList(new[] { "(UTC-07:00) Mountain Time (US & Canada)" })));
            list.Add(GenerateStateOrProvince("NE", "Nebraska", "US", 0, GenerateTimeZoneList(new[] { "(UTC-06:00) Central Time (US & Canada)" })));
            list.Add(GenerateStateOrProvince("NV", "Nevada", "US", 0, GenerateTimeZoneList(new[] { "(UTC-07:00) Mountain Time (US & Canada)" })));
            list.Add(GenerateStateOrProvince("NH", "New Hampshire", "US", 0, GenerateTimeZoneList(new[] { "(UTC-05:00) Eastern Time (US & Canada)" })));
            list.Add(GenerateStateOrProvince("NJ", "New Jersey", "US", 0.06M, GenerateTimeZoneList(new[] { "(UTC-05:00) Eastern Time (US & Canada)" }),
                                                GenerateCountyList_NJ(),
                                                GenerateCityList_US_NJ()));
            list.Add(GenerateStateOrProvince("NM", "New Mexico", "US", 0, GenerateTimeZoneList(new[] { "(UTC-07:00) Mountain Time (US & Canada)" })));
            list.Add(GenerateStateOrProvince("NY", "New York", "US", 0.0825M, GenerateTimeZoneList(new[] { "(UTC-05:00) Eastern Time (US & Canada)" })));
            list.Add(GenerateStateOrProvince("NC", "North Carolina", "US", 0, GenerateTimeZoneList(new[] { "(UTC-05:00) Eastern Time (US & Canada)" })));
            list.Add(GenerateStateOrProvince("ND", "North Dakota", "US", 0, GenerateTimeZoneList(new[] { "(UTC-06:00) Central Time (US & Canada)" })));
            list.Add(GenerateStateOrProvince("OH", "Ohio", "US", 0, GenerateTimeZoneList(new[] { "(UTC-05:00) Eastern Time (US & Canada)" })));
            list.Add(GenerateStateOrProvince("OK", "Oklahoma", "US", 0, GenerateTimeZoneList(new[] { "(UTC-06:00) Central Time (US & Canada)" })));
            list.Add(GenerateStateOrProvince("OR", "Oregon", "US", 0, GenerateTimeZoneList(new[] { "(UTC-08:00) Pacific Time (US & Canada)" })));
            list.Add(GenerateStateOrProvince("PA", "Pennsylvania", "US", 0.06M, GenerateTimeZoneList(new[] { "(UTC-05:00) Eastern Time (US & Canada)" }),
                                                GenerateCountyList_PA(),
                                                GenerateCityList_US_PA()));
            list.Add(GenerateStateOrProvince("RI", "Rhode Island", "US", 0, GenerateTimeZoneList(new[] { "(UTC-05:00) Eastern Time (US & Canada)" })));
            list.Add(GenerateStateOrProvince("SC", "South Carolina", "US", 0, GenerateTimeZoneList(new[] { "(UTC-05:00) Eastern Time (US & Canada)" })));
            list.Add(GenerateStateOrProvince("SD", "South Dakota", "US", 0, GenerateTimeZoneList(new[] { "(UTC-06:00) Central Time (US & Canada)" })));
            list.Add(GenerateStateOrProvince("TN", "Tennessee", "US", 0, GenerateTimeZoneList(new[] { "(UTC-05:00) Eastern Time (US & Canada)" })));
            list.Add(GenerateStateOrProvince("TX", "Texas", "US", 0, GenerateTimeZoneList(new[] { "(UTC-06:00) Central Time (US & Canada)" })));
            list.Add(GenerateStateOrProvince("UT", "Utah", "US", 0, GenerateTimeZoneList(new[] { "(UTC-07:00) Mountain Time (US & Canada)" })));
            list.Add(GenerateStateOrProvince("VT", "Vermont", "US", 0, GenerateTimeZoneList(new[] { "(UTC-05:00) Eastern Time (US & Canada)" })));
            list.Add(GenerateStateOrProvince("VA", "Virginia", "US", 0, GenerateTimeZoneList(new[] { "(UTC-05:00) Eastern Time (US & Canada)" })));
            list.Add(GenerateStateOrProvince("WA", "Washington", "US", 0, GenerateTimeZoneList(new[] { "(UTC-08:00) Pacific Time (US & Canada)" })));
            list.Add(GenerateStateOrProvince("WV", "West Virginia", "US", 0, GenerateTimeZoneList(new[] { "(UTC-05:00) Eastern Time (US & Canada)" })));
            list.Add(GenerateStateOrProvince("WI", "Wisconsin", "US", 0, GenerateTimeZoneList(new[] { "(UTC-06:00) Central Time (US & Canada)" })));
            list.Add(GenerateStateOrProvince("WY", "Wyoming", "US", 0, GenerateTimeZoneList(new[] { "(UTC-07:00) Mountain Time (US & Canada)" })));

            return list;
        }

        private List<CountyCmd> GenerateCountyList_NJ()
        {
            string stateAbbreviation = "NJ";

            List<CountyCmd> list = new List<CountyCmd>();

            list.Add(GenerateCounty("Atlantic", stateAbbreviation));
            list.Add(GenerateCounty("Bergen", stateAbbreviation));
            list.Add(GenerateCounty("Burlington", stateAbbreviation));
            list.Add(GenerateCounty("Camden", stateAbbreviation));
            list.Add(GenerateCounty("Cape May", stateAbbreviation));
            list.Add(GenerateCounty("Cumberland", stateAbbreviation));
            list.Add(GenerateCounty("Essex", stateAbbreviation));
            list.Add(GenerateCounty("Gloucester", stateAbbreviation));
            list.Add(GenerateCounty("Hudson", stateAbbreviation));
            list.Add(GenerateCounty("Hunterdon", stateAbbreviation));
            list.Add(GenerateCounty("Mercer", stateAbbreviation));
            list.Add(GenerateCounty("Middlesex", stateAbbreviation));
            list.Add(GenerateCounty("Monmouth", stateAbbreviation));
            list.Add(GenerateCounty("Morris", stateAbbreviation));
            list.Add(GenerateCounty("Ocean", stateAbbreviation));
            list.Add(GenerateCounty("Passaic", stateAbbreviation));
            list.Add(GenerateCounty("Salem", stateAbbreviation));
            list.Add(GenerateCounty("Somerset", stateAbbreviation));
            list.Add(GenerateCounty("Sussex", stateAbbreviation));
            list.Add(GenerateCounty("Union", stateAbbreviation));
            list.Add(GenerateCounty("Warren", stateAbbreviation));

            return list;
        }

        private List<CountyCmd> GenerateCountyList_PA()
        {
            string stateAbbreviation = "PA";

            List<CountyCmd> list = new List<CountyCmd>();

            list.Add(GenerateCounty("Erie", stateAbbreviation));
            list.Add(GenerateCounty("Crawford", stateAbbreviation));
            list.Add(GenerateCounty("Mercer", stateAbbreviation));
            list.Add(GenerateCounty("Lawrence", stateAbbreviation));
            list.Add(GenerateCounty("Beaver", stateAbbreviation));
            list.Add(GenerateCounty("Washington", stateAbbreviation));
            list.Add(GenerateCounty("Greene", stateAbbreviation));
            list.Add(GenerateCounty("Venango", stateAbbreviation));
            list.Add(GenerateCounty("Butler", stateAbbreviation));
            list.Add(GenerateCounty("Allegheny", stateAbbreviation));
            list.Add(GenerateCounty("Warren", stateAbbreviation));
            list.Add(GenerateCounty("Forest", stateAbbreviation));
            list.Add(GenerateCounty("Clarion", stateAbbreviation));
            list.Add(GenerateCounty("Armstrong", stateAbbreviation));
            list.Add(GenerateCounty("Westmoreland", stateAbbreviation));
            list.Add(GenerateCounty("Fayette", stateAbbreviation));
            list.Add(GenerateCounty("McKean", stateAbbreviation));
            list.Add(GenerateCounty("Elk", stateAbbreviation));
            list.Add(GenerateCounty("Jefferson", stateAbbreviation));
            list.Add(GenerateCounty("Indiana", stateAbbreviation));
            list.Add(GenerateCounty("Somerset", stateAbbreviation));
            list.Add(GenerateCounty("Cambria", stateAbbreviation));
            list.Add(GenerateCounty("Clearfield", stateAbbreviation));
            list.Add(GenerateCounty("Cameron", stateAbbreviation));
            list.Add(GenerateCounty("Potter", stateAbbreviation));
            list.Add(GenerateCounty("Clinton", stateAbbreviation));
            list.Add(GenerateCounty("Center", stateAbbreviation));
            list.Add(GenerateCounty("Huntington", stateAbbreviation));
            list.Add(GenerateCounty("Bedford", stateAbbreviation));
            list.Add(GenerateCounty("Fulton", stateAbbreviation));
            list.Add(GenerateCounty("Chambersburg", stateAbbreviation));
            list.Add(GenerateCounty("Cumberland", stateAbbreviation));
            list.Add(GenerateCounty("Perry", stateAbbreviation));
            list.Add(GenerateCounty("Juniata", stateAbbreviation));
            list.Add(GenerateCounty("Snyder", stateAbbreviation));
            list.Add(GenerateCounty("Union", stateAbbreviation));
            list.Add(GenerateCounty("Lycoming", stateAbbreviation));
            list.Add(GenerateCounty("Tioga", stateAbbreviation));
            list.Add(GenerateCounty("Bradford", stateAbbreviation));
            list.Add(GenerateCounty("Union", stateAbbreviation));
            list.Add(GenerateCounty("Montour", stateAbbreviation));
            list.Add(GenerateCounty("Columbia", stateAbbreviation));
            list.Add(GenerateCounty("Sullivan", stateAbbreviation));
            list.Add(GenerateCounty("North Cumberland", stateAbbreviation));
            list.Add(GenerateCounty("Dauphen", stateAbbreviation));
            list.Add(GenerateCounty("Schuylkill", stateAbbreviation));
            list.Add(GenerateCounty("Lebanon", stateAbbreviation));
            list.Add(GenerateCounty("Lancaster", stateAbbreviation));
            list.Add(GenerateCounty("York", stateAbbreviation));
            list.Add(GenerateCounty("Adams", stateAbbreviation));
            list.Add(GenerateCounty("Franklin", stateAbbreviation));
            list.Add(GenerateCounty("Lancaster", stateAbbreviation));
            list.Add(GenerateCounty("Berks", stateAbbreviation));
            list.Add(GenerateCounty("Lehigh", stateAbbreviation));
            list.Add(GenerateCounty("Clarion", stateAbbreviation));
            list.Add(GenerateCounty("Luzerne", stateAbbreviation));
            list.Add(GenerateCounty("Wyoming", stateAbbreviation));
            list.Add(GenerateCounty("Susquehanna", stateAbbreviation));
            list.Add(GenerateCounty("Lackawanna", stateAbbreviation));
            list.Add(GenerateCounty("Wayne", stateAbbreviation));
            list.Add(GenerateCounty("Pike", stateAbbreviation));
            list.Add(GenerateCounty("Monroe", stateAbbreviation));
            list.Add(GenerateCounty("Carbon", stateAbbreviation));
            list.Add(GenerateCounty("Northampton", stateAbbreviation));
            list.Add(GenerateCounty("Bucks", stateAbbreviation));
            list.Add(GenerateCounty("Montgomery", stateAbbreviation));
            list.Add(GenerateCounty("Delaware", stateAbbreviation));
            list.Add(GenerateCounty("Cheser", stateAbbreviation));

            return list;
        }

        private CountyCmd GenerateCounty(string name, string stateOrProvinceAbbreviation,
                                         bool isActive = true
                                        )
        {
            CustomMessage customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            CountyCmd cmd = _countyCrudServices.Cmd_Create(_userName, stateOrProvinceAbbreviation, out customMessage);

            if (cmd == null)
                return null;

            cmd.DisplayName = name;
            //cmd.StateOrProvinceAbbreviation = stateOrProvinceAbbreviation;

            // default values
            cmd.IsActive = isActive;

            return cmd;
        }

        private List<CityCmd> GenerateCityList_CA_AB()
        {
            string stateAbbreviation = "AB";

            List<CityCmd> list = new List<CityCmd>();

            list.Add(GenerateCity("Edmonton", "", stateAbbreviation));
            list.Add(GenerateCity("Calgary", "", stateAbbreviation));

            return list;
        }

        private List<CityCmd> GenerateCityList_CA_BC()
        {
            string stateAbbreviation = "BC";

            List<CityCmd> list = new List<CityCmd>();

            list.Add(GenerateCity("Vancouver", "", stateAbbreviation));
            list.Add(GenerateCity("Victoria", "", stateAbbreviation));

            return list;
        }

        private List<CityCmd> GenerateCityList_CA_MB()
        {
            string stateAbbreviation = "MB";

            List<CityCmd> list = new List<CityCmd>();

            list.Add(GenerateCity("Winnipeg", "", stateAbbreviation));

            return list;
        }

        private List<CityCmd> GenerateCityList_CA_NB()
        {
            string stateAbbreviation = "NB";

            List<CityCmd> list = new List<CityCmd>();

            list.Add(GenerateCity("Fredericton", "", stateAbbreviation));
            list.Add(GenerateCity("Moncton", "", stateAbbreviation));
            list.Add(GenerateCity("Saint John", "", stateAbbreviation));

            return list;
        }

        private List<CityCmd> GenerateCityList_CA_NL()
        {
            string stateAbbreviation = "NL";

            List<CityCmd> list = new List<CityCmd>();

            list.Add(GenerateCity("St. John's", "", stateAbbreviation));

            return list;
        }

        private List<CityCmd> GenerateCityList_CA_NS()
        {
            string stateAbbreviation = "NS";

            List<CityCmd> list = new List<CityCmd>();

            list.Add(GenerateCity("Halifax", "", stateAbbreviation));

            return list;
        }

        private List<CityCmd> GenerateCityList_CA_ON()
        {
            string stateAbbreviation = "CA";

            List<CityCmd> list = new List<CityCmd>();

            list.Add(GenerateCity("Toronto", "", stateAbbreviation));
            list.Add(GenerateCity("Ottawa", "", stateAbbreviation));
            list.Add(GenerateCity("Cornwall", "", stateAbbreviation));

            return list;
        }

        private List<CityCmd> GenerateCityList_CA_PE()
        {
            string stateAbbreviation = "PE";

            List<CityCmd> list = new List<CityCmd>();

            list.Add(GenerateCity("Charlottetown", "", stateAbbreviation));

            return list;
        }

        private List<CityCmd> GenerateCityList_CA_QC()
        {
            string stateAbbreviation = "QC";

            List<CityCmd> list = new List<CityCmd>();

            list.Add(GenerateCity("Quebec City", "", stateAbbreviation));
            list.Add(GenerateCity("Montreal", "", stateAbbreviation));

            return list;
        }

        private List<CityCmd> GenerateCityList_CA_SK()
        {
            string stateAbbreviation = "SK";

            List<CityCmd> list = new List<CityCmd>();

            list.Add(GenerateCity("Regina", "", stateAbbreviation));
            list.Add(GenerateCity("Saskatoon", "", stateAbbreviation));

            return list;
        }

        private List<CityCmd> GenerateCityList_US_NJ()
        {
            string stateAbbreviation = "NJ";

            List<CityCmd> list = new List<CityCmd>();

            list.Add(GenerateCity("Absecon", "", stateAbbreviation));
            list.Add(GenerateCity("Aberdeen Township", "", stateAbbreviation));
            list.Add(GenerateCity("Adelphia", "", stateAbbreviation));
            list.Add(GenerateCity("Alexandria Townshipv", "", stateAbbreviation));
            list.Add(GenerateCity("Allamuchy Township", "", stateAbbreviation));
            list.Add(GenerateCity("Allendale", "", stateAbbreviation));
            list.Add(GenerateCity("Allenhurst", "", stateAbbreviation));
            list.Add(GenerateCity("Allentown", "", stateAbbreviation));
            list.Add(GenerateCity("Alloway Township", "", stateAbbreviation));
            list.Add(GenerateCity("Alpha Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Alpine Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Andover Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Andover Township", "", stateAbbreviation));
            list.Add(GenerateCity("Asbury Park", "", stateAbbreviation));
            list.Add(GenerateCity("Atlantic City", "", stateAbbreviation));
            list.Add(GenerateCity("Atlantic Highlands", "", stateAbbreviation));
            list.Add(GenerateCity("Audubon Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Audubon Park Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Avalon", "", stateAbbreviation));
            list.Add(GenerateCity("Avon", "", stateAbbreviation));
            list.Add(GenerateCity("Barnegat Light", "", stateAbbreviation));
            list.Add(GenerateCity("Barnegat Township", "", stateAbbreviation));
            list.Add(GenerateCity("Barrington Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Bass River Township", "", stateAbbreviation));
            list.Add(GenerateCity("Bay Head Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Bayonne", "", stateAbbreviation));
            list.Add(GenerateCity("Beach Haven Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Beachwood Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Bedminster", "", stateAbbreviation));
            list.Add(GenerateCity("Bellmawr", "", stateAbbreviation));
            list.Add(GenerateCity("Belmar", "", stateAbbreviation));
            list.Add(GenerateCity("Belleville", "", stateAbbreviation));
            list.Add(GenerateCity("Belvidere Town", "", stateAbbreviation));
            list.Add(GenerateCity("Bergenfield", "", stateAbbreviation));
            list.Add(GenerateCity("Berkeley Township", "", stateAbbreviation));
            list.Add(GenerateCity("Berkeley Heights", "", stateAbbreviation));
            list.Add(GenerateCity("Berlin", "", stateAbbreviation));
            list.Add(GenerateCity("Berlin Township", "", stateAbbreviation));
            list.Add(GenerateCity("Bernards Township", "", stateAbbreviation));
            list.Add(GenerateCity("Bernardsville", "", stateAbbreviation));
            list.Add(GenerateCity("Bethlehem Township", "", stateAbbreviation));
            list.Add(GenerateCity("Beverly City", "", stateAbbreviation));
            list.Add(GenerateCity("Blairstown Township", "", stateAbbreviation));
            list.Add(GenerateCity("Bloomfield Township", "", stateAbbreviation));
            list.Add(GenerateCity("Bloomingdale Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Bloomsbury Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Bogota", "", stateAbbreviation));
            list.Add(GenerateCity("Boonton", "", stateAbbreviation));
            list.Add(GenerateCity("Boonton Township", "", stateAbbreviation));
            list.Add(GenerateCity("Bordentown, City of", "", stateAbbreviation));
            list.Add(GenerateCity("Bordentown Township", "", stateAbbreviation));
            list.Add(GenerateCity("Bound Brook Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Bradley Beach", "", stateAbbreviation));
            list.Add(GenerateCity("Branchburg", "", stateAbbreviation));
            list.Add(GenerateCity("Branchville Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Brick Township", "", stateAbbreviation));
            list.Add(GenerateCity("Bridgeton", "", stateAbbreviation));
            list.Add(GenerateCity("Bridgewater Township", "", stateAbbreviation));
            list.Add(GenerateCity("Brielle Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Brigantine", "", stateAbbreviation));
            list.Add(GenerateCity("Brooklawn", "", stateAbbreviation));
            list.Add(GenerateCity("Budd Lake", "", stateAbbreviation));
            list.Add(GenerateCity("Buena Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Buena Vista Township", "", stateAbbreviation));
            list.Add(GenerateCity("Burlington City", "", stateAbbreviation));
            list.Add(GenerateCity("Burlington Township", "", stateAbbreviation));
            list.Add(GenerateCity("Butler Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Byram Township", "", stateAbbreviation));
            list.Add(GenerateCity("Caldwell", "", stateAbbreviation));
            list.Add(GenerateCity("Camden", "", stateAbbreviation));
            list.Add(GenerateCity("Cape May", "", stateAbbreviation));
            list.Add(GenerateCity("Carlstadt", "", stateAbbreviation));
            list.Add(GenerateCity("Carneys Point Township", "", stateAbbreviation));
            list.Add(GenerateCity("Carteret", "", stateAbbreviation));
            list.Add(GenerateCity("Cedar Grove", "", stateAbbreviation));
            list.Add(GenerateCity("Chatham Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Chatham Township", "", stateAbbreviation));
            list.Add(GenerateCity("Cherry Hill", "", stateAbbreviation));
            list.Add(GenerateCity("Chesilhurst Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Chester Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Chester Township", "", stateAbbreviation));
            list.Add(GenerateCity("Chesterfield Township", "", stateAbbreviation));
            list.Add(GenerateCity("Cinnaminson Township", "", stateAbbreviation));
            list.Add(GenerateCity("Clark", "", stateAbbreviation));
            list.Add(GenerateCity("Clayton Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Clementon Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Cliffside Park Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Clifton", "", stateAbbreviation));
            list.Add(GenerateCity("Clinton", "", stateAbbreviation));
            list.Add(GenerateCity("Clinton Township", "", stateAbbreviation));
            list.Add(GenerateCity("Closter Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Collingswood Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Colts Neck", "", stateAbbreviation));
            list.Add(GenerateCity("Commercial Township", "", stateAbbreviation));
            list.Add(GenerateCity("Corbin City", "", stateAbbreviation));
            list.Add(GenerateCity("Cranbury", "", stateAbbreviation));
            list.Add(GenerateCity("Cranford", "", stateAbbreviation));
            list.Add(GenerateCity("Cresskill", "", stateAbbreviation));
            list.Add(GenerateCity("Deal", "", stateAbbreviation));
            list.Add(GenerateCity("Deerfield Township", "", stateAbbreviation));
            list.Add(GenerateCity("Delanco Township", "", stateAbbreviation));
            list.Add(GenerateCity("Delaware Township", "", stateAbbreviation));
            list.Add(GenerateCity("Delran Township", "", stateAbbreviation));
            list.Add(GenerateCity("Demarest Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Dennis Township", "", stateAbbreviation));
            list.Add(GenerateCity("Denville Township", "", stateAbbreviation));
            list.Add(GenerateCity("Deptford Township", "", stateAbbreviation));
            list.Add(GenerateCity("Dover", "", stateAbbreviation));
            list.Add(GenerateCity("Downe Township", "", stateAbbreviation));
            list.Add(GenerateCity("Dumont", "", stateAbbreviation));
            list.Add(GenerateCity("Dunellen", "", stateAbbreviation));
            list.Add(GenerateCity("East Amwell Township", "", stateAbbreviation));
            list.Add(GenerateCity("East Brunswick", "", stateAbbreviation));
            list.Add(GenerateCity("East Greenwich Township", "", stateAbbreviation));
            list.Add(GenerateCity("East Hanover", "", stateAbbreviation));
            list.Add(GenerateCity("East Newark Borough", "", stateAbbreviation));
            list.Add(GenerateCity("East Orange", "", stateAbbreviation));
            list.Add(GenerateCity("East Rutherford Borough", "", stateAbbreviation));
            list.Add(GenerateCity("East Windsor", "", stateAbbreviation));
            list.Add(GenerateCity("Eastampton", "", stateAbbreviation));
            list.Add(GenerateCity("Eatontown", "", stateAbbreviation));
            list.Add(GenerateCity("Edgewater", "", stateAbbreviation));
            list.Add(GenerateCity("Edgewater Park Township", "", stateAbbreviation));
            list.Add(GenerateCity("Edison", "", stateAbbreviation));
            list.Add(GenerateCity("Egg Harbor City", "", stateAbbreviation));
            list.Add(GenerateCity("Egg Harbor Township", "", stateAbbreviation));
            list.Add(GenerateCity("Elizabeth", "", stateAbbreviation));
            list.Add(GenerateCity("Elk Township", "", stateAbbreviation));
            list.Add(GenerateCity("Elmer Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Elmwood Park", "", stateAbbreviation));
            list.Add(GenerateCity("Emerson Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Englewood", "", stateAbbreviation));
            list.Add(GenerateCity("Englewood Cliffs Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Englishtown", "", stateAbbreviation));
            list.Add(GenerateCity("Essex Fells Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Estell Manor City", "", stateAbbreviation));
            list.Add(GenerateCity("Evesham Township", "", stateAbbreviation));
            list.Add(GenerateCity("Ewing Township", "", stateAbbreviation));
            list.Add(GenerateCity("Fair Haven Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Fair Lawn", "", stateAbbreviation));
            list.Add(GenerateCity("Fairfield", "", stateAbbreviation));
            list.Add(GenerateCity("Fairfield Township", "", stateAbbreviation));
            list.Add(GenerateCity("Fanwood Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Far Hills Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Flemington", "", stateAbbreviation));
            list.Add(GenerateCity("Florence", "", stateAbbreviation));
            list.Add(GenerateCity("Florham Park", "", stateAbbreviation));
            list.Add(GenerateCity("Folsom Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Fort Lee", "", stateAbbreviation));
            list.Add(GenerateCity("Frankford Township", "", stateAbbreviation));
            list.Add(GenerateCity("Franklin Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Franklin Lakes", "", stateAbbreviation));
            list.Add(GenerateCity("Franklin Township (Gloucester County)", "", stateAbbreviation));
            list.Add(GenerateCity("Franklin Township (Hunterdon County)", "", stateAbbreviation));
            list.Add(GenerateCity("Franklin Township (Somerset County)", "", stateAbbreviation));
            list.Add(GenerateCity("Franklin Township (Warren County)", "", stateAbbreviation));
            list.Add(GenerateCity("Fredon Township", "", stateAbbreviation));
            list.Add(GenerateCity("Freehold Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Freehold Township", "", stateAbbreviation));
            list.Add(GenerateCity("Frelinghuysen Township", "", stateAbbreviation));
            list.Add(GenerateCity("Frenchtown", "", stateAbbreviation));
            list.Add(GenerateCity("Galloway Township", "", stateAbbreviation));
            list.Add(GenerateCity("Garfield", "", stateAbbreviation));
            list.Add(GenerateCity("Garwood", "", stateAbbreviation));
            list.Add(GenerateCity("Gibbsboro", "", stateAbbreviation));
            list.Add(GenerateCity("Glassboro", "", stateAbbreviation));
            list.Add(GenerateCity("Glen Gardner Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Glen Ridge Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Glen Rock", "", stateAbbreviation));
            list.Add(GenerateCity("Gloucester", "", stateAbbreviation));
            list.Add(GenerateCity("Gloucester Township", "", stateAbbreviation));
            list.Add(GenerateCity("Green Brook Township", "", stateAbbreviation));
            list.Add(GenerateCity("Green Township", "", stateAbbreviation));
            list.Add(GenerateCity("Greenwich Township (Cumberland County)", "", stateAbbreviation));
            list.Add(GenerateCity("Greenwich Township (Gloucester County)", "", stateAbbreviation));
            list.Add(GenerateCity("Greenwich Township (Warren County)", "", stateAbbreviation));
            list.Add(GenerateCity("Guttenberg Town", "", stateAbbreviation));
            list.Add(GenerateCity("Hackensack", "", stateAbbreviation));
            list.Add(GenerateCity("Hackettstown", "", stateAbbreviation));
            list.Add(GenerateCity("Haddonfield", "", stateAbbreviation));
            list.Add(GenerateCity("Haddon Heights Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Haddon Township", "", stateAbbreviation));
            list.Add(GenerateCity("Hainesport", "", stateAbbreviation));
            list.Add(GenerateCity("Haledon Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Hamilton (Mercer County)", "", stateAbbreviation));
            list.Add(GenerateCity("Hamilton Township(Atlantic County)", "", stateAbbreviation));
            list.Add(GenerateCity("Hammonton", "", stateAbbreviation));
            list.Add(GenerateCity("Hampton Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Hampton Township", "", stateAbbreviation));
            list.Add(GenerateCity("Hanover Township", "", stateAbbreviation));
            list.Add(GenerateCity("Harding Township", "", stateAbbreviation));
            list.Add(GenerateCity("Hardwick Township", "", stateAbbreviation));
            list.Add(GenerateCity("Hardyston Township", "", stateAbbreviation));
            list.Add(GenerateCity("Harmony Township", "", stateAbbreviation));
            list.Add(GenerateCity("Harrington Park", "", stateAbbreviation));
            list.Add(GenerateCity("Harrison Town (Hudson County)", "", stateAbbreviation));
            list.Add(GenerateCity("Harrison Township", "", stateAbbreviation));
            list.Add(GenerateCity("Harvey Cedars", "", stateAbbreviation));
            list.Add(GenerateCity("Hasbrouck Heights", "", stateAbbreviation));
            list.Add(GenerateCity("Hawthorne Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Haworth Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Hazlet", "", stateAbbreviation));
            list.Add(GenerateCity("Helmetta Borough", "", stateAbbreviation));
            list.Add(GenerateCity("High Bridge", "", stateAbbreviation));
            list.Add(GenerateCity("Highlands", "", stateAbbreviation));
            list.Add(GenerateCity("Highland Park", "", stateAbbreviation));
            list.Add(GenerateCity("Hightstown Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Hillsborough", "", stateAbbreviation));
            list.Add(GenerateCity("Hillsdale", "", stateAbbreviation));
            list.Add(GenerateCity("Hillside Township", "", stateAbbreviation));
            list.Add(GenerateCity("Hi-nella", "", stateAbbreviation));
            list.Add(GenerateCity("Hoboken", "", stateAbbreviation));
            list.Add(GenerateCity("Ho-Ho-Kus", "", stateAbbreviation));
            list.Add(GenerateCity("Holland Township", "", stateAbbreviation));
            list.Add(GenerateCity("Holmdel", "", stateAbbreviation));
            list.Add(GenerateCity("Hopatcong", "", stateAbbreviation));
            list.Add(GenerateCity("Hope Township", "", stateAbbreviation));
            list.Add(GenerateCity("Hopewell Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Hopewell Township (Cumberland County)", "", stateAbbreviation));
            list.Add(GenerateCity("Hopewell Township (Mercer County)", "", stateAbbreviation));
            list.Add(GenerateCity("Howell", "", stateAbbreviation));
            list.Add(GenerateCity("Independence Township", "", stateAbbreviation));
            list.Add(GenerateCity("Interlaken", "", stateAbbreviation));
            list.Add(GenerateCity("Irvington Township", "", stateAbbreviation));
            list.Add(GenerateCity("Island Heights", "", stateAbbreviation));
            list.Add(GenerateCity("Jackson Township", "", stateAbbreviation));
            list.Add(GenerateCity("Jamesburg", "", stateAbbreviation));
            list.Add(GenerateCity("Jefferson Township", "", stateAbbreviation));
            list.Add(GenerateCity("Jersey City", "", stateAbbreviation));
            list.Add(GenerateCity("Keansburg", "", stateAbbreviation));
            list.Add(GenerateCity("Kearny", "", stateAbbreviation));
            list.Add(GenerateCity("Kenilworth Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Keyport Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Kingwood Township", "", stateAbbreviation));
            list.Add(GenerateCity("Kinnelon", "", stateAbbreviation));
            list.Add(GenerateCity("Knowlton Township", "", stateAbbreviation));
            list.Add(GenerateCity("Lacey Township", "", stateAbbreviation));
            list.Add(GenerateCity("Lafayette Township", "", stateAbbreviation));
            list.Add(GenerateCity("Lake Como (formerly South Belmar)", "", stateAbbreviation));
            list.Add(GenerateCity("Lakehurst", "", stateAbbreviation));
            list.Add(GenerateCity("Lakewood Township", "", stateAbbreviation));
            list.Add(GenerateCity("Lambertville", "", stateAbbreviation));
            list.Add(GenerateCity("Laurel Springs", "", stateAbbreviation));
            list.Add(GenerateCity("Lavallette Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Lawnside", "", stateAbbreviation));
            list.Add(GenerateCity("Lawrence Township (Cumberland County)", "", stateAbbreviation));
            list.Add(GenerateCity("Lawrence Township (Mercer County)", "", stateAbbreviation));
            list.Add(GenerateCity("Lebanon Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Lebanon Township", "", stateAbbreviation));
            list.Add(GenerateCity("Leonia Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Liberty Township", "", stateAbbreviation));
            list.Add(GenerateCity("Lincoln Park", "", stateAbbreviation));
            list.Add(GenerateCity("Linden", "", stateAbbreviation));
            list.Add(GenerateCity("Lindenwold", "", stateAbbreviation));
            list.Add(GenerateCity("Linwood City", "", stateAbbreviation));
            list.Add(GenerateCity("Little Egg Harbor Township", "", stateAbbreviation));
            list.Add(GenerateCity("Little Falls", "", stateAbbreviation));
            list.Add(GenerateCity("Little Ferry Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Little Silver Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Livingston", "", stateAbbreviation));
            list.Add(GenerateCity("Loch Arbor Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Lodi Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Logan Township", "", stateAbbreviation));
            list.Add(GenerateCity("Long Beach Township", "", stateAbbreviation));
            list.Add(GenerateCity("Long Branch", "", stateAbbreviation));
            list.Add(GenerateCity("Long Hill Township", "", stateAbbreviation));
            list.Add(GenerateCity("Longport", "", stateAbbreviation));
            list.Add(GenerateCity("Lopatcong Township", "", stateAbbreviation));
            list.Add(GenerateCity("Lower Alloways Creek Township", "", stateAbbreviation));
            list.Add(GenerateCity("Lower Township", "", stateAbbreviation));
            list.Add(GenerateCity("Lumberton", "", stateAbbreviation));
            list.Add(GenerateCity("Lyndhurst", "", stateAbbreviation));
            list.Add(GenerateCity("Madison", "", stateAbbreviation));
            list.Add(GenerateCity("Magnolia", "", stateAbbreviation));
            list.Add(GenerateCity("Mahwah", "", stateAbbreviation));
            list.Add(GenerateCity("Manalapan", "", stateAbbreviation));
            list.Add(GenerateCity("Manasquan", "", stateAbbreviation));
            list.Add(GenerateCity("Manchester Township", "", stateAbbreviation));
            list.Add(GenerateCity("Mannington Township", "", stateAbbreviation));
            list.Add(GenerateCity("Mansfield Township (Burlington County)", "", stateAbbreviation));
            list.Add(GenerateCity("Mansfield Township (Warren County)", "", stateAbbreviation));
            list.Add(GenerateCity("Mantoloking Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Mantua Township", "", stateAbbreviation));
            list.Add(GenerateCity("Manville Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Maple Shade Township", "", stateAbbreviation));
            list.Add(GenerateCity("Maplewood", "", stateAbbreviation));
            list.Add(GenerateCity("Margate", "", stateAbbreviation));
            list.Add(GenerateCity("Marlboro Township", "", stateAbbreviation));
            list.Add(GenerateCity("Matawan borough of", "", stateAbbreviation));
            list.Add(GenerateCity("Maywood", "", stateAbbreviation));
            list.Add(GenerateCity("Maurice River Township", "", stateAbbreviation));
            list.Add(GenerateCity("Medford", "", stateAbbreviation));
            list.Add(GenerateCity("Medford Lakes", "", stateAbbreviation));
            list.Add(GenerateCity("Mendham Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Mendham Township", "", stateAbbreviation));
            list.Add(GenerateCity("Merchantville", "", stateAbbreviation));
            list.Add(GenerateCity("Metuchen", "", stateAbbreviation));
            list.Add(GenerateCity("Middlesex Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Middle Township", "", stateAbbreviation));
            list.Add(GenerateCity("Middletown Township", "", stateAbbreviation));
            list.Add(GenerateCity("Midland Park", "", stateAbbreviation));
            list.Add(GenerateCity("Milford Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Millburn", "", stateAbbreviation));
            list.Add(GenerateCity("Millburn Township", "", stateAbbreviation));
            list.Add(GenerateCity("Millstone Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Millstone Township", "", stateAbbreviation));
            list.Add(GenerateCity("Milltown", "", stateAbbreviation));
            list.Add(GenerateCity("Millville", "", stateAbbreviation));
            list.Add(GenerateCity("Mine Hill", "", stateAbbreviation));
            list.Add(GenerateCity("Monmouth Beach Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Monroe Township (Gloucester County)", "", stateAbbreviation));
            list.Add(GenerateCity("Monroe Township (Middlesex County)", "", stateAbbreviation));
            list.Add(GenerateCity("Montague", "", stateAbbreviation));
            list.Add(GenerateCity("Montclair", "", stateAbbreviation));
            list.Add(GenerateCity("Montgomery Township", "", stateAbbreviation));
            list.Add(GenerateCity("Montvale", "", stateAbbreviation));
            list.Add(GenerateCity("Montville Township", "", stateAbbreviation));
            list.Add(GenerateCity("Moonachie Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Moorestown", "", stateAbbreviation));
            list.Add(GenerateCity("Morris Plains Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Morris Township", "", stateAbbreviation));
            list.Add(GenerateCity("Morristown", "", stateAbbreviation));
            list.Add(GenerateCity("Mount Arlington", "", stateAbbreviation));
            list.Add(GenerateCity("Mount Ephraim Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Mount Holly", "", stateAbbreviation));
            list.Add(GenerateCity("Mount Laurel", "", stateAbbreviation));
            list.Add(GenerateCity("Mount Olive Township", "", stateAbbreviation));
            list.Add(GenerateCity("Mountain Lakes", "", stateAbbreviation));
            list.Add(GenerateCity("Mountainside", "", stateAbbreviation));
            list.Add(GenerateCity("Mullica Township", "", stateAbbreviation));
            list.Add(GenerateCity("National Park Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Neptune City", "", stateAbbreviation));
            list.Add(GenerateCity("Neptune Township", "", stateAbbreviation));
            list.Add(GenerateCity("Netcong", "", stateAbbreviation));
            list.Add(GenerateCity("Newark", "", stateAbbreviation));
            list.Add(GenerateCity("New Brunswick", "", stateAbbreviation));
            list.Add(GenerateCity("New Milford Borough", "", stateAbbreviation));
            list.Add(GenerateCity("New Providence", "", stateAbbreviation));
            list.Add(GenerateCity("Newfield Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Newton", "", stateAbbreviation));
            list.Add(GenerateCity("North Arlington Borough", "", stateAbbreviation));
            list.Add(GenerateCity("North Bergen", "", stateAbbreviation));
            list.Add(GenerateCity("North Brunswick Township", "", stateAbbreviation));
            list.Add(GenerateCity("North Caldwell Borough", "", stateAbbreviation));
            list.Add(GenerateCity("North Haledon", "", stateAbbreviation));
            list.Add(GenerateCity("North Hanover Township", "", stateAbbreviation));
            list.Add(GenerateCity("North Plainfield Borough", "", stateAbbreviation));
            list.Add(GenerateCity("North Wildwood", "", stateAbbreviation));
            list.Add(GenerateCity("Northfield", "", stateAbbreviation));
            list.Add(GenerateCity("Northvale Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Norwood Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Nutley", "", stateAbbreviation));
            list.Add(GenerateCity("Oakland", "", stateAbbreviation));
            list.Add(GenerateCity("Oaklyn", "", stateAbbreviation));
            list.Add(GenerateCity("Ocean City", "", stateAbbreviation));
            list.Add(GenerateCity("Ocean Gate (Borough)", "", stateAbbreviation));
            list.Add(GenerateCity("Ocean Township (Monmouth County)", "", stateAbbreviation));
            list.Add(GenerateCity("Ocean Township (Ocean County)", "", stateAbbreviation));
            list.Add(GenerateCity("Oceanport Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Ogdensburg Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Old Bridge Township", "", stateAbbreviation));
            list.Add(GenerateCity("Oldmans Township", "", stateAbbreviation));
            list.Add(GenerateCity("Old Tappan", "", stateAbbreviation));
            list.Add(GenerateCity("Oradell", "", stateAbbreviation));
            list.Add(GenerateCity("Orange Township", "", stateAbbreviation));
            list.Add(GenerateCity("Oxford Township", "", stateAbbreviation));
            list.Add(GenerateCity("Palisades Park", "", stateAbbreviation));
            list.Add(GenerateCity("Palmyra Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Park Ridge", "", stateAbbreviation));
            list.Add(GenerateCity("Paramus", "", stateAbbreviation));
            list.Add(GenerateCity("Parsippany", "", stateAbbreviation));
            list.Add(GenerateCity("Passaic", "", stateAbbreviation));
            list.Add(GenerateCity("Paterson", "", stateAbbreviation));
            list.Add(GenerateCity("Paulsboro", "", stateAbbreviation));
            list.Add(GenerateCity("Peapack-Gladstone Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Pemberton Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Pemberton Township", "", stateAbbreviation));
            list.Add(GenerateCity("Pennington Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Pennsauken Township", "", stateAbbreviation));
            list.Add(GenerateCity("Penns Grove Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Pennsville", "", stateAbbreviation));
            list.Add(GenerateCity("Pequannock", "", stateAbbreviation));
            list.Add(GenerateCity("Perth Amboy", "", stateAbbreviation));
            list.Add(GenerateCity("Phillipsburg", "", stateAbbreviation));
            list.Add(GenerateCity("Pilesgrove Township", "", stateAbbreviation));
            list.Add(GenerateCity("Pine Beach Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Pine Hill Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Pine Valley Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Piscataway Township", "", stateAbbreviation));
            list.Add(GenerateCity("Pitman", "", stateAbbreviation));
            list.Add(GenerateCity("Pittsgrove", "", stateAbbreviation));
            list.Add(GenerateCity("Plainfield", "", stateAbbreviation));
            list.Add(GenerateCity("Plainsboro", "", stateAbbreviation));
            list.Add(GenerateCity("Pleasantville", "", stateAbbreviation));
            list.Add(GenerateCity("Plumsted Township", "", stateAbbreviation));
            list.Add(GenerateCity("Pohatcong", "", stateAbbreviation));
            list.Add(GenerateCity("Point Pleasant Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Point Pleasant Beach", "", stateAbbreviation));
            list.Add(GenerateCity("Pompton Lakes", "", stateAbbreviation));
            list.Add(GenerateCity("Port Republic Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Princeton", "", stateAbbreviation));
            list.Add(GenerateCity("Prospect Park Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Rahway", "", stateAbbreviation));
            list.Add(GenerateCity("Ramsey", "", stateAbbreviation));
            list.Add(GenerateCity("Randolph", "", stateAbbreviation));
            list.Add(GenerateCity("Raritan Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Raritan Township", "", stateAbbreviation));
            list.Add(GenerateCity("Readington Township", "", stateAbbreviation));
            list.Add(GenerateCity("Red Bank", "", stateAbbreviation));
            list.Add(GenerateCity("Ridgefield Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Ridgewood", "", stateAbbreviation));
            list.Add(GenerateCity("Ringwood", "", stateAbbreviation));
            list.Add(GenerateCity("River Edge Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Riverdale Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Riverside Township", "", stateAbbreviation));
            list.Add(GenerateCity("Riverton", "", stateAbbreviation));
            list.Add(GenerateCity("River Vale Township", "", stateAbbreviation));
            list.Add(GenerateCity("Robbinsville Township", "", stateAbbreviation));
            list.Add(GenerateCity("Rochelle Park Township", "", stateAbbreviation));
            list.Add(GenerateCity("Rockaway Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Rockaway Township", "", stateAbbreviation));
            list.Add(GenerateCity("Rockleigh Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Rocky Hill", "", stateAbbreviation));
            list.Add(GenerateCity("Roseland", "", stateAbbreviation));
            list.Add(GenerateCity("Roselle Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Roselle Park Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Roxbury Township", "", stateAbbreviation));
            list.Add(GenerateCity("Rumson", "", stateAbbreviation));
            list.Add(GenerateCity("Runnemede Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Rutherford", "", stateAbbreviation));
            list.Add(GenerateCity("Saddle Brook", "", stateAbbreviation));
            list.Add(GenerateCity("Saddle River", "", stateAbbreviation));
            list.Add(GenerateCity("Salem City", "", stateAbbreviation));
            list.Add(GenerateCity("Sandyston Township", "", stateAbbreviation));
            list.Add(GenerateCity("Sayreville", "", stateAbbreviation));
            list.Add(GenerateCity("Scotch Plains", "", stateAbbreviation));
            list.Add(GenerateCity("Sea Bright Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Sea Girt Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Sea Isle City", "", stateAbbreviation));
            list.Add(GenerateCity("Seaside Heights", "", stateAbbreviation));
            list.Add(GenerateCity("Seaside Park", "", stateAbbreviation));
            list.Add(GenerateCity("Secaucus", "", stateAbbreviation));
            list.Add(GenerateCity("Shamong Township", "", stateAbbreviation));
            list.Add(GenerateCity("Shiloh Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Ship Bottom Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Shrewsbury Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Somerdale Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Somers Point", "", stateAbbreviation));
            list.Add(GenerateCity("Somerville", "", stateAbbreviation));
            list.Add(GenerateCity("South Amboy", "", stateAbbreviation));
            list.Add(GenerateCity("South Bound Brook Borough", "", stateAbbreviation));
            list.Add(GenerateCity("South Brunswick", "", stateAbbreviation));
            list.Add(GenerateCity("South Hackensack Township", "", stateAbbreviation));
            list.Add(GenerateCity("South Harrison Township", "", stateAbbreviation));
            list.Add(GenerateCity("South Orange", "", stateAbbreviation));
            list.Add(GenerateCity("South Plainfield", "", stateAbbreviation));
            list.Add(GenerateCity("South River Borough", "", stateAbbreviation));
            list.Add(GenerateCity("South Toms River Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Southampton Township", "", stateAbbreviation));
            list.Add(GenerateCity("Sparta Township", "", stateAbbreviation));
            list.Add(GenerateCity("Spotswood", "", stateAbbreviation));
            list.Add(GenerateCity("Springfield", "", stateAbbreviation));
            list.Add(GenerateCity("Spring Lake", "", stateAbbreviation));
            list.Add(GenerateCity("Spring Lake Heights Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Stafford Township", "", stateAbbreviation));
            list.Add(GenerateCity("Stanhope Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Stillwater Township", "", stateAbbreviation));
            list.Add(GenerateCity("Stockton Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Stone Harbor", "", stateAbbreviation));
            list.Add(GenerateCity("Stow Creek Township", "", stateAbbreviation));
            list.Add(GenerateCity("Stratford", "", stateAbbreviation));
            list.Add(GenerateCity("Summit", "", stateAbbreviation));
            list.Add(GenerateCity("Sussex Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Swedesboro", "", stateAbbreviation));
            list.Add(GenerateCity("Tabernacle", "", stateAbbreviation));
            list.Add(GenerateCity("Tavistock Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Teaneck", "", stateAbbreviation));
            list.Add(GenerateCity("Tenafly Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Tewksbury", "", stateAbbreviation));
            list.Add(GenerateCity("Tinton Falls", "", stateAbbreviation));
            list.Add(GenerateCity("Toms River Township", "", stateAbbreviation));
            list.Add(GenerateCity("Totowa Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Trenton", "", stateAbbreviation));
            list.Add(GenerateCity("Tuckerton", "", stateAbbreviation));
            list.Add(GenerateCity("Union Beach Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Union City", "", stateAbbreviation));
            list.Add(GenerateCity("Union Township (Hunterdon County)", "", stateAbbreviation));
            list.Add(GenerateCity("Union Township (Union County)", "", stateAbbreviation));
            list.Add(GenerateCity("Upper Deerfield Township", "", stateAbbreviation));
            list.Add(GenerateCity("Upper Freehold Township", "", stateAbbreviation));
            list.Add(GenerateCity("Upper Pittsgrove Township", "", stateAbbreviation));
            list.Add(GenerateCity("Upper Saddle River", "", stateAbbreviation));
            list.Add(GenerateCity("Upper Township", "", stateAbbreviation));
            list.Add(GenerateCity("Ventnor City", "", stateAbbreviation));
            list.Add(GenerateCity("Vernon Township", "", stateAbbreviation));
            list.Add(GenerateCity("Verona", "", stateAbbreviation));
            list.Add(GenerateCity("Vineland", "", stateAbbreviation));
            list.Add(GenerateCity("Voorhees", "", stateAbbreviation));
            list.Add(GenerateCity("Waldwick", "", stateAbbreviation));
            list.Add(GenerateCity("Wall Township", "", stateAbbreviation));
            list.Add(GenerateCity("Wallington", "", stateAbbreviation));
            list.Add(GenerateCity("Walpack Township", "", stateAbbreviation));
            list.Add(GenerateCity("Wanaque Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Wantage Township", "", stateAbbreviation));
            list.Add(GenerateCity("Warren Township", "", stateAbbreviation));
            list.Add(GenerateCity("Washington Borough (Warren County)", "", stateAbbreviation));
            list.Add(GenerateCity("Washington Township (Bergen County)", "", stateAbbreviation));
            list.Add(GenerateCity("Washington Township (Gloucester County)", "", stateAbbreviation));
            list.Add(GenerateCity("Washington Township (Morris County)", "", stateAbbreviation));
            list.Add(GenerateCity("Washington Township (Warren County)", "", stateAbbreviation));
            list.Add(GenerateCity("Watchung", "", stateAbbreviation));
            list.Add(GenerateCity("Waterford Township", "", stateAbbreviation));
            list.Add(GenerateCity("Wayne Township", "", stateAbbreviation));
            list.Add(GenerateCity("Weehawken", "", stateAbbreviation));
            list.Add(GenerateCity("Wenonah Borough", "", stateAbbreviation));
            list.Add(GenerateCity("West Amwell", "", stateAbbreviation));
            list.Add(GenerateCity("West Caldwell", "", stateAbbreviation));
            list.Add(GenerateCity("West Cape May Borough", "", stateAbbreviation));
            list.Add(GenerateCity("West Deptford Township", "", stateAbbreviation));
            list.Add(GenerateCity("West Long Branch Borough", "", stateAbbreviation));
            list.Add(GenerateCity("West Milford Township", "", stateAbbreviation));
            list.Add(GenerateCity("West New York", "", stateAbbreviation));
            list.Add(GenerateCity("West Orange", "", stateAbbreviation));
            list.Add(GenerateCity("West Wildwood", "", stateAbbreviation));
            list.Add(GenerateCity("West Windsor", "", stateAbbreviation));
            list.Add(GenerateCity("Westampton Township", "", stateAbbreviation));
            list.Add(GenerateCity("Westfield", "", stateAbbreviation));
            list.Add(GenerateCity("Westville", "", stateAbbreviation));
            list.Add(GenerateCity("Westwood", "", stateAbbreviation));
            list.Add(GenerateCity("Weymouth", "", stateAbbreviation));
            list.Add(GenerateCity("Wharton", "", stateAbbreviation));
            list.Add(GenerateCity("White Towhip", "", stateAbbreviation));
            list.Add(GenerateCity("Wildwood Crest Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Wildwood", "", stateAbbreviation));
            list.Add(GenerateCity("Willingboro", "", stateAbbreviation));
            list.Add(GenerateCity("Winfield Township", "", stateAbbreviation));
            list.Add(GenerateCity("Winslow Township", "", stateAbbreviation));
            list.Add(GenerateCity("Woodbine Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Woodbridge Township", "", stateAbbreviation));
            list.Add(GenerateCity("Woodbury", "", stateAbbreviation));
            list.Add(GenerateCity("Woodbury Heights Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Woodcliff Lake", "", stateAbbreviation));
            list.Add(GenerateCity("Woodland Park", "", stateAbbreviation));
            list.Add(GenerateCity("Woodlynne", "", stateAbbreviation));
            list.Add(GenerateCity("Wood-Ridge", "", stateAbbreviation));
            list.Add(GenerateCity("Woodstown Borough", "", stateAbbreviation));
            list.Add(GenerateCity("Woolwich Township", "", stateAbbreviation));
            list.Add(GenerateCity("Wyckoff", "", stateAbbreviation));

            return list;
        }

        private List<CityCmd> GenerateCityList_US_PA()
        {
            string stateAbbreviation = "PA";

            List<CityCmd> list = new List<CityCmd>();

            //list.Add(GenerateCity("Please Select", "N/A", stateAbbreviation));   // would end up with duplicate "Please Select" display names for each City // KendoUI <select> will add this option automatically
            list.Add(GenerateCity("Abbottstown", "Adams", stateAbbreviation));
            list.Add(GenerateCity("Arendtsville", "Adams", stateAbbreviation));
            list.Add(GenerateCity("Bendersville", "Adams", stateAbbreviation));
            list.Add(GenerateCity("Biglerville", "Adams", stateAbbreviation));
            list.Add(GenerateCity("Bonneauville", "Adams", stateAbbreviation));
            list.Add(GenerateCity("Carroll Valley", "Adams", stateAbbreviation));
            list.Add(GenerateCity("East Berlin", "Adams", stateAbbreviation));
            list.Add(GenerateCity("Fairfield", "Adams", stateAbbreviation));
            list.Add(GenerateCity("Gettysburg", "Adams", stateAbbreviation));
            list.Add(GenerateCity("Littlestown", "Adams", stateAbbreviation));
            list.Add(GenerateCity("McSherrystown", "Adams", stateAbbreviation));
            list.Add(GenerateCity("New Oxford", "Adams", stateAbbreviation));
            list.Add(GenerateCity("York Springs", "Adams", stateAbbreviation));
            list.Add(GenerateCity("Aspinwall", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Avalon", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Baldwin", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Bell Acres", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Ben Avon", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Ben Avon Heights", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Blawnox", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Brackenridge", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Braddock", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Braddock Hills", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Brentwood", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Bridgeville", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Carnegie", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Castle Shannon", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Chalfant", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Cheswick", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Churchill", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Coraopolis", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Crafton", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Dormont", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Dravosburg", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("East McKeesport", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("East Pittsburgh", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Edgewood", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Edgeworth", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Elizabeth", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Emsworth", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Etna", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Forest Hills", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Fox Chapel", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Franklin Park", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Glassport", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Glen Osborne", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Glenfield", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Haysville", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Heidelberg", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Homestead", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Ingram", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Jefferson Hills", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Leetsdale", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Liberty", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Lincoln", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("McKees Rocks", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Millvale", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Mount Oliver", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Munhall", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("North Braddock", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Oakdale", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Oakmont", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Pennsbury Village", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Pitcairn", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Pleasant Hills", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Plum", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Port Vue", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Rankin", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Rosslyn Farms", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Sewickley", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Sewickley Heights", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Sewickley Hills", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Sharpsburg", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Springdale", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Swissvale", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Tarentum", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Thornburg", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Turtle Creek", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Verona", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Versailles", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Wall", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("West Elizabeth", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("West Homestead", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("West Mifflin", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("West View", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Whitaker", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("White Oak", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Wilkinsburg", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Wilmerding", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("McDonald(Allegheny&Washington)", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Trafford(Allegheny&Westmoreland)", "Allegheny", stateAbbreviation));
            list.Add(GenerateCity("Apollo", "Armstrong", stateAbbreviation));
            list.Add(GenerateCity("Applewold", "Armstrong", stateAbbreviation));
            list.Add(GenerateCity("Atwood", "Armstrong", stateAbbreviation));
            list.Add(GenerateCity("Dayto ", "Armstrong", stateAbbreviation));
            list.Add(GenerateCity("Elderton", "Armstrong", stateAbbreviation));
            list.Add(GenerateCity("Ford City", "Armstrong", stateAbbreviation));
            list.Add(GenerateCity("Ford Cliff", "Armstrong", stateAbbreviation));
            list.Add(GenerateCity("Freeport", "Armstrong", stateAbbreviation));
            list.Add(GenerateCity("Kittanning", "Armstrong", stateAbbreviation));
            list.Add(GenerateCity("Leechburg", "Armstrong", stateAbbreviation));
            list.Add(GenerateCity("Manorville", "Armstrong", stateAbbreviation));
            list.Add(GenerateCity("North Apollo", "Armstrong", stateAbbreviation));
            list.Add(GenerateCity("Rural Valley", "Armstrong", stateAbbreviation));
            list.Add(GenerateCity("South Bethlehem", "Armstrong", stateAbbreviation));
            list.Add(GenerateCity("West Kittanning", "Armstrong", stateAbbreviation));
            list.Add(GenerateCity("Worthington", "Armstrong", stateAbbreviation));
            list.Add(GenerateCity("Ambridge", "Beaver", stateAbbreviation));
            list.Add(GenerateCity("Baden", "Beaver", stateAbbreviation));
            list.Add(GenerateCity("Beaver", "Beaver", stateAbbreviation));
            list.Add(GenerateCity("Big Beaver", "Beaver", stateAbbreviation));
            list.Add(GenerateCity("Conway", "Beaver", stateAbbreviation));
            list.Add(GenerateCity("Darlington", "Beaver", stateAbbreviation));
            list.Add(GenerateCity("East Rochester", "Beaver", stateAbbreviation));
            list.Add(GenerateCity("Eastvale", "Beaver", stateAbbreviation));
            list.Add(GenerateCity("Economy", "Beaver", stateAbbreviation));
            list.Add(GenerateCity("Fallston", "Beaver", stateAbbreviation));
            list.Add(GenerateCity("Frankfort Spring ", "Beaver", stateAbbreviation));
            list.Add(GenerateCity("Freedom", "Beaver", stateAbbreviation));
            list.Add(GenerateCity("Georgetown", "Beaver", stateAbbreviation));
            list.Add(GenerateCity("Glasgow", "Beaver", stateAbbreviation));
            list.Add(GenerateCity("Homewood", "Beaver", stateAbbreviation));
            list.Add(GenerateCity("Hookstown", "Beaver", stateAbbreviation));
            list.Add(GenerateCity("Industry", "Beaver", stateAbbreviation));
            list.Add(GenerateCity("Koppel", "Beaver", stateAbbreviation));
            list.Add(GenerateCity("Midland", "Beaver", stateAbbreviation));
            list.Add(GenerateCity("Monaca", "Beaver", stateAbbreviation));
            list.Add(GenerateCity("New Brighton", "Beaver", stateAbbreviation));
            list.Add(GenerateCity("New Galilee", "Beaver", stateAbbreviation));
            list.Add(GenerateCity("Ohioville", "Beaver", stateAbbreviation));
            list.Add(GenerateCity("Patterson Heights", "Beaver", stateAbbreviation));
            list.Add(GenerateCity("Rochester", "Beaver", stateAbbreviation));
            list.Add(GenerateCity("Shippingport", "Beaver", stateAbbreviation));
            list.Add(GenerateCity("South Heights", "Beaver", stateAbbreviation));
            list.Add(GenerateCity("West Mayfield", "Beaver", stateAbbreviation));
            list.Add(GenerateCity("Ellwood City(Beaver& Lawrence)", "Beaver", stateAbbreviation));
            list.Add(GenerateCity("Bedford", "Bedford", stateAbbreviation));
            list.Add(GenerateCity("Coaldale", "Bedford", stateAbbreviation));
            list.Add(GenerateCity("Everett", "Bedford", stateAbbreviation));
            list.Add(GenerateCity("Hopewell", "Bedford", stateAbbreviation));
            list.Add(GenerateCity("Hyndman", "Bedford", stateAbbreviation));
            list.Add(GenerateCity("Manns Choice", "Bedford", stateAbbreviation));
            list.Add(GenerateCity("New Paris", "Bedford", stateAbbreviation));
            list.Add(GenerateCity("Pleasantville", "Bedford", stateAbbreviation));
            list.Add(GenerateCity("Rainsburg", "Bedford", stateAbbreviation));
            list.Add(GenerateCity("Saxton", "Bedford", stateAbbreviation));
            list.Add(GenerateCity("Schellsburg", "Bedford", stateAbbreviation));
            list.Add(GenerateCity("St.Clairsville", "Bedford", stateAbbreviation));
            list.Add(GenerateCity("Woodbury", "Bedford", stateAbbreviation));
            list.Add(GenerateCity("Bally", "Berks", stateAbbreviation));
            list.Add(GenerateCity("Bechtelsville", "Berks", stateAbbreviation));
            list.Add(GenerateCity("Bernville", "Berks", stateAbbreviation));
            list.Add(GenerateCity("Birdsboro", "Berks", stateAbbreviation));
            list.Add(GenerateCity("Boyertown", "Berks", stateAbbreviation));
            list.Add(GenerateCity("Centerport", "Berks", stateAbbreviation));
            list.Add(GenerateCity("Fleetwood", "Berks", stateAbbreviation));
            list.Add(GenerateCity("Hamburg", "Berks", stateAbbreviation));
            list.Add(GenerateCity("Kenhorst", "Berks", stateAbbreviation));
            list.Add(GenerateCity("Kutztown", "Berks", stateAbbreviation));
            list.Add(GenerateCity("Laureldale", "Berks", stateAbbreviation));
            list.Add(GenerateCity("Leesport", "Berks", stateAbbreviation));
            list.Add(GenerateCity("Lenhartsville", "Berks", stateAbbreviation));
            list.Add(GenerateCity("Lyons", "Berks", stateAbbreviation));
            list.Add(GenerateCity("Mohnton", "Berks", stateAbbreviation));
            list.Add(GenerateCity("Mount Penn", "Berks", stateAbbreviation));
            list.Add(GenerateCity("New Morgan", "Berks", stateAbbreviation));
            list.Add(GenerateCity("Robesonia", "Berks", stateAbbreviation));
            list.Add(GenerateCity("Shillington", "Berks", stateAbbreviation));
            list.Add(GenerateCity("Shoemakersville", "Berks", stateAbbreviation));
            list.Add(GenerateCity("Sinking Spring", "Berks", stateAbbreviation));
            list.Add(GenerateCity("St.Lawrence", "Berks", stateAbbreviation));
            list.Add(GenerateCity("Strausstown", "Berks", stateAbbreviation));
            list.Add(GenerateCity("Topton", "Berks", stateAbbreviation));
            list.Add(GenerateCity("Wernersville", "Berks", stateAbbreviation));
            list.Add(GenerateCity("West Reading", "Berks", stateAbbreviation));
            list.Add(GenerateCity("Womelsdorf", "Berks", stateAbbreviation));
            list.Add(GenerateCity("Wyomissing", "Berks", stateAbbreviation));
            list.Add(GenerateCity("Adamstown(Berks&", "Lancaster", stateAbbreviation));
            list.Add(GenerateCity("Bellwood", "Blair", stateAbbreviation));
            list.Add(GenerateCity("Duncansville", "Blair", stateAbbreviation));
            list.Add(GenerateCity("Hollidaysburg", "Blair", stateAbbreviation));
            list.Add(GenerateCity("Martinsburg", "Blair", stateAbbreviation));
            list.Add(GenerateCity("Newry", "Blair", stateAbbreviation));
            list.Add(GenerateCity("Roaring Spring", "Blair", stateAbbreviation));
            list.Add(GenerateCity("Williamsburg", "Blair", stateAbbreviation));
            list.Add(GenerateCity("Tunnelhill(Blair& Cambria)", "Cambria", stateAbbreviation));
            list.Add(GenerateCity("Alba", "Bradford", stateAbbreviation));
            list.Add(GenerateCity("Athens", "Bradford", stateAbbreviation));
            list.Add(GenerateCity("Burlington", "Bradford", stateAbbreviation));
            list.Add(GenerateCity("Canton", "Bradford", stateAbbreviation));
            list.Add(GenerateCity("Le Raysville", "Bradford", stateAbbreviation));
            list.Add(GenerateCity("Monroe", "Bradford", stateAbbreviation));
            list.Add(GenerateCity("New Albany", "Bradford", stateAbbreviation));
            list.Add(GenerateCity("Rome", "Bradford", stateAbbreviation));
            list.Add(GenerateCity("Sayre", "Bradford", stateAbbreviation));
            list.Add(GenerateCity("South Waverly", "Bradford", stateAbbreviation));
            list.Add(GenerateCity("Sylvania", "Bradford", stateAbbreviation));
            list.Add(GenerateCity("Towanda", "Bradford", stateAbbreviation));
            list.Add(GenerateCity("Troy", "Bradford", stateAbbreviation));
            list.Add(GenerateCity("Wyalusing", "Bradford", stateAbbreviation));
            list.Add(GenerateCity("Bristol", "Bucks", stateAbbreviation));
            list.Add(GenerateCity("Doylestown", "Bucks", stateAbbreviation));
            list.Add(GenerateCity("Dublin", "Bucks", stateAbbreviation));
            list.Add(GenerateCity("Hulmeville", "Bucks", stateAbbreviation));
            list.Add(GenerateCity("Ivyland", "Bucks", stateAbbreviation));
            list.Add(GenerateCity("Langhorne", "Bucks", stateAbbreviation));
            list.Add(GenerateCity("Langhorne Manor", "Bucks", stateAbbreviation));
            list.Add(GenerateCity("Morrisville", "Bucks", stateAbbreviation));
            list.Add(GenerateCity("New Britain", "Bucks", stateAbbreviation));
            list.Add(GenerateCity("New Hope", "Bucks", stateAbbreviation));
            list.Add(GenerateCity("Newtown", "Bucks", stateAbbreviation));
            list.Add(GenerateCity("Penndel", "Bucks", stateAbbreviation));
            list.Add(GenerateCity("Perkasie", "Bucks", stateAbbreviation));
            list.Add(GenerateCity("Quakertown", "Bucks", stateAbbreviation));
            list.Add(GenerateCity("Richlandtown", "Bucks", stateAbbreviation));
            list.Add(GenerateCity("Riegelsville", "Bucks", stateAbbreviation));
            list.Add(GenerateCity("Sellersville", "Bucks", stateAbbreviation));
            list.Add(GenerateCity("Silverdale", "Bucks", stateAbbreviation));
            list.Add(GenerateCity("Trumbauersville", "Bucks", stateAbbreviation));
            list.Add(GenerateCity("Tullytown", "Bucks", stateAbbreviation));
            list.Add(GenerateCity("Yardley", "Bucks", stateAbbreviation));
            list.Add(GenerateCity("Telford(Bucks&Montgomery)", "Bucks", stateAbbreviation));
            list.Add(GenerateCity("Bruin", "Butler", stateAbbreviation));
            list.Add(GenerateCity("Callery", "Butler", stateAbbreviation));
            list.Add(GenerateCity("Cherry Valley", "Butler", stateAbbreviation));
            list.Add(GenerateCity("Chicora", "Butler", stateAbbreviation));
            list.Add(GenerateCity("Connoquenessing", "Butler", stateAbbreviation));
            list.Add(GenerateCity("East Butler", "Butler", stateAbbreviation));
            list.Add(GenerateCity("Eau Claire", "Butler", stateAbbreviation));
            list.Add(GenerateCity("Evans City", "Butler", stateAbbreviation));
            list.Add(GenerateCity("Fairview", "Butler", stateAbbreviation));
            list.Add(GenerateCity("Harmony", "Butler", stateAbbreviation));
            list.Add(GenerateCity("Harrisville", "Butler", stateAbbreviation));
            list.Add(GenerateCity("Karns City", "Butler", stateAbbreviation));
            list.Add(GenerateCity("Mars", "Butler", stateAbbreviation));
            list.Add(GenerateCity("Petrolia", "Butler", stateAbbreviation));
            list.Add(GenerateCity("Portersville", "Butler", stateAbbreviation));
            list.Add(GenerateCity("Prospect", "Butler", stateAbbreviation));
            list.Add(GenerateCity("Saxonburg", "Butler", stateAbbreviation));
            list.Add(GenerateCity("Seven Fields", "Butler", stateAbbreviation));
            list.Add(GenerateCity("Slippery Rock", "Butler", stateAbbreviation));
            list.Add(GenerateCity("Valencia", "Butler", stateAbbreviation));
            list.Add(GenerateCity("West Liberty", "Butler", stateAbbreviation));
            list.Add(GenerateCity("West Sunbury", "Butler", stateAbbreviation));
            list.Add(GenerateCity("Zelienople", "Butler", stateAbbreviation));
            list.Add(GenerateCity("Ashville", "Cambria", stateAbbreviation));
            list.Add(GenerateCity("Brownstown", "Cambria", stateAbbreviation));
            list.Add(GenerateCity("Carrolltown", "Cambria", stateAbbreviation));
            list.Add(GenerateCity("Cassandra", "Cambria", stateAbbreviation));
            list.Add(GenerateCity("Chest Springs", "Cambria", stateAbbreviation));
            list.Add(GenerateCity("Cresson", "Cambria", stateAbbreviation));
            list.Add(GenerateCity("Daisytown", "Cambria", stateAbbreviation));
            list.Add(GenerateCity("Dale", "Cambria", stateAbbreviation));
            list.Add(GenerateCity("East Conemaugh", "Cambria", stateAbbreviation));
            list.Add(GenerateCity("Ebensburg", "Cambria", stateAbbreviation));
            list.Add(GenerateCity("Ehrenfeld", "Cambria", stateAbbreviation));
            list.Add(GenerateCity("Ferndale", "Cambria", stateAbbreviation));
            list.Add(GenerateCity("Franklin", "Cambria", stateAbbreviation));
            list.Add(GenerateCity("Gallitzin", "Cambria", stateAbbreviation));
            list.Add(GenerateCity("Geistown", "Cambria", stateAbbreviation));
            list.Add(GenerateCity("Hastings", "Cambria", stateAbbreviation));
            list.Add(GenerateCity("Lilly", "Cambria", stateAbbreviation));
            list.Add(GenerateCity("Lorain", "Cambria", stateAbbreviation));
            list.Add(GenerateCity("Loretto", "Cambria", stateAbbreviation));
            list.Add(GenerateCity("Nanty - Glo", "Cambria", stateAbbreviation));
            list.Add(GenerateCity("Northern Cambria", "Cambria", stateAbbreviation));
            list.Add(GenerateCity("Patton", "Cambria", stateAbbreviation));
            list.Add(GenerateCity("Sankertown", "Cambria", stateAbbreviation));
            list.Add(GenerateCity("Scalp Level", "Cambria", stateAbbreviation));
            list.Add(GenerateCity("South Fork", "Cambria", stateAbbreviation));
            list.Add(GenerateCity("Southmont", "Cambria", stateAbbreviation));
            list.Add(GenerateCity("Summerhill", "Cambria", stateAbbreviation));
            list.Add(GenerateCity("Vintondale", "Cambria", stateAbbreviation));
            list.Add(GenerateCity("Westmont", "Cambria", stateAbbreviation));
            list.Add(GenerateCity("Wilmore", "Cambria", stateAbbreviation));
            list.Add(GenerateCity("Driftwood", "Cameron", stateAbbreviation));
            list.Add(GenerateCity("Emporium", "Cameron", stateAbbreviation));
            list.Add(GenerateCity("Beaver Meadows", "Carbon", stateAbbreviation));
            list.Add(GenerateCity("Bowmanstown", "Carbon", stateAbbreviation));
            list.Add(GenerateCity("East Side", "Carbon", stateAbbreviation));
            list.Add(GenerateCity("Jim Thorpe", "Carbon", stateAbbreviation));
            list.Add(GenerateCity("Lansford", "Carbon", stateAbbreviation));
            list.Add(GenerateCity("Lehighton", "Carbon", stateAbbreviation));
            list.Add(GenerateCity("Nesquehoning", "Carbon", stateAbbreviation));
            list.Add(GenerateCity("Palmerton", "Carbon", stateAbbreviation));
            list.Add(GenerateCity("Parryville", "Carbon", stateAbbreviation));
            list.Add(GenerateCity("Summit Hill", "Carbon", stateAbbreviation));
            list.Add(GenerateCity("Weatherly", "Carbon", stateAbbreviation));
            list.Add(GenerateCity("Weissport", "Carbon", stateAbbreviation));
            list.Add(GenerateCity("Bellefonte", "Centre", stateAbbreviation));
            list.Add(GenerateCity("Centre Hall", "Centre", stateAbbreviation));
            list.Add(GenerateCity("Howard", "Centre", stateAbbreviation));
            list.Add(GenerateCity("Milesburg", "Centre", stateAbbreviation));
            list.Add(GenerateCity("Millheim", "Centre", stateAbbreviation));
            list.Add(GenerateCity("Philipsburg", "Centre", stateAbbreviation));
            list.Add(GenerateCity("Port Matilda", "Centre", stateAbbreviation));
            list.Add(GenerateCity("Snow Shoe", "Centre", stateAbbreviation));
            list.Add(GenerateCity("State College", "Centre", stateAbbreviation));
            list.Add(GenerateCity("Unionville", "Centre", stateAbbreviation));
            list.Add(GenerateCity("Atglen", "Chester", stateAbbreviation));
            list.Add(GenerateCity("Avondale", "Chester", stateAbbreviation));
            list.Add(GenerateCity("Downingtown", "Chester", stateAbbreviation));
            list.Add(GenerateCity("Elverson", "Chester", stateAbbreviation));
            list.Add(GenerateCity("Honey Brook", "Chester", stateAbbreviation));
            list.Add(GenerateCity("Kennett Square", "Chester", stateAbbreviation));
            list.Add(GenerateCity("Modena", "Chester", stateAbbreviation));
            list.Add(GenerateCity("Oxford", "Chester", stateAbbreviation));
            list.Add(GenerateCity("Parkesburg", "Chester", stateAbbreviation));
            list.Add(GenerateCity("Phoenixville", "Chester", stateAbbreviation));
            list.Add(GenerateCity("South Coatesville", "Chester", stateAbbreviation));
            list.Add(GenerateCity("Spring City", "Chester", stateAbbreviation));
            list.Add(GenerateCity("West Chester", "Chester", stateAbbreviation));
            list.Add(GenerateCity("West Grove", "Chester", stateAbbreviation));
            list.Add(GenerateCity("Callensburg", "Clarion", stateAbbreviation));
            list.Add(GenerateCity("Clarion", "Clarion", stateAbbreviation));
            list.Add(GenerateCity("East Brady", "Clarion", stateAbbreviation));
            list.Add(GenerateCity("Foxburg", "Clarion", stateAbbreviation));
            list.Add(GenerateCity("Hawthorn", "Clarion", stateAbbreviation));
            list.Add(GenerateCity("Knox", "Clarion", stateAbbreviation));
            list.Add(GenerateCity("New Bethlehem", "Clarion", stateAbbreviation));
            list.Add(GenerateCity("Rimersburg", "Clarion", stateAbbreviation));
            list.Add(GenerateCity("Shippenville", "Clarion", stateAbbreviation));
            list.Add(GenerateCity("Sligo", "Clarion", stateAbbreviation));
            list.Add(GenerateCity("St.Petersburg", "Clarion", stateAbbreviation));
            list.Add(GenerateCity("Strattanville", "Clarion", stateAbbreviation));
            list.Add(GenerateCity("Emlenton(Clarion&Venango)", "Clarion", stateAbbreviation));
            list.Add(GenerateCity("Brisbin", "Clearfield", stateAbbreviation));
            list.Add(GenerateCity("Burnside", "Clearfield", stateAbbreviation));
            list.Add(GenerateCity("Chester Hill", "Clearfield", stateAbbreviation));
            list.Add(GenerateCity("Clearfield", "Clearfield", stateAbbreviation));
            list.Add(GenerateCity("Coalport", "Clearfield", stateAbbreviation));
            list.Add(GenerateCity("Curwensville", "Clearfield", stateAbbreviation));
            list.Add(GenerateCity("Glen Hope", "Clearfield", stateAbbreviation));
            list.Add(GenerateCity("Grampian", "Clearfield", stateAbbreviation));
            list.Add(GenerateCity("Houtzdale", "Clearfield", stateAbbreviation));
            list.Add(GenerateCity("Irvona", "Clearfield", stateAbbreviation));
            list.Add(GenerateCity("Lumber City", "Clearfield", stateAbbreviation));
            list.Add(GenerateCity("Mahaffey", "Clearfield", stateAbbreviation));
            list.Add(GenerateCity("New Washington", "Clearfield", stateAbbreviation));
            list.Add(GenerateCity("Newburg", "Clearfield", stateAbbreviation));
            list.Add(GenerateCity("Osceola Mills", "Clearfield", stateAbbreviation));
            list.Add(GenerateCity("Ramey", "Clearfield", stateAbbreviation));
            list.Add(GenerateCity("Troutville", "Clearfield", stateAbbreviation));
            list.Add(GenerateCity("Wallaceton", "Clearfield", stateAbbreviation));
            list.Add(GenerateCity("Westover", "Clearfield", stateAbbreviation));
            list.Add(GenerateCity("Falls Creek(Clearfield&Jefferson)", "Clearfield", stateAbbreviation));
            list.Add(GenerateCity("Avis", "Clinton", stateAbbreviation));
            list.Add(GenerateCity("Beech Creek", "Clinton", stateAbbreviation));
            list.Add(GenerateCity("Flemington", "Clinton", stateAbbreviation));
            list.Add(GenerateCity("Loganton", "Clinton", stateAbbreviation));
            list.Add(GenerateCity("Mill Hall", "Clinton", stateAbbreviation));
            list.Add(GenerateCity("Renovo", "Clinton", stateAbbreviation));
            list.Add(GenerateCity("South Renovo", "Clinton", stateAbbreviation));
            list.Add(GenerateCity("Benton", "Columbia", stateAbbreviation));
            list.Add(GenerateCity("Berwick", "Columbia", stateAbbreviation));
            list.Add(GenerateCity("Briar Creek", "Columbia", stateAbbreviation));
            list.Add(GenerateCity("Catawissa", "Columbia", stateAbbreviation));
            list.Add(GenerateCity("Centralia", "Columbia", stateAbbreviation));
            list.Add(GenerateCity("Millville", "Columbia", stateAbbreviation));
            list.Add(GenerateCity("Orangeville", "Columbia", stateAbbreviation));
            list.Add(GenerateCity("Stillwater", "Columbia", stateAbbreviation));
            list.Add(GenerateCity("Ashland(Columbia&Schuylkill)", "Columbia", stateAbbreviation));
            list.Add(GenerateCity("Blooming Valley", "Crawford", stateAbbreviation));
            list.Add(GenerateCity("Centerville", "Crawford", stateAbbreviation));
            list.Add(GenerateCity("Cochranton", "Crawford", stateAbbreviation));
            list.Add(GenerateCity("Conneaut Lake", "Crawford", stateAbbreviation));
            list.Add(GenerateCity("Conneautville", "Crawford", stateAbbreviation));
            list.Add(GenerateCity("Hydetown", "Crawford", stateAbbreviation));
            list.Add(GenerateCity("Linesville", "Crawford", stateAbbreviation));
            list.Add(GenerateCity("Saegertown", "Crawford", stateAbbreviation));
            list.Add(GenerateCity("Spartansburg", "Crawford", stateAbbreviation));
            list.Add(GenerateCity("Springboro", "Crawford", stateAbbreviation));
            list.Add(GenerateCity("Townville", "Crawford", stateAbbreviation));
            list.Add(GenerateCity("Venango", "Crawford", stateAbbreviation));
            list.Add(GenerateCity("Woodcock", "Crawford", stateAbbreviation));
            list.Add(GenerateCity("Camp Hill", "Cumberland", stateAbbreviation));
            list.Add(GenerateCity("Carlisle", "Cumberland", stateAbbreviation));
            list.Add(GenerateCity("Lemoyne", "Cumberland", stateAbbreviation));
            list.Add(GenerateCity("Mechanicsburg", "Cumberland", stateAbbreviation));
            list.Add(GenerateCity("Mount Holly Springs", "Cumberland", stateAbbreviation));
            list.Add(GenerateCity("New Cumberland", "Cumberland", stateAbbreviation));
            list.Add(GenerateCity("Newburg", "Cumberland", stateAbbreviation));
            list.Add(GenerateCity("Newville", "Cumberland", stateAbbreviation));
            list.Add(GenerateCity("Shiremanstown", "Cumberland", stateAbbreviation));
            list.Add(GenerateCity("Wormleysburg", "Cumberland", stateAbbreviation));
            list.Add(GenerateCity("Shippensburg(Cumberland&Franklin)", "Cumberland", stateAbbreviation));
            list.Add(GenerateCity("Berrysburg", "Dauphin", stateAbbreviation));
            list.Add(GenerateCity("Dauphin", "Dauphin", stateAbbreviation));
            list.Add(GenerateCity("Elizabethville", "Dauphin", stateAbbreviation));
            list.Add(GenerateCity("Gratz", "Dauphin", stateAbbreviation));
            list.Add(GenerateCity("Halifax", "Dauphin", stateAbbreviation));
            list.Add(GenerateCity("Highspire", "Dauphin", stateAbbreviation));
            list.Add(GenerateCity("Hummelstown", "Dauphin", stateAbbreviation));
            list.Add(GenerateCity("Lykens", "Dauphin", stateAbbreviation));
            list.Add(GenerateCity("Middletown", "Dauphin", stateAbbreviation));
            list.Add(GenerateCity("Millersburg", "Dauphin", stateAbbreviation));
            list.Add(GenerateCity("Paxtang", "Dauphin", stateAbbreviation));
            list.Add(GenerateCity("Penbrook", "Dauphin", stateAbbreviation));
            list.Add(GenerateCity("Pillow", "Dauphin", stateAbbreviation));
            list.Add(GenerateCity("Royalton", "Dauphin", stateAbbreviation));
            list.Add(GenerateCity("Steelton", "Dauphin", stateAbbreviation));
            list.Add(GenerateCity("Williamstown", "Dauphin", stateAbbreviation));
            list.Add(GenerateCity("Aldan", "Delaware", stateAbbreviation));
            list.Add(GenerateCity("Brookhaven", "Delaware", stateAbbreviation));
            list.Add(GenerateCity("Chester Heights", "Delaware", stateAbbreviation));
            list.Add(GenerateCity("Clifton Heights", "Delaware", stateAbbreviation));
            list.Add(GenerateCity("Collingdale", "Delaware", stateAbbreviation));
            list.Add(GenerateCity("Colwyn", "Delaware", stateAbbreviation));
            list.Add(GenerateCity("Darby", "Delaware", stateAbbreviation));
            list.Add(GenerateCity("East Lansdowne", "Delaware", stateAbbreviation));
            list.Add(GenerateCity("Eddystone", "Delaware", stateAbbreviation));
            list.Add(GenerateCity("Folcroft", "Delaware", stateAbbreviation));
            list.Add(GenerateCity("Glenolden", "Delaware", stateAbbreviation));
            list.Add(GenerateCity("Lansdowne", "Delaware", stateAbbreviation));
            list.Add(GenerateCity("Marcus Hook", "Delaware", stateAbbreviation));
            list.Add(GenerateCity("Media", "Delaware", stateAbbreviation));
            list.Add(GenerateCity("Millbourne", "Delaware", stateAbbreviation));
            list.Add(GenerateCity("Morton", "Delaware", stateAbbreviation));
            list.Add(GenerateCity("Norwood", "Delaware", stateAbbreviation));
            list.Add(GenerateCity("Parkside", "Delaware", stateAbbreviation));
            list.Add(GenerateCity("Prospect Park", "Delaware", stateAbbreviation));
            list.Add(GenerateCity("Ridley Park", "Delaware", stateAbbreviation));
            list.Add(GenerateCity("Rose Valley", "Delaware", stateAbbreviation));
            list.Add(GenerateCity("Rutledge", "Delaware", stateAbbreviation));
            list.Add(GenerateCity("Sharon Hill", "Delaware", stateAbbreviation));
            list.Add(GenerateCity("Swarthmore", "Delaware", stateAbbreviation));
            list.Add(GenerateCity("Trainer", "Delaware", stateAbbreviation));
            list.Add(GenerateCity("Upland", "Delaware", stateAbbreviation));
            list.Add(GenerateCity("Yeadon", "Delaware", stateAbbreviation));
            list.Add(GenerateCity("Johnsonburg", "Elk", stateAbbreviation));
            list.Add(GenerateCity("Ridgway", "Elk", stateAbbreviation));
            list.Add(GenerateCity("Albion", "Erie", stateAbbreviation));
            list.Add(GenerateCity("Cranesville", "Erie", stateAbbreviation));
            list.Add(GenerateCity("Elgin", "Erie", stateAbbreviation));
            list.Add(GenerateCity("Girard", "Erie", stateAbbreviation));
            list.Add(GenerateCity("Lake City", "Erie", stateAbbreviation));
            list.Add(GenerateCity("McKean", "Erie", stateAbbreviation));
            list.Add(GenerateCity("Mill Village", "Erie", stateAbbreviation));
            list.Add(GenerateCity("North East", "Erie", stateAbbreviation));
            list.Add(GenerateCity("Platea", "Erie", stateAbbreviation));
            list.Add(GenerateCity("Union City", "Erie", stateAbbreviation));
            list.Add(GenerateCity("Waterford", "Erie", stateAbbreviation));
            list.Add(GenerateCity("Wattsburg", "Erie", stateAbbreviation));
            list.Add(GenerateCity("Wesleyville", "Erie", stateAbbreviation));
            list.Add(GenerateCity("Belle Vernon", "Fayette", stateAbbreviation));
            list.Add(GenerateCity("Brownsville", "Fayette", stateAbbreviation));
            list.Add(GenerateCity("Dawson", "Fayette", stateAbbreviation));
            list.Add(GenerateCity("Dunbar", "Fayette", stateAbbreviation));
            list.Add(GenerateCity("Everson", "Fayette", stateAbbreviation));
            list.Add(GenerateCity("Fairchance", "Fayette", stateAbbreviation));
            list.Add(GenerateCity("Fayette City", "Fayette", stateAbbreviation));
            list.Add(GenerateCity("Markleysburg", "Fayette", stateAbbreviation));
            list.Add(GenerateCity("Masontown", "Fayette", stateAbbreviation));
            list.Add(GenerateCity("Newell", "Fayette", stateAbbreviation));
            list.Add(GenerateCity("Ohiopyle", "Fayette", stateAbbreviation));
            list.Add(GenerateCity("Perryopolis", "Fayette", stateAbbreviation));
            list.Add(GenerateCity("Point Marion", "Fayette", stateAbbreviation));
            list.Add(GenerateCity("Smithfield", "Fayette", stateAbbreviation));
            list.Add(GenerateCity("South Connellsville", "Fayette", stateAbbreviation));
            list.Add(GenerateCity("Vanderbilt", "Fayette", stateAbbreviation));
            list.Add(GenerateCity("Seven Springs(Fayette&Somerset)", "Fayette", stateAbbreviation));
            list.Add(GenerateCity("Tionesta", "Forest", stateAbbreviation));
            list.Add(GenerateCity("Chambersburg", "Franklin", stateAbbreviation));
            list.Add(GenerateCity("Greencastle", "Franklin", stateAbbreviation));
            list.Add(GenerateCity("Mercersburg", "Franklin", stateAbbreviation));
            list.Add(GenerateCity("Mont Alto", "Franklin", stateAbbreviation));
            list.Add(GenerateCity("Orrstown", "Franklin", stateAbbreviation));
            list.Add(GenerateCity("Waynesboro", "Franklin", stateAbbreviation));
            list.Add(GenerateCity("McConnellsburg", "Fulton", stateAbbreviation));
            list.Add(GenerateCity("Valley - Hi", "Fulton", stateAbbreviation));
            list.Add(GenerateCity("Carmichaels", "Greene", stateAbbreviation));
            list.Add(GenerateCity("Clarksville", "Greene", stateAbbreviation));
            list.Add(GenerateCity("Greensboro", "Greene", stateAbbreviation));
            list.Add(GenerateCity("Jefferson", "Greene", stateAbbreviation));
            list.Add(GenerateCity("Rices Landing", "Greene", stateAbbreviation));
            list.Add(GenerateCity("Waynesburg", "Greene", stateAbbreviation));
            list.Add(GenerateCity("Alexandria", "Huntingdon", stateAbbreviation));
            list.Add(GenerateCity("Birmingham", "Huntingdon", stateAbbreviation));
            list.Add(GenerateCity("Broad Top City", "Huntingdon", stateAbbreviation));
            list.Add(GenerateCity("Cassville", "Huntingdon", stateAbbreviation));
            list.Add(GenerateCity("Coalmont", "Huntingdon", stateAbbreviation));
            list.Add(GenerateCity("Dudley", "Huntingdon", stateAbbreviation));
            list.Add(GenerateCity("Huntingdon", "Huntingdon", stateAbbreviation));
            list.Add(GenerateCity("Mapleton", "Huntingdon", stateAbbreviation));
            list.Add(GenerateCity("Marklesburg", "Huntingdon", stateAbbreviation));
            list.Add(GenerateCity("Mill Creek", "Huntingdon", stateAbbreviation));
            list.Add(GenerateCity("Mount Union", "Huntingdon", stateAbbreviation));
            list.Add(GenerateCity("Orbisonia", "Huntingdon", stateAbbreviation));
            list.Add(GenerateCity("Petersburg", "Huntingdon", stateAbbreviation));
            list.Add(GenerateCity("Rockhill", "Huntingdon", stateAbbreviation));
            list.Add(GenerateCity("Saltillo", "Huntingdon", stateAbbreviation));
            list.Add(GenerateCity("Shade Gap", "Huntingdon", stateAbbreviation));
            list.Add(GenerateCity("Shirleysburg", "Huntingdon", stateAbbreviation));
            list.Add(GenerateCity("Three Springs", "Huntingdon", stateAbbreviation));
            list.Add(GenerateCity("Armagh", "Indiana", stateAbbreviation));
            list.Add(GenerateCity("Blairsville", "Indiana", stateAbbreviation));
            list.Add(GenerateCity("Cherry Tree", "Indiana", stateAbbreviation));
            list.Add(GenerateCity("Clymer", "Indiana", stateAbbreviation));
            list.Add(GenerateCity("Creekside", "Indiana", stateAbbreviation));
            list.Add(GenerateCity("Ernest", "Indiana", stateAbbreviation));
            list.Add(GenerateCity("Glen Campbell", "Indiana", stateAbbreviation));
            list.Add(GenerateCity("Homer City", "Indiana", stateAbbreviation));
            list.Add(GenerateCity("Indiana", "Indiana", stateAbbreviation));
            list.Add(GenerateCity("Marion Center", "Indiana", stateAbbreviation));
            list.Add(GenerateCity("Plumville", "Indiana", stateAbbreviation));
            list.Add(GenerateCity("Saltsburg", "Indiana", stateAbbreviation));
            list.Add(GenerateCity("Shelocta", "Indiana", stateAbbreviation));
            list.Add(GenerateCity("Smicksburg", "Indiana", stateAbbreviation));
            list.Add(GenerateCity("Big Run", "Jefferson", stateAbbreviation));
            list.Add(GenerateCity("Brockway", "Jefferson", stateAbbreviation));
            list.Add(GenerateCity("Brookville", "Jefferson", stateAbbreviation));
            list.Add(GenerateCity("Corsica", "Jefferson", stateAbbreviation));
            list.Add(GenerateCity("Punxsutawney", "Jefferson", stateAbbreviation));
            list.Add(GenerateCity("Reynoldsville", "Jefferson", stateAbbreviation));
            list.Add(GenerateCity("Summerville", "Jefferson", stateAbbreviation));
            list.Add(GenerateCity("Sykesville", "Jefferson", stateAbbreviation));
            list.Add(GenerateCity("Timblin", "Jefferson", stateAbbreviation));
            list.Add(GenerateCity("Worthville", "Jefferson", stateAbbreviation));
            list.Add(GenerateCity("Mifflin", "Juniata", stateAbbreviation));
            list.Add(GenerateCity("Mifflintown", "Juniata", stateAbbreviation));
            list.Add(GenerateCity("Port Royal", "Juniata", stateAbbreviation));
            list.Add(GenerateCity("Thompsontown", "Juniata", stateAbbreviation));
            list.Add(GenerateCity("Archbald", "Lackawanna", stateAbbreviation));
            list.Add(GenerateCity("Blakely", "Lackawanna", stateAbbreviation));
            list.Add(GenerateCity("Clarks Green", "Lackawanna", stateAbbreviation));
            list.Add(GenerateCity("Clarks Summit", "Lackawanna", stateAbbreviation));
            list.Add(GenerateCity("Dalton", "Lackawanna", stateAbbreviation));
            list.Add(GenerateCity("Dickson City", "Lackawanna", stateAbbreviation));
            list.Add(GenerateCity("Dunmore", "Lackawanna", stateAbbreviation));
            list.Add(GenerateCity("Jermyn", "Lackawanna", stateAbbreviation));
            list.Add(GenerateCity("Jessup", "Lackawanna", stateAbbreviation));
            list.Add(GenerateCity("Mayfield", "Lackawanna", stateAbbreviation));
            list.Add(GenerateCity("Moosic", "Lackawanna", stateAbbreviation));
            list.Add(GenerateCity("Moscow", "Lackawanna", stateAbbreviation));
            list.Add(GenerateCity("Old Forge", "Lackawanna", stateAbbreviation));
            list.Add(GenerateCity("Olyphant", "Lackawanna", stateAbbreviation));
            list.Add(GenerateCity("Taylor", "Lackawanna", stateAbbreviation));
            list.Add(GenerateCity("Throop", "Lackawanna", stateAbbreviation));
            list.Add(GenerateCity("Vandling", "Lackawanna", stateAbbreviation));
            list.Add(GenerateCity("Akron", "Lancaster", stateAbbreviation));
            list.Add(GenerateCity("Christiana", "Lancaster", stateAbbreviation));
            list.Add(GenerateCity("Columbia", "Lancaster", stateAbbreviation));
            list.Add(GenerateCity("Denver", "Lancaster", stateAbbreviation));
            list.Add(GenerateCity("East Petersburg", "Lancaster", stateAbbreviation));
            list.Add(GenerateCity("Elizabethtown", "Lancaster", stateAbbreviation));
            list.Add(GenerateCity("Ephrata", "Lancaster", stateAbbreviation));
            list.Add(GenerateCity("Lititz", "Lancaster", stateAbbreviation));
            list.Add(GenerateCity("Manheim", "Lancaster", stateAbbreviation));
            list.Add(GenerateCity("Marietta", "Lancaster", stateAbbreviation));
            list.Add(GenerateCity("Millersville", "Lancaster", stateAbbreviation));
            list.Add(GenerateCity("Mount Joy", "Lancaster", stateAbbreviation));
            list.Add(GenerateCity("Mountville", "Lancaster", stateAbbreviation));
            list.Add(GenerateCity("New Holland", "Lancaster", stateAbbreviation));
            list.Add(GenerateCity("Quarryville", "Lancaster", stateAbbreviation));
            list.Add(GenerateCity("Strasburg", "Lancaster", stateAbbreviation));
            list.Add(GenerateCity("Terre Hill", "Lancaster", stateAbbreviation));
            list.Add(GenerateCity("Bessemer", "Lawrence", stateAbbreviation));
            list.Add(GenerateCity("Ellport", "Lawrence", stateAbbreviation));
            list.Add(GenerateCity("Enon Valley", "Lawrence", stateAbbreviation));
            list.Add(GenerateCity("New Beaver", "Lawrence", stateAbbreviation));
            list.Add(GenerateCity("New Wilmington", "Lawrence", stateAbbreviation));
            list.Add(GenerateCity("S.N.P.J.", "Lawrence", stateAbbreviation));
            list.Add(GenerateCity("South New Castle", "Lawrence", stateAbbreviation));
            list.Add(GenerateCity("Volant", "Lawrence", stateAbbreviation));
            list.Add(GenerateCity("Wampum", "Lawrence", stateAbbreviation));
            list.Add(GenerateCity("Cleona", "Lebanon", stateAbbreviation));
            list.Add(GenerateCity("Cornwall", "Lebanon", stateAbbreviation));
            list.Add(GenerateCity("Jonestown", "Lebanon", stateAbbreviation));
            list.Add(GenerateCity("Mount Gretna", "Lebanon", stateAbbreviation));
            list.Add(GenerateCity("Myerstown", "Lebanon", stateAbbreviation));
            list.Add(GenerateCity("Palmyra", "Lebanon", stateAbbreviation));
            list.Add(GenerateCity("Richland", "Lebanon", stateAbbreviation));
            list.Add(GenerateCity("Alburtis", "Lehigh", stateAbbreviation));
            list.Add(GenerateCity("Catasauqua", "Lehigh", stateAbbreviation));
            list.Add(GenerateCity("Coopersburg", "Lehigh", stateAbbreviation));
            list.Add(GenerateCity("Coplay", "Lehigh", stateAbbreviation));
            list.Add(GenerateCity("Emmaus", "Lehigh", stateAbbreviation));
            list.Add(GenerateCity("Fountain Hill", "Lehigh", stateAbbreviation));
            list.Add(GenerateCity("Macungie", "Lehigh", stateAbbreviation));
            list.Add(GenerateCity("Slatington", "Lehigh", stateAbbreviation));
            list.Add(GenerateCity("Ashley", "Luzerne", stateAbbreviation));
            list.Add(GenerateCity("Avoca", "Luzerne", stateAbbreviation));
            list.Add(GenerateCity("Bear Creek Village", "Luzerne", stateAbbreviation));
            list.Add(GenerateCity("Conyngham", "Luzerne", stateAbbreviation));
            list.Add(GenerateCity("Courtdale", "Luzerne", stateAbbreviation));
            list.Add(GenerateCity("Dallas", "Luzerne", stateAbbreviation));
            list.Add(GenerateCity("Dupont", "Luzerne", stateAbbreviation));
            list.Add(GenerateCity("Duryea", "Luzerne", stateAbbreviation));
            list.Add(GenerateCity("Edwardsville", "Luzerne", stateAbbreviation));
            list.Add(GenerateCity("Exeter", "Luzerne", stateAbbreviation));
            list.Add(GenerateCity("Forty Fort", "Luzerne", stateAbbreviation));
            list.Add(GenerateCity("Freeland", "Luzerne", stateAbbreviation));
            list.Add(GenerateCity("Harveys Lake", "Luzerne", stateAbbreviation));
            list.Add(GenerateCity("Hughestown", "Luzerne", stateAbbreviation));
            list.Add(GenerateCity("Jeddo", "Luzerne", stateAbbreviation));
            list.Add(GenerateCity("Laflin", "Luzerne", stateAbbreviation));
            list.Add(GenerateCity("Larksville", "Luzerne", stateAbbreviation));
            list.Add(GenerateCity("Laurel Run", "Luzerne", stateAbbreviation));
            list.Add(GenerateCity("Luzerne", "Luzerne", stateAbbreviation));
            list.Add(GenerateCity("Nescopeck", "Luzerne", stateAbbreviation));
            list.Add(GenerateCity("New Columbus", "Luzerne", stateAbbreviation));
            list.Add(GenerateCity("Nuangola", "Luzerne", stateAbbreviation));
            list.Add(GenerateCity("Penn Lake Park", "Luzerne", stateAbbreviation));
            list.Add(GenerateCity("Plymouth", "Luzerne", stateAbbreviation));
            list.Add(GenerateCity("Pringle", "Luzerne", stateAbbreviation));
            list.Add(GenerateCity("Shickshinny", "Luzerne", stateAbbreviation));
            list.Add(GenerateCity("Sugar Notch", "Luzerne", stateAbbreviation));
            list.Add(GenerateCity("Swoyersville", "Luzerne", stateAbbreviation));
            list.Add(GenerateCity("Warrior Run", "Luzerne", stateAbbreviation));
            list.Add(GenerateCity("West Hazleton", "Luzerne", stateAbbreviation));
            list.Add(GenerateCity("West Pittston", "Luzerne", stateAbbreviation));
            list.Add(GenerateCity("West Wyoming", "Luzerne", stateAbbreviation));
            list.Add(GenerateCity("White Haven", "Luzerne", stateAbbreviation));
            list.Add(GenerateCity("Wyoming", "Luzerne", stateAbbreviation));
            list.Add(GenerateCity("Yatesville", "Luzerne", stateAbbreviation));
            list.Add(GenerateCity("Duboistown", "Lycoming", stateAbbreviation));
            list.Add(GenerateCity("Hughesville", "Lycoming", stateAbbreviation));
            list.Add(GenerateCity("Jersey Shore", "Lycoming", stateAbbreviation));
            list.Add(GenerateCity("Montgomery", "Lycoming", stateAbbreviation));
            list.Add(GenerateCity("Montoursville", "Lycoming", stateAbbreviation));
            list.Add(GenerateCity("Muncy", "Lycoming", stateAbbreviation));
            list.Add(GenerateCity("Picture Rocks", "Lycoming", stateAbbreviation));
            list.Add(GenerateCity("Salladasburg", "Lycoming", stateAbbreviation));
            list.Add(GenerateCity("South Williamsport", "Lycoming", stateAbbreviation));
            list.Add(GenerateCity("Eldred", "McKean", stateAbbreviation));
            list.Add(GenerateCity("Kane", "McKean", stateAbbreviation));
            list.Add(GenerateCity("Lewis Run", "McKean", stateAbbreviation));
            list.Add(GenerateCity("Mount Jewett", "McKean", stateAbbreviation));
            list.Add(GenerateCity("Port Allegany", "McKean", stateAbbreviation));
            list.Add(GenerateCity("Smethport", "McKean", stateAbbreviation));
            list.Add(GenerateCity("Jackson Center", "Mercer", stateAbbreviation));
            list.Add(GenerateCity("Jamestown", "Mercer", stateAbbreviation));
            list.Add(GenerateCity("Clark", "Mercer", stateAbbreviation));
            list.Add(GenerateCity("Fredonia", "Mercer", stateAbbreviation));
            list.Add(GenerateCity("Greenville", "Mercer", stateAbbreviation));
            list.Add(GenerateCity("Grove City", "Mercer", stateAbbreviation));
            list.Add(GenerateCity("Mercer", "Mercer", stateAbbreviation));
            list.Add(GenerateCity("New Lebanon", "Mercer", stateAbbreviation));
            list.Add(GenerateCity("Sandy Lake", "Mercer", stateAbbreviation));
            list.Add(GenerateCity("Sharpsville", "Mercer", stateAbbreviation));
            list.Add(GenerateCity("Sheakleyville", "Mercer", stateAbbreviation));
            list.Add(GenerateCity("Stoneboro", "Mercer", stateAbbreviation));
            list.Add(GenerateCity("West Middlesex", "Mercer", stateAbbreviation));
            list.Add(GenerateCity("Wheatland", "Mercer", stateAbbreviation));
            list.Add(GenerateCity("Burnham", "Mifflin", stateAbbreviation));
            list.Add(GenerateCity("Juniata Terrace", "Mifflin", stateAbbreviation));
            list.Add(GenerateCity("Kistler", "Mifflin", stateAbbreviation));
            list.Add(GenerateCity("Lewistown", "Mifflin", stateAbbreviation));
            list.Add(GenerateCity("McVeytown", "Mifflin", stateAbbreviation));
            list.Add(GenerateCity("Newton Hamilton", "Mifflin", stateAbbreviation));
            list.Add(GenerateCity("Delaware Water Gap", "Monroe", stateAbbreviation));
            list.Add(GenerateCity("East Stroudsburg", "Monroe", stateAbbreviation));
            list.Add(GenerateCity("Mount Pocono", "Monroe", stateAbbreviation));
            list.Add(GenerateCity("Stroudsburg", "Monroe", stateAbbreviation));
            list.Add(GenerateCity("Ambler", "Montgomery", stateAbbreviation));
            list.Add(GenerateCity("Bridgeport", "Montgomery", stateAbbreviation));
            list.Add(GenerateCity("Collegeville", "Montgomery", stateAbbreviation));
            list.Add(GenerateCity("Conshohocken", "Montgomery", stateAbbreviation));
            list.Add(GenerateCity("East Greenville", "Montgomery", stateAbbreviation));
            list.Add(GenerateCity("Green Lane", "Montgomery", stateAbbreviation));
            list.Add(GenerateCity("Hatboro", "Montgomery", stateAbbreviation));
            list.Add(GenerateCity("Hatfield", "Montgomery", stateAbbreviation));
            list.Add(GenerateCity("Jenkintown", "Montgomery", stateAbbreviation));
            list.Add(GenerateCity("Lansdale", "Montgomery", stateAbbreviation));
            list.Add(GenerateCity("Narberth", "Montgomery", stateAbbreviation));
            list.Add(GenerateCity("North Wales", "Montgomery", stateAbbreviation));
            list.Add(GenerateCity("Pennsburg", "Montgomery", stateAbbreviation));
            list.Add(GenerateCity("Pottstown", "Montgomery", stateAbbreviation));
            list.Add(GenerateCity("Red Hill", "Montgomery", stateAbbreviation));
            list.Add(GenerateCity("Rockledge", "Montgomery", stateAbbreviation));
            list.Add(GenerateCity("Royersford", "Montgomery", stateAbbreviation));
            list.Add(GenerateCity("Schwenksville", "Montgomery", stateAbbreviation));
            list.Add(GenerateCity("Souderton", "Montgomery", stateAbbreviation));
            list.Add(GenerateCity("Trappe", "Montgomery", stateAbbreviation));
            list.Add(GenerateCity("West Conshohocken", "Montgomery", stateAbbreviation));
            list.Add(GenerateCity("Danville", "Montour", stateAbbreviation));
            list.Add(GenerateCity("Washingtonville", "Montour", stateAbbreviation));
            list.Add(GenerateCity("Bangor", "Northampton", stateAbbreviation));
            list.Add(GenerateCity("Bath", "Northampton", stateAbbreviation));
            list.Add(GenerateCity("Chapman", "Northampton", stateAbbreviation));
            list.Add(GenerateCity("East Bangor", "Northampton", stateAbbreviation));
            list.Add(GenerateCity("Freemansburg", "Northampton", stateAbbreviation));
            list.Add(GenerateCity("Glendon", "Northampton", stateAbbreviation));
            list.Add(GenerateCity("Hellertown", "Northampton", stateAbbreviation));
            list.Add(GenerateCity("Nazareth", "Northampton", stateAbbreviation));
            list.Add(GenerateCity("North Catasauqua", "Northampton", stateAbbreviation));
            list.Add(GenerateCity("Northampton", "Northampton", stateAbbreviation));
            list.Add(GenerateCity("Pen Argyl", "Northampton", stateAbbreviation));
            list.Add(GenerateCity("Portland", "Northampton", stateAbbreviation));
            list.Add(GenerateCity("Roseto", "Northampton", stateAbbreviation));
            list.Add(GenerateCity("Stockertown", "Northampton", stateAbbreviation));
            list.Add(GenerateCity("Tatamy", "Northampton", stateAbbreviation));
            list.Add(GenerateCity("Walnutport", "Northampton", stateAbbreviation));
            list.Add(GenerateCity("West Easton", "Northampton", stateAbbreviation));
            list.Add(GenerateCity("Wilson", "Northampton", stateAbbreviation));
            list.Add(GenerateCity("Wind Gap", "Northampton", stateAbbreviation));
            list.Add(GenerateCity("Herndon", "Northumberland", stateAbbreviation));
            list.Add(GenerateCity("Kulpmont", "Northumberland", stateAbbreviation));
            list.Add(GenerateCity("Marion Heights", "Northumberland", stateAbbreviation));
            list.Add(GenerateCity("McEwensville", "Northumberland", stateAbbreviation));
            list.Add(GenerateCity("Milton", "Northumberland", stateAbbreviation));
            list.Add(GenerateCity("Mount Carmel", "Northumberland", stateAbbreviation));
            list.Add(GenerateCity("Northumberland", "Northumberland", stateAbbreviation));
            list.Add(GenerateCity("Riverside", "Northumberland", stateAbbreviation));
            list.Add(GenerateCity("Snydertown", "Northumberland", stateAbbreviation));
            list.Add(GenerateCity("Turbotville", "Northumberland", stateAbbreviation));
            list.Add(GenerateCity("Watsontown", "Northumberland", stateAbbreviation));
            list.Add(GenerateCity("Blain", "Perry", stateAbbreviation));
            list.Add(GenerateCity("Bloomfield", "Perry", stateAbbreviation));
            list.Add(GenerateCity("Duncannon", "Perry", stateAbbreviation));
            list.Add(GenerateCity("Landisburg", "Perry", stateAbbreviation));
            list.Add(GenerateCity("Liverpool", "Perry", stateAbbreviation));
            list.Add(GenerateCity("Marysville", "Perry", stateAbbreviation));
            list.Add(GenerateCity("Millerstown", "Perry", stateAbbreviation));
            list.Add(GenerateCity("New Buffalo", "Perry", stateAbbreviation));
            list.Add(GenerateCity("Newport", "Perry", stateAbbreviation));
            list.Add(GenerateCity("Matamoras", "Pike", stateAbbreviation));
            list.Add(GenerateCity("Milford", "Pike", stateAbbreviation));
            list.Add(GenerateCity("Austin", "Potter", stateAbbreviation));
            list.Add(GenerateCity("Coudersport", "Potter", stateAbbreviation));
            list.Add(GenerateCity("Galeton", "Potter", stateAbbreviation));
            list.Add(GenerateCity("Oswayo", "Potter", stateAbbreviation));
            list.Add(GenerateCity("Shinglehouse", "Potter", stateAbbreviation));
            list.Add(GenerateCity("Ulysses", "Potter", stateAbbreviation));
            list.Add(GenerateCity("Auburn", "Schuylkill", stateAbbreviation));
            list.Add(GenerateCity("Coaldale", "Schuylkill", stateAbbreviation));
            list.Add(GenerateCity("Cressona", "Schuylkill", stateAbbreviation));
            list.Add(GenerateCity("Deer Lake", "Schuylkill", stateAbbreviation));
            list.Add(GenerateCity("Frackville", "Schuylkill", stateAbbreviation));
            list.Add(GenerateCity("Gilberton", "Schuylkill", stateAbbreviation));
            list.Add(GenerateCity("Girardville", "Schuylkill", stateAbbreviation));
            list.Add(GenerateCity("Gordon", "Schuylkill", stateAbbreviation));
            list.Add(GenerateCity("Landingville", "Schuylkill", stateAbbreviation));
            list.Add(GenerateCity("Mahanoy City", "Schuylkill", stateAbbreviation));
            list.Add(GenerateCity("McAdoo", "Schuylkill", stateAbbreviation));
            list.Add(GenerateCity("Mechanicsville", "Schuylkill", stateAbbreviation));
            list.Add(GenerateCity("Middleport", "Schuylkill", stateAbbreviation));
            list.Add(GenerateCity("Minersville", "Schuylkill", stateAbbreviation));
            list.Add(GenerateCity("Mount Carbon", "Schuylkill", stateAbbreviation));
            list.Add(GenerateCity("New Philadelphia", "Schuylkill", stateAbbreviation));
            list.Add(GenerateCity("New Ringgold", "Schuylkill", stateAbbreviation));
            list.Add(GenerateCity("Orwigsburg", "Schuylkill", stateAbbreviation));
            list.Add(GenerateCity("Palo Alto", "Schuylkill", stateAbbreviation));
            list.Add(GenerateCity("Pine Grove", "Schuylkill", stateAbbreviation));
            list.Add(GenerateCity("Port Carbon", "Schuylkill", stateAbbreviation));
            list.Add(GenerateCity("Port Clinton", "Schuylkill", stateAbbreviation));
            list.Add(GenerateCity("Ringtown", "Schuylkill", stateAbbreviation));
            list.Add(GenerateCity("Schuylkill Haven", "Schuylkill", stateAbbreviation));
            list.Add(GenerateCity("Shenandoah", "Schuylkill", stateAbbreviation));
            list.Add(GenerateCity("St.Clair", "Schuylkill", stateAbbreviation));
            list.Add(GenerateCity("Tamaqua", "Schuylkill", stateAbbreviation));
            list.Add(GenerateCity("Tower City", "Schuylkill", stateAbbreviation));
            list.Add(GenerateCity("Tremont", "Schuylkill", stateAbbreviation));
            list.Add(GenerateCity("Beavertown", "Snyder", stateAbbreviation));
            list.Add(GenerateCity("Freeburg", "Snyder", stateAbbreviation));
            list.Add(GenerateCity("McClure", "Snyder", stateAbbreviation));
            list.Add(GenerateCity("Middleburg", "Snyder", stateAbbreviation));
            list.Add(GenerateCity("Selinsgrove", "Snyder", stateAbbreviation));
            list.Add(GenerateCity("Shamokin Dam", "Snyder", stateAbbreviation));
            list.Add(GenerateCity("Addison", "Somerset", stateAbbreviation));
            list.Add(GenerateCity("Benson", "Somerset", stateAbbreviation));
            list.Add(GenerateCity("Berlin", "Somerset", stateAbbreviation));
            list.Add(GenerateCity("Boswell", "Somerset", stateAbbreviation));
            list.Add(GenerateCity("Callimont", "Somerset", stateAbbreviation));
            list.Add(GenerateCity("Casselman", "Somerset", stateAbbreviation));
            list.Add(GenerateCity("Central City", "Somerset", stateAbbreviation));
            list.Add(GenerateCity("Confluence", "Somerset", stateAbbreviation));
            list.Add(GenerateCity("Garrett", "Somerset", stateAbbreviation));
            list.Add(GenerateCity("Hooversville", "Somerset", stateAbbreviation));
            list.Add(GenerateCity("Indian Lake", "Somerset", stateAbbreviation));
            list.Add(GenerateCity("Jennerstown", "Somerset", stateAbbreviation));
            list.Add(GenerateCity("Meyersdale", "Somerset", stateAbbreviation));
            list.Add(GenerateCity("New Baltimore", "Somerset", stateAbbreviation));
            list.Add(GenerateCity("New Centerville", "Somerset", stateAbbreviation));
            list.Add(GenerateCity("Paint", "Somerset", stateAbbreviation));
            list.Add(GenerateCity("Rockwood", "Somerset", stateAbbreviation));
            list.Add(GenerateCity("Salisbury", "Somerset", stateAbbreviation));
            list.Add(GenerateCity("Shanksville", "Somerset", stateAbbreviation));
            list.Add(GenerateCity("Somerset", "Somerset", stateAbbreviation));
            list.Add(GenerateCity("Stoystown", "Somerset", stateAbbreviation));
            list.Add(GenerateCity("Ursina", "Somerset", stateAbbreviation));
            list.Add(GenerateCity("Wellersburg", "Somerset", stateAbbreviation));
            list.Add(GenerateCity("Windber", "Somerset", stateAbbreviation));
            list.Add(GenerateCity("Dushore", "Sullivan", stateAbbreviation));
            list.Add(GenerateCity("Eagles Mere", "Sullivan", stateAbbreviation));
            list.Add(GenerateCity("Forksville", "Sullivan", stateAbbreviation));
            list.Add(GenerateCity("Laporte", "Sullivan", stateAbbreviation));
            list.Add(GenerateCity("Bridgewater", "Susquehanna", stateAbbreviation));
            list.Add(GenerateCity("Forest City", "Susquehanna", stateAbbreviation));
            list.Add(GenerateCity("Friendsville", "Susquehanna", stateAbbreviation));
            list.Add(GenerateCity("Great Bend", "Susquehanna", stateAbbreviation));
            list.Add(GenerateCity("Hallstead", "Susquehanna", stateAbbreviation));
            list.Add(GenerateCity("Hop Bottom", "Susquehanna", stateAbbreviation));
            list.Add(GenerateCity("Lanesboro", "Susquehanna", stateAbbreviation));
            list.Add(GenerateCity("Little Meadows", "Susquehanna", stateAbbreviation));
            list.Add(GenerateCity("Montrose", "Susquehanna", stateAbbreviation));
            list.Add(GenerateCity("New Milford", "Susquehanna", stateAbbreviation));
            list.Add(GenerateCity("Oakland", "Susquehanna", stateAbbreviation));
            list.Add(GenerateCity("Susquehanna Depot", "Susquehanna", stateAbbreviation));
            list.Add(GenerateCity("Thompson", "Susquehanna", stateAbbreviation));
            list.Add(GenerateCity("Union Dale", "Susquehanna", stateAbbreviation));
            list.Add(GenerateCity("Blossburg", "Tioga", stateAbbreviation));
            list.Add(GenerateCity("Elkland", "Tioga", stateAbbreviation));
            list.Add(GenerateCity("Knoxville", "Tioga", stateAbbreviation));
            list.Add(GenerateCity("Lawrenceville", "Tioga", stateAbbreviation));
            list.Add(GenerateCity("Liberty", "Tioga", stateAbbreviation));
            list.Add(GenerateCity("Mansfield", "Tioga", stateAbbreviation));
            list.Add(GenerateCity("Roseville", "Tioga", stateAbbreviation));
            list.Add(GenerateCity("Tioga", "Tioga", stateAbbreviation));
            list.Add(GenerateCity("Wellsboro", "Tioga", stateAbbreviation));
            list.Add(GenerateCity("Westfield", "Tioga", stateAbbreviation));
            list.Add(GenerateCity("Hartleton", "Union", stateAbbreviation));
            list.Add(GenerateCity("Lewisburg", "Union", stateAbbreviation));
            list.Add(GenerateCity("Mifflinburg", "Union", stateAbbreviation));
            list.Add(GenerateCity("New Berlin", "Union", stateAbbreviation));
            list.Add(GenerateCity("Barkeyville", "Venango", stateAbbreviation));
            list.Add(GenerateCity("Clintonville", "Venango", stateAbbreviation));
            list.Add(GenerateCity("Cooperstown", "Venango", stateAbbreviation));
            list.Add(GenerateCity("Pleasantville", "Venango", stateAbbreviation));
            list.Add(GenerateCity("Polk", "Venango", stateAbbreviation));
            list.Add(GenerateCity("Rouseville", "Venango", stateAbbreviation));
            list.Add(GenerateCity("Sugarcreek", "Venango", stateAbbreviation));
            list.Add(GenerateCity("Utica", "Venango", stateAbbreviation));
            list.Add(GenerateCity("Bear Lake", "Warren", stateAbbreviation));
            list.Add(GenerateCity("Clarendon", "Warren", stateAbbreviation));
            list.Add(GenerateCity("Sugar Grove", "Warren", stateAbbreviation));
            list.Add(GenerateCity("Tidioute", "Warren", stateAbbreviation));
            list.Add(GenerateCity("Allenport", "Washington", stateAbbreviation));
            list.Add(GenerateCity("Beallsville", "Washington", stateAbbreviation));
            list.Add(GenerateCity("Bentleyville", "Washington", stateAbbreviation));
            list.Add(GenerateCity("Burgettstown", "Washington", stateAbbreviation));
            list.Add(GenerateCity("California", "Washington", stateAbbreviation));
            list.Add(GenerateCity("Canonsburg", "Washington", stateAbbreviation));
            list.Add(GenerateCity("Centerville", "Washington", stateAbbreviation));
            list.Add(GenerateCity("Charleroi", "Washington", stateAbbreviation));
            list.Add(GenerateCity("Claysville", "Washington", stateAbbreviation));
            list.Add(GenerateCity("Coal Center", "Washington", stateAbbreviation));
            list.Add(GenerateCity("Cokeburg", "Washington", stateAbbreviation));
            list.Add(GenerateCity("Deemston", "Washington", stateAbbreviation));
            list.Add(GenerateCity("Donora", "Washington", stateAbbreviation));
            list.Add(GenerateCity("Dunlevy", "Washington", stateAbbreviation));
            list.Add(GenerateCity("East Washington", "Washington", stateAbbreviation));
            list.Add(GenerateCity("Elco", "Washington", stateAbbreviation));
            list.Add(GenerateCity("Ellsworth", "Washington", stateAbbreviation));
            list.Add(GenerateCity("Finleyville", "Washington", stateAbbreviation));
            list.Add(GenerateCity("Green Hills", "Washington", stateAbbreviation));
            list.Add(GenerateCity("Houston", "Washington", stateAbbreviation));
            list.Add(GenerateCity("Long Branch", "Washington", stateAbbreviation));
            list.Add(GenerateCity("Marianna", "Washington", stateAbbreviation));
            list.Add(GenerateCity("Midway", "Washington", stateAbbreviation));
            list.Add(GenerateCity("New Eagle", "Washington", stateAbbreviation));
            list.Add(GenerateCity("North Charleroi", "Washington", stateAbbreviation));
            list.Add(GenerateCity("Roscoe", "Washington", stateAbbreviation));
            list.Add(GenerateCity("Speers", "Washington", stateAbbreviation));
            list.Add(GenerateCity("Stockdale", "Washington", stateAbbreviation));
            list.Add(GenerateCity("Twilight", "Washington", stateAbbreviation));
            list.Add(GenerateCity("West Brownsville", "Washington", stateAbbreviation));
            list.Add(GenerateCity("West Middletown", "Washington", stateAbbreviation));
            list.Add(GenerateCity("Bethany", "Wayne", stateAbbreviation));
            list.Add(GenerateCity("Hawley", "Wayne", stateAbbreviation));
            list.Add(GenerateCity("Honesdale", "Wayne", stateAbbreviation));
            list.Add(GenerateCity("Prompton", "Wayne", stateAbbreviation));
            list.Add(GenerateCity("Starrucca", "Wayne", stateAbbreviation));
            list.Add(GenerateCity("Waymart", "Wayne", stateAbbreviation));
            list.Add(GenerateCity("Adamsburg", "Westmoreland", stateAbbreviation));
            list.Add(GenerateCity("Arona", "Westmoreland", stateAbbreviation));
            list.Add(GenerateCity("Avonmore", "Westmoreland", stateAbbreviation));
            list.Add(GenerateCity("Bolivar", "Westmoreland", stateAbbreviation));
            list.Add(GenerateCity("Delmont", "Westmoreland", stateAbbreviation));
            list.Add(GenerateCity("Derry", "Westmoreland", stateAbbreviation));
            list.Add(GenerateCity("Donegal", "Westmoreland", stateAbbreviation));
            list.Add(GenerateCity("East Vandergrift", "Westmoreland", stateAbbreviation));
            list.Add(GenerateCity("Export", "Westmoreland", stateAbbreviation));
            list.Add(GenerateCity("Hunker", "Westmoreland", stateAbbreviation));
            list.Add(GenerateCity("Hyde Park", "Westmoreland", stateAbbreviation));
            list.Add(GenerateCity("Irwin", "Westmoreland", stateAbbreviation));
            list.Add(GenerateCity("Laurel Mountain", "Westmoreland", stateAbbreviation));
            list.Add(GenerateCity("Ligonier", "Westmoreland", stateAbbreviation));
            list.Add(GenerateCity("Madison", "Westmoreland", stateAbbreviation));
            list.Add(GenerateCity("Manor", "Westmoreland", stateAbbreviation));
            list.Add(GenerateCity("Mount Pleasant", "Westmoreland", stateAbbreviation));
            list.Add(GenerateCity("New Alexandria", "Westmoreland", stateAbbreviation));
            list.Add(GenerateCity("New Florence", "Westmoreland", stateAbbreviation));
            list.Add(GenerateCity("New Stanton", "Westmoreland", stateAbbreviation));
            list.Add(GenerateCity("North Belle Vernon", "Westmoreland", stateAbbreviation));
            list.Add(GenerateCity("North Irwin", "Westmoreland", stateAbbreviation));
            list.Add(GenerateCity("Oklahoma", "Westmoreland", stateAbbreviation));
            list.Add(GenerateCity("Penn", "Westmoreland", stateAbbreviation));
            list.Add(GenerateCity("Scottdale", "Westmoreland", stateAbbreviation));
            list.Add(GenerateCity("Seward", "Westmoreland", stateAbbreviation));
            list.Add(GenerateCity("Smithton", "Westmoreland", stateAbbreviation));
            list.Add(GenerateCity("South Greensburg", "Westmoreland", stateAbbreviation));
            list.Add(GenerateCity("Southwest Greensburg", "Westmoreland", stateAbbreviation));
            list.Add(GenerateCity("Sutersville", "Westmoreland", stateAbbreviation));
            list.Add(GenerateCity("Vandergrift", "Westmoreland", stateAbbreviation));
            list.Add(GenerateCity("West Leechburg", "Westmoreland", stateAbbreviation));
            list.Add(GenerateCity("West Newton", "Westmoreland", stateAbbreviation));
            list.Add(GenerateCity("Youngstown", "Westmoreland", stateAbbreviation));
            list.Add(GenerateCity("Youngwood", "Westmoreland", stateAbbreviation));
            list.Add(GenerateCity("Factoryville", "Wyoming", stateAbbreviation));
            list.Add(GenerateCity("Laceyville", "Wyoming", stateAbbreviation));
            list.Add(GenerateCity("Meshoppen", "Wyoming", stateAbbreviation));
            list.Add(GenerateCity("Nicholson", "Wyoming", stateAbbreviation));
            list.Add(GenerateCity("Tunkhannock", "Wyoming", stateAbbreviation));
            list.Add(GenerateCity("Cross Roads ", "York", stateAbbreviation));
            list.Add(GenerateCity("Dallastown ", "York", stateAbbreviation));
            list.Add(GenerateCity("Delta ", "York", stateAbbreviation));
            list.Add(GenerateCity("Dillsburg ", "York", stateAbbreviation));
            list.Add(GenerateCity("Dover ", "York", stateAbbreviation));
            list.Add(GenerateCity("East Prospect ", "York", stateAbbreviation));
            list.Add(GenerateCity("Fawn Grove ", "York", stateAbbreviation));
            list.Add(GenerateCity("Felton ", "York", stateAbbreviation));
            list.Add(GenerateCity("Franklintown ", "York", stateAbbreviation));
            list.Add(GenerateCity("Glen Rock ", "York", stateAbbreviation));
            list.Add(GenerateCity("Goldsboro ", "York", stateAbbreviation));
            list.Add(GenerateCity("Hallam ", "York", stateAbbreviation));
            list.Add(GenerateCity("Hanover ", "York", stateAbbreviation));
            list.Add(GenerateCity("Jacobus ", "York", stateAbbreviation));
            list.Add(GenerateCity("Jefferson ", "York", stateAbbreviation));
            list.Add(GenerateCity("Lewisberry ", "York", stateAbbreviation));
            list.Add(GenerateCity("Loganville ", "York", stateAbbreviation));
            list.Add(GenerateCity("Manchester ", "York", stateAbbreviation));
            list.Add(GenerateCity("Mount Wolf ", "York", stateAbbreviation));
            list.Add(GenerateCity("New Freedom ", "York", stateAbbreviation));
            list.Add(GenerateCity("New Salem ", "York", stateAbbreviation));
            list.Add(GenerateCity("North York", "York", stateAbbreviation));
            list.Add(GenerateCity("Railroad ", "York", stateAbbreviation));
            list.Add(GenerateCity("Red Lion ", "York", stateAbbreviation));
            list.Add(GenerateCity("Seven Valleys ", "York", stateAbbreviation));
            list.Add(GenerateCity("Shrewsbury ", "York", stateAbbreviation));
            list.Add(GenerateCity("Spring Grove ", "York", stateAbbreviation));
            list.Add(GenerateCity("Stewartstown ", "York", stateAbbreviation));
            list.Add(GenerateCity("Wellsville ", "York", stateAbbreviation));
            list.Add(GenerateCity("West York", "York", stateAbbreviation));
            list.Add(GenerateCity("Windsor ", "York", stateAbbreviation));
            list.Add(GenerateCity("Winterstown ", "York", stateAbbreviation));
            list.Add(GenerateCity("Wrightsville ", "York", stateAbbreviation));
            list.Add(GenerateCity("Yoe", "York", stateAbbreviation));
            list.Add(GenerateCity("York Haven", "York", stateAbbreviation));
            list.Add(GenerateCity("Yorkana", "York", stateAbbreviation));

            return list;
        }

        private CityCmd GenerateCity(string displayName, string county, string stateOrProvinceAbbreviation,
                                         bool isActive = true
                                        )
        {
            CustomMessage customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            CityCmd cmd = _cityCrudServices.Cmd_Create(_userName, stateOrProvinceAbbreviation, out customMessage);

            if (cmd == null)
                return null;

            cmd.DisplayName = displayName;

            // default values
            cmd.IsActive = isActive;

            return cmd;
        }

        private ICollection<TimeZoneCmd> GenerateTimeZoneList(string[] displayNames)
        {
            List<TimeZoneCmd> list = new List<TimeZoneCmd>();

            foreach (string displayName in displayNames)
            {
                TimeZoneCmd timeZone = _timeZoneQueries.GetCmd(displayName);
                if (timeZone != null)
                    list.Add(timeZone);
            }

            return list;
        }

        private void AddResultCountsToCustomMessage(string entityName, int addSuccessCount, int addFailureCount)
        {
            if (_customMessage == null)
                _customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
            if (_customMessage.MessageDictionary1 == null)
                _customMessage.MessageDictionary1 = new Dictionary<string, string>();
            if (_customMessage.MessageDictionary2 == null)
                _customMessage.MessageDictionary2 = new Dictionary<string, string>();

            _customMessage.MessageDictionary1.Add("Core." + entityName + ".AddSuccessCount", addSuccessCount.ToString());
            _customMessage.MessageDictionary2.Add("Core." + entityName + ".AddFailureCount", addFailureCount.ToString());
        }

        #endregion
    }
}
