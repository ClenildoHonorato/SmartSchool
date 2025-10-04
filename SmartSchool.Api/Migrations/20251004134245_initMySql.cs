using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSchool.Api.Migrations
{
    public partial class initMySql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                values: new object[,]
                {
                    { 1, null, new DateTime(2025, 10, 4, 10, 42, 45, 416, DateTimeKind.Local).AddTicks(2741), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, "Marta", "Kent", "33225555" },
                    { 2, null, new DateTime(2025, 10, 4, 10, 42, 45, 416, DateTimeKind.Local).AddTicks(5465), new DateTime(2005, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2, "Paula", "Isabela", "3354288" },
                    { 3, null, new DateTime(2025, 10, 4, 10, 42, 45, 416, DateTimeKind.Local).AddTicks(5529), new DateTime(2005, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3, "Laura", "Antonia", "55668899" },
                    { 4, null, new DateTime(2025, 10, 4, 10, 42, 45, 416, DateTimeKind.Local).AddTicks(5539), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4, "Luiza", "Maria", "6565659" },
                    { 5, null, new DateTime(2025, 10, 4, 10, 42, 45, 416, DateTimeKind.Local).AddTicks(5546), new DateTime(2005, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 5, "Lucas", "Machado", "565685415" },
                    { 6, null, new DateTime(2025, 10, 4, 10, 42, 45, 416, DateTimeKind.Local).AddTicks(5559), new DateTime(2005, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 6, "Pedro", "Alvares", "456454545" },
                    { 7, null, new DateTime(2025, 10, 4, 10, 42, 45, 416, DateTimeKind.Local).AddTicks(5565), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 7, "Paulo", "José", "9874512" }
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Tecnologia da Informação" },
                    { 2, "Sistema de Informação" },
                    { 3, "Ciência da Computação" }
                });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "DataFim", "DataInicio", "IsActive", "Nome", "Registro", "SobreNome", "Telefone" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2025, 10, 4, 10, 42, 45, 411, DateTimeKind.Local).AddTicks(3382), true, "Lauro", 1, "Oliveira", null },
                    { 2, null, new DateTime(2025, 10, 4, 10, 42, 45, 412, DateTimeKind.Local).AddTicks(5186), true, "Roberto", 2, "Soares", null },
                    { 3, null, new DateTime(2025, 10, 4, 10, 42, 45, 412, DateTimeKind.Local).AddTicks(5245), true, "Ronaldo", 3, "Carvalho", null },
                    { 4, null, new DateTime(2025, 10, 4, 10, 42, 45, 412, DateTimeKind.Local).AddTicks(5250), true, "Rodrigo", 4, "Marconi", null },
                    { 5, null, new DateTime(2025, 10, 4, 10, 42, 45, 412, DateTimeKind.Local).AddTicks(5252), true, "Alexandre", 5, "Montanha", null }
                });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Name", "PreRequisitoId", "ProfessorId" },
                values: new object[,]
                {
                    { 1, 0, 1, "Matemática", null, 1 },
                    { 2, 0, 3, "Matemática", null, 1 },
                    { 3, 0, 3, "Física", null, 2 },
                    { 4, 0, 1, "Português", null, 3 },
                    { 5, 0, 1, "Inglês", null, 4 },
                    { 6, 0, 2, "Inglês", null, 4 },
                    { 7, 0, 3, "Inglês", null, 4 },
                    { 8, 0, 1, "Programação", null, 5 },
                    { 9, 0, 2, "Programação", null, 5 },
                    { 10, 0, 2, "Programação", null, 5 }
                });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[,]
                {
                    { 2, 1, null, new DateTime(2025, 10, 4, 10, 42, 45, 416, DateTimeKind.Local).AddTicks(8073), null },
                    { 4, 5, null, new DateTime(2025, 10, 4, 10, 42, 45, 416, DateTimeKind.Local).AddTicks(8090), null },
                    { 2, 5, null, new DateTime(2025, 10, 4, 10, 42, 45, 416, DateTimeKind.Local).AddTicks(8079), null },
                    { 1, 5, null, new DateTime(2025, 10, 4, 10, 42, 45, 416, DateTimeKind.Local).AddTicks(8070), null },
                    { 7, 4, null, new DateTime(2025, 10, 4, 10, 42, 45, 416, DateTimeKind.Local).AddTicks(8107), null },
                    { 6, 4, null, new DateTime(2025, 10, 4, 10, 42, 45, 416, DateTimeKind.Local).AddTicks(8101), null },
                    { 5, 4, null, new DateTime(2025, 10, 4, 10, 42, 45, 416, DateTimeKind.Local).AddTicks(8092), null },
                    { 4, 4, null, new DateTime(2025, 10, 4, 10, 42, 45, 416, DateTimeKind.Local).AddTicks(8088), null },
                    { 1, 4, null, new DateTime(2025, 10, 4, 10, 42, 45, 416, DateTimeKind.Local).AddTicks(8032), null },
                    { 7, 3, null, new DateTime(2025, 10, 4, 10, 42, 45, 416, DateTimeKind.Local).AddTicks(8105), null },
                    { 5, 5, null, new DateTime(2025, 10, 4, 10, 42, 45, 416, DateTimeKind.Local).AddTicks(8094), null },
                    { 6, 3, null, new DateTime(2025, 10, 4, 10, 42, 45, 416, DateTimeKind.Local).AddTicks(8098), null },
                    { 7, 2, null, new DateTime(2025, 10, 4, 10, 42, 45, 416, DateTimeKind.Local).AddTicks(8104), null },
                    { 6, 2, null, new DateTime(2025, 10, 4, 10, 42, 45, 416, DateTimeKind.Local).AddTicks(8096), null },
                    { 3, 2, null, new DateTime(2025, 10, 4, 10, 42, 45, 416, DateTimeKind.Local).AddTicks(8082), null },
                    { 2, 2, null, new DateTime(2025, 10, 4, 10, 42, 45, 416, DateTimeKind.Local).AddTicks(8075), null },
                    { 1, 2, null, new DateTime(2025, 10, 4, 10, 42, 45, 416, DateTimeKind.Local).AddTicks(7188), null },
                    { 7, 1, null, new DateTime(2025, 10, 4, 10, 42, 45, 416, DateTimeKind.Local).AddTicks(8102), null },
                    { 6, 1, null, new DateTime(2025, 10, 4, 10, 42, 45, 416, DateTimeKind.Local).AddTicks(8095), null },
                    { 4, 1, null, new DateTime(2025, 10, 4, 10, 42, 45, 416, DateTimeKind.Local).AddTicks(8087), null },
                    { 3, 1, null, new DateTime(2025, 10, 4, 10, 42, 45, 416, DateTimeKind.Local).AddTicks(8081), null },
                    { 3, 3, null, new DateTime(2025, 10, 4, 10, 42, 45, 416, DateTimeKind.Local).AddTicks(8084), null },
                    { 7, 5, null, new DateTime(2025, 10, 4, 10, 42, 45, 416, DateTimeKind.Local).AddTicks(8108), null }
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
