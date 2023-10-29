using Microsoft.EntityFrameworkCore.Migrations;

namespace CL2TristanVela.Migrations
{
    public partial class ActulizarDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AlumnosEntity",
                table: "AlumnosEntity");

            migrationBuilder.RenameTable(
                name: "AlumnosEntity",
                newName: "Alumnos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alumnos",
                table: "Alumnos",
                column: "IdAlumno");

            migrationBuilder.CreateTable(
                name: "Notas",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAlumno = table.Column<int>(nullable: true),
                    NombreCurso = table.Column<string>(nullable: true),
                    Nota = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notas", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Notas_Alumnos_IdAlumno",
                        column: x => x.IdAlumno,
                        principalTable: "Alumnos",
                        principalColumn: "IdAlumno",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notas_IdAlumno",
                table: "Notas",
                column: "IdAlumno");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alumnos",
                table: "Alumnos");

            migrationBuilder.RenameTable(
                name: "Alumnos",
                newName: "AlumnosEntity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlumnosEntity",
                table: "AlumnosEntity",
                column: "IdAlumno");
        }
    }
}
