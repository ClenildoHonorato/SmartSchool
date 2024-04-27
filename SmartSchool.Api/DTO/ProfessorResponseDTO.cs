using System;

namespace SmartSchool.Api.DTO
{
    public class ProfessorResponseDTO
    {
        public int Id { get; set; }

        public int Registro { get; set; }

        public string Nome { get; set; }

        public string Telefone { get; set; }

        public DateTime DataInicio { get; set; }

        public bool IsActive { get; set; }
    }
}
