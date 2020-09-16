using Microsoft.EntityFrameworkCore.Migrations;

namespace TestRanking.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblTiendas",
                columns: table => new
                {
                    IdTienda = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTienda = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    Imagen = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblTiendas", x => x.IdTienda);
                });

            migrationBuilder.CreateTable(
                name: "TblHorarios",
                columns: table => new
                {
                    IdHorario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoraApertura = table.Column<string>(nullable: true),
                    HoraCierre = table.Column<string>(nullable: true),
                    Dias = table.Column<string>(nullable: true),
                    IdTienda = table.Column<int>(nullable: false),
                    IdTiendaNavigationIdTienda = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblHorarios", x => x.IdHorario);
                    table.ForeignKey(
                        name: "FK_TblHorarios_TblTiendas_IdTiendaNavigationIdTienda",
                        column: x => x.IdTiendaNavigationIdTienda,
                        principalTable: "TblTiendas",
                        principalColumn: "IdTienda",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TblPuntos",
                columns: table => new
                {
                    IdPuntos = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Puntos = table.Column<int>(nullable: false),
                    Total = table.Column<int>(nullable: false),
                    IdTienda = table.Column<int>(nullable: false),
                    IdTiendaNavigationIdTienda = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblPuntos", x => x.IdPuntos);
                    table.ForeignKey(
                        name: "FK_TblPuntos_TblTiendas_IdTiendaNavigationIdTienda",
                        column: x => x.IdTiendaNavigationIdTienda,
                        principalTable: "TblTiendas",
                        principalColumn: "IdTienda",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblHorarios_IdTiendaNavigationIdTienda",
                table: "TblHorarios",
                column: "IdTiendaNavigationIdTienda");

            migrationBuilder.CreateIndex(
                name: "IX_TblPuntos_IdTiendaNavigationIdTienda",
                table: "TblPuntos",
                column: "IdTiendaNavigationIdTienda");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblHorarios");

            migrationBuilder.DropTable(
                name: "TblPuntos");

            migrationBuilder.DropTable(
                name: "TblTiendas");
        }
    }
}
