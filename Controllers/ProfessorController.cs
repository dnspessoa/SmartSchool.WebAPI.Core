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
        private readonly SmartContext _smartContext;
        private readonly IRepository _irepository;

        //Construtores
        public ProfessorController(SmartContext smartContext, IRepository irepository) 
        { 
                _smartContext = smartContext;
                _irepository = irepository;
        }

        //Metodos
        //utilizando IRepository
        [HttpGet("{GetIRepository}")]
        public async Task<ActionResult<Professor>> GetIRepository(int id)
        {
            return Ok(_irepository.GetIRepositoryTeste());
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Professor>>> Get()
        {
            var professores = _smartContext.Professores; 
            return Ok(professores);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Professor>> GetId(int id)
        {
            var professor = _smartContext.Professores.FirstOrDefault(x => x.Id == id);
            if (professor == null)
            return BadRequest("O Professor não foi encontrado");

            return Ok(professor);
        }

        [HttpGet("ByName")]
        public async Task<ActionResult<Professor>> GetByName(string nome)
        {
            var professor = _smartContext.Professores.FirstOrDefault(p => p.Nome.Contains(nome));

            if (professor == null)
                return BadRequest("O Professor não foi encontrado");

            return Ok(professor);
        }

        [HttpPost]
        public async Task<ActionResult<Professor>> Post(Professor professor)
        {
            _smartContext.Add(professor);
            _smartContext.SaveChanges();
            return Ok(professor);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Professor>> Put(int id, Professor professor)
        {
            var professorAux = _smartContext.Professores
                .AsNoTracking().FirstOrDefault(p => p.Id == id);
            if(professor == null)
            return BadRequest("O Professor não foi encontrado");

            _smartContext.Update(professor);
            _smartContext.SaveChanges();

            return Ok(professor);
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult<Professor>> Patch(int id, Professor professor)
        {
            var professorAux = _smartContext.Professores
                .AsNoTracking().FirstOrDefault(p => p.Id == id);
            if(professor == null)
            return BadRequest("O Professor não foi encontrado");

            _smartContext.Update(professor);
            _smartContext.SaveChanges();

            return Ok(professor);
        }
        
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Professor>> Delete(int id)
        {
            var professor = _smartContext.Professores
                .FirstOrDefault(p => p.Id == id);
            if(professor == null)
            return BadRequest("O Professor não foi encontrado");

            _smartContext.Remove(professor);
            _smartContext.SaveChanges();

            return Ok();
        }
    }
}