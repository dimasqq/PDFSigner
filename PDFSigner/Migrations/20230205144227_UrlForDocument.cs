using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PDFSigner.Migrations
{
    /// <inheritdoc />
    public partial class UrlForDocument : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DocumentURL",
                schema: "public",
                table: "Document",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentURL",
                schema: "public",
                table: "Document");
        }
    }
}
