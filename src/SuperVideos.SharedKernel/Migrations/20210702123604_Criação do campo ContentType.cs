using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperVideos.SharedKernel.Migrations
{
    public partial class CriaçãodocampoContentType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContenType",
                table: "Movies",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContenType",
                table: "Movies");
        }
    }
}
