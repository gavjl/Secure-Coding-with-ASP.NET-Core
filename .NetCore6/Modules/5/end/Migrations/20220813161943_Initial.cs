using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Globomantics.Survey.Migrations
{
    public partial class Initial : Migration
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
                    SurveyCompleteMessage = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerSurveys", x => x.Id);
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
                values: new object[] { new Guid("2a8e0083-3558-49a4-b8a8-9b5a5c801788"), new Guid("8f8afc29-228d-4508-9f7a-7d17c4ae9900") });

            migrationBuilder.InsertData(
                table: "CustomerSurveyResponses",
                columns: new[] { "Id", "SurveyId" },
                values: new object[] { new Guid("4591765c-a4d3-47ac-b0e2-3fc8cdcb3eeb"), new Guid("8f8afc29-228d-4508-9f7a-7d17c4ae9900") });

            migrationBuilder.InsertData(
                table: "CustomerSurveys",
                columns: new[] { "Id", "SurveyCompleteMessage", "Title" },
                values: new object[] { new Guid("8f8afc29-228d-4508-9f7a-7d17c4ae9900"), "You completed the survey, THANKS!!!", "Staff Survey - Carved Rock" });

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
                values: new object[] { new Guid("8f8afc29-228d-4508-9f7a-7d17c4ae9903"), "", "", "Any comments on how you find working for Carved Rock?", new Guid("8f8afc29-228d-4508-9f7a-7d17c4ae9900") });

            migrationBuilder.InsertData(
                table: "SurveyAnswer",
                columns: new[] { "Id", "Answer", "Question", "SurveyResponseId" },
                values: new object[] { new Guid("02690d61-33fb-4d91-9ee0-b2e98bef00bd"), "Yes", "Do you enjoy working at Carved Rock?", new Guid("4591765c-a4d3-47ac-b0e2-3fc8cdcb3eeb") });

            migrationBuilder.InsertData(
                table: "SurveyAnswer",
                columns: new[] { "Id", "Answer", "Question", "SurveyResponseId" },
                values: new object[] { new Guid("41c30f46-0b04-425a-b538-e4d70faede95"), "More than 5 years", "How long have you worked at Carved Rock?", new Guid("2a8e0083-3558-49a4-b8a8-9b5a5c801788") });

            migrationBuilder.InsertData(
                table: "SurveyAnswer",
                columns: new[] { "Id", "Answer", "Question", "SurveyResponseId" },
                values: new object[] { new Guid("a15a3f29-7932-43d0-81ad-b811ba4e2547"), "It's really cool here!", "Any comments on how you find working for Carved Rock?", new Guid("4591765c-a4d3-47ac-b0e2-3fc8cdcb3eeb") });

            migrationBuilder.InsertData(
                table: "SurveyAnswer",
                columns: new[] { "Id", "Answer", "Question", "SurveyResponseId" },
                values: new object[] { new Guid("a694606f-c45f-4654-af87-3c459227f56d"), "Less than 1 year", "How long have you worked at Carved Rock?", new Guid("4591765c-a4d3-47ac-b0e2-3fc8cdcb3eeb") });

            migrationBuilder.InsertData(
                table: "SurveyAnswer",
                columns: new[] { "Id", "Answer", "Question", "SurveyResponseId" },
                values: new object[] { new Guid("ea46a0f3-8435-4dec-860c-8647cee007a2"), "My computer is really slow", "Any comments on how you find working for Carved Rock?", new Guid("2a8e0083-3558-49a4-b8a8-9b5a5c801788") });

            migrationBuilder.InsertData(
                table: "SurveyAnswer",
                columns: new[] { "Id", "Answer", "Question", "SurveyResponseId" },
                values: new object[] { new Guid("fda43275-a995-4e38-90ac-fb5d3df5b934"), "No", "Do you enjoy working at Carved Rock?", new Guid("2a8e0083-3558-49a4-b8a8-9b5a5c801788") });

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
                name: "SurveyAnswer");

            migrationBuilder.DropTable(
                name: "CustomerSurveys");

            migrationBuilder.DropTable(
                name: "CustomerSurveyResponses");
        }
    }
}
