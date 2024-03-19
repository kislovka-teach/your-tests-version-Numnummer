using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddUserData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Login", "Password", "Role" },
                values: new object[,]
                {
                    { "admin", "admin", "couch" },
                    { "login1", "password1", "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Login",
                keyValue: "admin");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Login",
                keyValue: "login1");
        }
    }
}
