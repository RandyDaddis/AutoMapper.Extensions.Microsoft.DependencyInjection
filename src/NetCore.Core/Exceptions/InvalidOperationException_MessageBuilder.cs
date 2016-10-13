using NetCore.Core.Common;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NetCore.Core.Exceptions
{
    public partial class InvalidOperationException_MessageBuilder : IInvalidOperationException_MessageBuilder
    {
        #region Private Fields

        private readonly IException_MessageBuilder _exceptionMessageBuilder;
        private CustomMessage _customMessage;
        private InvalidOperationException _exception;

        #endregion

        #region Public Properties

        public virtual SerializationInfo Info { get; set; }
        public virtual StreamingContext Context { get; set; }
        public virtual int ErrorCode { get; set; }

        #endregion

        #region ctor

        public InvalidOperationException_MessageBuilder(IException_MessageBuilder exceptionMessageBuilder)
        {
            _exceptionMessageBuilder = exceptionMessageBuilder;
        }

        #endregion

        #region Methods

        public virtual CustomMessage Parse(InvalidOperationException exception)
        {
            _customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if ((InvalidOperationException)exception == null)
            {
                _customMessage.Message = ".Parse(exception) - NullReferenceException";
            }
            else
            {
                _exception = exception;

                ParseInnerExceptionStack();
            }

            AddMessagePrefix();

            return _customMessage;
        }

        private void AddMessagePrefix()
        {
            _customMessage = _customMessage ?? new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            _customMessage.IsErrorCondition = true;

            string message = " -->>InvalidOperationException_MessageBuilder: ";

            if (!string.IsNullOrEmpty(_exception.Message))
                message += _exception.Message;

            _customMessage.Message = message + _customMessage.Message;
        }

        private void ParseInnerExceptionStack()
        {
            if (_exception.InnerException != null)
                _customMessage = _exceptionMessageBuilder.Parse(_exception.InnerException);
        }

        #endregion
    }
}
