using API.Dtos;
using AutoMapper;
using Dominio.Entities;

namespace API.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Asignatura,AsignaturaDto>().ReverseMap();
        CreateMap<CursoEscolar,CursoEscolarDto>().ReverseMap();
        CreateMap<Grado,GradoDto>().ReverseMap();
        CreateMap<Persona,PersonaDto>().ReverseMap();
        CreateMap<Departamento,DepartamentoDto>().ReverseMap();

    }
}