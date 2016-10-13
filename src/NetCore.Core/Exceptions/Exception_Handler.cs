﻿using NetCore.Core.Common;
using NetCore.Core.Infrastructure.Logging;
using System;
using System.Collections;
using System.Collections.Generic;

namespace NetCore.Core.Exceptions
{
    public static class Exception_Handler
    {
        #region Methods

        // TODO: .NET Core implementation
        /////// <summary>
        ///////// 
        ///////// // WARNING: System.Exception.TargetSite is not implemented in System.Runtime, Version=4.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
        ///////// //                                                            .nuget\packages\System.Runtime\4.1.0\ref\netstandard1.5\System.Runtime.dll
        /////////
        /////// parse the messages and log the error
        /////// </summary>
        /////// <param name="exception"></param>
        /////// <returns>CustomMessage</returns>
        //public static CustomMessage Handle(this Exception exception)
        //{
        //    CustomMessage customMessage = new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

        //    customMessage.Message = Get_StackTrace(exception);

        //    customMessage = ParseData(exception, customMessage);

        //    customMessage = ParseInnerException(exception, customMessage);

        //    string message = " -->>Exception_HResult: "
        //                        + exception.HResult.ToString()
        //                        + " DeclaringType_ClassName: "
        //                        + Get_TargetSite_DeclaringType_ClassName(exception)
        //                        + " DeclaringType_MethodName: "
        //                        + Get_TargetSite_MethodName(exception)
        //                        //+ " DeclaringType_MemberType: "
        //                        //+ Get_TargetSite_MemberType(exception)
        //                        + " "
        //                        + exception.Message ?? ""
        //                        + " "
        //                        + customMessage.Message ?? "";

        //    customMessage.Message += message;

        //    customMessage.IsErrorCondition = true;

        //    if (customMessage != null && !string.IsNullOrEmpty(customMessage.Message))
        //        Log.Write(message);

        //    return customMessage;
        //}

        public static CustomMessage ParseData(this Exception exception, CustomMessage customMessage)
        {
            customMessage = customMessage ?? new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            foreach (DictionaryEntry de in exception.Data)
                customMessage.MessageDictionary1.Add(de.Key.ToString(), de.Value.ToString());

            return customMessage;
        }

        public static CustomMessage ParseInnerException(this Exception exception, CustomMessage customMessage)
        {
            customMessage = customMessage ?? new CustomMessage() { MessageDictionary1 = new Dictionary<string, string>(), MessageDictionary2 = new Dictionary<string, string>() };

            if (exception.InnerException != null)
            {
                var innerException = exception.InnerException;
                while (innerException != null)
                {
                        customMessage.Message += " -->>InnerException: ";

                        if (!string.IsNullOrEmpty(innerException.Message))
                            customMessage.Message += innerException.Message;

                        if (innerException.InnerException != null)
                            innerException = innerException.InnerException;
                        else
                            break;
                }
            }

            return customMessage;
        }

        /// <summary>
        /// returns the current line # of each class in the call stack
        /// </summary>
        /// <param name="exception"></param>
        /// <returns>string</returns>
        public static string Get_StackTrace (this Exception exception)
        {
            string stackTrace = exception.StackTrace;
            return stackTrace;
        }

        // TODO: .NET Core implementation
        /////// <summary>
        /////// 
        /////// // WARNING: System.Exception.TargetSite is implemented in mscorlib,
        ///////               but it is not implemented in System.Runtime, Version=4.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
        /////// //                                                            .nuget\packages\System.Runtime\4.1.0\ref\netstandard1.5\System.Runtime.dll
        ///////
        /////// returns the class name for the method that caused the exception
        /////// </summary>
        /////// <param name="exception"></param>
        /////// <returns>class name</returns>
        //public static string Get_TargetSite_DeclaringType_ClassName(this Exception exception)
        //{
        //    string name = exception.TargetSite.DeclaringType.FullName;
        //    return name;
        //}

        /////// <summary>
        ///////// 
        ///////// // WARNING: System.Exception.TargetSite is not implemented in System.Runtime, Version=4.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
        ///////// //                                                            .nuget\packages\System.Runtime\4.1.0\ref\netstandard1.5\System.Runtime.dll
        /////////
        /////// returns the method name that caused the exception
        /////// </summary>
        /////// <param name="exception"></param>
        /////// <returns>method name</returns>
        //public static string Get_TargetSite_MethodName(this Exception exception)
        //{
        //    string name = exception.TargetSite.Name;
        //    return name;
        //}

        /////// <summary>
        /////// identifies the member type (E.G. property vs. method) that caused the exception
        /////// </summary>
        /////// <param name="exception"></param>
        /////// <returns>member types:Constructor, Event, Field, Method, Property, TypeInfo, Custom, NestedType, All</returns>
        ////public static string Get_TargetSite_MemberType(this Exception exception)
        ////{
        ////    string s = System.Enum.GetName(MemberTypes, exception.TargetSite.MemberType.GetType as object);

        ////    return s;
        ////}

        #endregion
    }
}