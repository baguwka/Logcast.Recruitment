using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Logcast.Recruitment.DataAccess.Migrations
{
    public partial class AddAudio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AudioFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FileId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    //TODO rest of the columns
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudioFiles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AudioFiles_FileId",
                table: "AudioFiles",
                column: "FileId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AudioFiles");
        }
    }
}