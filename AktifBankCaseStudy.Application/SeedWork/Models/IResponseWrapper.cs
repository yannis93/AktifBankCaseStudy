namespace AktifBankCaseStudy.Application.SeedWork.Models
{
    public interface IResponseWrapper<out TResponse>
    {
        TResponse Response { get; }
        string RequestId { get; }
        bool IsSuccess { get; }
        Exception Error { get; }
    }
}
