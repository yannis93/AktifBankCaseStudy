namespace AktifBankCaseStudy.SharedKernel.SeedWork
{
    public interface IFilterInfo
    {
        string OrderBy { get; }
        string SortBy { get; }
        string SearchTerm { get; }
    }
}
