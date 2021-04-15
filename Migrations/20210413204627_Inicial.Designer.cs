﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartSchool.WebAPI.Data;

namespace SmartSchool.WebAPI.Migrations
{
    [DbContext(typeof(SmartContext))]
    [Migration("20210413204627_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("SmartSchool.WebAPI.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataNasc")
                        .HasColumnType("datetime2");

                    b.Property<int>("Matricula")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("asAtivo")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Alunos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataInicio = new DateTime(2021, 4, 13, 17, 46, 27, 186, DateTimeKind.Local).AddTicks(6290),
                            DataNasc = new DateTime(2008, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 1,
                            Nome = "aNomeAluno",
                            Sobrenome = "aSobreNomeAluno",
                            Telefone = "123456789",
                            asAtivo = true
                        },
                        new
                        {
                            Id = 2,
                            DataInicio = new DateTime(2021, 4, 13, 17, 46, 27, 186, DateTimeKind.Local).AddTicks(7806),
                            DataNasc = new DateTime(2009, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 2,
                            Nome = "bNomeAluno",
                            Sobrenome = "bSobreNomeAluno",
                            Telefone = "223456789",
                            asAtivo = true
                        },
                        new
                        {
                            Id = 3,
                            DataInicio = new DateTime(2021, 4, 13, 17, 46, 27, 186, DateTimeKind.Local).AddTicks(7819),
                            DataNasc = new DateTime(2010, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 3,
                            Nome = "cNomeAluno",
                            Sobrenome = "cSobreNomeAluno",
                            Telefone = "323456789",
                            asAtivo = true
                        },
                        new
                        {
                            Id = 4,
                            DataInicio = new DateTime(2021, 4, 13, 17, 46, 27, 186, DateTimeKind.Local).AddTicks(7824),
                            DataNasc = new DateTime(2011, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 4,
                            Nome = "dNomeAluno",
                            Sobrenome = "dSobreNomeAluno",
                            Telefone = "423456789",
                            asAtivo = true
                        },
                        new
                        {
                            Id = 5,
                            DataInicio = new DateTime(2021, 4, 13, 17, 46, 27, 186, DateTimeKind.Local).AddTicks(7831),
                            DataNasc = new DateTime(2012, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 5,
                            Nome = "eNomeAluno",
                            Sobrenome = "eSobreNomeAluno",
                            Telefone = "523456789",
                            asAtivo = true
                        },
                        new
                        {
                            Id = 6,
                            DataInicio = new DateTime(2021, 4, 13, 17, 46, 27, 186, DateTimeKind.Local).AddTicks(7840),
                            DataNasc = new DateTime(2013, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 6,
                            Nome = "fNomeAluno",
                            Sobrenome = "fSobreNomeAluno",
                            Telefone = "623456789",
                            asAtivo = true
                        },
                        new
                        {
                            Id = 7,
                            DataInicio = new DateTime(2021, 4, 13, 17, 46, 27, 186, DateTimeKind.Local).AddTicks(7845),
                            DataNasc = new DateTime(2014, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 7,
                            Nome = "gNomeAluno",
                            Sobrenome = "gSobreNomeAluno",
                            Telefone = "723456789",
                            asAtivo = true
                        });
                });

            modelBuilder.Entity("SmartSchool.WebAPI.Models.AlunoCurso", b =>
                {
                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<int>("CursoId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.HasKey("AlunoId", "CursoId");

                    b.HasIndex("CursoId");

                    b.ToTable("AlunosCursos");
                });

            modelBuilder.Entity("SmartSchool.WebAPI.Models.AlunoDisciplina", b =>
                {
                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<int>("DisciplinaId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Nota")
                        .HasColumnType("int");

                    b.HasKey("AlunoId", "DisciplinaId");

                    b.HasIndex("DisciplinaId");

                    b.ToTable("AlunosDisciplinas");

                    b.HasData(
                        new
                        {
                            AlunoId = 1,
                            DisciplinaId = 2,
                            DataInicio = new DateTime(2021, 4, 13, 17, 46, 27, 187, DateTimeKind.Local).AddTicks(287)
                        },
                        new
                        {
                            AlunoId = 1,
                            DisciplinaId = 4,
                            DataInicio = new DateTime(2021, 4, 13, 17, 46, 27, 187, DateTimeKind.Local).AddTicks(645)
                        },
                        new
                        {
                            AlunoId = 1,
                            DisciplinaId = 5,
                            DataInicio = new DateTime(2021, 4, 13, 17, 46, 27, 187, DateTimeKind.Local).AddTicks(649)
                        },
                        new
                        {
                            AlunoId = 2,
                            DisciplinaId = 1,
                            DataInicio = new DateTime(2021, 4, 13, 17, 46, 27, 187, DateTimeKind.Local).AddTicks(651)
                        },
                        new
                        {
                            AlunoId = 2,
                            DisciplinaId = 2,
                            DataInicio = new DateTime(2021, 4, 13, 17, 46, 27, 187, DateTimeKind.Local).AddTicks(652)
                        },
                        new
                        {
                            AlunoId = 2,
                            DisciplinaId = 5,
                            DataInicio = new DateTime(2021, 4, 13, 17, 46, 27, 187, DateTimeKind.Local).AddTicks(656)
                        },
                        new
                        {
                            AlunoId = 3,
                            DisciplinaId = 1,
                            DataInicio = new DateTime(2021, 4, 13, 17, 46, 27, 187, DateTimeKind.Local).AddTicks(657)
                        },
                        new
                        {
                            AlunoId = 3,
                            DisciplinaId = 2,
                            DataInicio = new DateTime(2021, 4, 13, 17, 46, 27, 187, DateTimeKind.Local).AddTicks(659)
                        },
                        new
                        {
                            AlunoId = 3,
                            DisciplinaId = 3,
                            DataInicio = new DateTime(2021, 4, 13, 17, 46, 27, 187, DateTimeKind.Local).AddTicks(660)
                        },
                        new
                        {
                            AlunoId = 4,
                            DisciplinaId = 1,
                            DataInicio = new DateTime(2021, 4, 13, 17, 46, 27, 187, DateTimeKind.Local).AddTicks(662)
                        },
                        new
                        {
                            AlunoId = 4,
                            DisciplinaId = 4,
                            DataInicio = new DateTime(2021, 4, 13, 17, 46, 27, 187, DateTimeKind.Local).AddTicks(663)
                        },
                        new
                        {
                            AlunoId = 4,
                            DisciplinaId = 5,
                            DataInicio = new DateTime(2021, 4, 13, 17, 46, 27, 187, DateTimeKind.Local).AddTicks(665)
                        },
                        new
                        {
                            AlunoId = 5,
                            DisciplinaId = 4,
                            DataInicio = new DateTime(2021, 4, 13, 17, 46, 27, 187, DateTimeKind.Local).AddTicks(666)
                        },
                        new
                        {
                            AlunoId = 5,
                            DisciplinaId = 5,
                            DataInicio = new DateTime(2021, 4, 13, 17, 46, 27, 187, DateTimeKind.Local).AddTicks(667)
                        },
                        new
                        {
                            AlunoId = 6,
                            DisciplinaId = 1,
                            DataInicio = new DateTime(2021, 4, 13, 17, 46, 27, 187, DateTimeKind.Local).AddTicks(668)
                        },
                        new
                        {
                            AlunoId = 6,
                            DisciplinaId = 2,
                            DataInicio = new DateTime(2021, 4, 13, 17, 46, 27, 187, DateTimeKind.Local).AddTicks(670)
                        },
                        new
                        {
                            AlunoId = 6,
                            DisciplinaId = 3,
                            DataInicio = new DateTime(2021, 4, 13, 17, 46, 27, 187, DateTimeKind.Local).AddTicks(672)
                        },
                        new
                        {
                            AlunoId = 6,
                            DisciplinaId = 4,
                            DataInicio = new DateTime(2021, 4, 13, 17, 46, 27, 187, DateTimeKind.Local).AddTicks(674)
                        },
                        new
                        {
                            AlunoId = 7,
                            DisciplinaId = 1,
                            DataInicio = new DateTime(2021, 4, 13, 17, 46, 27, 187, DateTimeKind.Local).AddTicks(675)
                        },
                        new
                        {
                            AlunoId = 7,
                            DisciplinaId = 2,
                            DataInicio = new DateTime(2021, 4, 13, 17, 46, 27, 187, DateTimeKind.Local).AddTicks(676)
                        },
                        new
                        {
                            AlunoId = 7,
                            DisciplinaId = 3,
                            DataInicio = new DateTime(2021, 4, 13, 17, 46, 27, 187, DateTimeKind.Local).AddTicks(744)
                        },
                        new
                        {
                            AlunoId = 7,
                            DisciplinaId = 4,
                            DataInicio = new DateTime(2021, 4, 13, 17, 46, 27, 187, DateTimeKind.Local).AddTicks(746)
                        },
                        new
                        {
                            AlunoId = 7,
                            DisciplinaId = 5,
                            DataInicio = new DateTime(2021, 4, 13, 17, 46, 27, 187, DateTimeKind.Local).AddTicks(748)
                        });
                });

            modelBuilder.Entity("SmartSchool.WebAPI.Models.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cursos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Tecnologia da Informação"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Sistemas de Informação"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Ciência da Computação"
                        });
                });

            modelBuilder.Entity("SmartSchool.WebAPI.Models.Disciplina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CargaHoraria")
                        .HasColumnType("int");

                    b.Property<int>("CursoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PrerequisitoId")
                        .HasColumnType("int");

                    b.Property<int>("ProfessorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.HasIndex("PrerequisitoId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Disciplinas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CargaHoraria = 0,
                            CursoId = 1,
                            Nome = "Matemática",
                            ProfessorId = 1
                        },
                        new
                        {
                            Id = 2,
                            CargaHoraria = 0,
                            CursoId = 3,
                            Nome = "Física",
                            ProfessorId = 1
                        },
                        new
                        {
                            Id = 3,
                            CargaHoraria = 0,
                            CursoId = 3,
                            Nome = "Quimica",
                            ProfessorId = 2
                        },
                        new
                        {
                            Id = 4,
                            CargaHoraria = 0,
                            CursoId = 1,
                            Nome = "Geometria",
                            ProfessorId = 3
                        },
                        new
                        {
                            Id = 5,
                            CargaHoraria = 0,
                            CursoId = 1,
                            Nome = "eDisciplina",
                            ProfessorId = 4
                        },
                        new
                        {
                            Id = 6,
                            CargaHoraria = 0,
                            CursoId = 2,
                            Nome = "fDisciplina",
                            ProfessorId = 4
                        },
                        new
                        {
                            Id = 7,
                            CargaHoraria = 0,
                            CursoId = 3,
                            Nome = "gDisciplina",
                            ProfessorId = 4
                        },
                        new
                        {
                            Id = 8,
                            CargaHoraria = 0,
                            CursoId = 1,
                            Nome = "hDisciplina",
                            ProfessorId = 5
                        },
                        new
                        {
                            Id = 9,
                            CargaHoraria = 0,
                            CursoId = 2,
                            Nome = "iDisciplina",
                            ProfessorId = 5
                        },
                        new
                        {
                            Id = 10,
                            CargaHoraria = 0,
                            CursoId = 3,
                            Nome = "mDisciplina",
                            ProfessorId = 5
                        });
                });

            modelBuilder.Entity("SmartSchool.WebAPI.Models.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Registro")
                        .HasColumnType("int");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("asAtivo")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Professores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataInicio = new DateTime(2021, 4, 13, 17, 46, 27, 176, DateTimeKind.Local).AddTicks(9482),
                            Nome = "aProfessor",
                            Registro = 1,
                            Sobrenome = "aSobrenome",
                            asAtivo = true
                        },
                        new
                        {
                            Id = 2,
                            DataInicio = new DateTime(2021, 4, 13, 17, 46, 27, 177, DateTimeKind.Local).AddTicks(7230),
                            Nome = "bProfessor",
                            Registro = 2,
                            Sobrenome = "bSobrenome",
                            asAtivo = true
                        },
                        new
                        {
                            Id = 3,
                            DataInicio = new DateTime(2021, 4, 13, 17, 46, 27, 177, DateTimeKind.Local).AddTicks(7243),
                            Nome = "cProfessor",
                            Registro = 3,
                            Sobrenome = "cSobrenome",
                            asAtivo = true
                        },
                        new
                        {
                            Id = 4,
                            DataInicio = new DateTime(2021, 4, 13, 17, 46, 27, 177, DateTimeKind.Local).AddTicks(7244),
                            Nome = "dProfessor",
                            Registro = 4,
                            Sobrenome = "dSobrenome",
                            asAtivo = true
                        },
                        new
                        {
                            Id = 5,
                            DataInicio = new DateTime(2021, 4, 13, 17, 46, 27, 177, DateTimeKind.Local).AddTicks(7246),
                            Nome = "eProfessor",
                            Registro = 5,
                            Sobrenome = "eSobrenome",
                            asAtivo = true
                        });
                });

            modelBuilder.Entity("SmartSchool.WebAPI.Models.AlunoCurso", b =>
                {
                    b.HasOne("SmartSchool.WebAPI.Models.Aluno", "Aluno")
                        .WithMany()
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartSchool.WebAPI.Models.Curso", "Curso")
                        .WithMany()
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Curso");
                });

            modelBuilder.Entity("SmartSchool.WebAPI.Models.AlunoDisciplina", b =>
                {
                    b.HasOne("SmartSchool.WebAPI.Models.Aluno", "Aluno")
                        .WithMany("AlunosDisciplinas")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartSchool.WebAPI.Models.Disciplina", "Disciplina")
                        .WithMany("AlunosDisciplinas")
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Disciplina");
                });

            modelBuilder.Entity("SmartSchool.WebAPI.Models.Disciplina", b =>
                {
                    b.HasOne("SmartSchool.WebAPI.Models.Curso", "Curso")
                        .WithMany("Disciplinas")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartSchool.WebAPI.Models.Disciplina", "Prerequisito")
                        .WithMany()
                        .HasForeignKey("PrerequisitoId");

                    b.HasOne("SmartSchool.WebAPI.Models.Professor", "Professor")
                        .WithMany("Disciplinas")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curso");

                    b.Navigation("Prerequisito");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("SmartSchool.WebAPI.Models.Aluno", b =>
                {
                    b.Navigation("AlunosDisciplinas");
                });

            modelBuilder.Entity("SmartSchool.WebAPI.Models.Curso", b =>
                {
                    b.Navigation("Disciplinas");
                });

            modelBuilder.Entity("SmartSchool.WebAPI.Models.Disciplina", b =>
                {
                    b.Navigation("AlunosDisciplinas");
                });

            modelBuilder.Entity("SmartSchool.WebAPI.Models.Professor", b =>
                {
                    b.Navigation("Disciplinas");
                });
#pragma warning restore 612, 618
        }
    }
}