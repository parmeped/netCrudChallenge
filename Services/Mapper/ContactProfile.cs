using AutoMapper;
using Contracts.Dto.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using Mo = Entities.Models;

namespace Services.Mapper
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Mo.Contact, ContactDto>();
        }
    }
}
