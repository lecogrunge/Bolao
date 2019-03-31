using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolao.Infra.Migrations
{
    public partial class MyFirstMigration1 : Migration
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
                name: "Lottery",
                columns: table => new
                {
                    LoterryId = table.Column<Guid>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    StartDateBet = table.Column<DateTime>(nullable: false),
                    EndDateBet = table.Column<DateTime>(nullable: false),
                    TypeBetId = table.Column<int>(nullable: false),
                    StatusPagSeguro = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lottery", x => x.LoterryId);
                });

            migrationBuilder.CreateTable(
                name: "TypeBet",
                columns: table => new
                {
                    TypeBetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeBet", x => x.TypeBetId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    FisrtName = table.Column<string>(maxLength: 15, nullable: false),
                    LastName = table.Column<string>(maxLength: 30, nullable: false),
                    Email = table.Column<string>(maxLength: 80, nullable: false),
                    Password = table.Column<string>(maxLength: 36, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    TokenConfirm = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Buy",
                columns: table => new
                {
                    BuyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Total = table.Column<decimal>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    TotalTicket = table.Column<int>(nullable: false),
                    LotteryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buy", x => x.BuyId);
                    table.ForeignKey(
                        name: "FK_Buy_Lottery_LotteryId",
                        column: x => x.LotteryId,
                        principalTable: "Lottery",
                        principalColumn: "LoterryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LotteryNumberResult",
                columns: table => new
                {
                    LotteryNumberResultId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<string>(nullable: true),
                    LoterryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LotteryNumberResult", x => x.LotteryNumberResultId);
                    table.ForeignKey(
                        name: "FK_LotteryNumberResult_Lottery_LoterryId",
                        column: x => x.LoterryId,
                        principalTable: "Lottery",
                        principalColumn: "LoterryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OwnerJackpot",
                columns: table => new
                {
                    OwnerJackpotId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Jackpot = table.Column<decimal>(nullable: false),
                    Profit = table.Column<decimal>(nullable: false),
                    LotteryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerJackpot", x => x.OwnerJackpotId);
                    table.ForeignKey(
                        name: "FK_OwnerJackpot_Lottery_LotteryId",
                        column: x => x.LotteryId,
                        principalTable: "Lottery",
                        principalColumn: "LoterryId",
                        onDelete: ReferentialAction.Cascade);
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
                        principalColumn: "LoterryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WinnerJackpot_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    TicketId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    BuyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Ticket_Buy_BuyId",
                        column: x => x.BuyId,
                        principalTable: "Buy",
                        principalColumn: "BuyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LotteryNumberBet",
                columns: table => new
                {
                    LotteryNumberBetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<string>(nullable: true),
                    TicketId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LotteryNumberBet", x => x.LotteryNumberBetId);
                    table.ForeignKey(
                        name: "FK_LotteryNumberBet_Ticket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Ticket",
                        principalColumn: "TicketId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buy_LotteryId",
                table: "Buy",
                column: "LotteryId");

            migrationBuilder.CreateIndex(
                name: "IX_LotteryNumberBet_TicketId",
                table: "LotteryNumberBet",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_LotteryNumberResult_LoterryId",
                table: "LotteryNumberResult",
                column: "LoterryId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerJackpot_LotteryId",
                table: "OwnerJackpot",
                column: "LotteryId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_BuyId",
                table: "Ticket",
                column: "BuyId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_UserId",
                table: "Ticket",
                column: "UserId");

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
                name: "LotteryNumberBet");

            migrationBuilder.DropTable(
                name: "LotteryNumberResult");

            migrationBuilder.DropTable(
                name: "OwnerJackpot");

            migrationBuilder.DropTable(
                name: "TypeBet");

            migrationBuilder.DropTable(
                name: "WinnerJackpot");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Buy");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Lottery");
        }
    }
}
