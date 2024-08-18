using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShopping.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeModelCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    EmployeeDOB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeMobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EmployeeAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeJoinDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Employee", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "tbl_Employee",
                columns: new[] { "Id", "EmployeeAddress", "EmployeeDOB", "EmployeeId", "EmployeeJoinDate", "EmployeeMobile", "EmployeeName" },
                values: new object[] { 1, "chennai", "20-09-90", 101, "29-3.2013", "67800008900", "sudhar" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Employee");
        }
    }
}
