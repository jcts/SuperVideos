using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperVideos.SharedKernel.Migrations
{
    public partial class AdiçãodocampoCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Movies",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_Code",
                table: "Movies",
                column: "Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Movies_Code",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Movies");
        }
    }
}
