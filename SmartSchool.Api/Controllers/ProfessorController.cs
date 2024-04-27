using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.Api.DTO;
using SmartSchool.Api.Inject;
using SmartSchool.Api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository repository;

        private readonly IMapper mapper;

        public ProfessorController(IRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        // GET: api/<ProfessorController>
        [HttpGet]
        public IActionResult Get()
        {
            var professor = this.repository.GetAllProfessores(true, false);
            return Ok(professor);
        }

        // GET api/<ProfessorController>/5
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var professor = this.repository.GetProfessorById(id, true, true);
            if (professor == null) return BadRequest("Professor não encontrado");

            var professorResponse = this.mapper.Map<ProfessorResponseDTO>(professor);

            return Ok(professorResponse);
        }

        [HttpGet("getresponse")]
        public IActionResult GetResponse(int id)
        {
            return Ok(new ProfessorResponseDTO());
        }

        // POST api/<ProfessorController>
        [HttpPost]
        public IActionResult Post(ProfessorDTO model)
        {
            var professor = this.mapper.Map<Professor>(model);

            this.repository.Add(professor);

            if (this.repository.SaveChanges())
            {
                return Created($"/api/professor/{model.Id}", this.mapper.Map<ProfessorResponseDTO>(professor));
            }

            return BadRequest("Professor não cadastrado");
        }

        // PUT api/<ProfessorController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, ProfessorDTO model)
        {
            var professor = this.repository.GetProfessorById(id, true, true);
            if (professor == null) return BadRequest("Professor não encontrado");

            this.mapper.Map(model, professor);

            this.repository.Update(professor);

            if (this.repository.SaveChanges())
            {
                return Created($"/api/professor/{model.Id}", this.mapper.Map<ProfessorResponseDTO>(professor));
            }

            return BadRequest("Professor não atualizado");

        }

        // PUT api/<ProfessorController>/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, ProfessorDTO model)
        {
            var professor = this.repository.GetProfessorById(id, true, true);
            if (professor == null) return BadRequest("Professor não encontrado");

            this.mapper.Map(model, professor);

            this.repository.Update(professor);

            if (this.repository.SaveChanges())
            {
                return Created($"/api/professor/{model.Id}", this.mapper.Map<ProfessorResponseDTO>(professor));
            }

            return BadRequest("Professor não atualizado");

        }

        // DELETE api/<ProfessorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = this.repository.GetProfessorById(id);
            if (professor == null) return BadRequest("Professor não encontrado");

            this.repository.Delete(professor);
            this.repository.SaveChanges();

            return Ok(id);
        }
    }
}
