using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddUserToCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserLogin",
                table: "Carts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserLogin",
                table: "Carts",
                column: "UserLogin");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Users_UserLogin",
                table: "Carts",
                column: "UserLogin",
                principalTable: "Users",
                principalColumn: "Login",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Users_UserLogin",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_UserLogin",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "UserLogin",
                table: "Carts");
        }
    }
}
