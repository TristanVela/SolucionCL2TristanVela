using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CL2TristanVela.Migrations
{
    public partial class MigracionBdCalificaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlumnosEntity",
                columns: table => new
                {
                    IdAlumno = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreAlumno = table.Column<string>(nullable: true),
                    ApellidoAlumno = table.Column<string>(nullable: true),
                    DNI = table.Column<int>(nullable: false),
                    FechaNamiento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlumnosEntity", x => x.IdAlumno);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlumnosEntity");
        }
    }
}
