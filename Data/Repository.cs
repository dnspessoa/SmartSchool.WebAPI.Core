using System.Linq;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public class Repository : IRepository
    {
        private readonly SmartContext _context;
        public Repository(SmartContext context)
        {
            _context = context;
        }

        public string GetIRepositoryTeste()
        {
            throw new System.NotImplementedException();
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return(_context.SaveChanges() > 0);
        }
        //region Alunos
        public Aluno[] GetAllAlunos(bool asIncludeDisciplina = false)
        {
            IQueryable<Aluno> query = _context.Alunos;
            
            if (asIncludeDisciplina)
            {
                //Join
                query = query.Include(a => a.AlunosDisciplinas)
                             .ThenInclude(ad => ad.Disciplina)
                             .ThenInclude(d => d.Professor);
            }
            
            query = query.AsNoTracking().OrderBy(a => a.Id);

            return query.ToArray();
        }

        public Aluno[] GetAllAlunosByDisciplinaId(int disciplinaId, bool asIncludeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;
            if (asIncludeProfessor)
            {
                //Join
                query = query.Include(a => a.AlunosDisciplinas)
                             .ThenInclude(ad => ad.Disciplina)
                             .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking()
                         .OrderBy(a => a.Id)
                         .Where(aluno => aluno.AlunosDisciplinas.Any(ad => ad.DisciplinaId == disciplinaId));

            return query.ToArray();
        }

        public Aluno GetAlunoById(int alunoId, bool asIncludeDisciplina = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (asIncludeDisciplina)
            {
                //Join
                query = query.Include(a => a.AlunosDisciplinas)
                             .ThenInclude(ad => ad.Disciplina)
                             .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking()
                         .OrderBy(a => a.Id)
                         .Where(a => a.Id == alunoId);
            
            return query.FirstOrDefault();
        }

        //region Professores
        public Professor[] GetAllProfessores(bool asIncludeAlunos = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if (asIncludeAlunos)
            {
                //Join
                query = query.Include(d => d.Disciplinas)
                             .ThenInclude(ad => ad.AlunosDisciplinas)
                             .ThenInclude(a => a.Aluno);
                             
            }

            return query.AsNoTracking().OrderBy(p => p.Id).ToArray();
        }

        public Professor[] GetAllProfessoresByDisciplinaId(int disciplinaId, bool asIncludeDisciplina = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if (asIncludeDisciplina)
            {
                //Join
                query = query.Include(d => d.Disciplinas)
                             .ThenInclude(ad => ad.AlunosDisciplinas)
                             .ThenInclude(a => a.Aluno);
            }

            query = query.AsNoTracking()
                         .OrderBy(p => p.Id)
                         .Where(d => d.Disciplinas.Any(
                             ad  => ad.AlunosDisciplinas.Any(ad => ad.DisciplinaId == disciplinaId)
                         ));
                         
            return query.ToArray();
        }

        public Professor GetProfessorById(int professorId, bool asIncludeDisciplina = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if (asIncludeDisciplina)
            {
                //Join
                query = query.Include(p => p.Disciplinas)
                             .ThenInclude(ad => ad.AlunosDisciplinas)
                             .ThenInclude(a => a.Aluno);
            }

            return query.FirstOrDefault();
        }
    }
}