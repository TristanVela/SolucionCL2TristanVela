using AutoMapper;
using CL2TristanVela.Database;
using CL2TristanVela.Models;

namespace CL2TristanVela.Profiles
{
    public class NotasProfile : Profile
    {
        public NotasProfile()
        {
            CreateMap<NotasEntity, AlumnoViewModel>().ReverseMap();
        }
    }

}

