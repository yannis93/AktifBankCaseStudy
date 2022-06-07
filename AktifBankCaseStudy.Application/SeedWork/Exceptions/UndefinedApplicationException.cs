using System.Runtime.Serialization;

namespace AktifBankCaseStudy.Application.SeedWork.Exceptions
{
    /// <summary>
    /// Exception base of application layer
    /// </summary>
    [Serializable]
    public class UndefinedApplicationException : Exception
    {
        protected UndefinedApplicationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }

        public UndefinedApplicationException()
        { }

        public UndefinedApplicationException(string message)
            : base(message)
        { }

        public UndefinedApplicationException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
