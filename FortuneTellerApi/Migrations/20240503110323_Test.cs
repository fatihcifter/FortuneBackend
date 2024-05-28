using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FortuneTellerApi.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyMessages",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageHeader = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstimatedPublishTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyMessages", x => x.MessageId);
                });

            migrationBuilder.CreateTable(
                name: "FortuneDetails",
                columns: table => new
                {
                    FortuneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FortuneInformation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FortuneDetails", x => x.FortuneId);
                });

            migrationBuilder.CreateTable(
                name: "FortuneImageInfos",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FortuneId = table.Column<int>(type: "int", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FortuneImageInfos", x => x.ImageId);
                });

            migrationBuilder.CreateTable(
                name: "FortuneInfos",
                columns: table => new
                {
                    FortuneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FortuneTellerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPayed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FortuneInfos", x => x.FortuneId);
                });

            migrationBuilder.CreateTable(
                name: "FortunePrices",
                columns: table => new
                {
                    PriceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TurkishPrice = table.Column<double>(type: "float", nullable: false),
                    FortuneType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FortunePrices", x => x.PriceId);
                });

            migrationBuilder.CreateTable(
                name: "FortuneTellers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Base64Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    Coffee = table.Column<bool>(type: "bit", nullable: false),
                    CoffeePrice = table.Column<double>(type: "float", nullable: false),
                    Tarot = table.Column<bool>(type: "bit", nullable: false),
                    TarotPrice = table.Column<double>(type: "float", nullable: false),
                    Water = table.Column<bool>(type: "bit", nullable: false),
                    WaterPrice = table.Column<double>(type: "float", nullable: false),
                    Birthmap = table.Column<bool>(type: "bit", nullable: false),
                    BirthmapPrice = table.Column<double>(type: "float", nullable: false),
                    PlayingCard = table.Column<bool>(type: "bit", nullable: false),
                    PlayingCardPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FortuneTellers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HoroscopeInfos",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageHeader = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstimatedPublishTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoroscopeSign = table.Column<int>(type: "int", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoroscopeInfos", x => x.MessageId);
                });

            migrationBuilder.CreateTable(
                name: "UserRefreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRefreshToken", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "WeeklyHoroscopeMessages",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageHeader = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstimatedPublishTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoroscopeSign = table.Column<int>(type: "int", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyHoroscopeMessages", x => x.MessageId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyMessages");

            migrationBuilder.DropTable(
                name: "FortuneDetails");

            migrationBuilder.DropTable(
                name: "FortuneImageInfos");

            migrationBuilder.DropTable(
                name: "FortuneInfos");

            migrationBuilder.DropTable(
                name: "FortunePrices");

            migrationBuilder.DropTable(
                name: "FortuneTellers");

            migrationBuilder.DropTable(
                name: "HoroscopeInfos");

            migrationBuilder.DropTable(
                name: "UserRefreshToken");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "WeeklyHoroscopeMessages");
        }
    }
}
