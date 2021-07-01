using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Emotional.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "HashPassword");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Musics",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Emotions",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Diaries",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "HashPassword",
                table: "Users",
                newName: "Password");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Musics",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Emotions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Diaries",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }
    }
}
