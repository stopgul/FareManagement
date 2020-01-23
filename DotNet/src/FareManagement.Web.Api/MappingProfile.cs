using AutoMapper;
using FareManagement.Calculator.Model;

namespace FareManagement.Web.Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TripDetail, TripDetailDto>();
            CreateMap<TripDetailDto, TripDetail>();
        }
    }
}
