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
    //Endpoint => URL
    //http://localhost:5000
    //https://localhost:5001 // atual
    //https://meuapp.azurewebsites.net/
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        //Seta banco
        // public List<Aluno> Alunos = new List<Aluno>()
        // {
        //     new Aluno() { Id = 1, Nome = "aNome", Sobrenome = "aSobrenome", Telefone = "12345678912" },
        //     new Aluno() { Id = 2, Nome = "bNome", Sobrenome = "bSobrenome", Telefone = "32345678912" },
        //     new Aluno() { Id = 3, Nome = "cNome", Sobrenome = "cSobrenome", Telefone = "62345678912" },
        //     new Aluno() { Id = 4, Nome = "dNome", Sobrenome = "dSobrenome", Telefone = "92345678912" }
        // };

        //Variáveis globais
        // private readonly SmartContext _smartContext;
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        //Construtores
        public AlunoController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            // _smartContext = smartContext;
        }

        //Metodos
        //utilizando repository
        // [HttpGet("GetIRepository")]
        // public async Task<ActionResult<List<Aluno>>> GetIRepository()
        // {
        //     // return Ok("Alunos: Marta, Paula, Lucas, Rafa"); //teste
        //     //return Ok(repository.GetIRepositoryTeste());
        //     return Ok(repository.GetIRepositoryTeste());
        // }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Aluno>>> GetAllAlunos()
        {
            var alunos = _repository.GetAllAlunos(true);
            
            // return Ok("Alunos: Marta, Paula, Lucas, Rafa"); //teste
            //return Ok(_smartContext.Alunos);

            //Usando Dto DataTransObject
            // var alunosDtos = new List<AlunoDto>();
            // foreach (var aluno in alunos)
            // {
            //     alunosDtos.Add(new AlunoDto(){
            //         Id = aluno.Id,
            //         Matricula = aluno.Matricula,
            //         Nome = $"{aluno.Nome} {aluno.Sobrenome}",
            //         Telefone = aluno.Telefone,
            //         DataNasc = aluno.DataNasc,
            //         DataInicio = aluno.DataInicio, 
            //         asAtivo = aluno.asAtivo
            //     });
            // }
            // return Ok(alunosDtos);

            return Ok(_mapper.Map<IEnumerable<AlunoDto>>(alunos));
        }

        //http://localhost:5000/api/aluno/8
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Aluno>> GetAlunoById(int id, bool asIncludeDisciplina)
        {
            // var aluno = _smartContext.Alunos.FirstOrDefault(a => a.Id == id);

            var aluno = _repository.GetAlunoById(id, asIncludeDisciplina);

            if (aluno == null)
            {
                return BadRequest("O Aluno não foi encontrado");
            }
            
            var alunoDto = _mapper.Map<AlunoDto>(aluno);

            // return Ok("Alunos: Marta, Paula, Lucas, Rafa"); //teste
            //return Ok(aluno);

            return Ok(alunoDto);
        }

        //teste recuperar um obj aluno
        [HttpGet("getRegister")]
        public IActionResult GetAction()
        {
            return Ok(new AlunoRegistrarDto());
        }

        //localhost:5000/api/Aluno/ByName?nome=eNome
        // [HttpGet("ByName")]
        // public async Task<ActionResult<Aluno>> ByName(string nome)
        // {
        //     var aluno = _smartContext.Alunos.FirstOrDefault(a => 
        //         a.Nome.Contains(nome));

        //     if (aluno == null)
        //         return BadRequest("O Aluno não foi encontrado");

        //     return Ok(aluno);
        // }

        //localhost:5000/api/Aluno/s?nome=s&sobrenome=s
        // [HttpGet("{ByNameSobrenome}")]
        // public async Task<ActionResult<Aluno>> AlunoGetByNameSobrenome(string nome, string sobrenome)
        // {
        //     var aluno = _smartContext.Alunos.FirstOrDefault(a => 
        //         a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));

        //     if (aluno == null)
        //         return BadRequest("O Aluno não foi encontrado");

        //     return Ok(aluno);
        // }

        [HttpPost]
        public async Task<ActionResult<Aluno>> PostAluno(AlunoRegistrarDto alunoDto)
        {
            //Pega alunoDto e transforma em aluno
            var aluno = _mapper.Map<Aluno>(alunoDto);

            _repository.Add(aluno);
            // if (_repository.SaveChanges())
            // {
            //     return Ok(aluno);
            // }

            if (_repository.SaveChanges())
            {
                return Created($"/api/aluno/{alunoDto.Id}", _mapper.Map<AlunoDto>(aluno));
            }

            // _smartContext.Add(aluno);
            // _smartContext.SaveChanges();
            //return Ok(aluno);

            return BadRequest("Aluno não cadastrado");
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Aluno>> PutAluno(int id, AlunoRegistrarDto alunoDto)
        {
            //var alunoAux = _smartContext.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            var aluno = _repository.GetAlunoById(id);
                
            if(aluno == null) 
            return BadRequest("Aluno não encontrado");

            _mapper.Map(alunoDto, aluno);
            
            // _smartContext.Update(aluno);
            // _smartContext.SaveChanges();
            // return Ok(aluno);

            _repository.Update(aluno);
            if (_repository.SaveChanges())
            {
                //return Ok(aluno);
                return Created($"/api/aluno/{alunoDto.Id}", _mapper.Map<AlunoDto>(aluno));
            }

            return BadRequest("Aluno não cadastrado");
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult<Aluno>> PatchAluno(int id, AlunoRegistrarDto alunoDto)
        {
            //var alunoAux = _smartContext.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            var aluno = _repository.GetAlunoById(id);
                
            if(aluno == null) 
            return BadRequest("Aluno não encontrado");

            _mapper.Map(alunoDto, aluno);

            // _smartContext.Update(aluno);
            // _smartContext.SaveChanges();
            // return Ok(aluno);

            _repository.Update(aluno);
            if (_repository.SaveChanges())
            {
                //return Ok(aluno);
                return Created($"/api/aluno/{alunoDto.Id}", _mapper.Map<AlunoDto>(aluno));
            }
            return BadRequest("Aluno não encontrado");

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Aluno>> DeleteAluno(int id)
        {
            //var aluno = _smartContext.Alunos.FirstOrDefault(a => a.Id == id);
            var aluno = _repository.GetAlunoById(id);
                
            if(aluno == null) 
            return BadRequest("Aluno não removido");
            
            // _smartContext.Remove(aluno);
            // _smartContext.SaveChanges();
            // return Ok();

            _repository.Delete(aluno);
            if (_repository.SaveChanges())
            {
                return Ok(aluno);
            }
            return BadRequest("Aluno não removido");
        }

        //http://localhost:5000/api/aluno/byId?id=1
        // [HttpGet("byId/{id}")]
        // public async Task<ActionResult> GetById(int id)
        // {
        //     // return Ok("Alunos: Marta, Paula, Lucas, Rafa"); //teste
        //     var aluno = Alunos.FirstOrDefault(a => a.Id == id);

        //     if(aluno == null) 
        //     {
        //         return BadRequest("O Aluno não foi encontrado");
        //     }
        //     return Ok(aluno);
        // }

        //http://localhost:5000/api/aluno/byName?nome=aNome&sobrenome=aSobrenome
        // [HttpGet("ByName")]
        // public IActionResult GetByName(string nome, string sobrenome)
        // {
        //     var aluno = Alunos.FirstOrDefault(a => 
        //         a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));

        //     if(nome == null)
        //     return BadRequest("O Aluno não foi encontrado");

        //     return Ok(aluno);
        // }
    }
}