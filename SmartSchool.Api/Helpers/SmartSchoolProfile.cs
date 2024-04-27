using AutoMapper;
using SmartSchool.Api.DTO;
using SmartSchool.Api.Models;

namespace SmartSchool.Api.Helpers
{
    public class SmartSchoolProfile : Profile
    {
        public SmartSchoolProfile()
        {
            CreateMap<Aluno, AlunoResponseDTO>()
                .ForMember(
                    aluno => aluno.Nome,
                    opt => opt.MapFrom(alunoDto => $"{alunoDto.Nome} {alunoDto.SobreNome}")
                )
                .ForMember(
                    aluno => aluno.Idade,
                    opt => opt.MapFrom(alunoDTO => alunoDTO.DataNascimento.GetCurrentAge())
                );

            CreateMap<AlunoResponseDTO, Aluno >();
            CreateMap<AlunoDTO, Aluno>().ReverseMap();

            CreateMap<Professor, ProfessorResponseDTO>()
                .ForMember(
                    aluno => aluno.Nome,
                    opt => opt.MapFrom(alunoDto => $"{alunoDto.Nome} {alunoDto.SobreNome}")
                );

            CreateMap<ProfessorResponseDTO, Professor>();
            CreateMap<ProfessorDTO, Professor>().ReverseMap();
        }
    }
}
