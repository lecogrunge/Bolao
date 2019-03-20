using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolao.Infra.Migrations
{
    public partial class bolao5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MegaSenaBetNumber",
                columns: table => new
                {
                    IdMegaSenaBetNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<string>(nullable: true),
                    IdTicket = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MegaSenaBetNumber", x => x.IdMegaSenaBetNumber);
                });

            migrationBuilder.CreateTable(
                name: "MegaSenaLottery",
                columns: table => new
                {
                    IdMegaSenaLoterry = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LoterryDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MegaSenaLottery", x => x.IdMegaSenaLoterry);
                });

            migrationBuilder.CreateTable(
                name: "MegaSenaLotteryNumber",
                columns: table => new
                {
                    IdMegaSenaNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<string>(nullable: true),
                    IdMegaSenaLoterry = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MegaSenaLotteryNumber", x => x.IdMegaSenaNumber);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    IdTicket = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Price = table.Column<decimal>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    StartDateBet = table.Column<DateTime>(nullable: false),
                    EndDateBet = table.Column<DateTime>(nullable: false),
                    IdTypeBet = table.Column<int>(nullable: false),
                    IdUser = table.Column<Guid>(nullable: false)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MegaSenaBetNumber");

            migrationBuilder.DropTable(
                name: "MegaSenaLottery");

            migrationBuilder.DropTable(
                name: "MegaSenaLotteryNumber");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "TypeBet");
        }
    }
}
