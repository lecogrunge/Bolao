using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolao.Infra.Migrations
{
    public partial class novo4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "TokenForgotPassword",
                table: "UserSecurity",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.InsertData(
                table: "TypeBet",
                columns: new[] { "TypeBetId", "Description", "Title" },
                values: new object[] { 1, "Descição", "Sena15Numbers" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TypeBet",
                keyColumn: "TypeBetId",
                keyValue: 1);

            migrationBuilder.AlterColumn<Guid>(
                name: "TokenForgotPassword",
                table: "UserSecurity",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);
        }
    }
}
