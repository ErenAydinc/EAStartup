using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EADataBase.Migrations
{
    /// <inheritdoc />
    public partial class mig_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoggeableRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CommandName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoggeableRequests", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "OperationClaim",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 28, 14, 0, 29, 848, DateTimeKind.Local).AddTicks(7293));

            migrationBuilder.UpdateData(
                table: "UserOperationClaim",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 6, 28, 14, 0, 29, 849, DateTimeKind.Local).AddTicks(4157));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Password" },
                values: new object[] { new DateTime(2024, 6, 28, 14, 0, 29, 847, DateTimeKind.Local).AddTicks(1034), "$argon2id$v=19$m=65536,t=3,p=1$SU4wn/Lx8SkKhmpNhLGiwQ$M5y9dzXv5K8ePq0YnnB4cz3PVt3w9f+V5kPGFQL1mDY" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoggeableRequests");

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
    }
}
