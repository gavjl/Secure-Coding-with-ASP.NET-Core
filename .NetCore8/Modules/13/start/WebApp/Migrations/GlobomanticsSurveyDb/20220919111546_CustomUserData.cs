using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Globomantics.Survey.Migrations.GlobomanticsSurveyDb
{
    public partial class CustomUserData : Migration
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
                values: new object[] { new Guid("880c0329-3a0f-4ed4-8323-21f830c7c9d8"), new Guid("8f8afc29-228d-4508-9f7a-7d17c4ae9900") });

            migrationBuilder.InsertData(
                table: "CustomerSurveyResponses",
                columns: new[] { "Id", "SurveyId" },
                values: new object[] { new Guid("f516687f-b82a-482d-af45-434eb60d08cd"), new Guid("8f8afc29-228d-4508-9f7a-7d17c4ae9900") });

            migrationBuilder.InsertData(
                table: "CustomerSurveys",
                columns: new[] { "Id", "SurveyCompleteMessage", "Title" },
                values: new object[] { new Guid("8f8afc29-228d-4508-9f7a-7d17c4ae9900"), "You completed the survey, THANKS!!!", "Staff Survey - Carved Rock" });

            migrationBuilder.InsertData(
                table: "GloboSurveyUserTickets",
                columns: new[] { "Id", "Message", "Title", "UserId" },
                values: new object[] { "0495090e-02f0-4b28-bea8-74b324a8d51f", "I've recently changed my surname from May to Johnson, could you update your system please?", "Name change required", "8f8afc29-228d-4508-9f7a-7d17c4ae9901" });

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
                values: new object[] { new Guid("297fc79c-e01e-44c8-9076-00fd358f9d6e"), "Yes", "Do you enjoy working at Carved Rock?", new Guid("880c0329-3a0f-4ed4-8323-21f830c7c9d8") });

            migrationBuilder.InsertData(
                table: "SurveyAnswer",
                columns: new[] { "Id", "Answer", "Question", "SurveyResponseId" },
                values: new object[] { new Guid("3b5b2580-8332-4e20-8c29-eecb90862a71"), "My computer is really slow", "Any comments on how you find working for Carved Rock?", new Guid("f516687f-b82a-482d-af45-434eb60d08cd") });

            migrationBuilder.InsertData(
                table: "SurveyAnswer",
                columns: new[] { "Id", "Answer", "Question", "SurveyResponseId" },
                values: new object[] { new Guid("78b48ad5-938c-4a32-b427-0deba8f7bc4f"), "No", "Do you enjoy working at Carved Rock?", new Guid("f516687f-b82a-482d-af45-434eb60d08cd") });

            migrationBuilder.InsertData(
                table: "SurveyAnswer",
                columns: new[] { "Id", "Answer", "Question", "SurveyResponseId" },
                values: new object[] { new Guid("e22657a4-01fe-4e33-91a0-74bbafb28e6e"), "It's really cool here!", "Any comments on how you find working for Carved Rock?", new Guid("880c0329-3a0f-4ed4-8323-21f830c7c9d8") });

            migrationBuilder.InsertData(
                table: "SurveyAnswer",
                columns: new[] { "Id", "Answer", "Question", "SurveyResponseId" },
                values: new object[] { new Guid("f702ec88-697c-4a2d-a174-c5dd1ac21ea2"), "More than 5 years", "How long have you worked at Carved Rock?", new Guid("f516687f-b82a-482d-af45-434eb60d08cd") });

            migrationBuilder.InsertData(
                table: "SurveyAnswer",
                columns: new[] { "Id", "Answer", "Question", "SurveyResponseId" },
                values: new object[] { new Guid("fbde44f5-479b-4836-bb05-77213230ffbb"), "Less than 1 year", "How long have you worked at Carved Rock?", new Guid("880c0329-3a0f-4ed4-8323-21f830c7c9d8") });

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
