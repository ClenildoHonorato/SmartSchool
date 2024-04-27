﻿using System;
using System.Collections.Generic;

namespace SmartSchool.Api.Models
{
    public class Aluno
    {
        public Aluno() { }
        public Aluno(int id, int matricula, string nome, string sobreNome, string telefone, DateTime dataNascimento)
        {
            this.Id = id;
            this.Matricula = matricula;
            this.Nome = nome;
            this.SobreNome = sobreNome;
            this.Telefone = telefone;
            this.DataNascimento = dataNascimento;

        }

        public int Id { get; set; }
        
        public int Matricula { get; set; }

        public string Nome { get; set; }

        public string SobreNome { get; set; }

        public string Telefone { get; set; }
        
        public DateTime DataNascimento { get; set; }
        
        public DateTime DataInicio { get; set; } = DateTime.Now;

        public DateTime? DataFim { get; set; } = null;

        public bool IsActive { get; set; } = true;

        public IEnumerable<AlunoDisciplina> AlunosDisciplinas { get; set; }
    }
}
