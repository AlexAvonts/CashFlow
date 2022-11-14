using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CashFlow.Data.Migrations
{
    public partial class FlowTypecolumninFlowtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Flows",
                keyColumn: "Id",
                keyValue: new Guid("696bced8-9716-42b1-924e-8b05a361bd8d"));

            migrationBuilder.AddColumn<string>(
                name: "FlowType",
                table: "Flows",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Flows",
                columns: new[] { "Id", "FlowType", "Value" },
                values: new object[] { new Guid("3eff6823-dd08-4e3e-988d-8f6755acb22f"), "C", 12.300000000000001 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Flows",
                keyColumn: "Id",
                keyValue: new Guid("3eff6823-dd08-4e3e-988d-8f6755acb22f"));

            migrationBuilder.DropColumn(
                name: "FlowType",
                table: "Flows");

            migrationBuilder.InsertData(
                table: "Flows",
                columns: new[] { "Id", "Value" },
                values: new object[] { new Guid("696bced8-9716-42b1-924e-8b05a361bd8d"), 12.300000000000001 });
        }
    }
}
