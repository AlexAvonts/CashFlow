using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CashFlow.Data.Migrations
{
    public partial class UpdatingDefaultFlow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Flows",
                keyColumn: "Id",
                keyValue: new Guid("a6ada567-22c5-43e9-8480-1fabdda8e5fa"));

            migrationBuilder.InsertData(
                table: "Flows",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "FlowType", "IsDeleted", "Value" },
                values: new object[] { new Guid("32ace793-15ee-4830-bf6a-496bbb486bfb"), new DateTime(), null, "C", false, 12.300000000000001 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Flows",
                keyColumn: "Id",
                keyValue: new Guid("32ace793-15ee-4830-bf6a-496bbb486bfb"));

            migrationBuilder.InsertData(
                table: "Flows",
                columns: new[] { "Id", "DateCreated", "DateUpdated", "FlowType", "IsDeleted", "Value" },
                values: new object[] { new Guid("a6ada567-22c5-43e9-8480-1fabdda8e5fa"), new DateTime(), null, "C", false, 12.300000000000001 });
        }
    }
}
