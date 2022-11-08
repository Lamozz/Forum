using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forum.Dal.Migrations
{
    public partial class ChangeSection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SectionTheme");

            migrationBuilder.AddColumn<int>(
                name: "SectionId",
                table: "Theme",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Theme_SectionId",
                table: "Theme",
                column: "SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Theme_Section_SectionId",
                table: "Theme",
                column: "SectionId",
                principalTable: "Section",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Theme_Section_SectionId",
                table: "Theme");

            migrationBuilder.DropIndex(
                name: "IX_Theme_SectionId",
                table: "Theme");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "Theme");

            migrationBuilder.CreateTable(
                name: "SectionTheme",
                columns: table => new
                {
                    SectionsId = table.Column<int>(type: "int", nullable: false),
                    ThemesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionTheme", x => new { x.SectionsId, x.ThemesId });
                    table.ForeignKey(
                        name: "FK_SectionTheme_Section_SectionsId",
                        column: x => x.SectionsId,
                        principalTable: "Section",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SectionTheme_Theme_ThemesId",
                        column: x => x.ThemesId,
                        principalTable: "Theme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SectionTheme_ThemesId",
                table: "SectionTheme",
                column: "ThemesId");
        }
    }
}
