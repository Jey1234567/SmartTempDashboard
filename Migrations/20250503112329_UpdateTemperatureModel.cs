using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartTempDashboard.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTemperatureModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Humid",
                table: "Temperatures",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Humid",
                table: "Temperatures");
        }
    }
}
