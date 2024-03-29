using AutoMapper;
using SmartSchool.WebAPI.Dtos;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Helpers
{
    public class SmartSchoolProfile : Profile
    {
        public SmartSchoolProfile()
        {
            //Aluno
            CreateMap<Aluno, AlunoDto>()
            .ForMember(
                destino => destino.Nome,
                opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}")
            )
            .ForMember(
                destino => destino.Idade,
                opt => opt.MapFrom(src => src.DataNasc.GetCurrentAge())
            );

            //mapeamento para add post
            CreateMap<AlunoDto, Aluno>();

            CreateMap<Aluno, AlunoRegistrarDto>().ReverseMap();
            //CreateMap<AlunoRegistrarDto, Aluno>();

            //Professor
            CreateMap<Professor, ProfessorDto>()
            .ForMember(
                dest => dest.Nome,
                opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}")
            );

            CreateMap<ProfessorDto, Professor>();
            
            CreateMap<Professor, ProfessorDto>().ReverseMap();

            CreateMap<Professor, ProfessorRegistrarDto>().ReverseMap();
        }
    }
}