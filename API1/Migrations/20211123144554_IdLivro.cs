using Microsoft.EntityFrameworkCore.Migrations;

namespace API1.Migrations
{
    public partial class IdLivro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdLivro",
                table: "Filmes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IdLivro",
                table: "Filmes",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
