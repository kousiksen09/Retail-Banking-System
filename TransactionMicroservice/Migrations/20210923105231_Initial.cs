using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TransactionMicroservice.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    AccountType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Balance = table.Column<int>(type: "int", nullable: false),
                    minBalance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
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

            migrationBuilder.CreateTable(
                name: "TransactionStatus",
                columns: table => new
                {
<<<<<<< HEAD:TransactionMicroservice/Migrations/20210923102503_initial.cs
<<<<<<< HEAD
                    Id = table.Column<int>(type: "int", nullable: false),
=======
>>>>>>> a83808bc7b9313aea7cd35d3addc0b6e1007d6ec:TransactionMicroservice/Migrations/20210923105231_Initial.cs
=======
<<<<<<< HEAD:TransactionMicroservice/Migrations/20210923102503_initial.cs
                    Id = table.Column<int>(type: "int", nullable: false),
=======
>>>>>>> a83808bc7b9313aea7cd35d3addc0b6e1007d6ec:TransactionMicroservice/Migrations/20210923105231_Initial.cs
=======
>>>>>>> a83808bc7b9313aea7cd35d3addc0b6e1007d6ec:TransactionMicroservice/Migrations/20210923105231_Initial.cs
>>>>>>> a83808bc7b9313aea7cd35d3addc0b6e1007d6ec
                    message = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "TransactionHistories");

            migrationBuilder.DropTable(
                name: "TransactionStatus");
        }
    }
}
