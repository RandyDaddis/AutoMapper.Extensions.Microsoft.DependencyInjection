using Dna.NetCore.Core.BLL.Initializers;
using Dna.NetCore.Core.Common;
using Dna.NetCore.Core.Initializers;
using System.Collections.Generic;

namespace AspNetCore.NetCore.WebApp.Initializers
{
    public class SeedData : ISeedData
    {
        #region Private Fields

        private readonly CoreSeedData_enUS _coreSeedData;
        private CustomMessage _customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
        private string _administratorUserName = "admin";
        private string _administratorPassword = "password";

        #endregion

        #region ctor

        public SeedData(CoreSeedData_enUS coreSeedData)
        {
            _coreSeedData = coreSeedData;
        }

        #endregion ctor

        #region Methods

        public CustomMessage Execute()
        {
            CoreSeedData_enUS();

            return _customMessage;
        }

        private void CoreSeedData_enUS()
        {
            CustomMessage seedMessages = _coreSeedData.Execute(_administratorUserName);

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
                            _customMessage.MessageDictionary1[message.Key] = total.ToString();
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
