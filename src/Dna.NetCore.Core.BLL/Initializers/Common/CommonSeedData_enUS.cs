using Dna.NetCore.Core.Common;
using Dna.NetCore.Core.Initializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dna.NetCore.Core.BLL.Initializers.Common
{
    public class CommonSeedData_enUS : ISeedData
    {
        #region Private Fields

        private readonly CountrySeedData_enUS _countrySeedData;
        private readonly CurrencySeedData_enUS _currencySeedData;
        private readonly TimeZoneSeedData_enUS _timeZoneSeedData;
        private CustomMessage _customMessage;
        private string _userName;

        #endregion

        #region ctor

        public CommonSeedData_enUS(CountrySeedData_enUS countrySeedData,
                                   CurrencySeedData_enUS currencySeedData,
                                   TimeZoneSeedData_enUS timeZoneSeedData)
        {
            _countrySeedData = countrySeedData;
            _currencySeedData = currencySeedData;
            _timeZoneSeedData = timeZoneSeedData;
        }

        #endregion

        #region Methods

        public CustomMessage Execute(string userName)
        {
            _userName = userName;

            _customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            // init order:
            // Localities - LocaleSeedData_enUS is executed by CoreDomainSeedData_enUS
            // TimeZoneSummaries
            // Currencies - before Countries
            // Countries

            TimeZoneSeedData_enUS();

            CurrencySeedData_enUS();

            CountrySeedData_enUS();

            return _customMessage;
        }

        private void TimeZoneSeedData_enUS()
        {
            CustomMessage seedMessages = _timeZoneSeedData.Execute(_userName);

            BubbleUpCustomMessageDictionaries(seedMessages);
        }

        private void CurrencySeedData_enUS()
        {
            CustomMessage seedMessages = _currencySeedData.Execute(_userName);

            BubbleUpCustomMessageDictionaries(seedMessages);
        }

        private void CountrySeedData_enUS()
        {
            CustomMessage seedMessages = _countrySeedData.Execute(_userName);

            BubbleUpCustomMessageDictionaries(seedMessages);
        }

        private void BubbleUpCustomMessageDictionaries(CustomMessage seedMessages)
        {
            if (seedMessages != null)
            {
                if (seedMessages.MessageDictionary1 != null)
                {
                    foreach (var message in seedMessages.MessageDictionary1)
                    {
                        if (_customMessage.MessageDictionary1.ContainsKey(message.Key))
                        {
                            int total = int.Parse(_customMessage.MessageDictionary1[message.Key]);
                            total += int.Parse(message.Value);
                            _customMessage.MessageDictionary1[message.Key] += total;
                        }
                        else
                        {
                            _customMessage.MessageDictionary1.Add(message.Key, message.Value);
                        }
                    }
                }
                if (seedMessages.MessageDictionary2 != null)
                {
                    foreach (var message in seedMessages.MessageDictionary2)
                    {
                        if (_customMessage.MessageDictionary2.ContainsKey(message.Key))
                        {
                            int total = int.Parse(_customMessage.MessageDictionary2[message.Key]);
                            total += int.Parse(message.Value);
                            _customMessage.MessageDictionary2[message.Key] = total.ToString();
                        }
                        else
                        {
                            _customMessage.MessageDictionary2.Add(message.Key, message.Value);
                        }
                    }
                }
            }
        }

        #endregion
    }
}
