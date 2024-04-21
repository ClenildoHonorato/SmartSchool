using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.Api.Data;
using SmartSchool.Api.Models;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly SmartSchoolContext context;
        public ProfessorController(SmartSchoolContext context)
        {
            this.context = context;
        }

        // GET: api/<ProfessorController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.context.Professores);
        }

        // GET api/<ProfessorController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var professor = this.context.Professores.FirstOrDefault(p => p.Id == id);
            return Ok(this.context.Professores);
        }

        // GET api/<ProfessorController>/5
        [HttpGet("{nome}")]
        public IActionResult GetByName(string nome)
        {
            var professor = this.context.Professores.FirstOrDefault(p => p.Nome.Contains(nome));
            return Ok(this.context.Professores);
        }

        // POST api/<ProfessorController>
        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            this.context.Add(professor);
            this.context.SaveChanges();

            return Ok(professor);
        }

        // PUT api/<ProfessorController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = this.context.Professores.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if (prof == null) return BadRequest("Professor não encontrado");

            this.context.Update(professor);
            this.context.SaveChanges();

            return Ok(professor);
        }

        // DELETE api/<ProfessorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = this.context.Professores.FirstOrDefault(p => p.Id == id);
            if (professor == null) return BadRequest("Professor não encontrado");

            this.context.Remove(professor);
            this.context.SaveChanges();

            return Ok(id);
        }
    }
}
