using Microsoft.EntityFrameworkCore.Migrations;

namespace _04_XX_Relacionamento_N_N.Migrations
{
    public partial class AdicionandoRelacionamentoEntreCinemaEFilme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CinemaFilme",
                columns: table => new
                {
                    CinemasId = table.Column<int>(type: "int", nullable: false),
                    FilmesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaFilme", x => new { x.CinemasId, x.FilmesId });
                    table.ForeignKey(
                        name: "FK_CinemaFilme_Cinemas_CinemasId",
                        column: x => x.CinemasId,
                        principalTable: "Cinemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CinemaFilme_Filmes_FilmesId",
                        column: x => x.FilmesId,
                        principalTable: "Filmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CinemaFilme_FilmesId",
                table: "CinemaFilme",
                column: "FilmesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CinemaFilme");
        }
    }
}