using AutoMapper;
using DemokrataBryan.Entities;
using DemokrataBryan.Entities.Models;

namespace DemokrataBryan.Api.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapeo entre UsuarioCreateDTO y Usuario
            CreateMap<UsuarioDto, Usuario>()
                .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.FechaModificacion, opt => opt.MapFrom(src => DateTime.Now));
        }
    }
}
