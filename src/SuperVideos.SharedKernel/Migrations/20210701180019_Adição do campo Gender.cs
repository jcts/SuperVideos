using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperVideos.SharedKernel.Migrations
{
    public partial class AdiçãodocampoGender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Movies",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Movies");
        }
    }
}
