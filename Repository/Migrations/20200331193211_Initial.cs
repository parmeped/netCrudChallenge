using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Repository.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhoneTypes",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    StateID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cities_States_StateID",
                        column: x => x.StateID,
                        principalTable: "States",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    StreetName = table.Column<string>(nullable: true),
                    StreetNumber = table.Column<int>(nullable: false),
                    CityID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Companies_Cities_CityID",
                        column: x => x.CityID,
                        principalTable: "Cities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CompanyID = table.Column<long>(nullable: false),
                    ProfileImage = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    StreetName = table.Column<string>(nullable: true),
                    StreetNumber = table.Column<int>(nullable: false),
                    CityID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Contacts_Cities_CityID",
                        column: x => x.CityID,
                        principalTable: "Cities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contacts_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: false),
                    Prefix = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    PhoneTypeID = table.Column<long>(nullable: false),
                    ContactID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Phones_Contacts_ContactID",
                        column: x => x.ContactID,
                        principalTable: "Contacts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Phones_PhoneTypes_PhoneTypeID",
                        column: x => x.PhoneTypeID,
                        principalTable: "PhoneTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PhoneTypes",
                columns: new[] { "ID", "CreatedAt", "DeletedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "work", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "personal", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "ID", "CreatedAt", "DeletedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "State 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "State 2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "State 3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "State 4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "State 5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "ID", "CreatedAt", "DeletedAt", "Name", "StateID", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City 1", 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City 2", 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City 3", 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City 4", 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City 5", 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City 6", 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City 7", 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City 8", 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City 9", 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City 10", 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "ID", "CityID", "CreatedAt", "DeletedAt", "Name", "StreetName", "StreetNumber", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Company 1", "Street Name", 2398, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, 2L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Company 2", "Street Name", 4265, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, 3L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Company 3", "Street Name", 4405, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, 4L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Company 4", "Street Name", 2686, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, 5L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Company 5", "Street Name", 3474, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6L, 6L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Company 6", "Street Name", 2348, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7L, 7L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Company 7", "Street Name", 2352, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8L, 8L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Company 8", "Street Name", 1221, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9L, 9L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Company 9", "Street Name", 3538, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10L, 10L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Company 10", "Street Name", 738, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ID", "BirthDate", "CityID", "CompanyID", "CreatedAt", "DeletedAt", "Email", "Name", "ProfileImage", "StreetName", "StreetNumber", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(1999, 6, 6, 16, 32, 10, 427, DateTimeKind.Local).AddTicks(4554), 1L, 1L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail1@mail.com", "Contact 1", "ImageUrl", "Street Name", 3346, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18L, new DateTime(1915, 7, 23, 16, 32, 10, 428, DateTimeKind.Local).AddTicks(6542), 9L, 9L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail18@mail.com", "Contact 18", "ImageUrl", "Street Name", 565, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17L, new DateTime(1956, 8, 23, 16, 32, 10, 428, DateTimeKind.Local).AddTicks(6447), 9L, 9L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail17@mail.com", "Contact 17", "ImageUrl", "Street Name", 453, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16L, new DateTime(1924, 10, 21, 16, 32, 10, 428, DateTimeKind.Local).AddTicks(6352), 8L, 8L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail16@mail.com", "Contact 16", "ImageUrl", "Street Name", 657, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15L, new DateTime(1917, 6, 18, 16, 32, 10, 428, DateTimeKind.Local).AddTicks(6252), 8L, 8L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail15@mail.com", "Contact 15", "ImageUrl", "Street Name", 3920, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14L, new DateTime(1989, 10, 22, 16, 32, 10, 428, DateTimeKind.Local).AddTicks(6004), 7L, 7L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail14@mail.com", "Contact 14", "ImageUrl", "Street Name", 3477, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13L, new DateTime(1945, 4, 2, 16, 32, 10, 428, DateTimeKind.Local).AddTicks(5913), 7L, 7L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail13@mail.com", "Contact 13", "ImageUrl", "Street Name", 3477, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12L, new DateTime(1990, 5, 27, 16, 32, 10, 428, DateTimeKind.Local).AddTicks(5821), 6L, 6L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail12@mail.com", "Contact 12", "ImageUrl", "Street Name", 2902, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11L, new DateTime(1942, 6, 16, 16, 32, 10, 428, DateTimeKind.Local).AddTicks(5729), 6L, 6L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail11@mail.com", "Contact 11", "ImageUrl", "Street Name", 486, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10L, new DateTime(1993, 12, 6, 16, 32, 10, 428, DateTimeKind.Local).AddTicks(5637), 5L, 5L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail10@mail.com", "Contact 10", "ImageUrl", "Street Name", 3427, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9L, new DateTime(1937, 5, 11, 16, 32, 10, 428, DateTimeKind.Local).AddTicks(5537), 5L, 5L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail9@mail.com", "Contact 9", "ImageUrl", "Street Name", 4215, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8L, new DateTime(1924, 2, 10, 16, 32, 10, 428, DateTimeKind.Local).AddTicks(5446), 4L, 4L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail8@mail.com", "Contact 8", "ImageUrl", "Street Name", 1224, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7L, new DateTime(1942, 1, 9, 16, 32, 10, 428, DateTimeKind.Local).AddTicks(5356), 4L, 4L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail7@mail.com", "Contact 7", "ImageUrl", "Street Name", 1066, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6L, new DateTime(1981, 3, 19, 16, 32, 10, 428, DateTimeKind.Local).AddTicks(5265), 3L, 3L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail6@mail.com", "Contact 6", "ImageUrl", "Street Name", 2781, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, new DateTime(1929, 4, 30, 16, 32, 10, 428, DateTimeKind.Local).AddTicks(5167), 3L, 3L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail5@mail.com", "Contact 5", "ImageUrl", "Street Name", 3905, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, new DateTime(1910, 12, 3, 16, 32, 10, 428, DateTimeKind.Local).AddTicks(5075), 2L, 2L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail4@mail.com", "Contact 4", "ImageUrl", "Street Name", 3459, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, new DateTime(1993, 5, 31, 16, 32, 10, 428, DateTimeKind.Local).AddTicks(4978), 2L, 2L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail3@mail.com", "Contact 3", "ImageUrl", "Street Name", 4387, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(1942, 5, 14, 16, 32, 10, 428, DateTimeKind.Local).AddTicks(4744), 1L, 1L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail2@mail.com", "Contact 2", "ImageUrl", "Street Name", 3083, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19L, new DateTime(1960, 9, 1, 16, 32, 10, 428, DateTimeKind.Local).AddTicks(6635), 10L, 10L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail19@mail.com", "Contact 19", "ImageUrl", "Street Name", 3481, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20L, new DateTime(1973, 7, 12, 16, 32, 10, 428, DateTimeKind.Local).AddTicks(6729), 10L, 10L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail20@mail.com", "Contact 20", "ImageUrl", "Street Name", 4354, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "ID", "ContactID", "CreatedAt", "DeletedAt", "Number", "PhoneTypeID", "Prefix", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "57971562", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12L, 12L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "77626861", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32L, 12L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "43486955", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13L, 13L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "60773601", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33L, 13L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "86777028", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14L, 14L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "62298008", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34L, 14L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "41403956", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15L, 15L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "15591661", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31L, 11L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "25711760", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35L, 15L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "64854477", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36L, 16L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "82795824", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17L, 17L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "55024688", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37L, 17L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "66712381", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18L, 18L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "50939302", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38L, 18L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "83446253", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19L, 19L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "97733669", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39L, 19L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "66449358", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16L, 16L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "11142156", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11L, 11L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "66788199", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30L, 10L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "37335700", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10L, 10L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "85289847", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21L, 1L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "50374484", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, 2L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "36946716", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22L, 2L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "57065761", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, 3L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "14971823", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23L, 3L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "30139612", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, 4L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "79254735", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24L, 4L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "86784561", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, 5L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "59650556", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25L, 5L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "71070089", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6L, 6L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "30230729", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26L, 6L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "73612778", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7L, 7L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "68007467", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27L, 7L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "26573683", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8L, 8L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "29560344", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28L, 8L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "72639275", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9L, 9L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "37111279", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29L, 9L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "60941976", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20L, 20L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "32236085", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40L, 20L, new DateTime(2020, 3, 31, 16, 32, 10, 411, DateTimeKind.Local).AddTicks(877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "53803797", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateID",
                table: "Cities",
                column: "StateID");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CityID",
                table: "Companies",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CityID",
                table: "Contacts",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CompanyID",
                table: "Contacts",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_ContactID",
                table: "Phones",
                column: "ContactID");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_PhoneTypeID",
                table: "Phones",
                column: "PhoneTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "PhoneTypes");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
