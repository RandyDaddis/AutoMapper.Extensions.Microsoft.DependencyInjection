using Dna.NetCore.Core.Common;
using Dna.NetCore.Core.Infrastructure.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Dna.NetCore.Core.Exceptions
{
    public static class SqlException_Handler
    {
        #region Methods

        /// <summary>
        /// parse the exception message stack and log the exception
        /// </summary>
        /// <param name="exception"></param>
        /// <returns>CustomMessage</returns>
        public static CustomMessage Handle(this SqlException exception)
        {
            CustomMessage customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
            customMessage.IsErrorCondition = true;

            customMessage = ParseSqlErrorCollection(exception, customMessage);

            string message = " -->>SqlException_Handler: "
                                + HResult(exception)
                                + SqlException_SqlServerProvider_SeverityLevel(exception)
                                + SqlException_ClientConnectionId(exception)
                                + SqlException_ErrorLineNumber(exception)
                                + SqlException_ErrorType(exception)
                                + SqlException_ProcedureName(exception)
                                + SqlException_SqlServerName(exception)
                                + SqlException_Provider(exception)
                                + SqlException_SqlServer_ErrorCode(exception)
                                + " "
                                + exception.Message ?? ""
                                + " "
                                + customMessage.Message ?? "";

            customMessage.Message = message;

            if (customMessage != null && !string.IsNullOrEmpty(customMessage.Message))
                Log.Write(message);

            return customMessage;
        }

        public static string HResult(this SqlException exception)
        {
            string result = "HResult: ";

            if (exception.HResult != 0)
                result += exception.HResult.ToString();

            return result;
        }

        /// <summary>
        /// parses the ParseSqlErrorCollection - but - does not log the exception
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="customMessage"></param>
        /// <returns>CustomMessage</returns>
        public static CustomMessage ParseSqlErrorCollection(this SqlException exception, CustomMessage customMessage)
        {
            if (customMessage == null)
            {
                customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };
                customMessage.IsErrorCondition = true;
                customMessage.Message = exception.Message;
            }

            if (exception.Errors != null && exception.Errors.Count > 0)
            {
                string keyPrefix = " -->>SqlException.Error";
                int keyIndex = 0;
                string key = keyPrefix + keyIndex.ToString();
                foreach (SqlError error in exception.Errors)
                {
                    // set next key
                    while (customMessage.MessageDictionary1.ContainsKey(key))
                    {
                        keyIndex++;
                        key = keyPrefix + keyIndex.ToString();
                    }
                    // set message
                    string message = SqlError_SqlServerProvider_SeverityLevel(error)
                                        + SqlError_ErrorLineNumber(error)
                                        + SqlError_Message(error)
                                        + SqlError_ErrorType(error)
                                        + SqlError_ProcedureName(error)
                                        + SqlError_SqlServerName(error)
                                        + SqlError_Provider(error)
                                        + SqlError_SqlServer_ErrorCode(error);
                    // add message to dictionary
                    customMessage.MessageDictionary1.Add(key, message);
                }
            }

            return customMessage;
        }

        /// <summary>
        /// Gets the severity level of the error returned from the .NET Framework Data Provider for SQL Server.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns>A value from 1 to 25 that indicates the severity level of the error.</returns>
        public static string SqlException_SqlServerProvider_SeverityLevel(this SqlException exception)
        {
            string severityLevel = "SqlException_SqlServerProvider_SeverityLevel: ";

            if (exception != null && exception.Class > 0 && exception.Class < 26)
                severityLevel += exception.Class.ToString();

            return severityLevel;
        }

        /// <summary>
        /// Represents the client connection ID. For more information, see Data Tracing in ADO.NET.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns>Returns the client connection ID.</returns>
        public static string SqlException_ClientConnectionId(this SqlException exception)
        {
            string clientConnectionId = "SqlException_ClientConnectionId: ";

            if ((Guid)exception.ClientConnectionId != null)
                clientConnectionId += exception.ClientConnectionId.ToString();

            return clientConnectionId.ToString();
        }

        /// <summary>
        /// Gets the line number within the Transact-SQL command batch or stored procedure that generated the error.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns>The line number within the Transact-SQL command batch or stored procedure that generated the error.</returns>
        public static string SqlException_ErrorLineNumber(this SqlException exception)
        {
            string lineNumber = "SqlException_ErrorLineNumber: ";

            if (exception.LineNumber != 0)
                lineNumber += exception.LineNumber.ToString();

            return lineNumber.ToString();
        }

        /// <summary>
        /// Gets a number that identifies the type of error.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns>The number that identifies the type of error.</returns>
        public static string SqlException_ErrorType(this SqlException exception)
        {
            string number = "SqlException_ErrorType: ";

            if (exception.Number != 0)
                number += exception.Number.ToString();

            return number.ToString();
        }

        /// <summary>
        /// Gets the name of the stored procedure or remote procedure call (RPC) that generated the error.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns>The name of the stored procedure or RPC.</returns>
        public static string SqlException_ProcedureName(this SqlException exception)
        {
            string name = "SqlException_ProcedureName: ";

            if (!string.IsNullOrEmpty(exception.Procedure))
                name += exception.Procedure;

            return name;
        }

        /// <summary>
        /// Gets the name of the computer that is running an instance of SQL Server that generated the error.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns>The name of the computer running an instance of SQL Server.</returns>
        public static string SqlException_SqlServerName(this SqlException exception)
        {
            string name = "SqlException_SqlServerName: ";

            if (!string.IsNullOrEmpty(exception.Server))
                name += exception.Server;

            return name;
        }

        /// <summary>
        /// Gets the name of the provider that generated the error.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns>The name of the provider that generated the error.</returns>
        public static string SqlException_Provider(this SqlException exception)
        {
            string name = "SqlException_Provider: ";

            if (!string.IsNullOrEmpty(exception.Source))
                name += exception.Source;

            return name;
        }

        /// <summary>
        ///     Gets a numeric error code from SQL Server that represents an error, warning
        ///     or "no data found" message. For more information about how to decode these
        ///     values, see SQL Server Books Online.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns>The number representing the error code.</returns>
        public static string SqlException_SqlServer_ErrorCode(this SqlException exception)
        {
            string errorCode = "SqlException_SqlServer_ErrorCode: ";

            if (exception != null && exception.State != 0)
                errorCode += exception.State.ToString();

            return errorCode;
        }

        /// <summary>
        /// Gets the severity level of the error returned from the .NET Framework Data Provider for SQL Server.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns>A value from 1 to 25 that indicates the severity level of the error.</returns>
        public static string SqlError_SqlServerProvider_SeverityLevel(SqlError sqlError)
        {
            string severityLevel = "SqlError_SqlServerProvider_SeverityLevel: ";

            if (sqlError != null && sqlError.Class != 0)
                severityLevel += sqlError.Class.ToString();

            return severityLevel;
        }

        /// <summary>
        /// Gets the line number within the Transact-SQL command batch or stored procedure that generated the error.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns>The line number within the Transact-SQL command batch or stored procedure that generated the error.</returns>
        public static string SqlError_ErrorLineNumber(SqlError sqlError)
        {
            string lineNumber = "SqlError_ErrorLineNumber: ";

            if (sqlError.LineNumber != 0)
                lineNumber += sqlError.LineNumber.ToString();

            return lineNumber.ToString();
        }

        /// <summary>
        /// Gets the text describing the error.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns>The line number within the Transact-SQL command batch or stored procedure that generated the error.
        ///     The text describing the error.For more information on errors generated by
        ///     SQL Server, see SQL Server Books Online.</returns>
        public static string SqlError_Message(SqlError sqlError)
        {
            string message = "SqlError_Message: ";

            if (!string.IsNullOrEmpty(sqlError.Message))
                message += sqlError.Message;

            return sqlError.Message;
        }

        /// <summary>
        /// Gets a number that identifies the type of error.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns>The number that identifies the type of error.</returns>
        public static string SqlError_ErrorType(SqlError sqlError)
        {
            string number = "SqlError_ErrorType: ";

            if (sqlError.Number != 0)
                number += sqlError.Number.ToString();

            return number.ToString();
        }

        /// <summary>
        /// Gets the name of the stored procedure or remote procedure call (RPC) that generated the error.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns>The name of the stored procedure or RPC.</returns>
        public static string SqlError_ProcedureName(SqlError sqlError)
        {
            string name = "SqlError_ProcedureName: ";

            if (!string.IsNullOrEmpty(sqlError.Procedure))
                name += sqlError.Procedure;

            return name;
        }

        /// <summary>
        /// Gets the name of the computer that is running an instance of SQL Server that generated the error.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns>The name of the computer running an instance of SQL Server.</returns>
        public static string SqlError_SqlServerName(SqlError sqlError)
        {
            string name = "SqlError_SqlServerName: ";

            if (!string.IsNullOrEmpty(sqlError.Server))
                name += sqlError.Server;
            return name;
        }

        /// <summary>
        /// Gets the name of the provider that generated the error.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns>The name of the provider that generated the error.</returns>
        public static string SqlError_Provider(SqlError sqlError)
        {
            string name = "SqlError_Provider: ";

            if (!string.IsNullOrEmpty(sqlError.Source))
                name += sqlError.Source;

            return name;
        }

        /// <summary>
        ///     Gets a numeric error code from SQL Server that represents an error, warning
        ///     or "no data found" message. For more information about how to decode these
        ///     values, see SQL Server Books Online.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns>The number representing the error code.</returns>
        public static string SqlError_SqlServer_ErrorCode(SqlError sqlError)
        {
            string errorCode = "SqlError_SqlServer_ErrorCode: ";

            if (sqlError != null && sqlError.State != 0)
                errorCode += sqlError.State.ToString();

            return errorCode;
        }

        #endregion
    }
}
