using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Emotional.Data.Migrations
{
    public partial class UpdateCategoryEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Diaries",
                keyColumn: "Id",
                keyValue: new Guid("64c73e39-08f4-47e6-bf8f-2b704bbc93ad"));

            migrationBuilder.DeleteData(
                table: "Emotions",
                keyColumn: "Id",
                keyValue: new Guid("e037bbf0-088e-46cc-9349-f30e6feeac9c"));

            migrationBuilder.DeleteData(
                table: "Musics",
                keyColumn: "Id",
                keyValue: new Guid("98339f19-04e0-4622-8e37-f60d8d3608b7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2eb554c1-28cb-4629-97da-960753f13234"));

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Musics",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Emotions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldDefaultValue: (byte)1);

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Diaries",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldDefaultValue: (byte)1);

            migrationBuilder.InsertData(
                table: "Musics",
                columns: new[] { "Id", "Category", "MusicUrl", "Name" },
                values: new object[] { new Guid("76850e5c-38e9-4ea7-92e3-046e0a12bada"), "PEACEFUL", "https://freesound.org/data/previews/554/554415_2975501-lq.mp3", "Peaceful-sound-001" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "Email", "HashPassword", "Name" },
                values: new object[] { new Guid("3a5a4a27-b0cc-4c17-bf1f-a97b79888c9c"), null, "Emotional@gmail.com", "AQAAAAEAACcQAAAAEH2W6nOQOkg6ugEx9xy9jfJ2/cYMxcT3Oav12rY4cr/EmFqSqT+LvTVURl0solClZQ==", "Emotional" });

            migrationBuilder.InsertData(
                table: "Diaries",
                columns: new[] { "Id", "Category", "Content", "CreatedOn", "UserId" },
                values: new object[] { new Guid("66a9ef91-ca1c-4eaa-812a-4e0f166c1053"), "HAPPY", "Today is a good day.", new DateTime(2021, 7, 1, 12, 5, 24, 272, DateTimeKind.Utc).AddTicks(1753), new Guid("3a5a4a27-b0cc-4c17-bf1f-a97b79888c9c") });

            migrationBuilder.InsertData(
                table: "Emotions",
                columns: new[] { "Id", "Category", "CreatedOn", "Percentage", "UserId" },
                values: new object[] { new Guid("b3033c02-7849-451a-b34c-3d2306f6401d"), "PEACEFUL", new DateTime(2021, 7, 1, 12, 5, 24, 272, DateTimeKind.Utc).AddTicks(80), 70f, new Guid("3a5a4a27-b0cc-4c17-bf1f-a97b79888c9c") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Diaries",
                keyColumn: "Id",
                keyValue: new Guid("66a9ef91-ca1c-4eaa-812a-4e0f166c1053"));

            migrationBuilder.DeleteData(
                table: "Emotions",
                keyColumn: "Id",
                keyValue: new Guid("b3033c02-7849-451a-b34c-3d2306f6401d"));

            migrationBuilder.DeleteData(
                table: "Musics",
                keyColumn: "Id",
                keyValue: new Guid("76850e5c-38e9-4ea7-92e3-046e0a12bada"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3a5a4a27-b0cc-4c17-bf1f-a97b79888c9c"));

            migrationBuilder.AlterColumn<byte>(
                name: "Category",
                table: "Musics",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<byte>(
                name: "Category",
                table: "Emotions",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)1,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<byte>(
                name: "Category",
                table: "Diaries",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)1,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Musics",
                columns: new[] { "Id", "Category", "MusicUrl", "Name" },
                values: new object[] { new Guid("98339f19-04e0-4622-8e37-f60d8d3608b7"), (byte)1, "https://freesound.org/data/previews/554/554415_2975501-lq.mp3", "Peaceful-sound-001" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarUrl", "Email", "HashPassword", "Name" },
                values: new object[] { new Guid("2eb554c1-28cb-4629-97da-960753f13234"), null, "Emotional@gmail.com", "AQAAAAEAACcQAAAAEBdVbiJm41NS4ZQTD1CMGRX7PzhoEVBUXtPGEwtGPha57Ox56hUh6MvIKIJg/qjhOw==", "Emotional" });

            migrationBuilder.InsertData(
                table: "Diaries",
                columns: new[] { "Id", "Content", "CreatedOn", "UserId" },
                values: new object[] { new Guid("64c73e39-08f4-47e6-bf8f-2b704bbc93ad"), "Today is a good day.", new DateTime(2021, 7, 1, 5, 26, 48, 398, DateTimeKind.Utc).AddTicks(8520), new Guid("2eb554c1-28cb-4629-97da-960753f13234") });

            migrationBuilder.InsertData(
                table: "Emotions",
                columns: new[] { "Id", "Category", "CreatedOn", "Percentage", "UserId" },
                values: new object[] { new Guid("e037bbf0-088e-46cc-9349-f30e6feeac9c"), (byte)1, new DateTime(2021, 7, 1, 5, 26, 48, 398, DateTimeKind.Utc).AddTicks(6616), 70f, new Guid("2eb554c1-28cb-4629-97da-960753f13234") });
        }
    }
}
