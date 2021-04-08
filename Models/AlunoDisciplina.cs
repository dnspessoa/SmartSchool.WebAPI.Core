using System;

namespace SmartSchool.WebAPI.Models
{
    public class AlunoDisciplina
    {
        public AlunoDisciplina() { }

        public AlunoDisciplina(int alunoId, int disciplinaId)
        {
            this.AlunoId = alunoId;
            this.DisciplinaId = disciplinaId;
        }

        public DateTime DataInicio { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; }
        public int? Nota { get; set; } = null;

        //Aluno
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }

        //Disciplina
        public int DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }
    }
}