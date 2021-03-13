using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public class SmartContext : DbContext
    {
        public SmartContext(DbContextOptions<SmartContext> options)
            : base(options)
        {
        }

        public DbSet<Aluno> Alunos { get; set; }       
        public DbSet<Professor> Professores { get; set; }       
        public DbSet<Disciplina> Disciplinas { get; set; }       
        public DbSet<AlunoDisciplina> AlunosDisciplinas { get; set; }       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlunoDisciplina>()
                .HasKey(ad => new {ad.AlunoId, ad.DisciplinaId});

            modelBuilder.Entity<Professor>()
                .HasData(new List<Professor>(){
                    new Professor(1, "aProfessor"),
                    new Professor(2, "bProfessor"),
                    new Professor(3, "cProfessor"),
                    new Professor(4, "dProfessor"),
                    new Professor(5, "eProfessor")
                });
            
            modelBuilder.Entity<Disciplina>()
                .HasData(new List<Disciplina>(){
                    new Disciplina(1, "Matemática", 1),
                    new Disciplina(2, "Física", 2),
                    new Disciplina(3, "Quimica", 3),
                    new Disciplina(4, "Geometria", 4),
                    new Disciplina(5, "eDiciplina", 1),
                    new Disciplina(6, "fDiciplina", 2),
                    new Disciplina(7, "gDiciplina", 3),
                    new Disciplina(8, "hDiciplina", 4),
                    new Disciplina(9, "iDiciplina", 3),
                    new Disciplina(10, "mDiciplina", 4),
                });

            modelBuilder.Entity<Aluno>()
                .HasData(new List<Aluno>(){
                    new Aluno(1, "aNomeAluno", "aSobreNomeAluno", "123456789"),
                    new Aluno(2, "bNomeAluno", "bSobreNomeAluno", "223456789"),
                    new Aluno(3, "cNomeAluno", "cSobreNomeAluno", "323456789"),
                    new Aluno(4, "dNomeAluno", "dSobreNomeAluno", "423456789"),
                    new Aluno(5, "eNomeAluno", "eSobreNomeAluno", "523456789"),
                    new Aluno(6, "fNomeAluno", "fSobreNomeAluno", "623456789"),
                    new Aluno(7, "gNomeAluno", "gSobreNomeAluno", "723456789"),
                });

            modelBuilder.Entity<AlunoDisciplina>()
                .HasData(new List<AlunoDisciplina>(){
                    new AlunoDisciplina() {AlunoId = 1, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 1, DisciplinaId = 4 },
                    new AlunoDisciplina() {AlunoId = 1, DisciplinaId = 5 },
                    new AlunoDisciplina() {AlunoId = 2, DisciplinaId = 1 },
                    new AlunoDisciplina() {AlunoId = 2, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 2, DisciplinaId = 5 },
                    new AlunoDisciplina() {AlunoId = 3, DisciplinaId = 1 },
                    new AlunoDisciplina() {AlunoId = 3, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 3, DisciplinaId = 3 },
                    new AlunoDisciplina() {AlunoId = 4, DisciplinaId = 1 },
                    new AlunoDisciplina() {AlunoId = 4, DisciplinaId = 4 },
                    new AlunoDisciplina() {AlunoId = 4, DisciplinaId = 5 },
                    new AlunoDisciplina() {AlunoId = 5, DisciplinaId = 4 },
                    new AlunoDisciplina() {AlunoId = 5, DisciplinaId = 5 },
                    new AlunoDisciplina() {AlunoId = 6, DisciplinaId = 1 },
                    new AlunoDisciplina() {AlunoId = 6, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 6, DisciplinaId = 3 },
                    new AlunoDisciplina() {AlunoId = 6, DisciplinaId = 4 },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 1 },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 2 },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 3 },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 4 },
                    new AlunoDisciplina() {AlunoId = 7, DisciplinaId = 5 }
                });
                
        }    
    }
}