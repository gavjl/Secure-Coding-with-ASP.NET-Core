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
                values: new object[] { new Guid("1abbd06e-a72b-480d-afa6-1586e7eb6da4"), new Guid("8f8afc29-228d-4508-9f7a-7d17c4ae9900") });

            migrationBuilder.InsertData(
                table: "CustomerSurveyResponses",
                columns: new[] { "Id", "SurveyId" },
                values: new object[] { new Guid("4f31e0b4-10ec-4a0f-86c6-726ea2a34d90"), new Guid("8f8afc29-228d-4508-9f7a-7d17c4ae9900") });

            migrationBuilder.InsertData(
                table: "CustomerSurveys",
                columns: new[] { "Id", "SurveyCompleteMessage", "Title" },
                values: new object[] { new Guid("8f8afc29-228d-4508-9f7a-7d17c4ae9900"), "You completed the survey, THANKS!!!", "Staff Survey - Carved Rock" });

            migrationBuilder.InsertData(
                table: "GloboSurveyUserTickets",
                columns: new[] { "Id", "Message", "Title", "UserId" },
                values: new object[] { "a4df7171-f21e-4ce3-a98b-fbc3310f62f0", "I've recently changed my surname from May to Johnson, could you update your system please?", "Name change required", "8f8afc29-228d-4508-9f7a-7d17c4ae9901" });

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
                values: new object[] { new Guid("1806bf4d-c7ad-4a66-a57b-696555c9987b"), "More than 5 years", "How long have you worked at Carved Rock?", new Guid("1abbd06e-a72b-480d-afa6-1586e7eb6da4") });

            migrationBuilder.InsertData(
                table: "SurveyAnswer",
                columns: new[] { "Id", "Answer", "Question", "SurveyResponseId" },
                values: new object[] { new Guid("285d0c21-89bf-461d-9b5b-c92eba210bc1"), "My computer is really slow", "Any comments on how you find working for Carved Rock?", new Guid("1abbd06e-a72b-480d-afa6-1586e7eb6da4") });

            migrationBuilder.InsertData(
                table: "SurveyAnswer",
                columns: new[] { "Id", "Answer", "Question", "SurveyResponseId" },
                values: new object[] { new Guid("3c80744a-8ab3-415a-8043-06cceaf8da75"), "Yes", "Do you enjoy working at Carved Rock?", new Guid("4f31e0b4-10ec-4a0f-86c6-726ea2a34d90") });

            migrationBuilder.InsertData(
                table: "SurveyAnswer",
                columns: new[] { "Id", "Answer", "Question", "SurveyResponseId" },
                values: new object[] { new Guid("44c7cda7-1e08-4f34-88d4-0bd6da36b447"), "It's really cool here!", "Any comments on how you find working for Carved Rock?", new Guid("4f31e0b4-10ec-4a0f-86c6-726ea2a34d90") });

            migrationBuilder.InsertData(
                table: "SurveyAnswer",
                columns: new[] { "Id", "Answer", "Question", "SurveyResponseId" },
                values: new object[] { new Guid("5dfa6f94-b93c-4150-a33a-57c85574bcce"), "No", "Do you enjoy working at Carved Rock?", new Guid("1abbd06e-a72b-480d-afa6-1586e7eb6da4") });

            migrationBuilder.InsertData(
                table: "SurveyAnswer",
                columns: new[] { "Id", "Answer", "Question", "SurveyResponseId" },
                values: new object[] { new Guid("70e42800-d3a3-4f72-a492-3de95ade3acf"), "Less than 1 year", "How long have you worked at Carved Rock?", new Guid("4f31e0b4-10ec-4a0f-86c6-726ea2a34d90") });

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
