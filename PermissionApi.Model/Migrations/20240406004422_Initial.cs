using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PermissionApi.Model.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PermissionType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    EmployeeFirstName = table.Column<string>(nullable: false),
                    EmployeeLastName = table.Column<string>(nullable: false),
                    PermissionTypeId = table.Column<int>(nullable: false),
                    PermissionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permission_PermissionType_PermissionTypeId",
                        column: x => x.PermissionTypeId,
                        principalTable: "PermissionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PermissionType",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "IsDeleted", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, null, new DateTime(2024, 4, 5, 20, 44, 21, 836, DateTimeKind.Local).AddTicks(3929), "Enfermedad", false, null, null });

            migrationBuilder.InsertData(
                table: "PermissionType",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "IsDeleted", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 2, null, new DateTime(2024, 4, 5, 20, 44, 21, 837, DateTimeKind.Local).AddTicks(65), "Diligencias", false, null, null });

            migrationBuilder.InsertData(
                table: "PermissionType",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "IsDeleted", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 3, null, new DateTime(2024, 4, 5, 20, 44, 21, 837, DateTimeKind.Local).AddTicks(81), "Otro", false, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Permission_PermissionTypeId",
                table: "Permission",
                column: "PermissionTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "PermissionType");
        }
    }
}
