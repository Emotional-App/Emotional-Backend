using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Emotional.Data.Migrations
{
    public partial class UpdateNullableAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Diaries",
                keyColumn: "Id",
                keyValue: new Guid("6846c40c-48a0-4529-8126-9d324b0917e8"));

            migrationBuilder.DeleteData(
                table: "Emotions",
                keyColumn: "Id",
                keyValue: new Guid("4e0494cf-cbe9-4e74-85bc-9954a5f6cbe7"));

            migrationBuilder.DeleteData(
                table: "Musics",
                keyColumn: "Id",
                keyValue: new Guid("2d106c65-5430-4ac8-a5d1-39b27c928715"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("10713172-9b96-4e83-bab8-45d3c4c23b96"));

            migrationBuilder.AlterColumn<byte>(
                name: "Category",
                table: "Diaries",
                type: "tinyint",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.InsertData(
                table: "Musics",
                columns: new[] { "Id", "Category", "CategoryName", "MusicUrl", "Name" },
                values: new object[] { new Guid("d7c2e78f-ed6a-4968-a022-575771005f36"), (byte)5, "PEACEFUL", "https://freesound.org/data/previews/554/554415_2975501-lq.mp3", "Peaceful-sound-001" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "Email", "HashPassword", "Name" },
                values: new object[] { new Guid("8a30ab77-eb1e-4695-af89-3af93f491497"), null, "Emotional@gmail.com", "AQAAAAEAACcQAAAAEGyiPePFbiytQkffniz2c8NLekbtJxGWkrm55pfFOBNqm7zCiPZAV9Um8j94OMmHJA==", "Emotional" });

            migrationBuilder.InsertData(
                table: "Diaries",
                columns: new[] { "Id", "Category", "CategoryName", "Content", "CreatedOn", "UserId" },
                values: new object[] { new Guid("8dc8c0d6-aeb1-4d54-9b61-c4ef970eb619"), null, null, "Today is a good day.", new DateTime(2021, 7, 3, 2, 18, 57, 967, DateTimeKind.Utc).AddTicks(8649), new Guid("8a30ab77-eb1e-4695-af89-3af93f491497") });

            migrationBuilder.InsertData(
                table: "Emotions",
                columns: new[] { "Id", "Category", "CategoryName", "CreatedOn", "Percentage", "UserId" },
                values: new object[] { new Guid("bb3867fe-107c-470b-a351-89bb7570efa6"), (byte)5, "PEACEFUL", new DateTime(2021, 7, 3, 2, 18, 57, 967, DateTimeKind.Utc).AddTicks(4625), 70f, new Guid("8a30ab77-eb1e-4695-af89-3af93f491497") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Diaries",
                keyColumn: "Id",
                keyValue: new Guid("8dc8c0d6-aeb1-4d54-9b61-c4ef970eb619"));

            migrationBuilder.DeleteData(
                table: "Emotions",
                keyColumn: "Id",
                keyValue: new Guid("bb3867fe-107c-470b-a351-89bb7570efa6"));

            migrationBuilder.DeleteData(
                table: "Musics",
                keyColumn: "Id",
                keyValue: new Guid("d7c2e78f-ed6a-4968-a022-575771005f36"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8a30ab77-eb1e-4695-af89-3af93f491497"));

            migrationBuilder.AlterColumn<byte>(
                name: "Category",
                table: "Diaries",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldNullable: true);

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
    }
}
