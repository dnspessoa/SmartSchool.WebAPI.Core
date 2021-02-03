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

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // return Ok("Alunos: Marta, Paula, Lucas, Rafa"); //teste
            var alunos = Alunos.FirstOrDefault(a => a.Id == a.Id);

            return Ok(alunos);
        }
    }
}