using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.Api.DTO;
using SmartSchool.Api.Helpers;
using SmartSchool.Api.Inject;
using SmartSchool.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartSchool.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {

        private readonly IRepository repository;

        private readonly IMapper mapper;

        public AlunoController(IRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }


        /// <summary>
        /// Método responsável por retornor todos os aluno.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]PageParameters pageParameters)
        {

            var alunos = await this.repository.GetAllAlunosAsync(pageParameters, true);
            var resultAlunos = this.mapper.Map<IEnumerable<AlunoResponseDTO>>(alunos);

            Response.AddPagination(alunos.CurrentPage, alunos.TotalPages, alunos.PageSize, alunos.TotalCount);

            return Ok(resultAlunos);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var aluno = this.repository.GetAlunoById(id);
            if (aluno == null) return BadRequest("Aluno não encontrado");

            var alunoDto = this.mapper.Map<AlunoResponseDTO>(aluno);

            return Ok(alunoDto);
        }

        [HttpGet("getresponse")]
        public IActionResult GetResponse(int id)
        {            
            return Ok(new AlunoResponseDTO());
        }


        [HttpPost]
        public IActionResult Post(AlunoDTO model)
        {
            var checkAluno = this.repository.GetAlunoById(model.Matricula);
            if (checkAluno != null) return BadRequest("Aluno já cadastrado.");

            var aluno = this.mapper.Map<Aluno>(model);

            this.repository.Add(aluno);

            if (this.repository.SaveChanges())
            {
                return Created($"/api/aluno/{model.Id}", this.mapper.Map<AlunoResponseDTO>(aluno));
            }

            return BadRequest("Aluno não cadastrado");            
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, AlunoDTO model)
        {
            var aluno = this.repository.GetAlunoById(id);
            if (aluno == null) return BadRequest("Aluno não encontrado.");

            this.mapper.Map(model, aluno);

            this.repository.Update(aluno);
            if (this.repository.SaveChanges())
            {
                return Created($"/api/aluno/{model.Id}", this.mapper.Map<AlunoResponseDTO>(aluno));
            }

            return BadRequest("Aluno não cadastrado");
        }

        [HttpPatch("{id:int}")]
        public IActionResult Patch(int id, AlunoDTO model)
        {
            var aluno = this.repository.GetAlunoById(id);
            if (aluno == null) return BadRequest("Aluno não encontrado.");

            aluno = this.mapper.Map<Aluno>(model);

            this.repository.Update(aluno);
            if (this.repository.SaveChanges())
            {
                return Created($"/api/aluno/{model.Id}", this.mapper.Map<AlunoResponseDTO>(aluno));
            }

            return BadRequest("Aluno não cadastrado");
        }


        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var getaluno = this.repository.GetAlunoById(id);
            if (getaluno == null) return BadRequest("Aluno não encontrado.");

            this.repository.Delete(getaluno);
            this.repository.SaveChanges();

            return Ok(id);
        }

    }
}
