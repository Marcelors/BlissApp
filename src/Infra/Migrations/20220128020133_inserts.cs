using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class inserts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "QuestionId",
                table: "Choices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "ImageUrl", "PublishedAt", "Question", "ThumbUrl" },
                values: new object[,]
                {
                    { 1, "https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)", new DateTime(2022, 1, 28, 2, 1, 32, 939, DateTimeKind.Utc).AddTicks(5410), "Favourite programming language?", "https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)" },
                    { 2, "https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)", new DateTime(2022, 1, 28, 2, 1, 32, 939, DateTimeKind.Utc).AddTicks(7090), "Favourite programming language?", "https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)" },
                    { 3, "https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)", new DateTime(2022, 1, 28, 2, 1, 32, 939, DateTimeKind.Utc).AddTicks(7100), "Favourite programming language?", "https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)" },
                    { 4, "https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)", new DateTime(2022, 1, 28, 2, 1, 32, 939, DateTimeKind.Utc).AddTicks(7100), "Favourite programming language?", "https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)" },
                    { 5, "https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)", new DateTime(2022, 1, 28, 2, 1, 32, 939, DateTimeKind.Utc).AddTicks(7100), "Favourite programming language?", "https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)" },
                    { 6, "https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)", new DateTime(2022, 1, 28, 2, 1, 32, 939, DateTimeKind.Utc).AddTicks(7110), "Favourite programming language?", "https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)" },
                    { 7, "https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)", new DateTime(2022, 1, 28, 2, 1, 32, 939, DateTimeKind.Utc).AddTicks(7110), "Favourite programming language?", "https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)" },
                    { 8, "https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)", new DateTime(2022, 1, 28, 2, 1, 32, 939, DateTimeKind.Utc).AddTicks(7110), "Favourite programming language?", "https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)" },
                    { 9, "https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)", new DateTime(2022, 1, 28, 2, 1, 32, 939, DateTimeKind.Utc).AddTicks(7110), "Favourite programming language?", "https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)" },
                    { 10, "https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)", new DateTime(2022, 1, 28, 2, 1, 32, 939, DateTimeKind.Utc).AddTicks(7110), "Favourite programming language?", "https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)" },
                    { 11, "https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)", new DateTime(2022, 1, 28, 2, 1, 32, 939, DateTimeKind.Utc).AddTicks(7120), "Favourite programming language?", "https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)" },
                    { 12, "https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)", new DateTime(2022, 1, 28, 2, 1, 32, 939, DateTimeKind.Utc).AddTicks(7120), "Favourite programming language?", "https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)" }
                });

            migrationBuilder.InsertData(
                table: "Choices",
                columns: new[] { "Id", "Choice", "QuestionId", "Votes" },
                values: new object[,]
                {
                    { 1, "C#", 1, 10 },
                    { 22, "C++", 11, 15 },
                    { 21, "C#", 11, 10 },
                    { 20, "C++", 10, 15 },
                    { 19, "C#", 10, 10 },
                    { 18, "C++", 9, 15 },
                    { 17, "C#", 9, 10 },
                    { 16, "C++", 8, 15 },
                    { 15, "C#", 8, 10 },
                    { 14, "C++", 7, 15 },
                    { 13, "C#", 7, 10 },
                    { 12, "C++", 6, 15 },
                    { 11, "C#", 6, 10 },
                    { 10, "C++", 5, 15 },
                    { 9, "C#", 5, 10 },
                    { 8, "C++", 4, 15 },
                    { 7, "C#", 4, 10 },
                    { 6, "C++", 3, 15 },
                    { 5, "C#", 3, 10 },
                    { 4, "C++", 2, 15 },
                    { 3, "C#", 2, 10 },
                    { 2, "C++", 1, 15 },
                    { 23, "C#", 12, 10 },
                    { 24, "C++", 12, 15 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Choices",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.AlterColumn<int>(
                name: "QuestionId",
                table: "Choices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
