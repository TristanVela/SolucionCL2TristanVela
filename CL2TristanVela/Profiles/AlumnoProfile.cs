using AutoMapper;
using CL2TristanVela.Database;
using CL2TristanVela.Models;

namespace CL2TristanVela.Profiles
{
    public class AlumnoProfile : Profile
    {
        public AlumnoProfile()
        {
            CreateMap<AlumnosEntity, AlumnoViewModel>().ReverseMap();
        }
    }

}
