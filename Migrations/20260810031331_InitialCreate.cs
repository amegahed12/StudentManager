using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentManager.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DeptId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DeptId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeptId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Departments_DeptId",
                        column: x => x.DeptId,
                        principalTable: "Departments",
                        principalColumn: "DeptId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DeptId", "Name" },
                values: new object[,]
                {
                    { 1, "IT" },
                    { 2, "CS" },
                    { 3, "IS" },
                    { 4, "AI" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "Age", "DeptId", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { 1, "Alexandria", 20, 1, "ahmed@gmail.com", "Ahmed", "123456" },
                    { 2, "Ismailia", 24, 1, "ali@gmail.com", "Ali", "123456" },
                    { 3, "Cairo", 26, 1, "mohamed@gmail.com", "Mohamed", "123456" },
                    { 4, "Ismailia", 22, 2, "salah@gmail.com", "Salah", "123456" },
                    { 5, "Sinai", 27, 2, "ziad@gmail.com", "Ziad", "123456" },
                    { 6, "Ismailia", 29, 2, "mahmoud@gmail.com", "Mahmoud", "123456" },
                    { 7, "Sinai", 21, 3, "osama@gmail.com", "Osama", "123456" },
                    { 8, "Ismailia", 20, 3, "ezz@gmail.com", "Ezz", "123456" },
                    { 9, "Cairo", 24, 4, "mazen@gmail.com", "Mazen", "123456" },
                    { 10, "Sinai", 24, 4, "eid@gmail.com", "Eid", "123456" },
                    { 11, "Ismailia", 28, 4, "hagag@gmail.com", "Hagag", "123456" },
                    { 12, "Cairo", 23, 4, "abdelrahman@gmail.com", "Abdelrahman", "123456" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_DeptId",
                table: "Students",
                column: "DeptId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
