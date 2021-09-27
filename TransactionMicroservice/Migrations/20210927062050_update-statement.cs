using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TransactionMicroservice.Migrations
{
    public partial class updatestatement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Statements",
                columns: table => new
                {
                    StatementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    Narration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClosingBalance = table.Column<double>(type: "float", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statements", x => x.StatementId);
                });

            migrationBuilder.CreateTable(
                name: "TransactionHistories",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    TransactionAmount = table.Column<double>(type: "float", nullable: false),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    source_balance = table.Column<double>(type: "float", nullable: false),
                    destination_balance = table.Column<double>(type: "float", nullable: false),
                    DateOfTransaction = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionHistories", x => x.TransactionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Statements");

            migrationBuilder.DropTable(
                name: "TransactionHistories");
        }
    }
}
