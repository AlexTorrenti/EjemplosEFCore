using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dia1.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: true),
                    FechaAlta = table.Column<DateTime>(nullable: false),
                    Activa = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(nullable: true),
                    CategoriaID = table.Column<int>(nullable: true),
                    Activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cursos_Categorias_CategoriaID",
                        column: x => x.CategoriaID,
                        principalTable: "Categorias",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: true),
                    Apellidos = table.Column<string>(nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    Direccion = table.Column<string>(nullable: true),
                    EstaActivo = table.Column<bool>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    CursoID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Usuarios_Cursos_CursoID",
                        column: x => x.CursoID,
                        principalTable: "Cursos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matriculaciones",
                columns: table => new
                {
                    CursoID = table.Column<int>(nullable: false),
                    EstudianteID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matriculaciones", x => new { x.EstudianteID, x.CursoID });
                    table.ForeignKey(
                        name: "FK_Matriculaciones_Cursos_CursoID",
                        column: x => x.CursoID,
                        principalTable: "Cursos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matriculaciones_Usuarios_EstudianteID",
                        column: x => x.EstudianteID,
                        principalTable: "Usuarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "ID", "Activa", "FechaAlta", "Nombre" },
                values: new object[] { 1, true, new DateTime(2020, 1, 26, 22, 45, 48, 696, DateTimeKind.Local).AddTicks(1510), "Desarrollo Web" });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "ID", "Activa", "FechaAlta", "Nombre" },
                values: new object[] { 2, true, new DateTime(2020, 1, 26, 22, 45, 48, 703, DateTimeKind.Local).AddTicks(5100), "Desarrollo Móvil" });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "ID", "Activa", "FechaAlta", "Nombre" },
                values: new object[] { 3, true, new DateTime(2020, 1, 26, 22, 45, 48, 703, DateTimeKind.Local).AddTicks(5120), "Microsoft" });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "ID", "Activa", "FechaAlta", "Nombre" },
                values: new object[] { 4, true, new DateTime(2020, 1, 26, 22, 45, 48, 703, DateTimeKind.Local).AddTicks(5130), "Seguridad" });

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_CategoriaID",
                table: "Cursos",
                column: "CategoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculaciones_CursoID",
                table: "Matriculaciones",
                column: "CursoID");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CursoID",
                table: "Usuarios",
                column: "CursoID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matriculaciones");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
