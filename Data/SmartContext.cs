using System;
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
        public DbSet<AlunoCurso> AlunosCursos { get; set; }
        public DbSet<AlunoDisciplina> AlunosDisciplinas { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Professor> Professores { get; set; }    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlunoDisciplina>()
                .HasKey(ad => new {ad.AlunoId, ad.DisciplinaId});

            modelBuilder.Entity<AlunoCurso>()
                .HasKey(ac => new {ac.AlunoId, ac.CursoId});

            modelBuilder.Entity<Professor>()
                .HasData(new List<Professor>(){
                    new Professor(1, 1, "aProfessor", "aSobrenome"),
                    new Professor(2, 2, "bProfessor", "bSobrenome"),
                    new Professor(3, 3, "cProfessor", "cSobrenome"),
                    new Professor(4, 4, "dProfessor", "dSobrenome"),
                    new Professor(5, 5, "eProfessor", "eSobrenome")
                });

            modelBuilder.Entity<Curso>()
                .HasData(new List<Curso>{
                    new Curso(1, "Tecnologia da Informação"),
                    new Curso(2, "Sistemas de Informação"),
                    new Curso(3, "Ciência da Computação")             
                });
            
            modelBuilder.Entity<Disciplina>()
                .HasData(new List<Disciplina>(){
                    new Disciplina(1, "Matemática", 1, 1),
                    new Disciplina(2, "Física", 1, 3),
                    new Disciplina(3, "Quimica", 2, 3),
                    new Disciplina(4, "Geometria", 3, 1),
                    new Disciplina(5, "eDisciplina", 4, 1),
                    new Disciplina(6, "fDisciplina", 4, 2),
                    new Disciplina(7, "gDisciplina", 4, 3),
                    new Disciplina(8, "hDisciplina", 5, 1),
                    new Disciplina(9, "iDisciplina", 5, 2),
                    new Disciplina(10, "mDisciplina", 5, 3)
                });

            modelBuilder.Entity<Aluno>()
                .HasData(new List<Aluno>(){
                    new Aluno(1, 1, "aNomeAluno", "aSobreNomeAluno", "123456789", DateTime.Parse("2008-05-01")),
                    new Aluno(2, 2, "bNomeAluno", "bSobreNomeAluno", "223456789", DateTime.Parse("2009-05-01")),
                    new Aluno(3, 3, "cNomeAluno", "cSobreNomeAluno", "323456789", DateTime.Parse("2010-05-01")),
                    new Aluno(4, 4, "dNomeAluno", "dSobreNomeAluno", "423456789", DateTime.Parse("2011-05-01")),
                    new Aluno(5, 5, "eNomeAluno", "eSobreNomeAluno", "523456789", DateTime.Parse("2012-05-01")),
                    new Aluno(6, 6, "fNomeAluno", "fSobreNomeAluno", "623456789", DateTime.Parse("2013-05-01")),
                    new Aluno(7, 7, "gNomeAluno", "gSobreNomeAluno", "723456789", DateTime.Parse("2014-05-01")),
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