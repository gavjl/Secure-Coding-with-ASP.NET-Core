using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Globomantics.Survey.Migrations.IdentityDb
{
    public partial class CreateUsersRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6e6e3afa-b637-4ab7-a5c5-2c0156c945fb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c7a39a22-06f1-4619-a12b-14fa430144bb");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2fd3e41b-ef99-460a-87e1-87f50d6dd023", 0, "65a027be-b1f0-4840-833e-e67ba9f1912d", "Admin@globomantics.com", true, false, null, "ADMIN@GLOBOMANTICS.COM", "ADMIN@GLOBOMANTICS.COM", "AQAAAAEAACcQAAAAEIU2LnluIinHw1eS+WQ5MYWPyJJKIWP2kplL8TQSMaGQvp7Hy7KXhYd5hRFhafvIxw==", null, false, "52bf8711-990b-4f52-be17-3b0721fbfc2c", false, "Admin@globomantics.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7a68bfb1-fa87-4055-96f2-2679cc43d2b0", 0, "d2818c8b-2a72-4a8c-afc0-5548fd12f7fb", "SuperAdmin@globomantics.com", true, false, null, "SUPERADMIN@GLOBOMANTICS.COM", "SUPERADMIN@GLOBOMANTICS.COM", "AQAAAAEAACcQAAAAEMT75gd1Y/jQw2LRkSnfsaSbiS9do9OA7xMRQrpdGiAB3EDS4pPPn7Aol15YmRrpzw==", null, false, "51cea1d1-4cc4-46df-85a1-6a3bf71f761a", false, "SuperAdmin@globomantics.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6e6e3afa-b637-4ab7-a5c5-2c0156c945fb", 0, "18844320-9dd3-4c94-a4b7-3ca0d7c965be", "Admin@globomantics.com", true, false, null, "ADMIN@GLOBOMANTICS.COM", "ADMIN@GLOBOMANTICS.COM", "AQAAAAEAACcQAAAAEHksbvroiAXLPF4CYD0hM7+vc+XJjA8EyhfVFcNDG/wTf58ofCO+XinK1lQMpiLmeA==", null, false, "6aadb14f-1995-45d5-aa12-a6ad72898161", false, "Admin@globomantics.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c7a39a22-06f1-4619-a12b-14fa430144bb", 0, "51e3cd45-aff7-4cd1-a04e-cba80c6df836", "SuperAdmin@globomantics.com", true, false, null, "SUPERADMIN@GLOBOMANTICS.COM", "SUPERADMIN@GLOBOMANTICS.COM", "AQAAAAEAACcQAAAAEGt4ousyFyz3Z7PKTVtnG09CtXhnp+GdGaXOrQ79521bvB2kT9rsZ8DQFp2SdKkpyQ==", null, false, "5ca230ce-9683-4406-82a9-c918743e34f0", false, "SuperAdmin@globomantics.com" });
        }
    }
}
