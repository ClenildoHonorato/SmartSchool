using SmartSchool.Api.Models;
using System.Collections.Generic;

namespace SmartSchool.Api.Inject
{
    public interface IRepository
    {
        List<Aluno> GetAllAlunos(bool includeProfessor = false);

        List<Aluno> GetAllAlunosByDisciplina(int disciplinaId, bool includeProfessor = false);

        Aluno GetAlunoById(int alunoId, bool includeProfessor = false);

        List<Professor> GetAllProfessores(bool includeDisciplinas = false, bool includeAlunos = false);

        List<Professor> GetAllProfessoresByDisciplina(int disciplinaId, bool includeDisciplinas = false, bool includeAlunos = false);

        Professor GetProfessorById(int professorId, bool includeDisciplinas = false, bool includeAlunos = false);

        void Add<T>(T entity) where T : class;

        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        bool SaveChanges();
    }
}
