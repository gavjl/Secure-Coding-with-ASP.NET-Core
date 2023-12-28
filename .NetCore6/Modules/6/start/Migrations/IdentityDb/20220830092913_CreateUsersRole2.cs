using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Globomantics.Survey.Migrations.IdentityDb
{
    public partial class CreateUsersRole2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2fd3e41b-ef99-460a-87e1-87f50d6dd023");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a68bfb1-fa87-4055-96f2-2679cc43d2b0");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2fd3e41b-ef99-460a-87e1-87f50d6dd023", 0, "65a027be-b1f0-4840-833e-e67ba9f1912d", "Admin@globomantics.com", true, false, null, "ADMIN@GLOBOMANTICS.COM", "ADMIN@GLOBOMANTICS.COM", "AQAAAAEAACcQAAAAEIU2LnluIinHw1eS+WQ5MYWPyJJKIWP2kplL8TQSMaGQvp7Hy7KXhYd5hRFhafvIxw==", null, false, "52bf8711-990b-4f52-be17-3b0721fbfc2c", false, "Admin@globomantics.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7a68bfb1-fa87-4055-96f2-2679cc43d2b0", 0, "d2818c8b-2a72-4a8c-afc0-5548fd12f7fb", "SuperAdmin@globomantics.com", true, false, null, "SUPERADMIN@GLOBOMANTICS.COM", "SUPERADMIN@GLOBOMANTICS.COM", "AQAAAAEAACcQAAAAEMT75gd1Y/jQw2LRkSnfsaSbiS9do9OA7xMRQrpdGiAB3EDS4pPPn7Aol15YmRrpzw==", null, false, "51cea1d1-4cc4-46df-85a1-6a3bf71f761a", false, "SuperAdmin@globomantics.com" });
        }
    }
}
