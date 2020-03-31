using AutoMapper;
using Contracts.Dto.Requests;
using Contracts.Dto.Responses;
using Mo = Entities.Models;

namespace Services.Mapper
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Mo.Contact, ContactDto>()
                .ForMember(dest => dest.CityName, act => act.MapFrom(src => src.City.Name))
                .ForMember(dest => dest.CompanyName, act => act.MapFrom(src => src.Company.Name))
                .ForMember(dest => dest.StateName, act => act.MapFrom(src => src.City.State.Name))
                .ForMember(dest => dest.StateID, act => act.MapFrom(src => src.City.State.ID));

            CreateMap<CreateContactDto, Mo.Contact>()
                .ForMember(dest => dest.Phones, act => act.MapFrom(src => src.Phones));

            CreateMap<Mo.Phone, PhoneDto>();

            CreateMap<ContactDto, Mo.Contact>();

            CreateMap<PhoneDto, Mo.Phone>();
        }
    }
}
