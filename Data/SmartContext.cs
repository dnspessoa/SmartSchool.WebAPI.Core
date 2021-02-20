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
                    new Professor(2, "aProfessor"),
                    new Professor(3, "aProfessor"),
                    new Professor(4, "aProfessor")
                });
            
            modelBuilder.Entity<Disciplina>()
                .HasData(new List<Disciplina>(){
                    new Disciplina(1, "Matemática", 1),
                    new Disciplina(2, "Física", 2),
                    new Disciplina(3, "Quimica", 3),
                    new Disciplina(4, "Geometria", 4)
                });

            modelBuilder.Entity<Aluno>()
                .HasData(new List<Aluno>(){
                    new Aluno(1, "aNomeAluno", "aSobreNomeAluno", "123456789"),
                    new Aluno(2, "bNomeAluno", "bSobreNomeAluno", "123456789"),
                    new Aluno(3, "cNomeAluno", "cSobreNomeAluno", "123456789"),
                    new Aluno(4, "dNomeAluno", "dSobreNomeAluno", "123456789")
                });
        }    
    }
}