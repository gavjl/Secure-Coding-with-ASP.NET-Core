using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Globomantics.Survey.Migrations.IdentityDb
{
    public partial class CreateUsersClaim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f40bc981-4a20-4edf-945b-681b98424c7a", "a5ffd767-bcc0-4ec1-98a5-02991086f75b" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64b6c09d-6ac9-42c4-a3c6-5c72aa61efe2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f40bc981-4a20-4edf-945b-681b98424c7a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a5ffd767-bcc0-4ec1-98a5-02991086f75b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9eafa2c9-03cb-4878-b63c-81c7254c32b5", "1", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8516e0b6-aaf7-4086-b2b8-60a595e3d62c", 0, "e9e3293b-53a1-435c-b242-e6c775ad6f68", "Admin@globomantics.com", true, false, null, "ADMIN@GLOBOMANTICS.COM", "ADMIN@GLOBOMANTICS.COM", "AQAAAAEAACcQAAAAEFsQwWOquL/Xs5+pWqAM7lYY6S45LhRFvkT53EOHdSiWQIpHFKcQsXy5ON8sbKiEoQ==", null, false, "495cb088-b1ea-476d-ae81-2c5ba6bfb42a", false, "Admin@globomantics.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b0a6b4d1-900d-4533-8e5a-94db8bf604e9", 0, "b13621c2-3e11-4aca-a5d2-5920a654bcd6", "SuperAdmin@globomantics.com", true, false, null, "SUPERADMIN@GLOBOMANTICS.COM", "SUPERADMIN@GLOBOMANTICS.COM", "AQAAAAEAACcQAAAAEFX1iBtMYqGIA8GXpqpWAFOR6vggxp0+oq1yTeDWDV2hHGZkQrrYDC6VqtHVCQ126g==", null, false, "ed46c994-73ac-466c-8765-66b2319719b6", false, "SuperAdmin@globomantics.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { 1, "IsManager", "true", "b0a6b4d1-900d-4533-8e5a-94db8bf604e9" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9eafa2c9-03cb-4878-b63c-81c7254c32b5", "8516e0b6-aaf7-4086-b2b8-60a595e3d62c" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9eafa2c9-03cb-4878-b63c-81c7254c32b5", "b0a6b4d1-900d-4533-8e5a-94db8bf604e9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9eafa2c9-03cb-4878-b63c-81c7254c32b5", "8516e0b6-aaf7-4086-b2b8-60a595e3d62c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9eafa2c9-03cb-4878-b63c-81c7254c32b5", "b0a6b4d1-900d-4533-8e5a-94db8bf604e9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9eafa2c9-03cb-4878-b63c-81c7254c32b5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8516e0b6-aaf7-4086-b2b8-60a595e3d62c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b0a6b4d1-900d-4533-8e5a-94db8bf604e9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f40bc981-4a20-4edf-945b-681b98424c7a", "1", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "64b6c09d-6ac9-42c4-a3c6-5c72aa61efe2", 0, "ca53a0c5-bfc3-414d-ada0-eed03fc4d414", "SuperAdmin@globomantics.com", true, false, null, "SUPERADMIN@GLOBOMANTICS.COM", "SUPERADMIN@GLOBOMANTICS.COM", "AQAAAAEAACcQAAAAEEXQKgsiwsNrbYawW7TAruB0DO4uKca3zAbmWCPm4F6Ff11ykGW0XCr82g+duOxinQ==", null, false, "331e52ab-d2f4-4e86-8845-15fadcf72e57", false, "SuperAdmin@globomantics.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a5ffd767-bcc0-4ec1-98a5-02991086f75b", 0, "50a18e95-23ca-4644-ac3f-68d391e3d591", "Admin@globomantics.com", true, false, null, "ADMIN@GLOBOMANTICS.COM", "ADMIN@GLOBOMANTICS.COM", "AQAAAAEAACcQAAAAEAfqUoXfAnljLcV7onqecCLecZJ135rejlVl4enIhiO5W4+2bqRX94C8pbleapDIfQ==", null, false, "5edb41df-cf21-4c83-acbe-30dff3499399", false, "Admin@globomantics.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f40bc981-4a20-4edf-945b-681b98424c7a", "a5ffd767-bcc0-4ec1-98a5-02991086f75b" });
        }
    }
}
