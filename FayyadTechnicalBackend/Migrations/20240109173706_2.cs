using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FayyadTechnicalBackend.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Employees_EmployeesId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_EmployeesId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "EmployeesId",
                table: "Transactions");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Transactions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_EmployeeId",
                table: "Transactions",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Employees_EmployeeId",
                table: "Transactions",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Employees_EmployeeId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_EmployeeId",
                table: "Transactions");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeesId",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_EmployeesId",
                table: "Transactions",
                column: "EmployeesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Employees_EmployeesId",
                table: "Transactions",
                column: "EmployeesId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
