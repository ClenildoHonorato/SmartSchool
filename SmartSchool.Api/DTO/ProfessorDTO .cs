using System;

namespace SmartSchool.Api.DTO
{
    public class ProfessorDTO
    {
        public int Id { get; set; }

        public int Registro { get; set; }

        public string Nome { get; set; }

        public string SobreNome { get; set; }

        public string Telefone { get; set; }

        public DateTime DataInicio { get; set; } = DateTime.Now;

        public DateTime? DataFim { get; set; } = null;

        public bool IsActive { get; set; }
    }
}
