using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
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
        private readonly SmartContext _smartContext;
        private readonly IRepository _irepository;

        //Construtores
        public AlunoController(SmartContext smartContext, IRepository irepository)
        {
            _irepository = irepository;
            _smartContext = smartContext;
        }

        //Metodos
        //utilizando irepository
        // [HttpGet("GetIRepository")]
        // public async Task<ActionResult<List<Aluno>>> GetIRepository()
        // {
        //     // return Ok("Alunos: Marta, Paula, Lucas, Rafa"); //teste
        //     //return Ok(_irepository.GetIRepositoryTeste());
        //     return Ok(_irepository.GetIRepositoryTeste());
        // }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Aluno>>> Get()
        {
            // return Ok("Alunos: Marta, Paula, Lucas, Rafa"); //teste
            return Ok(_smartContext.Alunos);
        }

        //http://localhost:5000/api/aluno/8
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Aluno>> GetById(int id)
        {
            // return Ok("Alunos: Marta, Paula, Lucas, Rafa"); //teste
            var aluno = _smartContext.Alunos.FirstOrDefault(a => a.Id == id);

            if (aluno == null)
            {
                return BadRequest("O Aluno não foi encontrado");
            }
            return Ok(aluno);
        }

        //localhost:5000/api/Aluno/ByName?nome=eNome
        [HttpGet("ByName")]
        public async Task<ActionResult<Aluno>> GetByName(string nome)
        {
            var aluno = _smartContext.Alunos.FirstOrDefault(a => 
                a.Nome.Contains(nome));

            if (aluno == null)
                return BadRequest("O Aluno não foi encontrado");

            return Ok(aluno);
        }

        //localhost:5000/api/Aluno/s?nome=s&sobrenome=s
        [HttpGet("{ByNameSobrenome}")]
        public async Task<ActionResult<Aluno>> GetByNameSobrenome(string nome, string sobrenome)
        {
            var aluno = _smartContext.Alunos.FirstOrDefault(a => 
                a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));

            if (aluno == null)
                return BadRequest("O Aluno não foi encontrado");

            return Ok(aluno);
        }

        [HttpPost]
        public async Task<ActionResult<Aluno>> Post(Aluno aluno)
        {
            _irepository.Add(aluno);
            if (_irepository.SaveChanges())
            {
                return Ok(aluno);
            }

            // _smartContext.Add(aluno);
            // _smartContext.SaveChanges();
            //return Ok(aluno);

            return BadRequest("Aluno não cadastrado");
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Aluno>> Put(int id, Aluno aluno)
        {
            var alunoAux = _smartContext.Alunos
                .AsNoTracking().FirstOrDefault(a => a.Id == id);
            if(alunoAux == null) 
            return BadRequest("Aluno não encontrado");
            
            // _smartContext.Update(aluno);
            // _smartContext.SaveChanges();
            // return Ok(aluno);

            _irepository.Update(aluno);
            if (_irepository.SaveChanges())
            {
                return Ok(aluno);
            }

            return BadRequest("Aluno não cadastrado");
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult<Aluno>> Patch(int id, Aluno aluno)
        {
            var alunoAux = _smartContext.Alunos
                .AsNoTracking().FirstOrDefault(a => a.Id == id);
            if(alunoAux == null) 
            return BadRequest("Aluno não encontrado");

            // _smartContext.Update(aluno);
            // _smartContext.SaveChanges();
            // return Ok(aluno);

            _irepository.Update(aluno);
            if (_irepository.SaveChanges())
            {
                return Ok(aluno);
            }
            return BadRequest("Aluno não encontrado");

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Aluno>> Delete(int id)
        {
            var aluno = _smartContext.Alunos
                .FirstOrDefault(a => a.Id == id);
            if(aluno == null) 
            return BadRequest("Aluno não removido");
            
            // _smartContext.Remove(aluno);
            // _smartContext.SaveChanges();
            // return Ok();

            _irepository.Delete(aluno);
            if (_irepository.SaveChanges())
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