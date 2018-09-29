using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleCustomerSurveyApp.Migrations
{
    public partial class CreateInitialTableStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SurveyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuestionText = table.Column<string>(nullable: true),
                    QuestionType = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    SurveyId = table.Column<int>(nullable: true),
                    AnswerA_Answer = table.Column<string>(nullable: true),
                    AnswerA_Count = table.Column<int>(nullable: true),
                    AnswerB_Answer = table.Column<string>(nullable: true),
                    AnswerB_Count = table.Column<int>(nullable: true),
                    AnswerC_Answer = table.Column<string>(nullable: true),
                    AnswerC_Count = table.Column<int>(nullable: true),
                    AnswerD_Answer = table.Column<string>(nullable: true),
                    AnswerD_Count = table.Column<int>(nullable: true),
                    Scale = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_SurveyId",
                table: "Questions",
                column: "SurveyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Surveys");
        }
    }
}
