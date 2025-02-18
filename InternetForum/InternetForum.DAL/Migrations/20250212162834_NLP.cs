using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InternetForum.DAL.Migrations
{
    public partial class NLP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserInterests",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Weight = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInterests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Avatar = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: true),
                    UserName = table.Column<string>(maxLength: 30, nullable: false),
                    Bio = table.Column<string>(maxLength: 200, nullable: true),
                    FirstName = table.Column<string>(maxLength: 35, nullable: true),
                    LastName = table.Column<string>(maxLength: 35, nullable: true),
                    RegisteredAt = table.Column<DateTime>(nullable: false),
                    BirthDay = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    Header = table.Column<string>(maxLength: 50, nullable: false),
                    Text = table.Column<string>(maxLength: 300, nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserInterest",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    InterestId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInterest", x => new { x.UserId, x.InterestId });
                    table.ForeignKey(
                        name: "FK_UserInterest_UserInterests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "UserInterests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserInterest_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CommentText = table.Column<string>(maxLength: 140, nullable: false),
                    PostId = table.Column<string>(nullable: false),
                    CommentId = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PostReactions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    PostId = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    IsLiked = table.Column<bool>(nullable: false),
                    ReactedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostReactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostReactions_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostReactions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CommentReactions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CommentId = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    IsLiked = table.Column<bool>(nullable: false),
                    ReactedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentReactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentReactions_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentReactions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PostId = table.Column<string>(nullable: false),
                    CommentId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Topics_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Topics_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostTopic",
                columns: table => new
                {
                    PostId = table.Column<string>(nullable: false),
                    TopicId = table.Column<string>(nullable: false),
                    MyPropertyTopicId = table.Column<string>(nullable: true),
                    MyPropertyPostId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTopic", x => new { x.TopicId, x.PostId });
                    table.ForeignKey(
                        name: "FK_PostTopic_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PostTopic_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTopic_PostTopic_MyPropertyTopicId_MyPropertyPostId",
                        columns: x => new { x.MyPropertyTopicId, x.MyPropertyPostId },
                        principalTable: "PostTopic",
                        principalColumns: new[] { "TopicId", "PostId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Avatar", "Bio", "BirthDay", "FirstName", "LastName", "RegisteredAt", "UserName" },
                values: new object[,]
                {
                    { "1", null, "https://zoloft100.com/wp-content/uploads/2021/10/Top-5-Benefits-of-Being-an-Electrician-UEI-College.jpg", "Electrical Engineer", new DateTime(1990, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anton", "Gerashenko", new DateTime(2025, 2, 12, 16, 28, 33, 742, DateTimeKind.Local).AddTicks(53), "anton_1990" },
                    { "2", null, null, "18 years", null, "Dmitro", null, new DateTime(2025, 2, 12, 16, 28, 33, 751, DateTimeKind.Local).AddTicks(1485), "dmidro" },
                    { "3", null, null, null, new DateTime(2000, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2025, 2, 12, 16, 28, 33, 751, DateTimeKind.Local).AddTicks(1607), "user1984" },
                    { "4", null, null, "The best chef in Iceland", null, "bad", null, new DateTime(2025, 2, 12, 16, 28, 33, 751, DateTimeKind.Local).AddTicks(1627), "Have_A_Nice_Day" },
                    { "5", null, null, null, new DateTime(1999, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2025, 2, 12, 16, 28, 33, 751, DateTimeKind.Local).AddTicks(1635), "mike_2002" },
                    { "6", null, null, null, new DateTime(2002, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Danil", null, new DateTime(2025, 2, 12, 16, 28, 33, 751, DateTimeKind.Local).AddTicks(1642), "danil_owner" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CreatedAt", "Header", "Text", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { "1", new DateTime(2025, 2, 12, 16, 28, 33, 753, DateTimeKind.Local).AddTicks(2202), "Summer holidays", "Tell about your best summer holidays", new DateTime(2025, 2, 12, 16, 38, 33, 753, DateTimeKind.Local).AddTicks(2644), "1" },
                    { "5", new DateTime(2025, 8, 16, 16, 28, 33, 753, DateTimeKind.Local).AddTicks(4334), "Test post for updating", "Test text", null, "2" },
                    { "2", new DateTime(2025, 5, 13, 16, 28, 33, 753, DateTimeKind.Local).AddTicks(4192), "Winter holidays", "Tell about your best winter holidays", null, "3" },
                    { "4", new DateTime(2025, 8, 13, 16, 28, 33, 753, DateTimeKind.Local).AddTicks(4324), "Test post for deleting", "Test text", null, "4" },
                    { "3", new DateTime(2025, 8, 11, 16, 28, 33, 753, DateTimeKind.Local).AddTicks(4313), "Autumn holidays", "Tell about your best Autumn holidays", null, "5" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentId", "CommentText", "CreatedAt", "PostId", "UserId" },
                values: new object[,]
                {
                    { "1", null, "My last summer holidays was the best", new DateTime(2025, 2, 12, 17, 28, 33, 754, DateTimeKind.Local).AddTicks(845), "1", "1" },
                    { "4", "1", "My last summer holidays was the best too. Thank you!", new DateTime(2025, 2, 12, 17, 28, 33, 754, DateTimeKind.Local).AddTicks(1673), "1", "5" },
                    { "2", null, "My last winter holidays was the best", new DateTime(2025, 5, 14, 16, 28, 33, 754, DateTimeKind.Local).AddTicks(1627), "2", "2" },
                    { "5", "2", "My last winter holidays was the best too. It was good time", new DateTime(2025, 5, 14, 16, 28, 33, 754, DateTimeKind.Local).AddTicks(1680), "2", "4" },
                    { "6", null, "My last winter holidays was the best too. It was the best time", new DateTime(2025, 5, 14, 16, 28, 33, 754, DateTimeKind.Local).AddTicks(1687), "2", "1" },
                    { "3", null, "My last autumn holidays was the best", new DateTime(2025, 8, 12, 16, 28, 33, 754, DateTimeKind.Local).AddTicks(1666), "3", "3" }
                });

            migrationBuilder.InsertData(
                table: "PostReactions",
                columns: new[] { "Id", "IsLiked", "PostId", "ReactedAt", "UserId" },
                values: new object[,]
                {
                    { "1", true, "1", new DateTime(2025, 2, 12, 17, 28, 33, 754, DateTimeKind.Local).AddTicks(8945), "1" },
                    { "2", false, "1", new DateTime(2025, 2, 12, 17, 28, 33, 754, DateTimeKind.Local).AddTicks(9294), "2" },
                    { "7", false, "1", new DateTime(2025, 2, 12, 17, 28, 33, 754, DateTimeKind.Local).AddTicks(9341), "5" },
                    { "8", true, "1", new DateTime(2025, 2, 12, 17, 28, 33, 754, DateTimeKind.Local).AddTicks(9347), "4" },
                    { "3", true, "2", new DateTime(2025, 5, 14, 16, 28, 33, 754, DateTimeKind.Local).AddTicks(9314), "3" },
                    { "6", true, "2", new DateTime(2025, 5, 4, 16, 28, 33, 754, DateTimeKind.Local).AddTicks(9335), "4" },
                    { "10", false, "2", new DateTime(2025, 5, 14, 16, 28, 33, 754, DateTimeKind.Local).AddTicks(9360), "2" },
                    { "4", true, "3", new DateTime(2025, 8, 12, 16, 28, 33, 754, DateTimeKind.Local).AddTicks(9322), "3" },
                    { "5", false, "3", new DateTime(2025, 8, 12, 16, 28, 33, 754, DateTimeKind.Local).AddTicks(9328), "4" },
                    { "9", false, "3", new DateTime(2025, 8, 12, 16, 28, 33, 754, DateTimeKind.Local).AddTicks(9353), "5" }
                });

            migrationBuilder.InsertData(
                table: "CommentReactions",
                columns: new[] { "Id", "CommentId", "IsLiked", "ReactedAt", "UserId" },
                values: new object[] { "1", "1", true, new DateTime(2025, 2, 12, 18, 28, 33, 755, DateTimeKind.Local).AddTicks(2846), "5" });

            migrationBuilder.InsertData(
                table: "CommentReactions",
                columns: new[] { "Id", "CommentId", "IsLiked", "ReactedAt", "UserId" },
                values: new object[] { "2", "2", true, new DateTime(2025, 5, 15, 16, 28, 33, 755, DateTimeKind.Local).AddTicks(3170), "4" });

            migrationBuilder.InsertData(
                table: "CommentReactions",
                columns: new[] { "Id", "CommentId", "IsLiked", "ReactedAt", "UserId" },
                values: new object[] { "3", "3", false, new DateTime(2025, 8, 12, 16, 28, 33, 755, DateTimeKind.Local).AddTicks(3191), "1" });

            migrationBuilder.CreateIndex(
                name: "IX_CommentReactions_CommentId",
                table: "CommentReactions",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentReactions_UserId",
                table: "CommentReactions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostReactions_PostId",
                table: "PostReactions",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostReactions_UserId",
                table: "PostReactions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTopic_PostId",
                table: "PostTopic",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTopic_MyPropertyTopicId_MyPropertyPostId",
                table: "PostTopic",
                columns: new[] { "MyPropertyTopicId", "MyPropertyPostId" });

            migrationBuilder.CreateIndex(
                name: "IX_Topics_CommentId",
                table: "Topics",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_PostId",
                table: "Topics",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInterest_InterestId",
                table: "UserInterest",
                column: "InterestId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentReactions");

            migrationBuilder.DropTable(
                name: "PostReactions");

            migrationBuilder.DropTable(
                name: "PostTopic");

            migrationBuilder.DropTable(
                name: "UserInterest");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "UserInterests");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
