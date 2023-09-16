using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlackRevival.APIServer.Migrations
{
    /// <inheritdoc />
    public partial class MailV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MailEntryAttachments",
                columns: table => new
                {
                    mailAttachmentNum = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    mailNum = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailEntryAttachments", x => x.mailAttachmentNum);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MailEntries",
                columns: table => new
                {
                    mailNum = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    type = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    content = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status = table.Column<int>(type: "int", nullable: false),
                    senderNum = table.Column<int>(type: "int", nullable: false),
                    senderNickname = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    eventNum = table.Column<int>(type: "int", nullable: false),
                    createDtm = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    readDtm = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    attachmentmailAttachmentNum = table.Column<long>(type: "bigint", nullable: false),
                    expireDtm = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    publishId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    subTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    webLink = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserNum = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailEntries", x => x.mailNum);
                    table.ForeignKey(
                        name: "FK_MailEntries_MailEntryAttachments_attachmentmailAttachmentNum",
                        column: x => x.attachmentmailAttachmentNum,
                        principalTable: "MailEntryAttachments",
                        principalColumn: "mailAttachmentNum",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MailEntries_Users_UserNum",
                        column: x => x.UserNum,
                        principalTable: "Users",
                        principalColumn: "UserNum",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_MailEntries_attachmentmailAttachmentNum",
                table: "MailEntries",
                column: "attachmentmailAttachmentNum");

            migrationBuilder.CreateIndex(
                name: "IX_MailEntries_UserNum",
                table: "MailEntries",
                column: "UserNum");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MailEntries");

            migrationBuilder.DropTable(
                name: "MailEntryAttachments");
        }
    }
}
