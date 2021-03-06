﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Bolao.Infra.Migrations
{
    public partial class novo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bank",
                columns: table => new
                {
                    BankId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.BankId);
                });

            migrationBuilder.CreateTable(
                name: "ContactType",
                columns: table => new
                {
                    ContactTypeId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactType", x => x.ContactTypeId);
                });

            migrationBuilder.CreateTable(
                name: "TypeBet",
                columns: table => new
                {
                    TypeBetId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    CountNumberResult = table.Column<int>(nullable: false),
                    CountNumberBet = table.Column<int>(nullable: false)
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
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Lottery",
                columns: table => new
                {
                    LoterryId = table.Column<Guid>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(5, 2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DateTime", nullable: false),
                    StartDateBet = table.Column<DateTime>(type: "DateTime", nullable: false),
                    EndDateBet = table.Column<DateTime>(type: "DateTime", nullable: false),
                    LotteryDateBet = table.Column<DateTime>(type: "DateTime", nullable: false),
                    StatusPagSeguro = table.Column<int>(nullable: false),
                    TypeBetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lottery", x => x.LoterryId);
                    table.ForeignKey(
                        name: "FK_Lottery_TypeBet_TypeBetId",
                        column: x => x.TypeBetId,
                        principalTable: "TypeBet",
                        principalColumn: "TypeBetId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Email",
                columns: table => new
                {
                    Email = table.Column<string>(maxLength: 80, nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Email", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Email_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserContactType",
                columns: table => new
                {
                    UserContactTypeId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(nullable: false),
                    ContactTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserContactType", x => x.UserContactTypeId);
                    table.ForeignKey(
                        name: "FK_UserContactType_ContactType_ContactTypeId",
                        column: x => x.ContactTypeId,
                        principalTable: "ContactType",
                        principalColumn: "ContactTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserContactType_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserSecurity",
                columns: table => new
                {
                    UserSecurityId = table.Column<Guid>(nullable: false),
                    TokenCreateConfirmed = table.Column<Guid>(nullable: false),
                    TokenForgotPassword = table.Column<Guid>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSecurity", x => x.UserSecurityId);
                    table.ForeignKey(
                        name: "FK_UserSecurity_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Buy",
                columns: table => new
                {
                    BuyId = table.Column<Guid>(nullable: false),
                    Total = table.Column<decimal>(type: "decimal(5, 2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DateTime", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(5, 2)", nullable: false),
                    TotalTicket = table.Column<int>(nullable: false),
                    LotteryId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buy", x => x.BuyId);
                    table.ForeignKey(
                        name: "FK_Buy_Lottery_LotteryId",
                        column: x => x.LotteryId,
                        principalTable: "Lottery",
                        principalColumn: "LoterryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Buy_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LotteryNumberResult",
                columns: table => new
                {
                    LotteryNumberResultId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<string>(maxLength: 2, nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OwnerJackpot",
                columns: table => new
                {
                    OwnerJackpotId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Jackpot = table.Column<decimal>(type: "decimal(5, 2)", nullable: false),
                    Profit = table.Column<decimal>(type: "decimal(5, 2)", nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WinnerJackpot",
                columns: table => new
                {
                    WinnerJackpotId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    JackPot = table.Column<decimal>(type: "decimal(5, 2)", nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WinnerJackpot_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    TicketId = table.Column<Guid>(nullable: false),
                    BuyId = table.Column<int>(nullable: false),
                    BuyId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Ticket_Buy_BuyId1",
                        column: x => x.BuyId1,
                        principalTable: "Buy",
                        principalColumn: "BuyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LotteryNumberBet",
                columns: table => new
                {
                    LotteryNumberBetId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buy_LotteryId",
                table: "Buy",
                column: "LotteryId");

            migrationBuilder.CreateIndex(
                name: "IX_Buy_UserId",
                table: "Buy",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Lottery_TypeBetId",
                table: "Lottery",
                column: "TypeBetId");

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
                name: "IX_Ticket_BuyId1",
                table: "Ticket",
                column: "BuyId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserContactType_ContactTypeId",
                table: "UserContactType",
                column: "ContactTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserContactType_UserId",
                table: "UserContactType",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSecurity_UserId",
                table: "UserSecurity",
                column: "UserId",
                unique: true);

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
                name: "Email");

            migrationBuilder.DropTable(
                name: "LotteryNumberBet");

            migrationBuilder.DropTable(
                name: "LotteryNumberResult");

            migrationBuilder.DropTable(
                name: "OwnerJackpot");

            migrationBuilder.DropTable(
                name: "UserContactType");

            migrationBuilder.DropTable(
                name: "UserSecurity");

            migrationBuilder.DropTable(
                name: "WinnerJackpot");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "ContactType");

            migrationBuilder.DropTable(
                name: "Buy");

            migrationBuilder.DropTable(
                name: "Lottery");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "TypeBet");
        }
    }
}