using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperVideos.SharedKernel.Migrations
{
    public partial class CriaçãodoBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Synopsis = table.Column<string>(type: "TEXT", nullable: true),
                    Sleeve = table.Column<byte[]>(type: "BLOB", nullable: true),
                    Available = table.Column<bool>(type: "INTEGER", nullable: false),
                    BarCode = table.Column<long>(type: "INTEGER", nullable: true),
                    Duration = table.Column<int>(type: "INTEGER", nullable: true),
                    Isbn = table.Column<long>(type: "INTEGER", nullable: true),
                    CreateOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdateOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Delete = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
