using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace SmartSchool.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        List<Aluno> Alunos = new List<Aluno>(){
            new Aluno { Id = 1 , Nome = "Clenildo", SobreNome = "Honorato", Telefone = "85965254885"},
            new Aluno { Id = 2 , Nome = "Chelly", SobreNome = "Pereira", Telefone = "85996583215"},
            new Aluno { Id = 3 , Nome = "Alice", SobreNome = "Honorato"},
            new Aluno { Id = 4 , Nome = "Gabi", SobreNome = "Honorato"},
            new Aluno { Id = 5 , Nome = "Bianca", SobreNome = "Honorato"}
        };

        public AlunoController()
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("Aluno não encontrado");
            return Ok(aluno);
        }

        [HttpGet("{name}")]
        public IActionResult GetByNome(string name)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Nome == name);
            if (aluno == null) return BadRequest("Aluno não encontrado");
            return Ok(aluno);
        }

        [HttpGet("byname")]
        public IActionResult GetByName(string name, string sobrenome)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Nome == name && a.SobreNome == sobrenome);
            if (aluno == null) return BadRequest("Aluno não encontrado");
            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpPatch("{id:int}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            return Ok(aluno);
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Ok(id);
        }

    }
}
