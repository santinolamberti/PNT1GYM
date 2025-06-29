using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymFinal.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Planes",
                columns: table => new
                {
                    IdPlan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePlan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescripcionPlan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planes", x => x.IdPlan);
                });

            migrationBuilder.CreateTable(
                name: "Sedes",
                columns: table => new
                {
                    IdSede = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sedes", x => x.IdSede);
                });

            migrationBuilder.CreateTable(
                name: "Actividades",
                columns: table => new
                {
                    CodActividad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DuracionMins = table.Column<int>(type: "int", nullable: false),
                    IdSede = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actividades", x => x.CodActividad);
                    table.ForeignKey(
                        name: "FK_Actividades_Sedes_IdSede",
                        column: x => x.IdSede,
                        principalTable: "Sedes",
                        principalColumn: "IdSede",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Legajo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdSede = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Legajo);
                    table.ForeignKey(
                        name: "FK_Empleados_Sedes_IdSede",
                        column: x => x.IdSede,
                        principalTable: "Sedes",
                        principalColumn: "IdSede",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Socios",
                columns: table => new
                {
                    IdSocio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false),
                    IdPlan = table.Column<int>(type: "int", nullable: false),
                    IdSede = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Socios", x => x.IdSocio);
                    table.ForeignKey(
                        name: "FK_Socios_Planes_IdPlan",
                        column: x => x.IdPlan,
                        principalTable: "Planes",
                        principalColumn: "IdPlan",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Socios_Sedes_IdSede",
                        column: x => x.IdSede,
                        principalTable: "Sedes",
                        principalColumn: "IdSede",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpleadoActividad",
                columns: table => new
                {
                    ActividadesCodActividad = table.Column<int>(type: "int", nullable: false),
                    EmpleadosLegajo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpleadoActividad", x => new { x.ActividadesCodActividad, x.EmpleadosLegajo });
                    table.ForeignKey(
                        name: "FK_EmpleadoActividad_Actividades_ActividadesCodActividad",
                        column: x => x.ActividadesCodActividad,
                        principalTable: "Actividades",
                        principalColumn: "CodActividad",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpleadoActividad_Empleados_EmpleadosLegajo",
                        column: x => x.EmpleadosLegajo,
                        principalTable: "Empleados",
                        principalColumn: "Legajo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actividades_IdSede",
                table: "Actividades",
                column: "IdSede");

            migrationBuilder.CreateIndex(
                name: "IX_EmpleadoActividad_EmpleadosLegajo",
                table: "EmpleadoActividad",
                column: "EmpleadosLegajo");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_IdSede",
                table: "Empleados",
                column: "IdSede");

            migrationBuilder.CreateIndex(
                name: "IX_Socios_IdPlan",
                table: "Socios",
                column: "IdPlan");

            migrationBuilder.CreateIndex(
                name: "IX_Socios_IdSede",
                table: "Socios",
                column: "IdSede");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpleadoActividad");

            migrationBuilder.DropTable(
                name: "Socios");

            migrationBuilder.DropTable(
                name: "Actividades");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Planes");

            migrationBuilder.DropTable(
                name: "Sedes");
        }
    }
}
