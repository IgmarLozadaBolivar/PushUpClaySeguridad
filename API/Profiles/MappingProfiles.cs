using API.Dtos;
using AutoMapper;
using Domain.Entities;
namespace API.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Rol, RolDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();

        CreateMap<Pais, PaisDto>().ReverseMap();
        CreateMap<Departamento, DepartamentoDto>().ReverseMap();
        CreateMap<Ciudad, CiudadDto>().ReverseMap();
        CreateMap<Persona, PersonaDto>().ReverseMap();
        CreateMap<TipoContacto, TipoContactoDto>().ReverseMap();
        CreateMap<TipoDireccion, TipoDireccionDto>().ReverseMap();
        CreateMap<TipoPersona, TipoPersonaDto>().ReverseMap();
        CreateMap<Turno, TurnoDto>().ReverseMap();
        CreateMap<Programacion, ProgramacionDto>().ReverseMap();
        CreateMap<ContactoPer, ContactoPerDto>().ReverseMap();
        CreateMap<Contrato, ContratoDto>().ReverseMap();
        CreateMap<DirPersona, DirPersonaDto>().ReverseMap();
        CreateMap<Estado, EstadoDto>().ReverseMap();
        CreateMap<CategoriaPer, CategoriaPerDto>().ReverseMap();
    }
}