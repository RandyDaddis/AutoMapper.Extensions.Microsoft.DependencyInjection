using System.Collections.Generic;

namespace NetCore.Core.Common
{
    public partial class CustomMessage
    {
        #region ctor

        public CustomMessage()
        { }

        public CustomMessage(string message)
        {
            Message = message;
        }

        public CustomMessage(string message, Dictionary<string, string> messageDictionary)
        {
            Message = message;
            MessageDictionary1 = messageDictionary;
        }

        #endregion

        #region Public Properties

        public virtual string Message { get; set; }

        public virtual bool IsErrorCondition { get; set; }

        public virtual Dictionary<string, string> MessageDictionary1 { get; set; }

        public virtual Dictionary<string, string> MessageDictionary2 { get; set; }

        #endregion
    }
}
