using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Globomantics.Survey.Migrations.GlobomanticsSurveyDb
{
    /// <inheritdoc />
    public partial class CreateGlobomanticsSurveyDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerSurveyResponses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SurveyId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerSurveyResponses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerSurveys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    SurveyCompleteMessage = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerSurveys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GloboSurveyUserTickets",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Message = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GloboSurveyUserTickets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SurveyAnswer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SurveyResponseId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Question = table.Column<string>(type: "TEXT", nullable: false),
                    Answer = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyAnswer_CustomerSurveyResponses_SurveyResponseId",
                        column: x => x.SurveyResponseId,
                        principalTable: "CustomerSurveyResponses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerSurveyQuestions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SurveyId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Question = table.Column<string>(type: "TEXT", nullable: false),
                    Answer = table.Column<string>(type: "TEXT", nullable: false),
                    PossibleAnswers = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerSurveyQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerSurveyQuestions_CustomerSurveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "CustomerSurveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CustomerSurveyResponses",
                columns: new[] { "Id", "SurveyId" },
                values: new object[,]
                {
                    { new Guid("5e18547a-dd7b-444a-afb9-87431a1b4db1"), new Guid("8f8afc29-228d-4508-9f7a-7d17c4ae9900") },
                    { new Guid("8647f5bb-cfd4-40ed-bcda-b60e7b4ca60c"), new Guid("8f8afc29-228d-4508-9f7a-7d17c4ae9900") }
                });

            migrationBuilder.InsertData(
                table: "CustomerSurveys",
                columns: new[] { "Id", "SurveyCompleteMessage", "Title" },
                values: new object[] { new Guid("8f8afc29-228d-4508-9f7a-7d17c4ae9900"), "You completed the survey, THANKS!!!", "Staff Survey - Carved Rock" });

            migrationBuilder.InsertData(
                table: "CustomerSurveyQuestions",
                columns: new[] { "Id", "Answer", "PossibleAnswers", "Question", "SurveyId" },
                values: new object[,]
                {
                    { new Guid("8f8afc29-228d-4508-9f7a-7d17c4ae9901"), "", "Less than 1 year|1-5 years|More than 5 years", "How long have you worked at Carved Rock?", new Guid("8f8afc29-228d-4508-9f7a-7d17c4ae9900") },
                    { new Guid("8f8afc29-228d-4508-9f7a-7d17c4ae9902"), "", "Yes|No|Sometimes", "Do you enjoy working at Carved Rock?", new Guid("8f8afc29-228d-4508-9f7a-7d17c4ae9900") },
                    { new Guid("8f8afc29-228d-4508-9f7a-7d17c4ae9903"), "", "", "Any comments on how you find working for Carved Rock?", new Guid("8f8afc29-228d-4508-9f7a-7d17c4ae9900") }
                });

            migrationBuilder.InsertData(
                table: "SurveyAnswer",
                columns: new[] { "Id", "Answer", "Question", "SurveyResponseId" },
                values: new object[,]
                {
                    { new Guid("36a2048c-fe89-42e7-834a-0be5c21354b7"), "My computer is really slow", "Any comments on how you find working for Carved Rock?", new Guid("5e18547a-dd7b-444a-afb9-87431a1b4db1") },
                    { new Guid("43f02312-c461-4558-916f-af9b35b9ccce"), "No", "Do you enjoy working at Carved Rock?", new Guid("5e18547a-dd7b-444a-afb9-87431a1b4db1") },
                    { new Guid("44eddc36-cba7-495c-b709-aae1371d9c8a"), "Yes", "Do you enjoy working at Carved Rock?", new Guid("8647f5bb-cfd4-40ed-bcda-b60e7b4ca60c") },
                    { new Guid("49207441-80d6-4d23-b745-45e9cc039bed"), "It's really cool here!", "Any comments on how you find working for Carved Rock?", new Guid("8647f5bb-cfd4-40ed-bcda-b60e7b4ca60c") },
                    { new Guid("521058ad-2bb9-481d-b9fb-9f78ef16a85a"), "Less than 1 year", "How long have you worked at Carved Rock?", new Guid("8647f5bb-cfd4-40ed-bcda-b60e7b4ca60c") },
                    { new Guid("9be532e2-8830-4f96-9a57-11c126c50620"), "More than 5 years", "How long have you worked at Carved Rock?", new Guid("5e18547a-dd7b-444a-afb9-87431a1b4db1") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSurveyQuestions_SurveyId",
                table: "CustomerSurveyQuestions",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyAnswer_SurveyResponseId",
                table: "SurveyAnswer",
                column: "SurveyResponseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerSurveyQuestions");

            migrationBuilder.DropTable(
                name: "GloboSurveyUserTickets");

            migrationBuilder.DropTable(
                name: "SurveyAnswer");

            migrationBuilder.DropTable(
                name: "CustomerSurveys");

            migrationBuilder.DropTable(
                name: "CustomerSurveyResponses");
        }
    }
}
