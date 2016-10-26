using Dna.NetCore.Core.Common;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Dna.NetCore.Core.Exceptions
{
    public partial class ArgumentException_MessageBuilder : IArgumentException_MessageBuilder
    {
        #region Private Fields

        private readonly IException_MessageBuilder _exception_MessageBuilder;
        private CustomMessage _customMessage;
        private ArgumentException _exception;

        #endregion

        #region Public Properties

        public virtual SerializationInfo Info { get; set; }
        public virtual StreamingContext Context { get; set; }
        public virtual string ParamName { get; set; }

        #endregion

        #region ctor

        public ArgumentException_MessageBuilder(IException_MessageBuilder exceptionMessageBuilder)
        {
            _exception_MessageBuilder = exceptionMessageBuilder;
        }

        #endregion

        #region Methods

        public virtual CustomMessage Parse(ArgumentException exception)
        {
            _customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if (exception == null)
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

            string message = " -->>ArgumentException_MessageBuilder: ";

            if (!string.IsNullOrEmpty(_exception.Message))
                message += _exception.Message;

            _customMessage.Message = message + _customMessage.Message;
        }

        private void ParseInnerExceptionStack()
        {
            if (_exception.InnerException != null)
                _customMessage = _exception_MessageBuilder.Parse(_exception.InnerException);
        }

        #endregion
    }
}
