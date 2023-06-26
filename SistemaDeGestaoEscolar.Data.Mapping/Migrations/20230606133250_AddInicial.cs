using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaDeGestaoEscolar.Data.Mapping.Migrations
{
    public partial class AddInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "curso",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    requisito = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    carga_horaria = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_curso", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "disciplina",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    area = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    programa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_disciplina", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "professor",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    data_nascimento = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    hora = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_professor", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "aluno",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    data_nascimento = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    numero = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    morada = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    idade = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    contacto = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    id_disciplina = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_aluno", x => x.id);
                    table.ForeignKey(
                        name: "fk_aluno_id_disciplina",
                        column: x => x.id_disciplina,
                        principalTable: "disciplina",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "turma",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    periodo = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    id_aluno = table.Column<int>(type: "int", nullable: false),
                    id_professor = table.Column<int>(type: "int", nullable: false),
                    data_inicio = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    data_final = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    carga_horaria = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    id_curso = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_turma", x => x.id);
                    table.ForeignKey(
                        name: "fk_turma_id_aluno",
                        column: x => x.id_aluno,
                        principalTable: "aluno",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_turma_id_curso",
                        column: x => x.id_curso,
                        principalTable: "curso",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_turma_id_professor",
                        column: x => x.id_professor,
                        principalTable: "professor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "matricula",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_turma = table.Column<int>(type: "int", nullable: false),
                    id_aluno = table.Column<int>(type: "int", nullable: false),
                    data_matricula = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_matricula", x => x.id);
                    table.ForeignKey(
                        name: "fk_matricula_id_aluno",
                        column: x => x.id_aluno,
                        principalTable: "aluno",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_matricula_id_turma",
                        column: x => x.id_turma,
                        principalTable: "turma",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_aluno_id_disciplina",
                table: "aluno",
                column: "id_disciplina");

            migrationBuilder.CreateIndex(
                name: "idx_matricula_id_aluno",
                table: "matricula",
                column: "id_aluno");

            migrationBuilder.CreateIndex(
                name: "idx_matricula_id_turma",
                table: "matricula",
                column: "id_turma");

            migrationBuilder.CreateIndex(
                name: "idx_turma_id_aluno",
                table: "turma",
                column: "id_aluno");

            migrationBuilder.CreateIndex(
                name: "idx_turma_id_curso",
                table: "turma",
                column: "id_curso");

            migrationBuilder.CreateIndex(
                name: "idx_turma_id_professor",
                table: "turma",
                column: "id_professor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "matricula");

            migrationBuilder.DropTable(
                name: "turma");

            migrationBuilder.DropTable(
                name: "aluno");

            migrationBuilder.DropTable(
                name: "curso");

            migrationBuilder.DropTable(
                name: "professor");

            migrationBuilder.DropTable(
                name: "disciplina");
        }
    }
}
