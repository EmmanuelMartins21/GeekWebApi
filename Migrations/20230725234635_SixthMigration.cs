using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeekWebApi.Migrations
{
    /// <inheritdoc />
    public partial class SixthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DuracaoMinutos",
                table: "Animes");

            migrationBuilder.AddColumn<int>(
                name: "Temporadas",
                table: "Animes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Temporadas",
                table: "Animes");

            migrationBuilder.AddColumn<float>(
                name: "DuracaoMinutos",
                table: "Animes",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
