using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolao.Infra.Migrations
{
    public partial class teste1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "JackPot",
                table: "WinnerJackpot",
                type: "decimal",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Profit",
                table: "OwnerJackpot",
                type: "decimal",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Jackpot",
                table: "OwnerJackpot",
                type: "decimal",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Lottery",
                type: "decimal",
                nullable: false,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "JackPot",
                table: "WinnerJackpot",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal");

            migrationBuilder.AlterColumn<decimal>(
                name: "Profit",
                table: "OwnerJackpot",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal");

            migrationBuilder.AlterColumn<decimal>(
                name: "Jackpot",
                table: "OwnerJackpot",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Lottery",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal");
        }
    }
}
