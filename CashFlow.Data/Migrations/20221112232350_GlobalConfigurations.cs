using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CashFlow.Data.Migrations
{
    public partial class GlobalConfigurations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Flows",
                keyColumn: "Id",
                keyValue: new Guid("32ace793-15ee-4830-bf6a-496bbb486bfb"));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Flows",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Flows",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 12, 20, 23, 49, 701, DateTimeKind.Local).AddTicks(7103),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "Flows",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "FlowType", "Value" },
                values: new object[] { new Guid("022c5946-ba72-4706-9d7d-5015dd574978"), new DateTime(2022, 11, 12, 20, 23, 49, 709, DateTimeKind.Local).AddTicks(1180), null, "C", 12.300000000000001 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Flows",
                keyColumn: "Id",
                keyValue: new Guid("022c5946-ba72-4706-9d7d-5015dd574978"));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Flows",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Flows",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 11, 12, 20, 23, 49, 701, DateTimeKind.Local).AddTicks(7103));

            migrationBuilder.InsertData(
                table: "Flows",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "FlowType", "IsDeleted", "Value" },
                values: new object[] { new Guid("32ace793-15ee-4830-bf6a-496bbb486bfb"), new DateTime(2022, 11, 12, 19, 5, 52, 228, DateTimeKind.Local).AddTicks(6465), null, "C", false, 12.300000000000001 });
        }
    }
}
