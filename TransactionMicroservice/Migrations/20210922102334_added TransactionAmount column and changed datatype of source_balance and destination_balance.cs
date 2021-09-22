using Microsoft.EntityFrameworkCore.Migrations;

namespace TransactionMicroservice.Migrations
{
    public partial class addedTransactionAmountcolumnandchangeddatatypeofsource_balanceanddestination_balance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "source_balance",
                table: "TransactionHistories",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "destination_balance",
                table: "TransactionHistories",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<double>(
                name: "TransactionAmount",
                table: "TransactionHistories",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionAmount",
                table: "TransactionHistories");

            migrationBuilder.AlterColumn<int>(
                name: "source_balance",
                table: "TransactionHistories",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "destination_balance",
                table: "TransactionHistories",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
