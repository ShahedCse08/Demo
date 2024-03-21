using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51b5aab5-fca7-4d89-990e-09984179a297");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4b07218-cb4e-4730-a477-359961fdb6fd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3dfe8737-de33-4441-b02a-72125dddadf0", "a3f0bdb3-1e9a-4e6b-9a65-ca15da29acd9", "Administrator", "ADMINISTRATOR" },
                    { "ee42d90f-5d56-4d24-a4e1-4c71bcb836da", "ce2b1bf3-1043-49c3-9074-1a2e99df4f16", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "Days",
                columns: new[] { "DayId", "DayName" },
                values: new object[,]
                {
                    { new Guid("a9e44b30-1c61-4170-808a-daff4fefabe2"), "Friday" },
                    { new Guid("796f72c0-e41c-4661-965b-b80091bab18f"), "Thursday" },
                    { new Guid("e8f7aa4f-7665-44c5-bc95-787c21a3709d"), "Saturday" },
                    { new Guid("084fcdcf-fe24-4f07-bfaa-e7ca017ed4ff"), "Tuesday" },
                    { new Guid("617015bf-1ad1-4aa3-8b33-deb0bb4695b7"), "Monday" },
                    { new Guid("7dad6383-779f-4cd8-8081-ef069fbf4e50"), "Wednesday" },
                    { new Guid("07b89cb9-fbb3-4f53-bb92-9b4b2e38c244"), "Sunday" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "ItemName" },
                values: new object[,]
                {
                    { new Guid("1037a235-58d0-43fb-b936-7f0022658767"), "Kacchi Biriani" },
                    { new Guid("db748aa9-5627-4359-9c4e-856786ad6430"), "Chicken Polao" },
                    { new Guid("e2e009b9-bfb1-429f-be8d-8f0e4e293af8"), "Polao" },
                    { new Guid("98d196eb-0059-4314-bac5-f1d37e67136b"), "Chicken curry" },
                    { new Guid("eb342c57-e5da-4cc9-a4e2-87820a7f02fb"), "Deef" },
                    { new Guid("ca7767f7-b92d-42ac-924b-08c0e2c9ae4b"), "Chicken roast" },
                    { new Guid("973ddbdb-a252-4fd1-9b30-0700fbd5d0c7"), "Hilsha fish curry" },
                    { new Guid("968fe7c0-f691-463f-bffb-e054b67b3d39"), "Rui fish curry" },
                    { new Guid("c6ed9bfb-7cf4-4abb-be8c-64fbd49775f8"), "Khichri" },
                    { new Guid("3ea42539-e4a5-43df-9306-dc711a880c47"), "Mashed Potato" },
                    { new Guid("649108f3-0fa3-4fe4-b9bd-cf47a6ce5925"), "Red Lentil" },
                    { new Guid("6b9da871-8a3d-481f-b1b3-805440d55001"), "Rice" },
                    { new Guid("7e088cb4-5285-497e-835e-cbc7f272fb78"), "Hilsha fish fry" },
                    { new Guid("7c2aae64-532b-4c26-a368-ac18246002c0"), "Egg curry" }
                });

            migrationBuilder.InsertData(
                table: "MealTypes",
                columns: new[] { "TypeId", "TypeName" },
                values: new object[,]
                {
                    { new Guid("5605952f-8a67-4d21-ad25-02fafa687d84"), "Break Fast" },
                    { new Guid("36899ed8-cff9-401b-a3ae-39ff6f870e8e"), "Lunch" },
                    { new Guid("fe3a6760-763d-4aed-a807-c5b90fdd669c"), "Snacks" },
                    { new Guid("29344037-8b40-48c1-b742-da56208e8225"), "Dinner" }
                });

            migrationBuilder.InsertData(
                table: "OrderStates",
                columns: new[] { "StateId", "StateName" },
                values: new object[,]
                {
                    { new Guid("3bbe9cd9-f03b-407a-85cd-ebea1c3bfbf7"), "Order picked" },
                    { new Guid("43427e1b-5422-4677-b7ef-ab63ad6a30c6"), "On the way" },
                    { new Guid("bc1e22cb-8473-4529-8dc1-96919ecffba3"), "Delivered" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3dfe8737-de33-4441-b02a-72125dddadf0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee42d90f-5d56-4d24-a4e1-4c71bcb836da");

            migrationBuilder.DeleteData(
                table: "Days",
                keyColumn: "DayId",
                keyValue: new Guid("07b89cb9-fbb3-4f53-bb92-9b4b2e38c244"));

            migrationBuilder.DeleteData(
                table: "Days",
                keyColumn: "DayId",
                keyValue: new Guid("084fcdcf-fe24-4f07-bfaa-e7ca017ed4ff"));

            migrationBuilder.DeleteData(
                table: "Days",
                keyColumn: "DayId",
                keyValue: new Guid("617015bf-1ad1-4aa3-8b33-deb0bb4695b7"));

            migrationBuilder.DeleteData(
                table: "Days",
                keyColumn: "DayId",
                keyValue: new Guid("796f72c0-e41c-4661-965b-b80091bab18f"));

            migrationBuilder.DeleteData(
                table: "Days",
                keyColumn: "DayId",
                keyValue: new Guid("7dad6383-779f-4cd8-8081-ef069fbf4e50"));

            migrationBuilder.DeleteData(
                table: "Days",
                keyColumn: "DayId",
                keyValue: new Guid("a9e44b30-1c61-4170-808a-daff4fefabe2"));

            migrationBuilder.DeleteData(
                table: "Days",
                keyColumn: "DayId",
                keyValue: new Guid("e8f7aa4f-7665-44c5-bc95-787c21a3709d"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("1037a235-58d0-43fb-b936-7f0022658767"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("3ea42539-e4a5-43df-9306-dc711a880c47"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("649108f3-0fa3-4fe4-b9bd-cf47a6ce5925"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("6b9da871-8a3d-481f-b1b3-805440d55001"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("7c2aae64-532b-4c26-a368-ac18246002c0"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("7e088cb4-5285-497e-835e-cbc7f272fb78"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("968fe7c0-f691-463f-bffb-e054b67b3d39"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("973ddbdb-a252-4fd1-9b30-0700fbd5d0c7"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("98d196eb-0059-4314-bac5-f1d37e67136b"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("c6ed9bfb-7cf4-4abb-be8c-64fbd49775f8"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("ca7767f7-b92d-42ac-924b-08c0e2c9ae4b"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("db748aa9-5627-4359-9c4e-856786ad6430"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("e2e009b9-bfb1-429f-be8d-8f0e4e293af8"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("eb342c57-e5da-4cc9-a4e2-87820a7f02fb"));

            migrationBuilder.DeleteData(
                table: "MealTypes",
                keyColumn: "TypeId",
                keyValue: new Guid("29344037-8b40-48c1-b742-da56208e8225"));

            migrationBuilder.DeleteData(
                table: "MealTypes",
                keyColumn: "TypeId",
                keyValue: new Guid("36899ed8-cff9-401b-a3ae-39ff6f870e8e"));

            migrationBuilder.DeleteData(
                table: "MealTypes",
                keyColumn: "TypeId",
                keyValue: new Guid("5605952f-8a67-4d21-ad25-02fafa687d84"));

            migrationBuilder.DeleteData(
                table: "MealTypes",
                keyColumn: "TypeId",
                keyValue: new Guid("fe3a6760-763d-4aed-a807-c5b90fdd669c"));

            migrationBuilder.DeleteData(
                table: "OrderStates",
                keyColumn: "StateId",
                keyValue: new Guid("3bbe9cd9-f03b-407a-85cd-ebea1c3bfbf7"));

            migrationBuilder.DeleteData(
                table: "OrderStates",
                keyColumn: "StateId",
                keyValue: new Guid("43427e1b-5422-4677-b7ef-ab63ad6a30c6"));

            migrationBuilder.DeleteData(
                table: "OrderStates",
                keyColumn: "StateId",
                keyValue: new Guid("bc1e22cb-8473-4529-8dc1-96919ecffba3"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f4b07218-cb4e-4730-a477-359961fdb6fd", "3f9d51cd-cb3b-4d75-8b13-4eb16c45c4ac", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "51b5aab5-fca7-4d89-990e-09984179a297", "9c023eb9-4fb8-4908-87d5-75bb43d3cbec", "Administrator", "ADMINISTRATOR" });
        }
    }
}
