using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Globomantics.Survey.Migrations.GlobomanticsSurveyDb
{
    public partial class Questions : Migration
    {
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
                    IsRange = table.Column<bool>(type: "INTEGER", nullable: false),
                    SurveyCompleteMessage = table.Column<string>(type: "TEXT", nullable: false),
                    ExpectedEmailDomain = table.Column<string>(type: "TEXT", nullable: false)
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
                values: new object[] { new Guid("bef44a27-4c67-4532-9746-89b9f52a3ef2"), new Guid("8f8afc29-228d-4508-9f7a-7d17c4ae9900") });

            migrationBuilder.InsertData(
                table: "CustomerSurveyResponses",
                columns: new[] { "Id", "SurveyId" },
                values: new object[] { new Guid("cc0a488f-25b0-4756-b4fc-2ead62896f1a"), new Guid("8f8afc29-228d-4508-9f7a-7d17c4ae9900") });

            migrationBuilder.InsertData(
                table: "CustomerSurveys",
                columns: new[] { "Id", "ExpectedEmailDomain", "IsRange", "SurveyCompleteMessage", "Title" },
                values: new object[] { new Guid("8f8afc29-228d-4508-9f7a-7d17c4ae9000"), "globomantics.com", true, "You completed the survey, THANKS!!!", "Range Survey - Carved Rock" });

            migrationBuilder.InsertData(
                table: "CustomerSurveys",
                columns: new[] { "Id", "ExpectedEmailDomain", "IsRange", "SurveyCompleteMessage", "Title" },
                values: new object[] { new Guid("8f8afc29-228d-4508-9f7a-7d17c4ae9900"), "globomantics.com", false, "You completed the survey, THANKS!!!", "Staff Survey - Carved Rock" });

            migrationBuilder.InsertData(
                table: "GloboSurveyUserTickets",
                columns: new[] { "Id", "Message", "Title", "UserId" },
                values: new object[] { "7d186beb-99c7-45e3-bb6e-fc07954d03a4", "I've recently changed my surname from May to Johnson, could you update your system please?", "Name change required", "8f8afc29-228d-4508-9f7a-7d17c4ae9901" });

            migrationBuilder.InsertData(
                table: "CustomerSurveyQuestions",
                columns: new[] { "Id", "Answer", "PossibleAnswers", "Question", "SurveyId" },
                values: new object[] { new Guid("8f8afc29-228d-4508-9f7a-7d17c4ae9001"), "", "", "Rate us bad - good", new Guid("8f8afc29-228d-4508-9f7a-7d17c4ae9000") });

            migrationBuilder.InsertData(
                table: "CustomerSurveyQuestions",
                columns: new[] { "Id", "Answer", "PossibleAnswers", "Question", "SurveyId" },
                values: new object[] { new Guid("8f8afc29-228d-4508-9f7a-7d17c4ae9901"), "", "Less than 1 year|1-5 years|More than 5 years", "How long have you worked at Carved Rock?", new Guid("8f8afc29-228d-4508-9f7a-7d17c4ae9900") });

            migrationBuilder.InsertData(
                table: "CustomerSurveyQuestions",
                columns: new[] { "Id", "Answer", "PossibleAnswers", "Question", "SurveyId" },
                values: new object[] { new Guid("8f8afc29-228d-4508-9f7a-7d17c4ae9902"), "", "Yes|No|Sometimes", "Do you enjoy working at Carved Rock?", new Guid("8f8afc29-228d-4508-9f7a-7d17c4ae9900") });

            migrationBuilder.InsertData(
                table: "CustomerSurveyQuestions",
                columns: new[] { "Id", "Answer", "PossibleAnswers", "Question", "SurveyId" },
                values: new object[] { new Guid("8f8afc29-228d-4508-9f7a-7d17c4ae9904"), "", "", "Any comments on how you find working for Carved Rock?", new Guid("8f8afc29-228d-4508-9f7a-7d17c4ae9900") });

            migrationBuilder.InsertData(
                table: "SurveyAnswer",
                columns: new[] { "Id", "Answer", "Question", "SurveyResponseId" },
                values: new object[] { new Guid("3cb59ff2-11e2-4c95-8345-a0e759b72ac5"), "My computer is really slow", "Any comments on how you find working for Carved Rock?", new Guid("bef44a27-4c67-4532-9746-89b9f52a3ef2") });

            migrationBuilder.InsertData(
                table: "SurveyAnswer",
                columns: new[] { "Id", "Answer", "Question", "SurveyResponseId" },
                values: new object[] { new Guid("8d188615-e253-4db6-b97b-1bea3d03b112"), "No", "Do you enjoy working at Carved Rock?", new Guid("bef44a27-4c67-4532-9746-89b9f52a3ef2") });

            migrationBuilder.InsertData(
                table: "SurveyAnswer",
                columns: new[] { "Id", "Answer", "Question", "SurveyResponseId" },
                values: new object[] { new Guid("8f878cf3-2723-4cee-b6e3-1b2e4f75bcce"), "It's really cool here!", "Any comments on how you find working for Carved Rock?", new Guid("cc0a488f-25b0-4756-b4fc-2ead62896f1a") });

            migrationBuilder.InsertData(
                table: "SurveyAnswer",
                columns: new[] { "Id", "Answer", "Question", "SurveyResponseId" },
                values: new object[] { new Guid("b38f99b9-1dbc-4358-b7df-d17e05f7cc93"), "Yes", "Do you enjoy working at Carved Rock?", new Guid("cc0a488f-25b0-4756-b4fc-2ead62896f1a") });

            migrationBuilder.InsertData(
                table: "SurveyAnswer",
                columns: new[] { "Id", "Answer", "Question", "SurveyResponseId" },
                values: new object[] { new Guid("c995f2f0-e47e-46e4-90e5-53637bf348b9"), "More than 5 years", "How long have you worked at Carved Rock?", new Guid("bef44a27-4c67-4532-9746-89b9f52a3ef2") });

            migrationBuilder.InsertData(
                table: "SurveyAnswer",
                columns: new[] { "Id", "Answer", "Question", "SurveyResponseId" },
                values: new object[] { new Guid("dd8e213c-df86-4996-9088-4af913a56b16"), "Less than 1 year", "How long have you worked at Carved Rock?", new Guid("cc0a488f-25b0-4756-b4fc-2ead62896f1a") });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSurveyQuestions_SurveyId",
                table: "CustomerSurveyQuestions",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyAnswer_SurveyResponseId",
                table: "SurveyAnswer",
                column: "SurveyResponseId");
        }

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
