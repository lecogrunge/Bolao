using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolao.Infra.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MegaSenaLottery",
                columns: table => new
                {
                    IdMegaSenaLoterry = table.Column<Guid>(nullable: false),
                    LoterryDate = table.Column<DateTime>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    LoterryOfficialNumberBet = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MegaSenaLottery", x => x.IdMegaSenaLoterry);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    IdTicket = table.Column<Guid>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    StartDateBet = table.Column<DateTime>(nullable: false),
                    EndDateBet = table.Column<DateTime>(nullable: false),
                    IdTypeBet = table.Column<int>(nullable: false),
                    StatusPagSeguro = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.IdTicket);
                });

            migrationBuilder.CreateTable(
                name: "TypeBet",
                columns: table => new
                {
                    IdTypeBet = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeBet", x => x.IdTypeBet);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    IdUser = table.Column<Guid>(nullable: false),
                    FisrtName = table.Column<string>(maxLength: 15, nullable: false),
                    LastName = table.Column<string>(maxLength: 30, nullable: false),
                    Email = table.Column<string>(maxLength: 80, nullable: false),
                    Password = table.Column<string>(maxLength: 36, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    TokenConfirm = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "MegaSenaLotteryNumber",
                columns: table => new
                {
                    IdMegaSenaLoterryNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<string>(nullable: true),
                    IdMegaSenaLoterry = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MegaSenaLotteryNumber", x => x.IdMegaSenaLoterryNumber);
                    table.ForeignKey(
                        name: "FK_MegaSenaLotteryNumber_MegaSenaLottery_IdMegaSenaLoterry",
                        column: x => x.IdMegaSenaLoterry,
                        principalTable: "MegaSenaLottery",
                        principalColumn: "IdMegaSenaLoterry",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MegaSenaBetNumber",
                columns: table => new
                {
                    IdMegaSenaBetNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<string>(nullable: true),
                    IdTicket = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MegaSenaBetNumber", x => x.IdMegaSenaBetNumber);
                    table.ForeignKey(
                        name: "FK_MegaSenaBetNumber_Ticket_IdTicket",
                        column: x => x.IdTicket,
                        principalTable: "Ticket",
                        principalColumn: "IdTicket",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MegaSenaBetNumber_IdTicket",
                table: "MegaSenaBetNumber",
                column: "IdTicket");

            migrationBuilder.CreateIndex(
                name: "IX_MegaSenaLotteryNumber_IdMegaSenaLoterry",
                table: "MegaSenaLotteryNumber",
                column: "IdMegaSenaLoterry");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MegaSenaBetNumber");

            migrationBuilder.DropTable(
                name: "MegaSenaLotteryNumber");

            migrationBuilder.DropTable(
                name: "TypeBet");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "MegaSenaLottery");
        }
    }
}
