using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SmartSchool.Api.Data;
using SmartSchool.Api.Helpers;
using SmartSchool.Api.Inject;
using SmartSchool.Api.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.Api.DAO
{
    public class Repository : IRepository
    {

        private readonly SmartSchoolContext context;
        public Repository(SmartSchoolContext context)
        {
            this.context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            this.context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            this.context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            this.context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return (this.context.SaveChanges() > 0);
        }

        public async Task<PageList<Aluno>> GetAllAlunosAsync(PageParameters pageParameters, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = this.context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas)
                             .ThenInclude(ad => ad.Disciplina)
                             .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id);

            if (!string.IsNullOrEmpty(pageParameters.Nome))
            {
                query = query.Where(aluno => aluno.Nome.ToUpper().Contains(pageParameters.Nome.ToUpper()) ||
                                             aluno.SobreNome.ToUpper().Contains(pageParameters.Nome.ToUpper()));

            }

            if (pageParameters.Matricula > 0)
            {
                query = query.Where(aluno => aluno.Matricula == pageParameters.Matricula);
            }

            if (pageParameters.IsActive != null)
            {
                query = query.Where(aluno => aluno.IsActive == (pageParameters.IsActive != 0));
            }

            return await PageList<Aluno>.CreateAsync(query, pageParameters.PageNumber, pageParameters.PageSize);
        }

        public List<Aluno> GetAllAlunosByDisciplina(int disciplinaId, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = this.context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas)
                             .ThenInclude(ad => ad.Disciplina)
                             .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id)
                                        .Where(aluno => aluno.AlunosDisciplinas.Any(ad => ad.DisciplinaId == disciplinaId));

            return query.ToList();
        }

        public Aluno GetAlunoById(int alunoId, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = this.context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas)
                             .ThenInclude(ad => ad.Disciplina)
                             .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id).Where(aluno => aluno.Id == alunoId);

            return query.FirstOrDefault();
        }

        public List<Professor> GetAllProfessores(bool includeDisciplinas = false, bool includeAlunos = false)
        {
            IQueryable<Professor> query = this.context.Professores;

            if (includeDisciplinas && includeAlunos == false)
            {
                query = query.Include(p => p.Disciplinas);
            }

            if (includeAlunos)
            {
                query = query.Include(p => p.Disciplinas)
                             .ThenInclude(d => d.AlunosDisciplinas)
                             .ThenInclude(al => al.Aluno);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id);


            return query.ToList();
        }

        public List<Professor> GetAllProfessoresByDisciplina(int disciplinaId, bool includeDisciplinas = false, bool includeAlunos = false)
        {
            IQueryable<Professor> query = this.context.Professores;

            if (includeDisciplinas && includeAlunos == false)
            {
                query = query.Include(p => p.Disciplinas);
            }

            if (includeAlunos)
            {
                query = query.Include(p => p.Disciplinas)
                             .ThenInclude(d => d.AlunosDisciplinas)
                             .ThenInclude(al => al.Aluno);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id)
                         .Where(prof => prof.Disciplinas.Any(d => d.AlunosDisciplinas.Any(ad => ad.DisciplinaId == disciplinaId))); ;

            return query.ToList();
        }

        public Professor GetProfessorById(int professorId, bool includeDisciplinas = false, bool includeAlunos = false)
        {
            IQueryable<Professor> query = this.context.Professores;

            if (includeDisciplinas && includeAlunos == false)
            {
                query = query.Include(p => p.Disciplinas);
            }

            if (includeAlunos)
            {
                query = query.Include(p => p.Disciplinas)
                             .ThenInclude(d => d.AlunosDisciplinas)
                             .ThenInclude(al => al.Aluno);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id).Where(p => p.Id == professorId);


            return query.FirstOrDefault();
        }
    }
}
