using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace housewarming78.Migrations
{
    /// <inheritdoc />
    public partial class __initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "449dafa9-2dbf-4c22-9497-dcba35fea728");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UserName" },
                values: new object[] { "792e881e-b6ab-4517-bb92-0602e6fedc73", "AQAAAAEAACcQAAAAEIUOpNl5Dk6Dz+uteq22cfoNWhornle8QGtM8iNuwtMYYilmRCYoiEcarZzcFKCP/Q==", "ct03268" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "e813c006-ef5c-42a0-950c-f6525dae31d1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UserName" },
                values: new object[] { "665aead8-0d3c-4820-957a-7391c7b2a32d", "AQAAAAEAACcQAAAAEAcV8zd5t/NF2/EnCeN0QupLN4c6dL4dHT5HHhi08O064GTKl59bT/R58oPIff00eg==", "admin" });
        }
    }
}
