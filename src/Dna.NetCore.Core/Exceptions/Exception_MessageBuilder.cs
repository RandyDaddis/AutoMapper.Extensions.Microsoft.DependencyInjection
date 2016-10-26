using Dna.NetCore.Core.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;

namespace Dna.NetCore.Core.Exceptions
{
    public partial class Exception_MessageBuilder : IException_MessageBuilder
    {
        #region Private Fields

        private CustomMessage _customMessage;
        private Exception _exception;

        #endregion

        #region Public Properties

        public virtual SerializationInfo Info { get; set; }
        public virtual StreamingContext Context { get; set; }
        public virtual IDictionary Data { get; set; }
        public virtual string HelpLink { get; set; }
        public virtual int HResult { get; set; }
        public virtual string Source { get; set; }
        public virtual string StackTrace { get; set; }
        public virtual MethodBase TargetSite { get; set; }

        #endregion

        #region ctor

        public Exception_MessageBuilder()
        { }

        #endregion

        #region Methods

        public virtual CustomMessage Parse(Exception exception)
        {
            _customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if (exception == null)
            {
                _customMessage.Message = ".Parse(exception) - NullReferenceException";
            }
            else
            {
                _exception = exception;

                ParseData();

                ParseInnerException();
            }

            AddMessagePrefix();

            return _customMessage;
        }

        private void ParseData()
        {
            foreach (DictionaryEntry de in _exception.Data)
                _customMessage.MessageDictionary1.Add(de.Key.ToString(), de.Value.ToString());
        }

        private void ParseInnerException()
        {
            if (_exception.InnerException != null)
            {
                var innerException = _exception.InnerException;
                while (innerException != null)
                {
                        _customMessage.Message += " -->>InnerException: ";

                        if (!string.IsNullOrEmpty(innerException.Message))
                            _customMessage.Message += innerException.Message;

                        if (innerException.InnerException != null)
                            innerException = innerException.InnerException;
                        else
                            break;
                }
            }
        }

        private void AddMessagePrefix()
        {
            _customMessage = _customMessage ?? new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            _customMessage.IsErrorCondition = true;

            string message = " -->>Exception_MessageBuilder: ";

            if (!string.IsNullOrEmpty(_exception.Message))
                message += _exception.Message;

            _customMessage.Message = message + _customMessage.Message;
        }

        #endregion
    }
}
