using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        //Seta banco
        // public List<Professor> Professores = new List<Professor>(){
            
        //     new Professor(){Id = 1, Nome = "aProfessor" },
        //     new Professor(){Id = 2, Nome = "bProfessor" },
        //     new Professor(){Id = 3, Nome = "cProfessor" },
        //     new Professor(){Id = 4, Nome = "dProfessor" }
        // };

        //Variaveis globais
        // private readonly SmartContext _smartContext;
        private readonly IRepository _repository;

        //Construtores
        public ProfessorController(IRepository irepository) 
        { 
                _repository = irepository;
        }

        //Metodos
        //utilizando IRepository
        // [HttpGet("{GetIRepository}")]
        // public async Task<ActionResult<Professor>> GetIRepository(int id)
        // {
        //     return Ok(_irepository.GetIRepositoryTeste());
        // }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Professor>>> GetAllProfessores()
        {
            // var professores = _smartContext.Professores; 
            var professores = _repository.GetAllProfessores(false);

            return Ok(professores);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Professor>> GetProfessorById(int id)
        {
            // var professor = _smartContext.Professores.FirstOrDefault(x => x.Id == id);
            var professor = _repository.GetProfessorById(id, false);

            if (professor == null)
            return BadRequest("O Professor não foi encontrado");

            return Ok(professor);
        }

        // [HttpGet("ByName")]
        // public async Task<ActionResult<Professor>> GetProfessorByName(string nome)
        // {
        //     var professor = _smartContext.Professores.FirstOrDefault(p => p.Nome.Contains(nome));

        //     if (professor == null)
        //         return BadRequest("O Professor não foi encontrado");

        //     return Ok(professor);
        // }

        [HttpPost]
        public async Task<ActionResult<Professor>> PostProfessor(Professor professor)
        {
             _repository.Add(professor);
            if (_repository.SaveChanges())
            {
                return Ok(professor);
            }

            return BadRequest("Professor não cadastrado");
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Professor>> PutProfessor(int id, Professor professor)
        {
            // var professorAux = _smartContext.Professores.AsNoTracking().FirstOrDefault(p => p.Id == id);
            var professorAux = _repository.GetProfessorById(id);
                
            if(professor == null)
            return BadRequest("O Professor não foi encontrado");

            _repository.Update(professor);
            if (_repository.SaveChanges())
            {
                return Ok(professor);
            }

            return BadRequest("O Professor não foi encontrado");
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult<Professor>> PatchProfessor(int id, Professor professor)
        {
            // var professorAux = _smartContext.Professores.AsNoTracking().FirstOrDefault(p => p.Id == id);
            var professorAux = _repository.GetProfessorById(id);
                
            if(professor == null)
            return BadRequest("O Professor não foi encontrado");

            _repository.Update(professor);
            if (_repository.SaveChanges())
            {
                return Ok(professor);
            }

            return BadRequest("O Professor não foi encontrado");
        }
        
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Professor>> DeleteProfessor(int id)
        {
            //var professor = _smartContext.Professores.AsNoTracking().FirstOrDefault(p => p.Id == id);
            var professor = _repository.GetProfessorById(id);

            if(professor == null)
            return BadRequest("O Professor não foi encontrado");

            _repository.Delete(professor);
            if (_repository.SaveChanges())
            {
                return Ok(professor);
            }

            return BadRequest("O Professor não foi encontrado");
        }
    }
}