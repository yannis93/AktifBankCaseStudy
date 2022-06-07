using AutoMapper;

namespace AktifBankCaseStudy.Application.SeedWork.Mappings
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
