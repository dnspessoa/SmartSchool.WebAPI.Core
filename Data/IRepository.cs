using System.Threading.Tasks;
using SmartSchool.WebAPI.Helpers;
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
        // Task<Aluno[]> GetAllAlunosAsync (bool asIncludeDisciplina = false);
        //Task<PageList<Aluno>> GetAllAlunosAsync (bool asIncludeDisciplina = false);
        Task<PageList<Aluno>> GetAllAlunosAsync(PageParams pageParams, bool asIncludeDisciplina = false);
        Aluno[] GetAllAlunos(bool asIncludeDisciplina = false);
        Aluno[] GetAllAlunosByDisciplinaId(int disciplinaId, bool asIncludeProfessor = false);
        Aluno GetAlunoById(int alunoId, bool asIncludeDisciplina = false);

        //Professores
        Professor[] GetAllProfessores(bool asIncludeAlunos = false);
        Professor[] GetAllProfessoresByDisciplinaId(int disciplinaId, bool asIncludeDisciplina = false);
        Professor GetProfessorById(int professorId, bool asIncludeDisciplina = false);
    }
}