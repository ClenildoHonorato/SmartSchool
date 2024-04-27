using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSchool.Api.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Matricula = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    SobreNome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Registro = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    SobreNome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlunosCursos",
                columns: table => new
                {
                    AlunoId = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    CargaHoraria = table.Column<int>(nullable: false),
                    PreRequisitoId = table.Column<int>(nullable: true),
                    ProfessorId = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false)
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
                        name: "FK_Disciplinas_Disciplinas_PreRequisitoId",
                        column: x => x.PreRequisitoId,
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
                    AlunoId = table.Column<int>(nullable: false),
                    DisciplinaId = table.Column<int>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    Nota = table.Column<int>(nullable: true)
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
                columns: new[] { "Id", "DataFim", "DataInicio", "DataNascimento", "IsActive", "Matricula", "Nome", "SobreNome", "Telefone" },
                values: new object[] { 1, null, new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(52), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, "Marta", "Kent", "33225555" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "DataFim", "DataInicio", "DataNascimento", "IsActive", "Matricula", "Nome", "SobreNome", "Telefone" },
                values: new object[] { 2, null, new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(2795), new DateTime(2005, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2, "Paula", "Isabela", "3354288" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "DataFim", "DataInicio", "DataNascimento", "IsActive", "Matricula", "Nome", "SobreNome", "Telefone" },
                values: new object[] { 3, null, new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(2866), new DateTime(2005, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3, "Laura", "Antonia", "55668899" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "DataFim", "DataInicio", "DataNascimento", "IsActive", "Matricula", "Nome", "SobreNome", "Telefone" },
                values: new object[] { 4, null, new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(2874), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4, "Luiza", "Maria", "6565659" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "DataFim", "DataInicio", "DataNascimento", "IsActive", "Matricula", "Nome", "SobreNome", "Telefone" },
                values: new object[] { 5, null, new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(2881), new DateTime(2005, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 5, "Lucas", "Machado", "565685415" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "DataFim", "DataInicio", "DataNascimento", "IsActive", "Matricula", "Nome", "SobreNome", "Telefone" },
                values: new object[] { 6, null, new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(2894), new DateTime(2005, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 6, "Pedro", "Alvares", "456454545" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "DataFim", "DataInicio", "DataNascimento", "IsActive", "Matricula", "Nome", "SobreNome", "Telefone" },
                values: new object[] { 7, null, new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(2901), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 7, "Paulo", "José", "9874512" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Tecnologia da Informação" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Sistema de Informação" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Ciência da Computação" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "DataFim", "DataInicio", "IsActive", "Nome", "Registro", "SobreNome", "Telefone" },
                values: new object[] { 1, null, new DateTime(2024, 4, 24, 6, 57, 53, 532, DateTimeKind.Local).AddTicks(1168), true, "Lauro", 1, "Oliveira", null });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "DataFim", "DataInicio", "IsActive", "Nome", "Registro", "SobreNome", "Telefone" },
                values: new object[] { 2, null, new DateTime(2024, 4, 24, 6, 57, 53, 533, DateTimeKind.Local).AddTicks(7045), true, "Roberto", 2, "Soares", null });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "DataFim", "DataInicio", "IsActive", "Nome", "Registro", "SobreNome", "Telefone" },
                values: new object[] { 3, null, new DateTime(2024, 4, 24, 6, 57, 53, 533, DateTimeKind.Local).AddTicks(7111), true, "Ronaldo", 3, "Carvalho", null });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "DataFim", "DataInicio", "IsActive", "Nome", "Registro", "SobreNome", "Telefone" },
                values: new object[] { 4, null, new DateTime(2024, 4, 24, 6, 57, 53, 533, DateTimeKind.Local).AddTicks(7114), true, "Rodrigo", 4, "Marconi", null });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "DataFim", "DataInicio", "IsActive", "Nome", "Registro", "SobreNome", "Telefone" },
                values: new object[] { 5, null, new DateTime(2024, 4, 24, 6, 57, 53, 533, DateTimeKind.Local).AddTicks(7117), true, "Alexandre", 5, "Montanha", null });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Name", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 1, 0, 1, "Matemática", null, 1 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Name", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 2, 0, 3, "Matemática", null, 1 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Name", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 3, 0, 3, "Física", null, 2 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Name", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 4, 0, 1, "Português", null, 3 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Name", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 5, 0, 1, "Inglês", null, 4 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Name", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 6, 0, 2, "Inglês", null, 4 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Name", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 7, 0, 3, "Inglês", null, 4 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Name", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 8, 0, 1, "Programação", null, 5 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Name", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 9, 0, 2, "Programação", null, 5 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Name", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 10, 0, 2, "Programação", null, 5 });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 2, 1, null, new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(5742), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 4, 5, null, new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(5760), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 2, 5, null, new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(5748), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 1, 5, null, new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(5739), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 7, 4, null, new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(5777), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 6, 4, null, new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(5770), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 5, 4, null, new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(5761), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 4, 4, null, new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(5758), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 1, 4, null, new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(5692), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 7, 3, null, new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(5775), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 5, 5, null, new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(5763), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 6, 3, null, new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(5768), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 7, 2, null, new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(5774), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 6, 2, null, new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(5766), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 3, 2, null, new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(5752), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 2, 2, null, new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(5743), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 1, 2, null, new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(4779), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 7, 1, null, new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(5772), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 6, 1, null, new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(5764), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 4, 1, null, new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(5757), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 3, 1, null, new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(5750), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 3, 3, null, new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(5753), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[] { 7, 5, null, new DateTime(2024, 4, 24, 6, 57, 53, 538, DateTimeKind.Local).AddTicks(5778), null });

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
                name: "IX_Disciplinas_PreRequisitoId",
                table: "Disciplinas",
                column: "PreRequisitoId");

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
