using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolao.Infra.Migrations
{
    public partial class teste3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 36);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);
        }
    }
}
