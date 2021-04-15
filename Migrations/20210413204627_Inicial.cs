using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSchool.WebAPI.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matricula = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNasc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: true),
                    asAtivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Registro = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: true),
                    asAtivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlunosCursos",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    CursoId = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosCursos", x => new { x.AlunoId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_AlunosCursos_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosCursos_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CargaHoraria = table.Column<int>(type: "int", nullable: false),
                    PrerequisitoId = table.Column<int>(type: "int", nullable: true),
                    ProfessorId = table.Column<int>(type: "int", nullable: false),
                    CursoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Disciplinas_PrerequisitoId",
                        column: x => x.PrerequisitoId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunosDisciplinas",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    DisciplinaId = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Nota = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosDisciplinas", x => new { x.AlunoId, x.DisciplinaId });
                    table.ForeignKey(
                        name: "FK_AlunosDisciplinas_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosDisciplinas_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "DataFim", "DataInicio", "DataNasc", "Matricula", "Nome", "Sobrenome", "Telefone", "asAtivo" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2021, 4, 13, 17, 46, 27, 186, DateTimeKind.Local).AddTicks(6290), new DateTime(2008, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "aNomeAluno", "aSobreNomeAluno", "123456789", true },
                    { 2, null, new DateTime(2021, 4, 13, 17, 46, 27, 186, DateTimeKind.Local).AddTicks(7806), new DateTime(2009, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "bNomeAluno", "bSobreNomeAluno", "223456789", true },
                    { 3, null, new DateTime(2021, 4, 13, 17, 46, 27, 186, DateTimeKind.Local).AddTicks(7819), new DateTime(2010, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "cNomeAluno", "cSobreNomeAluno", "323456789", true },
                    { 4, null, new DateTime(2021, 4, 13, 17, 46, 27, 186, DateTimeKind.Local).AddTicks(7824), new DateTime(2011, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "dNomeAluno", "dSobreNomeAluno", "423456789", true },
                    { 5, null, new DateTime(2021, 4, 13, 17, 46, 27, 186, DateTimeKind.Local).AddTicks(7831), new DateTime(2012, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "eNomeAluno", "eSobreNomeAluno", "523456789", true },
                    { 6, null, new DateTime(2021, 4, 13, 17, 46, 27, 186, DateTimeKind.Local).AddTicks(7840), new DateTime(2013, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "fNomeAluno", "fSobreNomeAluno", "623456789", true },
                    { 7, null, new DateTime(2021, 4, 13, 17, 46, 27, 186, DateTimeKind.Local).AddTicks(7845), new DateTime(2014, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "gNomeAluno", "gSobreNomeAluno", "723456789", true }
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Tecnologia da Informação" },
                    { 2, "Sistemas de Informação" },
                    { 3, "Ciência da Computação" }
                });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "DataFim", "DataInicio", "Nome", "Registro", "Sobrenome", "Telefone", "asAtivo" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2021, 4, 13, 17, 46, 27, 176, DateTimeKind.Local).AddTicks(9482), "aProfessor", 1, "aSobrenome", null, true },
                    { 2, null, new DateTime(2021, 4, 13, 17, 46, 27, 177, DateTimeKind.Local).AddTicks(7230), "bProfessor", 2, "bSobrenome", null, true },
                    { 3, null, new DateTime(2021, 4, 13, 17, 46, 27, 177, DateTimeKind.Local).AddTicks(7243), "cProfessor", 3, "cSobrenome", null, true },
                    { 4, null, new DateTime(2021, 4, 13, 17, 46, 27, 177, DateTimeKind.Local).AddTicks(7244), "dProfessor", 4, "dSobrenome", null, true },
                    { 5, null, new DateTime(2021, 4, 13, 17, 46, 27, 177, DateTimeKind.Local).AddTicks(7246), "eProfessor", 5, "eSobrenome", null, true }
                });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[,]
                {
                    { 1, 0, 1, "Matemática", null, 1 },
                    { 2, 0, 3, "Física", null, 1 },
                    { 3, 0, 3, "Quimica", null, 2 },
                    { 4, 0, 1, "Geometria", null, 3 },
                    { 5, 0, 1, "eDisciplina", null, 4 },
                    { 6, 0, 2, "fDisciplina", null, 4 },
                    { 7, 0, 3, "gDisciplina", null, 4 },
                    { 8, 0, 1, "hDisciplina", null, 5 },
                    { 9, 0, 2, "iDisciplina", null, 5 },
                    { 10, 0, 3, "mDisciplina", null, 5 }
                });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[,]
                {
                    { 2, 1, null, new DateTime(2021, 4, 13, 17, 46, 27, 187, DateTimeKind.Local).AddTicks(651), null },
                    { 4, 5, null, new DateTime(2021, 4, 13, 17, 46, 27, 187, DateTimeKind.Local).AddTicks(665), null },
                    { 2, 5, null, new DateTime(2021, 4, 13, 17, 46, 27, 187, DateTimeKind.Local).AddTicks(656), null },
                    { 1, 5, null, new DateTime(2021, 4, 13, 17, 46, 27, 187, DateTimeKind.Local).AddTicks(649), null },
                    { 7, 4, null, new DateTime(2021, 4, 13, 17, 46, 27, 187, DateTimeKind.Local).AddTicks(746), null },
                    { 6, 4, null, new DateTime(2021, 4, 13, 17, 46, 27, 187, DateTimeKind.Local).AddTicks(674), null },
                    { 5, 4, null, new DateTime(2021, 4, 13, 17, 46, 27, 187, DateTimeKind.Local).AddTicks(666), null },
                    { 4, 4, null, new DateTime(2021, 4, 13, 17, 46, 27, 187, DateTimeKind.Local).AddTicks(663), null },
                    { 1, 4, null, new DateTime(2021, 4, 13, 17, 46, 27, 187, DateTimeKind.Local).AddTicks(645), null },
                    { 7, 3, null, new DateTime(2021, 4, 13, 17, 46, 27, 187, DateTimeKind.Local).AddTicks(744), null },
                    { 5, 5, null, new DateTime(2021, 4, 13, 17, 46, 27, 187, DateTimeKind.Local).AddTicks(667), null },
                    { 6, 3, null, new DateTime(2021, 4, 13, 17, 46, 27, 187, DateTimeKind.Local).AddTicks(672), null },
                    { 7, 2, null, new DateTime(2021, 4, 13, 17, 46, 27, 187, DateTimeKind.Local).AddTicks(676), null },
                    { 6, 2, null, new DateTime(2021, 4, 13, 17, 46, 27, 187, DateTimeKind.Local).AddTicks(670), null },
                    { 3, 2, null, new DateTime(2021, 4, 13, 17, 46, 27, 187, DateTimeKind.Local).AddTicks(659), null },
                    { 2, 2, null, new DateTime(2021, 4, 13, 17, 46, 27, 187, DateTimeKind.Local).AddTicks(652), null },
                    { 1, 2, null, new DateTime(2021, 4, 13, 17, 46, 27, 187, DateTimeKind.Local).AddTicks(287), null },
                    { 7, 1, null, new DateTime(2021, 4, 13, 17, 46, 27, 187, DateTimeKind.Local).AddTicks(675), null },
                    { 6, 1, null, new DateTime(2021, 4, 13, 17, 46, 27, 187, DateTimeKind.Local).AddTicks(668), null },
                    { 4, 1, null, new DateTime(2021, 4, 13, 17, 46, 27, 187, DateTimeKind.Local).AddTicks(662), null },
                    { 3, 1, null, new DateTime(2021, 4, 13, 17, 46, 27, 187, DateTimeKind.Local).AddTicks(657), null },
                    { 3, 3, null, new DateTime(2021, 4, 13, 17, 46, 27, 187, DateTimeKind.Local).AddTicks(660), null },
                    { 7, 5, null, new DateTime(2021, 4, 13, 17, 46, 27, 187, DateTimeKind.Local).AddTicks(748), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunosCursos_CursoId",
                table: "AlunosCursos",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosDisciplinas_DisciplinaId",
                table: "AlunosDisciplinas",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_CursoId",
                table: "Disciplinas",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_PrerequisitoId",
                table: "Disciplinas",
                column: "PrerequisitoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_ProfessorId",
                table: "Disciplinas",
                column: "ProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunosCursos");

            migrationBuilder.DropTable(
                name: "AlunosDisciplinas");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
