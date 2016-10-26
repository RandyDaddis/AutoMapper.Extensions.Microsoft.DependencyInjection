﻿using Dna.NetCore.Core.Common;
using System.Collections.Generic;
using System.Data.Common;
using System.Runtime.Serialization;

namespace Dna.NetCore.Core.Exceptions
{
    public partial class DbException_MessageBuilder : IDbException_MessageBuilder
    {
        #region Private Fields

        private readonly IException_MessageBuilder _exceptionMessageBuilder;
        private CustomMessage _customMessage;
        private DbException _exception;

        #endregion

        #region Public Properties

        public virtual SerializationInfo Info { get; set; }
        public virtual StreamingContext Context { get; set; }
        public virtual int ErrorCode { get; set; }

        #endregion

        #region ctor

        public DbException_MessageBuilder(IException_MessageBuilder exceptionMessageBuilder)
        {
            _exceptionMessageBuilder = exceptionMessageBuilder;
        }

        #endregion

        #region Methods

        public virtual CustomMessage Parse(DbException exception)
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

            string message = " -->>DbException: ";

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
