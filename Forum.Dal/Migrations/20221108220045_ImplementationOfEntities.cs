using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forum.Dal.Migrations
{
    public partial class ImplementationOfEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Theme_ThemeId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_User_AuthorId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Section_Categories_CategoryId",
                table: "Section");

            migrationBuilder.DropForeignKey(
                name: "FK_Theme_Section_SectionId",
                table: "Theme");

            migrationBuilder.DropForeignKey(
                name: "FK_Theme_User_AuthorId",
                table: "Theme");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Theme",
                table: "Theme");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Section",
                table: "Section");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Message",
                table: "Message");

            migrationBuilder.RenameTable(
                name: "Theme",
                newName: "Themes");

            migrationBuilder.RenameTable(
                name: "Section",
                newName: "Sections");

            migrationBuilder.RenameTable(
                name: "Message",
                newName: "Messages");

            migrationBuilder.RenameIndex(
                name: "IX_Theme_SectionId",
                table: "Themes",
                newName: "IX_Themes_SectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Theme_AuthorId",
                table: "Themes",
                newName: "IX_Themes_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Section_CategoryId",
                table: "Sections",
                newName: "IX_Sections_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_ThemeId",
                table: "Messages",
                newName: "IX_Messages_ThemeId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_AuthorId",
                table: "Messages",
                newName: "IX_Messages_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Themes",
                table: "Themes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sections",
                table: "Sections",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Themes_ThemeId",
                table: "Messages",
                column: "ThemeId",
                principalTable: "Themes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_User_AuthorId",
                table: "Messages",
                column: "AuthorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Categories_CategoryId",
                table: "Sections",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Themes_Sections_SectionId",
                table: "Themes",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Themes_User_AuthorId",
                table: "Themes",
                column: "AuthorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Themes_ThemeId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_User_AuthorId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Categories_CategoryId",
                table: "Sections");

            migrationBuilder.DropForeignKey(
                name: "FK_Themes_Sections_SectionId",
                table: "Themes");

            migrationBuilder.DropForeignKey(
                name: "FK_Themes_User_AuthorId",
                table: "Themes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Themes",
                table: "Themes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sections",
                table: "Sections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.RenameTable(
                name: "Themes",
                newName: "Theme");

            migrationBuilder.RenameTable(
                name: "Sections",
                newName: "Section");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "Message");

            migrationBuilder.RenameIndex(
                name: "IX_Themes_SectionId",
                table: "Theme",
                newName: "IX_Theme_SectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Themes_AuthorId",
                table: "Theme",
                newName: "IX_Theme_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Sections_CategoryId",
                table: "Section",
                newName: "IX_Section_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ThemeId",
                table: "Message",
                newName: "IX_Message_ThemeId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_AuthorId",
                table: "Message",
                newName: "IX_Message_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Theme",
                table: "Theme",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Section",
                table: "Section",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Message",
                table: "Message",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Theme_ThemeId",
                table: "Message",
                column: "ThemeId",
                principalTable: "Theme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_User_AuthorId",
                table: "Message",
                column: "AuthorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Section_Categories_CategoryId",
                table: "Section",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Theme_Section_SectionId",
                table: "Theme",
                column: "SectionId",
                principalTable: "Section",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Theme_User_AuthorId",
                table: "Theme",
                column: "AuthorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
