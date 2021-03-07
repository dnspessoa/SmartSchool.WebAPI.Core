using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public interface IRepository
    {
        //teste
        string GetIRepositoryTeste();

        void Add<T>(T entity ) where T : class;
        void Update<T>(T entity ) where T : class;
        void Delete<T>(T entity ) where T : class;
        bool SaveChanges();

        //Alunos
        Aluno[] GetAllAlunos(bool asIncludeDisciplina = false);
        Aluno[] GetAllAlunosByDisciplinaId(int disciplinaId, bool asIncludeProfessor = false);
        Aluno GetAlunoById(int alunoId, bool asIncludeDisciplina = false);

        //Professores
        Professor[] GetAllProfessores(bool asIncludeAlunos = false);
        Professor[] GetAllProfessoresByDisciplinaId(int disciplinaId, bool asIncludeDisciplina = false);
        Professor GetProfessorById(int professorId, bool asIncludeDisciplina = false);
    }
}