using Dna.NetCore.Core.BLL.Commands.Common;
using Dna.NetCore.Core.BLL.Services.Common;
using Dna.NetCore.Core.Common;
using Dna.NetCore.Core.Initializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dna.NetCore.Core.BLL.Initializers.Common
{
    public class CurrencySeedData_enUS : ISeedData
    {
        #region Private Fields

        private readonly ICurrency_CrudServices _service;
        private CustomMessage _customMessage;
        private string _userName;

        #endregion

        #region ctor

        public CurrencySeedData_enUS(ICurrency_CrudServices currencyService)
        {
            _service = currencyService;
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

            List<CurrencyCmd> entities = GenerateEntityList();

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

            AddResultCountsToCustomMessage("Currencies", addSuccessCount, addFailureCount);
        }

        private CurrencyCmd GenerateCurrency(string name, string code, string locality,
                                            string format, decimal rate, bool isactive = true)
        {
            CustomMessage customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            CurrencyCmd cmd = _service.Cmd_Create(_userName, out customMessage);

            if (cmd == null)
                return null;

            cmd.DisplayName = name;
            cmd.Code = code;
            cmd.Locality = locality;
            cmd.Format = format;
            cmd.Rate = rate;
            // default values
            cmd.IsActive = isactive;

            return cmd;
        }

        private List<CurrencyCmd> GenerateEntityList()
        {
            List<CurrencyCmd> list = new List<CurrencyCmd>();

            list.Add(GenerateCurrency("US Dollar ($)", "USD", "en-US", "", 1));
            list.Add(GenerateCurrency("Euro (€)", "EUR", "", string.Format("{0}0.00", "\u20ac"), 1));
            list.Add(GenerateCurrency("Argentine Peso ($)", "ARS", "", "", 1));
            list.Add(GenerateCurrency("Australian Dollar ($)", "AUD", "en-AU", "", 1));
            list.Add(GenerateCurrency("British Pound (&#163;)", "GBP", "en-GB", "", 1));
            list.Add(GenerateCurrency("Canadian Dollar ($)", "CAD", "en-CA", "", 1));
            list.Add(GenerateCurrency("Chinese Yuan Renminbi", "CNY", "zh-CN", "", 1));
            list.Add(GenerateCurrency("Danish Krone (kr)", "DKK", "", "", 1));
            list.Add(GenerateCurrency("Hong Kong Dollar", "HKD", "zh-HK", "", 1));
            list.Add(GenerateCurrency("Indonesian Rupiah (Rp)", "IDR", "", "", 1));
            list.Add(GenerateCurrency("Japanese Yen (&#165;", "JPY", "ja-JP", "", 1));
            list.Add(GenerateCurrency("Korean Won (₩)", "KRW", "", "", 1));
            list.Add(GenerateCurrency("New Zealand Dollar ($)", "NZD", "", "", 1));
            list.Add(GenerateCurrency("Norwegian Krone (kr)", "NOK", "", "", 1));
            list.Add(GenerateCurrency("Romanian Leu", "RON", "ro-RO", "", 1));
            list.Add(GenerateCurrency("Russian Rouble (руб)", "RUB", "ru-RU", "", 1));
            list.Add(GenerateCurrency("Saudi Riyal (R)", "SAR", "", "", 1));
            list.Add(GenerateCurrency("South African Rand (R)", "ZAR", "", "", 1));
            list.Add(GenerateCurrency("Swedish Krona (kr)", "SEK", "", "", 1));
            list.Add(GenerateCurrency("Swiss Frank (chf)", "CHF", "", "", 1));
            list.Add(GenerateCurrency("Taiwanese Dollar ($)", "TWD", "", "", 1));
            list.Add(GenerateCurrency("Turkish Lira (TL)", "TRY", "", "", 1));

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
