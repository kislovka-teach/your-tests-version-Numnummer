using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddTrainingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Trainings",
                columns: new[] { "Id", "Description", "Level", "Name" },
                values: new object[] { 1, "Hello this is description", 1, "best training" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trainings",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
