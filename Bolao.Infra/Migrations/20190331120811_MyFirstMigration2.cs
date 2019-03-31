using Microsoft.EntityFrameworkCore.Migrations;

namespace Bolao.Infra.Migrations
{
    public partial class MyFirstMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MegaSenaBetNumber_Lottery_IdLottery",
                table: "MegaSenaBetNumber");

            migrationBuilder.DropForeignKey(
                name: "FK_MegaSenaLotteryNumber_MegaSenaLottery_IdMegaSenaLoterry",
                table: "MegaSenaLotteryNumber");

            migrationBuilder.DropColumn(
                name: "IdTypeBet",
                table: "Lottery");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "User",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "IdTypeBet",
                table: "TypeBet",
                newName: "TypeBetId");

            migrationBuilder.RenameColumn(
                name: "IdLottery",
                table: "Lottery",
                newName: "LotteryId");

            migrationBuilder.RenameColumn(
                name: "IdMegaSenaLoterry",
                table: "MegaSenaLotteryNumber",
                newName: "MegaSenaLoterryId");

            migrationBuilder.RenameColumn(
                name: "IdMegaSenaLoterryNumber",
                table: "MegaSenaLotteryNumber",
                newName: "MegaSenaLoterryNumberId");

            migrationBuilder.RenameIndex(
                name: "IX_MegaSenaLotteryNumber_IdMegaSenaLoterry",
                table: "MegaSenaLotteryNumber",
                newName: "IX_MegaSenaLotteryNumber_MegaSenaLoterryId");

            migrationBuilder.RenameColumn(
                name: "IdMegaSenaLoterry",
                table: "MegaSenaLottery",
                newName: "MegaSenaLoterryId");

            migrationBuilder.RenameColumn(
                name: "IdLottery",
                table: "MegaSenaBetNumber",
                newName: "LotteryId");

            migrationBuilder.RenameColumn(
                name: "IdMegaSenaBetNumber",
                table: "MegaSenaBetNumber",
                newName: "MegaSenaBetNumberId");

            migrationBuilder.RenameIndex(
                name: "IX_MegaSenaBetNumber_IdLottery",
                table: "MegaSenaBetNumber",
                newName: "IX_MegaSenaBetNumber_LotteryId");

            migrationBuilder.AddColumn<int>(
                name: "TypeBetId",
                table: "Lottery",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_MegaSenaBetNumber_Lottery_LotteryId",
                table: "MegaSenaBetNumber",
                column: "LotteryId",
                principalTable: "Lottery",
                principalColumn: "LotteryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MegaSenaLotteryNumber_MegaSenaLottery_MegaSenaLoterryId",
                table: "MegaSenaLotteryNumber",
                column: "MegaSenaLoterryId",
                principalTable: "MegaSenaLottery",
                principalColumn: "MegaSenaLoterryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MegaSenaBetNumber_Lottery_LotteryId",
                table: "MegaSenaBetNumber");

            migrationBuilder.DropForeignKey(
                name: "FK_MegaSenaLotteryNumber_MegaSenaLottery_MegaSenaLoterryId",
                table: "MegaSenaLotteryNumber");

            migrationBuilder.DropColumn(
                name: "TypeBetId",
                table: "Lottery");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "User",
                newName: "IdUser");

            migrationBuilder.RenameColumn(
                name: "TypeBetId",
                table: "TypeBet",
                newName: "IdTypeBet");

            migrationBuilder.RenameColumn(
                name: "LotteryId",
                table: "Lottery",
                newName: "IdLottery");

            migrationBuilder.RenameColumn(
                name: "MegaSenaLoterryId",
                table: "MegaSenaLotteryNumber",
                newName: "IdMegaSenaLoterry");

            migrationBuilder.RenameColumn(
                name: "MegaSenaLoterryNumberId",
                table: "MegaSenaLotteryNumber",
                newName: "IdMegaSenaLoterryNumber");

            migrationBuilder.RenameIndex(
                name: "IX_MegaSenaLotteryNumber_MegaSenaLoterryId",
                table: "MegaSenaLotteryNumber",
                newName: "IX_MegaSenaLotteryNumber_IdMegaSenaLoterry");

            migrationBuilder.RenameColumn(
                name: "MegaSenaLoterryId",
                table: "MegaSenaLottery",
                newName: "IdMegaSenaLoterry");

            migrationBuilder.RenameColumn(
                name: "LotteryId",
                table: "MegaSenaBetNumber",
                newName: "IdLottery");

            migrationBuilder.RenameColumn(
                name: "MegaSenaBetNumberId",
                table: "MegaSenaBetNumber",
                newName: "IdMegaSenaBetNumber");

            migrationBuilder.RenameIndex(
                name: "IX_MegaSenaBetNumber_LotteryId",
                table: "MegaSenaBetNumber",
                newName: "IX_MegaSenaBetNumber_IdLottery");

            migrationBuilder.AddColumn<int>(
                name: "IdTypeBet",
                table: "Lottery",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_MegaSenaBetNumber_Lottery_IdLottery",
                table: "MegaSenaBetNumber",
                column: "IdLottery",
                principalTable: "Lottery",
                principalColumn: "IdLottery",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MegaSenaLotteryNumber_MegaSenaLottery_IdMegaSenaLoterry",
                table: "MegaSenaLotteryNumber",
                column: "IdMegaSenaLoterry",
                principalTable: "MegaSenaLottery",
                principalColumn: "IdMegaSenaLoterry",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
