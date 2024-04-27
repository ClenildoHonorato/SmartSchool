﻿using System;

namespace SmartSchool.Api.DTO
{
    public class AlunoDTO
    {
        public int Id { get; set; }

        public int Matricula { get; set; }

        public string Nome { get; set; }

        public string SobreNome { get; set; }

        public string Telefone { get; set; }

        public DateTime DataNascimento { get; set; }

        public DateTime DataInicio { get; set; } = DateTime.Now;

        public DateTime? DataFim { get; set; } = null;

        public bool IsActive { get; set; }
    }
}