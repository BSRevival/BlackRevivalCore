using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlackRevival.APIServer.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserNum = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ReceivePushMsg = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NewPostArrived = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TermsAgree = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Nickname = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TutorialProgress = table.Column<int>(type: "int", nullable: false),
                    Bgm = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SoundEffect = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Lastword = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Watchword = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ActiveCharacterNum = table.Column<long>(type: "bigint", nullable: false),
                    AppLanguageCode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LeaguePoint = table.Column<int>(type: "int", nullable: false),
                    AdViewCount = table.Column<int>(type: "int", nullable: false),
                    MaxAdViewCount = table.Column<int>(type: "int", nullable: false),
                    ActivatedPotentialSkillId = table.Column<int>(type: "int", nullable: false),
                    ResearcherExp = table.Column<int>(type: "int", nullable: false),
                    ResearcherTitleCode = table.Column<int>(type: "int", nullable: false),
                    MatchingCardCode = table.Column<int>(type: "int", nullable: false),
                    Lto = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Ltt = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Lte = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Ltf = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Ltv = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Ltr = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Sigc = table.Column<int>(type: "int", nullable: false),
                    Sigg = table.Column<int>(type: "int", nullable: false),
                    Rtn = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Aps = table.Column<int>(type: "int", nullable: false),
                    League = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserNum);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    CharacterNum = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserNum = table.Column<long>(type: "bigint", nullable: true),
                    UserNickname = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CharacterClass = table.Column<int>(type: "int", nullable: false),
                    CharacterGrade = table.Column<int>(type: "int", nullable: false),
                    ActiveCharacterSkinType = table.Column<int>(type: "int", nullable: false),
                    ActiveLive2D = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EnhanceExp = table.Column<int>(type: "int", nullable: false),
                    CharacterPurchaseType = table.Column<int>(type: "int", nullable: false),
                    RankPlayCount = table.Column<int>(type: "int", nullable: false),
                    RankWinCount = table.Column<int>(type: "int", nullable: false),
                    NormalPlayCount = table.Column<int>(type: "int", nullable: false),
                    NormalWinCount = table.Column<int>(type: "int", nullable: false),
                    TeamNumber = table.Column<int>(type: "int", nullable: false),
                    PotentialSkillId = table.Column<int>(type: "int", nullable: false),
                    Pmn = table.Column<int>(type: "int", nullable: false),
                    Pfr = table.Column<int>(type: "int", nullable: false),
                    Psd = table.Column<int>(type: "int", nullable: false),
                    Host = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CharacterStatus = table.Column<int>(type: "int", nullable: false),
                    ToNormalRemainSeconds = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.CharacterNum);
                    table.ForeignKey(
                        name: "FK_Characters_Users_UserNum",
                        column: x => x.UserNum,
                        principalTable: "Users",
                        principalColumn: "UserNum");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserAssets",
                columns: table => new
                {
                    UserNum = table.Column<long>(type: "bigint", nullable: false),
                    Gold = table.Column<int>(type: "int", nullable: false),
                    Gem = table.Column<int>(type: "int", nullable: false),
                    BearPoint = table.Column<int>(type: "int", nullable: false),
                    Credit = table.Column<int>(type: "int", nullable: false),
                    Mileage = table.Column<int>(type: "int", nullable: false),
                    ExperimentMemory = table.Column<int>(type: "int", nullable: false),
                    TournamentPoint = table.Column<int>(type: "int", nullable: false),
                    TournamentTicket = table.Column<int>(type: "int", nullable: false),
                    VoteTicket = table.Column<int>(type: "int", nullable: false),
                    VoteStamp = table.Column<int>(type: "int", nullable: false),
                    LabyrinthPoint = table.Column<int>(type: "int", nullable: false),
                    AgliaScore = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAssets", x => x.UserNum);
                    table.ForeignKey(
                        name: "FK_UserAssets_Users_UserNum",
                        column: x => x.UserNum,
                        principalTable: "Users",
                        principalColumn: "UserNum",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_UserNum",
                table: "Characters",
                column: "UserNum");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "UserAssets");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
