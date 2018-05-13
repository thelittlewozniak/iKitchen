using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Bisconti Flavian

namespace onessaye.Models.EXCEPTIONS
{
    [Serializable]
    public class UnableToLogInException : ApplicationException
    {
        //Attributes
        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }
        //Builders
        public UnableToLogInException() { }
        public UnableToLogInException(string message, string cause):base(message)
        {
            CauseOfError = cause;
            ErrorTimeStamp = DateTime.Now;
        }
        public UnableToLogInException(string message, Exception inner):base(message, inner) { }
        protected UnableToLogInException(System.Runtime.Serialization.SerializationInfo info, 
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}