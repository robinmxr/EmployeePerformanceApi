using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeePerformanceApi.Migrations
{
    /// <inheritdoc />
    public partial class Auth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MetricName",
                table: "Metrics");

            migrationBuilder.RenameColumn(
                name: "Score",
                table: "Metrics",
                newName: "TotalWorkHours");

            migrationBuilder.AddColumn<double>(
                name: "AvgDailyWorkHours",
                table: "Metrics",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ContributionScore",
                table: "Metrics",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "DaysPresent",
                table: "Metrics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LeaveTaken",
                table: "Metrics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "OnTimeCompletionRate",
                table: "Metrics",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ProjectsWorkedOn",
                table: "Metrics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TasksCompleted",
                table: "Metrics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropColumn(
                name: "AvgDailyWorkHours",
                table: "Metrics");

            migrationBuilder.DropColumn(
                name: "ContributionScore",
                table: "Metrics");

            migrationBuilder.DropColumn(
                name: "DaysPresent",
                table: "Metrics");

            migrationBuilder.DropColumn(
                name: "LeaveTaken",
                table: "Metrics");

            migrationBuilder.DropColumn(
                name: "OnTimeCompletionRate",
                table: "Metrics");

            migrationBuilder.DropColumn(
                name: "ProjectsWorkedOn",
                table: "Metrics");

            migrationBuilder.DropColumn(
                name: "TasksCompleted",
                table: "Metrics");

            migrationBuilder.RenameColumn(
                name: "TotalWorkHours",
                table: "Metrics",
                newName: "Score");

            migrationBuilder.AddColumn<string>(
                name: "MetricName",
                table: "Metrics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
