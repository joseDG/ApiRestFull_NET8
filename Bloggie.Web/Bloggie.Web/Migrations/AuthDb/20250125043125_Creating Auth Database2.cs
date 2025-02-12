using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bloggie.Web.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class CreatingAuthDatabase2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "472ba632-6133-44a1-b158-6c10bd7d850d", 0, "138c4ac5-2ac5-4ef2-a969-1f21b5d34825", "superadmin@bloggie.com", false, false, null, "SUPERADMIN@BLOGGIE.COM", "SUPERADMIN@BLOGGIE.COM", "AQAAAAIAAYagAAAAEMHhUXMEmKnUX/qe/CpdaoyKL55Qx//33aCdznehEzpHvzR05oP4668oHUI3Y4SbQQ==", null, false, "06e5e25e-3e1a-4ea0-8c51-38b334e9e089", false, "superadmin@bloggie.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "472ba632-6133-44a1-b158-6c10bd7d850d");
        }
    }
}
