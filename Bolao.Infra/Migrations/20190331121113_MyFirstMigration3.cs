using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolao.Infra.Migrations
{
    public partial class MyFirstMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bank",
                columns: table => new
                {
                    BankId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.BankId);
                });

            migrationBuilder.CreateTable(
                name: "OwnerJackpot",
                columns: table => new
                {
                    OwnerJackpotId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MegaSenaLoterryId = table.Column<Guid>(nullable: false),
                    Jackpot = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerJackpot", x => x.OwnerJackpotId);
                });

            migrationBuilder.CreateTable(
                name: "WinnerJackpot",
                columns: table => new
                {
                    WinnerJackpotId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    JackPot = table.Column<decimal>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    LotteryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WinnerJackpot", x => x.WinnerJackpotId);
                    table.ForeignKey(
                        name: "FK_WinnerJackpot_Lottery_LotteryId",
                        column: x => x.LotteryId,
                        principalTable: "Lottery",
                        principalColumn: "LotteryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WinnerJackpot_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WinnerJackpot_LotteryId",
                table: "WinnerJackpot",
                column: "LotteryId");

            migrationBuilder.CreateIndex(
                name: "IX_WinnerJackpot_UserId",
                table: "WinnerJackpot",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bank");

            migrationBuilder.DropTable(
                name: "OwnerJackpot");

            migrationBuilder.DropTable(
                name: "WinnerJackpot");
        }
    }
}
