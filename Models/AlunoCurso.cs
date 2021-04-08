using System;

namespace SmartSchool.WebAPI.Models
{
    public class AlunoCurso
    {
        public AlunoCurso() { }

        public AlunoCurso(int alunoId, int CursoId)
        {
            this.AlunoId = alunoId;
            this.CursoId = CursoId;
        }

        public DateTime DataInicio { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; }

        //Aluno
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }

        //Curso
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
    }
}