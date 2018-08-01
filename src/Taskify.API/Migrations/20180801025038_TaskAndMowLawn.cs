using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Taskify.API.Migrations
{
    public partial class TaskAndMowLawn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    BeginsAt = table.Column<DateTime>(nullable: false),
                    EndedAt = table.Column<DateTime>(nullable: true),
                    AdditionalInformation = table.Column<string>(nullable: true),
                    ClientId = table.Column<int>(nullable: false),
                    WorkerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tasks_Users_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tasks.MowLawn",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BackyardWidth = table.Column<int>(nullable: true),
                    BackyardLength = table.Column<int>(nullable: true),
                    FrontyardWidth = table.Column<int>(nullable: true),
                    FrontyardLength = table.Column<int>(nullable: true),
                    LeftSideWidth = table.Column<int>(nullable: true),
                    LeftSideLength = table.Column<int>(nullable: true),
                    RightSideWidth = table.Column<int>(nullable: true),
                    RightSideLength = table.Column<int>(nullable: true),
                    IDoHaveSawingMachine = table.Column<bool>(nullable: false),
                    IDoNotHaveSawingMachine = table.Column<bool>(nullable: false),
                    TaskId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks.MowLawn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks.MowLawn_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ClientId",
                table: "Tasks",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_WorkerId",
                table: "Tasks",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks.MowLawn_TaskId",
                table: "Tasks.MowLawn",
                column: "TaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks.MowLawn");

            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
