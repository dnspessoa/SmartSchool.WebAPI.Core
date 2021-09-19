using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Dtos;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    //version
    // [ApiVersion("1.0")]
    //[Route("api/v{version:apiVersion}/[controller]")]
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
        private readonly IMapper _mapper;

        //Construtores
        public ProfessorController(IRepository irepository, IMapper mapper)
        {
            _mapper = mapper;
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

            //return Ok(professores);

            return Ok(_mapper.Map<IEnumerable<ProfessorDto>>(professores));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Professor>> GetProfessorById(int id)
        {
            // var professor = _smartContext.Professores.FirstOrDefault(x => x.Id == id);
            var professor = _repository.GetProfessorById(id, false);

            if (professor == null)
                return BadRequest("O Professor não foi encontrado");

            var professorDto = _mapper.Map<ProfessorDto>(professor);

            //return Ok(professor);

            return Ok(professorDto);
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
        public async Task<ActionResult<Professor>> PostProfessor(ProfessorRegistrarDto professorDto)
        {
            var professor = _mapper.Map<Professor>(professorDto);

            _repository.Add(professor);
            if (_repository.SaveChanges())
            {
                //return Ok(professor);
                return Created($"/api/professor/{professor.Id}", _mapper.Map<ProfessorDto>(professor));
            }

            return BadRequest("Professor não cadastrado");
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Professor>> PutProfessor(int id, ProfessorRegistrarDto professorDto)
        {
            // var professorAux = _smartContext.Professores.AsNoTracking().FirstOrDefault(p => p.Id == id);
            var professor = _repository.GetProfessorById(id);

            if (professor == null)
                return BadRequest("O Professor não foi encontrado");

            _mapper.Map(professorDto, professor);

            _repository.Update(professor);
            if (_repository.SaveChanges())
            {
                //return Ok(professor);
                return Created($"/api/professor/{professor.Id}", _mapper.Map<ProfessorDto>(professor));
            }

            return BadRequest("O Professor não foi encontrado");
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult<Professor>> PatchProfessor(int id, ProfessorRegistrarDto professorDto)
        {
            // var professorAux = _smartContext.Professores.AsNoTracking().FirstOrDefault(p => p.Id == id);
            var professor = _repository.GetProfessorById(id);

            if (professor == null)
                return BadRequest("O Professor não foi encontrado");

            _mapper.Map(professorDto, professor);

            _repository.Update(professor);
            if (_repository.SaveChanges())
            {
                //return Ok(professor);
                return Created($"/api/professor/{professor.Id}", _mapper.Map<ProfessorDto>(professor));
            }

            return BadRequest("O Professor não foi encontrado");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Professor>> DeleteProfessor(int id)
        {
            //var professor = _smartContext.Professores.AsNoTracking().FirstOrDefault(p => p.Id == id);
            var professor = _repository.GetProfessorById(id);

            if (professor == null)
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