using System.Runtime.Serialization;

namespace AktifBankCaseStudy.SharedKernel.SeedWork
{
    /// <summary>
    /// Exception type for domain exceptions
    /// </summary>
    [Serializable]
    public class DomainException : Exception
    {
        protected DomainException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }

        public DomainException()
        { }

        public DomainException(string message)
            : base(message)
        { }

        public DomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
