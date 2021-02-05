using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>()
        {
            new Aluno() { Id = 1, Nome = "aNome", Sobrenome = "aSobrenome", Telefone = "12345678912" },
            new Aluno() { Id = 2, Nome = "bNome", Sobrenome = "bSobrenome", Telefone = "32345678912" },                
            new Aluno() { Id = 3, Nome = "cNome", Sobrenome = "cSobrenome", Telefone = "62345678912" },                
            new Aluno() { Id = 4, Nome = "dNome", Sobrenome = "dSobrenome", Telefone = "92345678912" }                 
        };
        public AlunoController() { }

        [HttpGet]
        public IActionResult GetAction()
        {
            // return Ok("Alunos: Marta, Paula, Lucas, Rafa"); //teste
            return Ok(Alunos);
        }

        //http://localhost:5000/api/aluno/8
        // [HttpGet("{id:int}")]
        // public IActionResult GetById(int id)
        // {
        //     // return Ok("Alunos: Marta, Paula, Lucas, Rafa"); //teste
        //     var aluno = Alunos.FirstOrDefault(a => a.Id == id);

        //     if(aluno == null) 
        //     {
        //         return BadRequest("O Aluno não foi encontrado");
        //     }
        //     return Ok(aluno);
        // }

        // [HttpGet("{nome}")]
        // public IActionResult GetByName(string nome)
        // {
        //     var aluno = Alunos.FirstOrDefault(a => a.Nome.Contains(nome));

        //     if(nome == null)
        //     return BadRequest("O Aluno não foi encontrado");

        //     return Ok(aluno);
        // }
        
        //http://localhost:5000/api/aluno/byId?id=1
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            // return Ok("Alunos: Marta, Paula, Lucas, Rafa"); //teste
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);

            if(aluno == null) 
            {
                return BadRequest("O Aluno não foi encontrado");
            }
            return Ok(aluno);
        }

        //http://localhost:5000/api/aluno/byName?nome=aNome&sobrenome=aSobrenome
        [HttpGet("ByName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = Alunos.FirstOrDefault(a => 
                a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));

            if(nome == null)
            return BadRequest("O Aluno não foi encontrado");

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {

            return Ok(aluno);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }

        
    }
}