using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Globomantics.Survey.Migrations.GlobomanticsSurveyDb
{
    /// <inheritdoc />
    public partial class CustomUserData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SurveyAnswer",
                keyColumn: "Id",
                keyValue: new Guid("02690d61-33fb-4d91-9ee0-b2e98bef00bd"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswer",
                keyColumn: "Id",
                keyValue: new Guid("41c30f46-0b04-425a-b538-e4d70faede95"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswer",
                keyColumn: "Id",
                keyValue: new Guid("a15a3f29-7932-43d0-81ad-b811ba4e2547"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswer",
                keyColumn: "Id",
                keyValue: new Guid("a694606f-c45f-4654-af87-3c459227f56d"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswer",
                keyColumn: "Id",
                keyValue: new Guid("ea46a0f3-8435-4dec-860c-8647cee007a2"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswer",
                keyColumn: "Id",
                keyValue: new Guid("fda43275-a995-4e38-90ac-fb5d3df5b934"));

            migrationBuilder.DeleteData(
                table: "CustomerSurveyResponses",
                keyColumn: "Id",
                keyValue: new Guid("2a8e0083-3558-49a4-b8a8-9b5a5c801788"));

            migrationBuilder.DeleteData(
                table: "CustomerSurveyResponses",
                keyColumn: "Id",
                keyValue: new Guid("4591765c-a4d3-47ac-b0e2-3fc8cdcb3eeb"));

            migrationBuilder.InsertData(
                table: "CustomerSurveyResponses",
                columns: new[] { "Id", "SurveyId" },
                values: new object[,]
                {
                    { new Guid("de174fb5-3671-470f-b84d-c529971ddfd4"), new Guid("8f8afc29-228d-4508-9f7a-7d17c4ae9900") },
                    { new Guid("e6e91a64-57a6-42fc-8898-c486d7375ed0"), new Guid("8f8afc29-228d-4508-9f7a-7d17c4ae9900") }
                });

            migrationBuilder.InsertData(
                table: "SurveyAnswer",
                columns: new[] { "Id", "Answer", "Question", "SurveyResponseId" },
                values: new object[,]
                {
                    { new Guid("2afdf24e-f422-491e-9dfd-0e6c0dfdfa17"), "Yes", "Do you enjoy working at Carved Rock?", new Guid("e6e91a64-57a6-42fc-8898-c486d7375ed0") },
                    { new Guid("2d001c19-d3ed-4adb-ad9d-1c14361e8a09"), "No", "Do you enjoy working at Carved Rock?", new Guid("de174fb5-3671-470f-b84d-c529971ddfd4") },
                    { new Guid("465504e2-a5fc-4700-9d3e-0a5a0f027ccc"), "Less than 1 year", "How long have you worked at Carved Rock?", new Guid("e6e91a64-57a6-42fc-8898-c486d7375ed0") },
                    { new Guid("6555b63d-fa18-4c21-9913-f19cb3484618"), "My computer is really slow", "Any comments on how you find working for Carved Rock?", new Guid("de174fb5-3671-470f-b84d-c529971ddfd4") },
                    { new Guid("c257e3a4-4196-4ba8-9b51-26d7721cb1b6"), "It's really cool here!", "Any comments on how you find working for Carved Rock?", new Guid("e6e91a64-57a6-42fc-8898-c486d7375ed0") },
                    { new Guid("da611407-4e4c-4383-b5b6-40fef6a1ae05"), "More than 5 years", "How long have you worked at Carved Rock?", new Guid("de174fb5-3671-470f-b84d-c529971ddfd4") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SurveyAnswer",
                keyColumn: "Id",
                keyValue: new Guid("2afdf24e-f422-491e-9dfd-0e6c0dfdfa17"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswer",
                keyColumn: "Id",
                keyValue: new Guid("2d001c19-d3ed-4adb-ad9d-1c14361e8a09"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswer",
                keyColumn: "Id",
                keyValue: new Guid("465504e2-a5fc-4700-9d3e-0a5a0f027ccc"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswer",
                keyColumn: "Id",
                keyValue: new Guid("6555b63d-fa18-4c21-9913-f19cb3484618"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswer",
                keyColumn: "Id",
                keyValue: new Guid("c257e3a4-4196-4ba8-9b51-26d7721cb1b6"));

            migrationBuilder.DeleteData(
                table: "SurveyAnswer",
                keyColumn: "Id",
                keyValue: new Guid("da611407-4e4c-4383-b5b6-40fef6a1ae05"));

            migrationBuilder.DeleteData(
                table: "CustomerSurveyResponses",
                keyColumn: "Id",
                keyValue: new Guid("de174fb5-3671-470f-b84d-c529971ddfd4"));

            migrationBuilder.DeleteData(
                table: "CustomerSurveyResponses",
                keyColumn: "Id",
                keyValue: new Guid("e6e91a64-57a6-42fc-8898-c486d7375ed0"));

            migrationBuilder.InsertData(
                table: "CustomerSurveyResponses",
                columns: new[] { "Id", "SurveyId" },
                values: new object[,]
                {
                    { new Guid("2a8e0083-3558-49a4-b8a8-9b5a5c801788"), new Guid("8f8afc29-228d-4508-9f7a-7d17c4ae9900") },
                    { new Guid("4591765c-a4d3-47ac-b0e2-3fc8cdcb3eeb"), new Guid("8f8afc29-228d-4508-9f7a-7d17c4ae9900") }
                });

            migrationBuilder.InsertData(
                table: "SurveyAnswer",
                columns: new[] { "Id", "Answer", "Question", "SurveyResponseId" },
                values: new object[,]
                {
                    { new Guid("02690d61-33fb-4d91-9ee0-b2e98bef00bd"), "Yes", "Do you enjoy working at Carved Rock?", new Guid("4591765c-a4d3-47ac-b0e2-3fc8cdcb3eeb") },
                    { new Guid("41c30f46-0b04-425a-b538-e4d70faede95"), "More than 5 years", "How long have you worked at Carved Rock?", new Guid("2a8e0083-3558-49a4-b8a8-9b5a5c801788") },
                    { new Guid("a15a3f29-7932-43d0-81ad-b811ba4e2547"), "It's really cool here!", "Any comments on how you find working for Carved Rock?", new Guid("4591765c-a4d3-47ac-b0e2-3fc8cdcb3eeb") },
                    { new Guid("a694606f-c45f-4654-af87-3c459227f56d"), "Less than 1 year", "How long have you worked at Carved Rock?", new Guid("4591765c-a4d3-47ac-b0e2-3fc8cdcb3eeb") },
                    { new Guid("ea46a0f3-8435-4dec-860c-8647cee007a2"), "My computer is really slow", "Any comments on how you find working for Carved Rock?", new Guid("2a8e0083-3558-49a4-b8a8-9b5a5c801788") },
                    { new Guid("fda43275-a995-4e38-90ac-fb5d3df5b934"), "No", "Do you enjoy working at Carved Rock?", new Guid("2a8e0083-3558-49a4-b8a8-9b5a5c801788") }
                });
        }
    }
}
