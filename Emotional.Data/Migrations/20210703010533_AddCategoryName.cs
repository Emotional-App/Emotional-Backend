using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Emotional.Data.Migrations
{
    public partial class AddCategoryName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diaries");

            migrationBuilder.DropTable(
                name: "Emotions");

            migrationBuilder.DropTable(
                name: "Musics");

            migrationBuilder.CreateTable(
                name: "Musics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MusicUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<byte>(type: "tinyint", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Diaries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Category = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diaries_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Emotions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Percentage = table.Column<float>(type: "real", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Category = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emotions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emotions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diaries_UserId",
                table: "Diaries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Emotions_UserId",
                table: "Emotions",
                column: "UserId");

            migrationBuilder.InsertData(
                table: "Musics",
                columns: new[] { "Id", "Category", "CategoryName", "MusicUrl", "Name" },
                values: new object[] { new Guid("2d106c65-5430-4ac8-a5d1-39b27c928715"), (byte)5, "PEACEFUL", "https://freesound.org/data/previews/554/554415_2975501-lq.mp3", "Peaceful-sound-001" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "Email", "HashPassword", "Name" },
                values: new object[] { new Guid("10713172-9b96-4e83-bab8-45d3c4c23b96"), null, "Emotional@gmail.com", "AQAAAAEAACcQAAAAEC0r18UxVUy4PZ93ScHl5th5VvPlhdoBIhlpn/8tJ/XF5O2a7RBQScI6c+AoUvUdhQ==", "Emotional" });

            migrationBuilder.InsertData(
                table: "Diaries",
                columns: new[] { "Id", "Category", "CategoryName", "Content", "CreatedOn", "UserId" },
                values: new object[] { new Guid("6846c40c-48a0-4529-8126-9d324b0917e8"), (byte)0, null, "Today is a good day.", new DateTime(2021, 7, 3, 1, 5, 32, 671, DateTimeKind.Utc).AddTicks(5783), new Guid("10713172-9b96-4e83-bab8-45d3c4c23b96") });

            migrationBuilder.InsertData(
                table: "Emotions",
                columns: new[] { "Id", "Category", "CategoryName", "CreatedOn", "Percentage", "UserId" },
                values: new object[] { new Guid("4e0494cf-cbe9-4e74-85bc-9954a5f6cbe7"), (byte)5, "PEACEFUL", new DateTime(2021, 7, 3, 1, 5, 32, 671, DateTimeKind.Utc).AddTicks(3172), 70f, new Guid("10713172-9b96-4e83-bab8-45d3c4c23b96") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diaries");

            migrationBuilder.DropTable(
                name: "Emotions");

            migrationBuilder.DropTable(
                name: "Musics");

            migrationBuilder.CreateTable(
                name: "Musics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MusicUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<byte>(type: "tinyint", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Diaries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Category = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diaries_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Emotions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Percentage = table.Column<float>(type: "real", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Category = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emotions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emotions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diaries_UserId",
                table: "Diaries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Emotions_UserId",
                table: "Emotions",
                column: "UserId");

            migrationBuilder.InsertData(
                table: "Musics",
                columns: new[] { "Id", "Category", "CategoryName", "MusicUrl", "Name" },
                values: new object[] { new Guid("ee60780b-0399-49f6-8ec7-e15b95d3cb91"), (byte)5, "PEACEFUL", "https://freesound.org/data/previews/554/554415_2975501-lq.mp3", "Peaceful-sound-001" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "Email", "HashPassword", "Name" },
                values: new object[] { new Guid("9085b543-60e2-4a63-8bd6-160ff7e50c5a"), null, "Emotional@gmail.com", "AQAAAAEAACcQAAAAEABZJEeq3NsrvbXIQOXUctIm/Wr00AykKRi2b21/LdWA2W5wH0dMw8uPMvS7FmztVQ==", "Emotional" });

            migrationBuilder.InsertData(
                table: "Diaries",
                columns: new[] { "Id", "Category", "CategoryName", "Content", "CreatedOn", "UserId" },
                values: new object[] { new Guid("dbf76ccd-d363-4039-a803-b58a64967b3b"), (byte)0, null, "Today is a good day.", new DateTime(2021, 7, 3, 0, 57, 40, 379, DateTimeKind.Utc).AddTicks(6329), new Guid("9085b543-60e2-4a63-8bd6-160ff7e50c5a") });

            migrationBuilder.InsertData(
                table: "Emotions",
                columns: new[] { "Id", "Category", "CategoryName", "CreatedOn", "Percentage", "UserId" },
                values: new object[] { new Guid("c0d77948-f142-4c86-be0a-e8675bc7139e"), (byte)5, "PEACEFUL", new DateTime(2021, 7, 3, 0, 57, 40, 379, DateTimeKind.Utc).AddTicks(3891), 70f, new Guid("9085b543-60e2-4a63-8bd6-160ff7e50c5a") });
        }
    }
}
