using System.Runtime.Serialization;

namespace AktifBankCaseStudy.Application.SeedWork.Exceptions;

[Serializable]
public class NotFoundException : ApplicationException
{
    protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    { }

    public NotFoundException()
    { }

    public NotFoundException(string message)
        : base(message)
    { }

    public NotFoundException(string message, Exception innerException)
        : base(message, innerException)
    { }
}