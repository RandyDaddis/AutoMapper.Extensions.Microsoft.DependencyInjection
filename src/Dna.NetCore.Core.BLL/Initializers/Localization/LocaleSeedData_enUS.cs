using Dna.NetCore.Core.BLL.Commands.Localization;
using Dna.NetCore.Core.BLL.Services.Localization;
using Dna.NetCore.Core.Common;
using Dna.NetCore.Core.Initializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dna.NetCore.Core.BLL.Initializers.Localization
{
    public class LocaleSeedData_enUS : ISeedData
    {
        #region Private Fields

        private string _userName;
        private readonly ILocale_CrudServices _service;
        private CustomMessage _customMessage;

        #endregion Class Level Members

        #region ctor

        public LocaleSeedData_enUS(ILocale_CrudServices timeZoneService)
        {
            _service = timeZoneService;
        }

        #endregion

        #region Methods

        public CustomMessage Execute(string userName)
        {
            _userName = userName;

            _customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            GenerateEntities();

            return _customMessage;
        }

        private void GenerateEntities()
        {
            int addSuccessCount = 0;
            int addFailureCount = 0;

            List<LocaleCmd> entities = GenerateEntityList();

            foreach (var entity in entities)
            {
                CustomMessage customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

                _service.Add(entity, _userName, out customMessage);

                if (customMessage == null)
                {
                    customMessage = new CustomMessage()
                    {
                        MessageDictionary1 = new Dictionary<string, string>(),
                        MessageDictionary2 = new Dictionary<string, string>(),
                        IsErrorCondition = true,
                        Message = "_localeCrudServices.Add() - null returned"
                    };
                    addFailureCount++;
                }
                else
                {
                    if (customMessage.MessageDictionary1 != null && customMessage.MessageDictionary1.ContainsKey("AddId"))
                        addSuccessCount++;
                    else
                        addFailureCount++;
                }
            }

            AddResultCountsToCustomMessage("LocaleSummaries", addSuccessCount, addFailureCount);
        }

        private LocaleCmd GenerateLocale(string name, string languageCode,
                                                string lCIDString, int lCIDDecimal,
                                                int lCIDHexadecimal, int codePage,
                                                bool isactive = true)
        {
            CustomMessage customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            LocaleCmd cmd = _service.Cmd_Create(_userName, out customMessage);

            if (cmd == null)
                return null;

            cmd.DisplayName = name;
            cmd.LanguageCode = languageCode;
            cmd.LCIDString = lCIDString;
            cmd.LCIDDecimal = lCIDDecimal;
            cmd.LCIDHexadecimal = lCIDHexadecimal;
            cmd.CodePage = codePage;

            return cmd;
        }

        private List<LocaleCmd> GenerateEntityList()
        {
            List<LocaleCmd> list = new List<LocaleCmd>();

            // DEVNOTE: verify that name is not unique - this list has Mongolian with two lcidDecimals
            //          languageCode can equal lcidString
            //          languageCode is not unique
            //
            //list.Add(GenerateLocale("Please Select", "N/A", "N/A", 0, 0, 0)//DEVNOTE: cannot do this - Unicode has lCIDDecimal = 0
            list.Add(GenerateLocale("English - United States", "en", "en-us", 1033, 409, 1252));
            list.Add(GenerateLocale("Afrikaans", "af", "af", 1078, 436, 1252));
            list.Add(GenerateLocale("Albanian", "sq", "sq", 1052, 0, 1250));
            list.Add(GenerateLocale("Amharic", "am", "am", 1118, 0, 0));
            list.Add(GenerateLocale("Arabic - Algeria", "ar", "ar-dz", 5121, 1401, 1256));
            list.Add(GenerateLocale("Arabic - Bahrain", "ar", "ar-bh", 15361, 0, 1256));
            list.Add(GenerateLocale("Arabic - Egypt", "ar", "ar-eg", 3073, 0, 1256));
            list.Add(GenerateLocale("Arabic - Iraq", "ar", "ar-iq", 2049, 801, 1256));
            list.Add(GenerateLocale("Arabic - Jordan", "ar", "ar-jo", 11265, 0, 1256));
            list.Add(GenerateLocale("Arabic - Kuwait", "ar", "ar-kw", 13313, 3401, 1256));
            list.Add(GenerateLocale("Arabic - Lebanon", "ar", "ar-lb", 12289, 3001, 1256));
            list.Add(GenerateLocale("Arabic - Libya", "ar", "ar-ly", 4097, 1001, 1256));
            list.Add(GenerateLocale("Arabic - Morocco", "ar", "ar-ma", 6145, 1801, 1256));
            list.Add(GenerateLocale("Arabic - Oman", "ar", "ar-om", 8193, 2001, 1256));
            list.Add(GenerateLocale("Arabic - Qatar", "ar", "ar-qa", 16385, 4001, 1256));
            list.Add(GenerateLocale("Arabic - Saudi Arabia", "ar", "ar-sa", 1025, 401, 1256));
            list.Add(GenerateLocale("Arabic - Syria", "ar", "ar-sy", 10241, 2801, 1256));
            list.Add(GenerateLocale("Arabic - Tunisia", "ar", "ar-tn", 7169, 0, 1256));
            list.Add(GenerateLocale("Arabic - United Arab Emirates", "ar", "ar-ae", 14337, 3801, 1256));
            list.Add(GenerateLocale("Arabic - Yemen", "ar", "ar-ye", 9217, 2401, 1256));
            list.Add(GenerateLocale("Armenian", "hy", "hy", 1067, 0, 0));
            list.Add(GenerateLocale("Assamese", "as", "as", 1101, 0, 0));
            list.Add(GenerateLocale("Azeri - Cyrillic", "az", "az-az", 2092, 0, 1251));
            list.Add(GenerateLocale("Azeri - Latin", "az", "az-az", 1068, 0, 1254));
            list.Add(GenerateLocale("Basque", "eu", "eu", 1069, 0, 1252));
            list.Add(GenerateLocale("Belarusian", "be", "be", 1059, 423, 1251));
            list.Add(GenerateLocale("Bengali - Bangladesh", "bn", "bn", 2117, 845, 0));
            list.Add(GenerateLocale("Bengali - India", "bn", "bn", 1093, 445, 0));
            list.Add(GenerateLocale("Bosnian", "bs", "bs", 5146, 0, 0));
            list.Add(GenerateLocale("Bulgarian", "bg", "bg", 1026, 402, 1251));
            list.Add(GenerateLocale("Burmese", "my", "my", 1109, 455, 0));
            list.Add(GenerateLocale("Catalan", "ca", "ca", 1027, 403, 1252));
            list.Add(GenerateLocale("Chinese - China", "zh", "zh-cn", 2052, 804, 0));
            list.Add(GenerateLocale("Chinese - Hong Kong SAR", "zh", "zh-hk", 3076, 0, 0));
            list.Add(GenerateLocale("Chinese - Macau SAR", "zh", "zh-mo", 5124, 1404, 0));
            list.Add(GenerateLocale("Chinese - Singapore", "zh", "zh-sg", 4100, 1004, 0));
            list.Add(GenerateLocale("Chinese - Taiwan", "zh", "zh-tw", 1028, 404, 0));
            list.Add(GenerateLocale("Croatian", "hr", "hr", 1050, 0, 1250));
            list.Add(GenerateLocale("Czech", "cs", "cs", 1029, 405, 1250));
            list.Add(GenerateLocale("Danish", "da", "da", 1030, 406, 1252));
            list.Add(GenerateLocale("Divehi; Dhivehi; Maldivian", "dv", "dv", 1125, 465, 0));
            list.Add(GenerateLocale("Dutch - Belgium", "nl", "nl-be", 2067, 813, 1252));
            list.Add(GenerateLocale("Dutch - Netherlands", "nl", "nl-nl", 1043, 413, 1252));
            list.Add(GenerateLocale("Edo", "", "", 1126, 466, 0));
            list.Add(GenerateLocale("English - Australia", "en", "en-au", 3081, 0, 1252));
            list.Add(GenerateLocale("English - Belize", "en", "en-bz", 10249, 2809, 1252));
            list.Add(GenerateLocale("English - Canada", "en", "en-ca", 4105, 1009, 1252));
            list.Add(GenerateLocale("English - Caribbean", "en", "en-cb", 9225, 2409, 1252));
            list.Add(GenerateLocale("English - Great Britain", "en", "en-gb", 2057, 809, 1252));
            list.Add(GenerateLocale("English - India", "en", "en-in", 16393, 4009, 0));
            list.Add(GenerateLocale("English - Ireland", "en", "en-ie", 6153, 1809, 1252));
            list.Add(GenerateLocale("English - Jamaica", "en", "en-jm", 8201, 2009, 1252));
            list.Add(GenerateLocale("English - New Zealand", "en", "en-nz", 5129, 1409, 1252));
            list.Add(GenerateLocale("English - Phillippines", "en", "en-ph", 13321, 340, 1252));
            list.Add(GenerateLocale("English - Southern Africa", "en", "en-za", 7177, 0, 1252));
            list.Add(GenerateLocale("English - Trinidad", "en", "en-tt", 11273, 0, 1252));
            list.Add(GenerateLocale("English - Zimbabwe", "en", "", 12297, 3009, 1252));
            list.Add(GenerateLocale("Estonian", "et", "et", 1061, 425, 1257));
            list.Add(GenerateLocale("Faroese", "fo", "fo", 1080, 438, 1252));
            list.Add(GenerateLocale("Farsi - Persian", "fa", "fa", 1065, 429, 1256));
            list.Add(GenerateLocale("Filipino", "", "", 1124, 464, 0));
            list.Add(GenerateLocale("Finnish", "fi", "fi", 1035, 0, 1252));
            list.Add(GenerateLocale("French - Belgium", "fr", "fr-be", 2060, 0, 1252));
            list.Add(GenerateLocale("French - Cameroon", "fr", "", 11276, 0, 0));
            list.Add(GenerateLocale("French - Canada", "fr", "fr-ca", 3084, 0, 1252));
            list.Add(GenerateLocale("French - Congo", "fr", "", 9228, 0, 0));
            list.Add(GenerateLocale("French - Cote d'Ivoire", "fr", "", 12300, 0, 0));
            list.Add(GenerateLocale("French - France", "fr", "fr-fr", 1036, 0, 1252));
            list.Add(GenerateLocale("French - Luxembourg", "fr", "fr-lu", 5132, 0, 1252));
            list.Add(GenerateLocale("French - Mali", "fr", "", 13324, 0, 0));
            list.Add(GenerateLocale("French - Monaco", "fr", "", 6156, 0, 1252));
            list.Add(GenerateLocale("French - Morocco", "fr", "", 14348, 0, 0));
            list.Add(GenerateLocale("French - Senegal", "fr", "", 10252, 0, 0));
            list.Add(GenerateLocale("French - Switzerland", "fr", "fr-ch", 4108, 0, 1252));
            list.Add(GenerateLocale("French - West Indies", "fr", "", 7180, 0, 0));
            list.Add(GenerateLocale("Frisian - Netherlands", "", "", 1122, 462, 0));
            list.Add(GenerateLocale("FYRO Macedonia", "mk", "mk", 1071, 0, 1251));
            list.Add(GenerateLocale("Gaelic - Ireland", "gd", "gd-ie", 2108, 0, 0));
            list.Add(GenerateLocale("Gaelic - Scotland", "gd", "gd", 1084, 0, 0));
            list.Add(GenerateLocale("Galician", "gl", "", 1110, 456, 1252));
            list.Add(GenerateLocale("Georgian", "ka", "", 1079, 437, 0));
            list.Add(GenerateLocale("German - Austria", "de", "de-at", 3079, 0, 1252));
            list.Add(GenerateLocale("German - Germany", "de", "de-de", 1031, 407, 1252));
            list.Add(GenerateLocale("German - Liechtenstein", "de", "de-li", 5127, 1407, 1252));
            list.Add(GenerateLocale("German - Luxembourg", "de", "de-lu", 4103, 1007, 1252));
            list.Add(GenerateLocale("German - Switzerland", "de", "de-ch", 2055, 807, 1252));
            list.Add(GenerateLocale("Greek", "el", "el", 1032, 408, 1253));
            list.Add(GenerateLocale("Guarani - Paraguay", "gn", "gn", 1140, 474, 0));
            list.Add(GenerateLocale("Gujarati", "gu", "gu", 1095, 447, 0));
            list.Add(GenerateLocale("Hebrew", "he", "he", 1037, 0, 1255));
            list.Add(GenerateLocale("HID (Human Interface Device)", "", "", 1279, 0, 0));
            list.Add(GenerateLocale("Hindi", "hi", "hi", 1081, 439, 0));
            list.Add(GenerateLocale("Hungarian", "hu", "hu", 1038, 0, 1250));
            list.Add(GenerateLocale("Icelandic", "is", "is", 1039, 0, 1252));
            list.Add(GenerateLocale("Igbo - Nigeria", "", "", 1136, 470, 0));
            list.Add(GenerateLocale("Indonesian", "id", "id", 1057, 421, 1252));
            list.Add(GenerateLocale("Italian - Italy", "it", "it-it", 1040, 410, 1252));
            list.Add(GenerateLocale("Italian - Switzerland", "it", "it-ch", 2064, 810, 1252));
            list.Add(GenerateLocale("Japanese", "ja", "ja", 1041, 411, 0));
            list.Add(GenerateLocale("Kannada", "kn", "kn", 1099, 0, 0));
            list.Add(GenerateLocale("Kashmiri", "ks", "ks", 1120, 460, 0));
            list.Add(GenerateLocale("Kazakh", "kk", "kk", 1087, 0, 1251));
            list.Add(GenerateLocale("Khmer", "km", "km", 1107, 453, 0));
            list.Add(GenerateLocale("Konkani", "", "", 1111, 457, 0));
            list.Add(GenerateLocale("Korean", "ko", "ko", 1042, 412, 0));
            list.Add(GenerateLocale("Kyrgyz - Cyrillic", "", "", 1088, 440, 1251));
            list.Add(GenerateLocale("Lao", "lo", "lo", 1108, 454, 0));
            list.Add(GenerateLocale("Latin", "la", "la", 1142, 476, 0));
            list.Add(GenerateLocale("Latvian", "lv", "lv", 1062, 426, 1257));
            list.Add(GenerateLocale("Lithuanian", "lt", "lt", 1063, 427, 1257));
            list.Add(GenerateLocale("Malay - Brunei", "ms", "ms-bn", 2110, 0, 1252));
            list.Add(GenerateLocale("Malay - Malaysia", "ms", "ms-my", 1086, 0, 1252));
            list.Add(GenerateLocale("Malayalam", "ml", "ml", 1100, 0, 0));
            list.Add(GenerateLocale("Maltese", "mt", "mt", 1082, 0, 0));
            list.Add(GenerateLocale("Manipuri", "", "", 1112, 458, 0));
            list.Add(GenerateLocale("Maori", "mi", "mi", 1153, 481, 0));
            list.Add(GenerateLocale("Marathi", "mr", "mr", 1102, 0, 0));
            list.Add(GenerateLocale("Mongolian", "mn", "mn", 2128, 850, 0));
            list.Add(GenerateLocale("Mongolian", "mn", "mn", 1104, 450, 1251));
            list.Add(GenerateLocale("Nepali", "ne", "ne", 1121, 461, 0));
            list.Add(GenerateLocale("Norwegian - Bokml", "nb", "no-no", 1044, 414, 1252));
            list.Add(GenerateLocale("Norwegian - Nynorsk", "nn", "no-no", 2068, 814, 1252));
            list.Add(GenerateLocale("Oriya", "or", "or", 1096, 448, 0));
            list.Add(GenerateLocale("Polish", "pl", "pl", 1045, 415, 1250));
            list.Add(GenerateLocale("Portuguese - Brazil", "pt", "pt-br", 1046, 416, 1252));
            list.Add(GenerateLocale("Portuguese - Portugal", "pt", "pt-pt", 2070, 816, 1252));
            list.Add(GenerateLocale("Punjabi", "pa", "pa", 1094, 446, 0));
            list.Add(GenerateLocale("Raeto-Romance", "rm", "rm", 1047, 417, 0));
            list.Add(GenerateLocale("Romanian - Moldova", "ro", "ro-mo", 2072, 818, 0));
            list.Add(GenerateLocale("Romanian - Romania", "ro", "ro", 1048, 418, 1250));
            list.Add(GenerateLocale("Russian", "ru", "ru", 1049, 419, 1251));
            list.Add(GenerateLocale("Russian - Moldova", "ru", "ru-mo", 2073, 819, 0));
            list.Add(GenerateLocale("Sami Lappish", "", "", 1083, 0, 0));
            list.Add(GenerateLocale("Sanskrit", "sa", "sa", 1103, 0, 0));
            list.Add(GenerateLocale("Serbian - Cyrillic", "sr", "sr-sp", 3098, 0, 1251));
            list.Add(GenerateLocale("Serbian - Latin", "sr", "sr-sp", 2074, 0, 1250));
            list.Add(GenerateLocale("Sesotho (Sutu)", "", "", 1072, 430, 0));
            list.Add(GenerateLocale("Setsuana", "tn", "tn", 1074, 432, 0));
            list.Add(GenerateLocale("Sindhi", "sd", "sd", 1113, 459, 0));
            list.Add(GenerateLocale("Sinhala; Sinhalese", "si", "si", 1115, 0, 0));
            list.Add(GenerateLocale("Slovak", "sk", "sk", 1051, 0, 1250));
            list.Add(GenerateLocale("Slovenian", "sl", "sl", 1060, 424, 1250));
            list.Add(GenerateLocale("Somali", "so", "so", 1143, 477, 0));
            list.Add(GenerateLocale("Sorbian", "sb", "sb", 1070, 0, 0));
            list.Add(GenerateLocale("Spanish - Argentina", "es", "es-ar", 11274, 0, 1252));
            list.Add(GenerateLocale("Spanish - Bolivia", "es", "es-bo", 16394, 0, 1252));
            list.Add(GenerateLocale("Spanish - Chile", "es", "es-cl", 13322, 0, 1252));
            list.Add(GenerateLocale("Spanish - Colombia", "es", "es-co", 9226, 0, 1252));
            list.Add(GenerateLocale("Spanish - Costa Rica", "es", "es-cr", 5130, 0, 1252));
            list.Add(GenerateLocale("Spanish - Dominican Republic", "es", "es-do", 7178, 0, 1252));
            list.Add(GenerateLocale("Spanish - Ecuador", "es", "es-ec", 12298, 0, 1252));
            list.Add(GenerateLocale("Spanish - El Salvador", "es", "es-sv", 17418, 0, 1252));
            list.Add(GenerateLocale("Spanish - Guatemala", "es", "es-gt", 4106, 0, 1252));
            list.Add(GenerateLocale("Spanish - Honduras", "es", "es-hn", 18442, 0, 1252));
            list.Add(GenerateLocale("Spanish - Mexico", "es", "es-mx", 2058, 0, 1252));
            list.Add(GenerateLocale("Spanish - Nicaragua", "es", "es-ni", 19466, 0, 1252));
            list.Add(GenerateLocale("Spanish - Panama", "es", "es-pa", 6154, 0, 1252));
            list.Add(GenerateLocale("Spanish - Paraguay", "es", "es-py", 15370, 0, 1252));
            list.Add(GenerateLocale("Spanish - Peru", "es", "es-pe", 10250, 0, 1252));
            list.Add(GenerateLocale("Spanish - Puerto Rico", "es", "es-pr", 20490, 0, 1252));
            list.Add(GenerateLocale("Spanish - Spain (Traditional)", "es", "es-es", 1034, 0, 1252));
            list.Add(GenerateLocale("Spanish - Uruguay", "es", "es-uy", 14346, 0, 1252));
            list.Add(GenerateLocale("Spanish - Venezuela", "es", "es-ve", 8202, 0, 1252));
            list.Add(GenerateLocale("Swahili", "sw", "sw", 1089, 441, 1252));
            list.Add(GenerateLocale("Swedish - Finland", "sv", "sv-fi", 2077, 0, 1252));
            list.Add(GenerateLocale("Swedish - Sweden", "sv", "sv-se", 1053, 0, 1252));
            list.Add(GenerateLocale("Syriac", "", "", 1114, 0, 0));
            list.Add(GenerateLocale("Tajik", "tg", "tg", 1064, 428, 0));
            list.Add(GenerateLocale("Tamil", "ta", "ta", 1097, 449, 0));
            list.Add(GenerateLocale("Tatar", "tt", "tt", 1092, 444, 1251));
            list.Add(GenerateLocale("Telugu", "te", "te", 1098, 0, 0));
            list.Add(GenerateLocale("Thai", "th", "th", 1054, 0, 0));
            list.Add(GenerateLocale("Tibetan", "bo", "bo", 1105, 451, 0));
            list.Add(GenerateLocale("Tsonga", "ts", "ts", 1073, 431, 0));
            list.Add(GenerateLocale("Turkish", "tr", "tr", 1055, 0, 1254));
            list.Add(GenerateLocale("Turkmen", "tk", "tk", 1090, 442, 0));
            list.Add(GenerateLocale("Ukrainian", "uk", "uk", 1058, 422, 1251));
            list.Add(GenerateLocale("Unicode", "", "UTF-8", 0, 0, 0));
            list.Add(GenerateLocale("Urdu", "ur", "ur", 1056, 420, 1256));
            list.Add(GenerateLocale("Uzbek - Cyrillic", "uz", "uz-uz", 2115, 843, 1251));
            list.Add(GenerateLocale("Uzbek - Latin", "uz", "uz-uz", 1091, 443, 1254));
            list.Add(GenerateLocale("Venda", "", "", 1075, 433, 0));
            list.Add(GenerateLocale("Vietnamese", "vi", "vi", 1066, 0, 1258));
            list.Add(GenerateLocale("Welsh", "cy", "cy", 1106, 452, 0));
            list.Add(GenerateLocale("Xhosa", "xh", "xh", 1076, 434, 0));
            list.Add(GenerateLocale("Yiddish", "yi", "yi", 1085, 0, 0));
            list.Add(GenerateLocale("Zulu", "zu", "zu", 1077, 435, 0));

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
