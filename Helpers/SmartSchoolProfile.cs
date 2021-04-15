using AutoMapper;
using SmartSchool.WebAPI.Dtos;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Helpers
{
    public class SmartSchoolProfile : Profile
    {
        public SmartSchoolProfile()
        {
            CreateMap<Aluno, AlunoDto>()
            .ForMember(
                destino => destino.Nome,
                opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}")
            )
            .ForMember(
                destino => destino.Idade,
                opt => opt.MapFrom(src => src.DataNasc.GetCurrentAge())
            )
            ;
        }
    }
}