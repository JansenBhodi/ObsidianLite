using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObsiLite_Backend.Migrations
{
    /// <inheritdoc />
    public partial class DbCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "references",
                table: "Note");

            migrationBuilder.DropColumn(
                name: "ContentIds",
                table: "Folder");

            migrationBuilder.AddColumn<int>(
                name: "FolderId",
                table: "Note",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NoteId",
                table: "Note",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FolderId",
                table: "Folder",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Note_FolderId",
                table: "Note",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_Note_NoteId",
                table: "Note",
                column: "NoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Folder_FolderId",
                table: "Folder",
                column: "FolderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Folder_Folder_FolderId",
                table: "Folder",
                column: "FolderId",
                principalTable: "Folder",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Note_Folder_FolderId",
                table: "Note",
                column: "FolderId",
                principalTable: "Folder",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Note_Note_NoteId",
                table: "Note",
                column: "NoteId",
                principalTable: "Note",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Folder_Folder_FolderId",
                table: "Folder");

            migrationBuilder.DropForeignKey(
                name: "FK_Note_Folder_FolderId",
                table: "Note");

            migrationBuilder.DropForeignKey(
                name: "FK_Note_Note_NoteId",
                table: "Note");

            migrationBuilder.DropIndex(
                name: "IX_Note_FolderId",
                table: "Note");

            migrationBuilder.DropIndex(
                name: "IX_Note_NoteId",
                table: "Note");

            migrationBuilder.DropIndex(
                name: "IX_Folder_FolderId",
                table: "Folder");

            migrationBuilder.DropColumn(
                name: "FolderId",
                table: "Note");

            migrationBuilder.DropColumn(
                name: "NoteId",
                table: "Note");

            migrationBuilder.DropColumn(
                name: "FolderId",
                table: "Folder");

            migrationBuilder.AddColumn<string>(
                name: "references",
                table: "Note",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContentIds",
                table: "Folder",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
