using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.Api.Data;
using SmartSchool.Api.Models;
using System.Linq;

namespace SmartSchool.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {

        private readonly SmartSchoolContext context;

        public AlunoController(SmartSchoolContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.context.Alunos);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var aluno = this.context.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("Aluno não encontrado");
            return Ok(aluno);
        }

        [HttpGet("{name}")]
        public IActionResult GetByNome(string name)
        {
            var aluno = this.context.Alunos.FirstOrDefault(a => a.Nome == name);
            if (aluno == null) return BadRequest("Aluno não encontrado");
            return Ok(aluno);
        }

        [HttpGet("byname")]
        public IActionResult GetByName(string name, string sobrenome)
        {
            var aluno = this.context.Alunos.FirstOrDefault(a => a.Nome == name && a.SobreNome == sobrenome);
            if (aluno == null) return BadRequest("Aluno não encontrado");
            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            this.context.Add(aluno);
            this.context.SaveChanges();
            return Ok(aluno);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var getaluno = this.context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (getaluno == null) return BadRequest("Aluno não encontrado.");

            this.context.Update(aluno);
            this.context.SaveChanges();


            return Ok(aluno);
        }

        [HttpPatch("{id:int}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var getaluno = this.context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (getaluno == null) return BadRequest("Aluno não encontrado.");

            this.context.Update(aluno);
            this.context.SaveChanges();

            return Ok(aluno);
        }


        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var getaluno = this.context.Alunos.FirstOrDefault(a => a.Id == id);
            if (getaluno == null) return BadRequest("Aluno não encontrado.");

            this.context.Remove(getaluno);
            this.context.SaveChanges();

            return Ok(id);
        }

    }
}
