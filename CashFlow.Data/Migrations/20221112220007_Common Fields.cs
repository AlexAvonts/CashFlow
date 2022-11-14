using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CashFlow.Data.Migrations
{
    public partial class CommonFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Flows",
                keyColumn: "Id",
                keyValue: new Guid("3eff6823-dd08-4e3e-988d-8f6755acb22f"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Flows",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "Flows",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Flows",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Flows",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "FlowType", "IsDeleted", "Value" },
                values: new object[] { new Guid("61ae05b8-5236-498c-8732-0a70681b6bad"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C", false, 12.300000000000001 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Flows",
                keyColumn: "Id",
                keyValue: new Guid("61ae05b8-5236-498c-8732-0a70681b6bad"));

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Flows");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "Flows");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Flows");

            migrationBuilder.InsertData(
                table: "Flows",
                columns: new[] { "Id", "FlowType", "Value" },
                values: new object[] { new Guid("3eff6823-dd08-4e3e-988d-8f6755acb22f"), "C", 12.300000000000001 });
        }
    }
}
