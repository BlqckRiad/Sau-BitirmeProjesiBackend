using AutoMapper;
using IysService.DtoLayer.MappingDtos;
using IysService.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IysService.BusinessLayer.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User -> UserListRequestDto eşleme
            CreateMap<Contact,ContactListMapDto >();
            CreateMap<Appointment, AppointmentListMapDto>();
            CreateMap<XRayResult, XRayResultListDto>();
        }
    }
}
