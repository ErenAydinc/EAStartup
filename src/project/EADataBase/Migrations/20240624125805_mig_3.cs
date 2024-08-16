using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EADataBase.Migrations
{
    /// <inheritdoc />
    public partial class mig_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OperationClaim",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 24, 15, 58, 4, 893, DateTimeKind.Local).AddTicks(5027));

            migrationBuilder.UpdateData(
                table: "UserOperationClaim",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 24, 15, 58, 4, 894, DateTimeKind.Local).AddTicks(3955));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2024, 6, 24, 15, 58, 4, 891, DateTimeKind.Local).AddTicks(4733), "$argon2id$v=19$m=65536,t=3,p=1$n2IV32kcUgooZAyT51lmgg$Juesl2yYM523aMQtMAjOp6SWmyhNdMmszgV5yNTeaAI" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OperationClaim",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 29, 17, 40, 10, 510, DateTimeKind.Local).AddTicks(3636));

            migrationBuilder.UpdateData(
                table: "UserOperationClaim",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 5, 29, 17, 40, 10, 510, DateTimeKind.Local).AddTicks(9550));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2024, 5, 29, 17, 40, 10, 509, DateTimeKind.Local).AddTicks(7673), "12345" });
        }
    }
}
