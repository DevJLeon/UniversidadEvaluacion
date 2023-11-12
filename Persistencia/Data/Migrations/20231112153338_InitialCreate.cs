using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {/*
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cursoEscolar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AnhoInicio = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    AnhoFin = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cursoEscolar", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "departamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departamento", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "grado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grado", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "persona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nit = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellido1 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellido2 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ciudad = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Direccion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaNacimiento = table.Column<DateOnly>(type: "date", maxLength: 10, nullable: false),
                    sexo = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tipo = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persona", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "asignatura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Creditos = table.Column<float>(type: "float", maxLength: 125, nullable: false),
                    tipo = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Curso = table.Column<sbyte>(type: "tinyint", nullable: false),
                    Cuatrimestre = table.Column<sbyte>(type: "tinyint", nullable: false),
                    ProfesorIdFk = table.Column<int>(type: "int", nullable: true),
                    GradoIdFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asignatura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_asignatura_grado_GradoIdFk",
                        column: x => x.GradoIdFk,
                        principalTable: "grado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_asignatura_persona_ProfesorIdFk",
                        column: x => x.ProfesorIdFk,
                        principalTable: "persona",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "profesor",
                columns: table => new
                {
                    ProfesorIdFk = table.Column<int>(type: "int", nullable: false),
                    DepartamentoIdFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profesor", x => new { x.DepartamentoIdFk, x.ProfesorIdFk });
                    table.ForeignKey(
                        name: "FK_profesor_departamento_DepartamentoIdFk",
                        column: x => x.DepartamentoIdFk,
                        principalTable: "departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_profesor_persona_ProfesorIdFk",
                        column: x => x.ProfesorIdFk,
                        principalTable: "persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "alumnoMatriculaAsignatura",
                columns: table => new
                {
                    AlumnoIdFk = table.Column<int>(type: "int", nullable: false),
                    AsignaturaIdFk = table.Column<int>(type: "int", nullable: false),
                    CursoEscolarIdFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alumnoMatriculaAsignatura", x => new { x.AlumnoIdFk, x.AsignaturaIdFk, x.CursoEscolarIdFk });
                    table.ForeignKey(
                        name: "FK_alumnoMatriculaAsignatura_asignatura_AsignaturaIdFk",
                        column: x => x.AsignaturaIdFk,
                        principalTable: "asignatura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_alumnoMatriculaAsignatura_cursoEscolar_CursoEscolarIdFk",
                        column: x => x.CursoEscolarIdFk,
                        principalTable: "cursoEscolar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_alumnoMatriculaAsignatura_persona_AlumnoIdFk",
                        column: x => x.AlumnoIdFk,
                        principalTable: "persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_alumnoMatriculaAsignatura_AsignaturaIdFk",
                table: "alumnoMatriculaAsignatura",
                column: "AsignaturaIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_alumnoMatriculaAsignatura_CursoEscolarIdFk",
                table: "alumnoMatriculaAsignatura",
                column: "CursoEscolarIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_asignatura_GradoIdFk",
                table: "asignatura",
                column: "GradoIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_asignatura_ProfesorIdFk",
                table: "asignatura",
                column: "ProfesorIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_profesor_ProfesorIdFk",
                table: "profesor",
                column: "ProfesorIdFk");*/
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {/*
            migrationBuilder.DropTable(
                name: "alumnoMatriculaAsignatura");

            migrationBuilder.DropTable(
                name: "profesor");

            migrationBuilder.DropTable(
                name: "asignatura");

            migrationBuilder.DropTable(
                name: "cursoEscolar");

            migrationBuilder.DropTable(
                name: "departamento");

            migrationBuilder.DropTable(
                name: "grado");

            migrationBuilder.DropTable(
                name: "persona");
        */}
    }
}
