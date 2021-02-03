using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        public List<Professor> Professores = new List<Professor>(){
            
            new Professor(){Id = 1, Nome = "aNome" },
            new Professor(){Id = 2, Nome = "bNome" },
            new Professor(){Id = 3, Nome = "cNome" },
            new Professor(){Id = 4, Nome = "dNome" }
        };

        public ProfessorController() { }

        [HttpGet]
        public IActionResult GetAction()
        {
            // return Ok("Professor: Denis, Cleber, David, Elio");
            return Ok(Professores);
        }
        
    }
}