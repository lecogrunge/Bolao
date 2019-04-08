using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolao.Infra.Migrations
{
    public partial class teste2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "Buy",
                type: "decimal(5, 2)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "Buy",
                type: "decimal(5, 2)",
                nullable: false,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "Buy",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "Buy",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5, 2)");
        }
    }
}
