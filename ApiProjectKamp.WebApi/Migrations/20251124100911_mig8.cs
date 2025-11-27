using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiProjectKamp.WebApi.Migrations
{
    public partial class mig8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTasks_Chefs_ChefId",
                table: "EmployeeTasks");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeTasks_ChefId",
                table: "EmployeeTasks");

            migrationBuilder.DropColumn(
                name: "ChefId",
                table: "EmployeeTasks");

            migrationBuilder.AddColumn<string>(
                name: "TaskStatus",
                table: "EmployeeTasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "EmployeeTaskChefs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeTaskId = table.Column<int>(type: "int", nullable: false),
                    ChefId = table.Column<int>(type: "int", nullable: false),
                    RoleInTask = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTaskChefs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeTaskChefs_Chefs_ChefId",
                        column: x => x.ChefId,
                        principalTable: "Chefs",
                        principalColumn: "ChefId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeTaskChefs_EmployeeTasks_EmployeeTaskId",
                        column: x => x.EmployeeTaskId,
                        principalTable: "EmployeeTasks",
                        principalColumn: "EmployeeTaskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTaskChefs_ChefId",
                table: "EmployeeTaskChefs",
                column: "ChefId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTaskChefs_EmployeeTaskId",
                table: "EmployeeTaskChefs",
                column: "EmployeeTaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeTaskChefs");

            migrationBuilder.DropColumn(
                name: "TaskStatus",
                table: "EmployeeTasks");

            migrationBuilder.AddColumn<int>(
                name: "ChefId",
                table: "EmployeeTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTasks_ChefId",
                table: "EmployeeTasks",
                column: "ChefId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTasks_Chefs_ChefId",
                table: "EmployeeTasks",
                column: "ChefId",
                principalTable: "Chefs",
                principalColumn: "ChefId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
