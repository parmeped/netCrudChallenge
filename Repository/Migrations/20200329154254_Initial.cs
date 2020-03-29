using System;
using Microsoft.EntityFrameworkCore.Migrations;

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
                    ID = table.Column<long>(nullable: false),
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
                    ID = table.Column<long>(nullable: false),
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
                    ID = table.Column<long>(nullable: false),
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
                    ID = table.Column<long>(nullable: false),
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
                    ID = table.Column<long>(nullable: false),
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
                    ID = table.Column<long>(nullable: false),
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
                    { 1L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "work", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "personal", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "ID", "CreatedAt", "DeletedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "State 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "State 2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "State 3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "State 4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "State 5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "ID", "CreatedAt", "DeletedAt", "Name", "StateID", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City 1", 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City 2", 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City 3", 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City 4", 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City 5", 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City 6", 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City 7", 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City 8", 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City 9", 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City 10", 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "ID", "CityID", "CreatedAt", "DeletedAt", "Name", "StreetName", "StreetNumber", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Company 1", "Street Name", 656, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, 2L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Company 2", "Street Name", 2420, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, 3L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Company 3", "Street Name", 174, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, 4L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Company 4", "Street Name", 918, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, 5L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Company 5", "Street Name", 1015, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6L, 6L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Company 6", "Street Name", 2273, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7L, 7L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Company 7", "Street Name", 3656, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8L, 8L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Company 8", "Street Name", 1765, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9L, 9L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Company 9", "Street Name", 2762, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10L, 10L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Company 10", "Street Name", 1861, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ID", "BirthDate", "CityID", "CompanyID", "CreatedAt", "DeletedAt", "Email", "Name", "ProfileImage", "StreetName", "StreetNumber", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(1992, 12, 16, 12, 42, 54, 278, DateTimeKind.Local).AddTicks(9036), 1L, 1L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail1@mail.com", "Contact 1", "ImageUrl", "Street Name", 2317, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18L, new DateTime(1940, 2, 18, 12, 42, 54, 279, DateTimeKind.Local).AddTicks(1879), 9L, 9L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail18@mail.com", "Contact 18", "ImageUrl", "Street Name", 1413, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17L, new DateTime(1965, 4, 8, 12, 42, 54, 279, DateTimeKind.Local).AddTicks(1850), 9L, 9L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail17@mail.com", "Contact 17", "ImageUrl", "Street Name", 1626, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16L, new DateTime(1972, 2, 13, 12, 42, 54, 279, DateTimeKind.Local).AddTicks(1823), 8L, 8L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail16@mail.com", "Contact 16", "ImageUrl", "Street Name", 2357, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15L, new DateTime(2000, 1, 14, 12, 42, 54, 279, DateTimeKind.Local).AddTicks(1796), 8L, 8L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail15@mail.com", "Contact 15", "ImageUrl", "Street Name", 1797, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14L, new DateTime(1925, 4, 25, 12, 42, 54, 279, DateTimeKind.Local).AddTicks(1769), 7L, 7L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail14@mail.com", "Contact 14", "ImageUrl", "Street Name", 4904, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13L, new DateTime(1923, 3, 3, 12, 42, 54, 279, DateTimeKind.Local).AddTicks(1742), 7L, 7L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail13@mail.com", "Contact 13", "ImageUrl", "Street Name", 697, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12L, new DateTime(1933, 5, 13, 12, 42, 54, 279, DateTimeKind.Local).AddTicks(1715), 6L, 6L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail12@mail.com", "Contact 12", "ImageUrl", "Street Name", 228, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11L, new DateTime(1940, 6, 27, 12, 42, 54, 279, DateTimeKind.Local).AddTicks(1687), 6L, 6L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail11@mail.com", "Contact 11", "ImageUrl", "Street Name", 4071, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10L, new DateTime(1960, 5, 13, 12, 42, 54, 279, DateTimeKind.Local).AddTicks(1656), 5L, 5L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail10@mail.com", "Contact 10", "ImageUrl", "Street Name", 2127, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9L, new DateTime(1999, 2, 17, 12, 42, 54, 279, DateTimeKind.Local).AddTicks(1572), 5L, 5L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail9@mail.com", "Contact 9", "ImageUrl", "Street Name", 4815, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8L, new DateTime(1932, 3, 27, 12, 42, 54, 279, DateTimeKind.Local).AddTicks(1545), 4L, 4L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail8@mail.com", "Contact 8", "ImageUrl", "Street Name", 3549, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7L, new DateTime(1956, 7, 13, 12, 42, 54, 279, DateTimeKind.Local).AddTicks(1518), 4L, 4L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail7@mail.com", "Contact 7", "ImageUrl", "Street Name", 298, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6L, new DateTime(1948, 12, 21, 12, 42, 54, 279, DateTimeKind.Local).AddTicks(1490), 3L, 3L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail6@mail.com", "Contact 6", "ImageUrl", "Street Name", 3698, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, new DateTime(1925, 6, 30, 12, 42, 54, 279, DateTimeKind.Local).AddTicks(1458), 3L, 3L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail5@mail.com", "Contact 5", "ImageUrl", "Street Name", 287, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, new DateTime(1927, 11, 7, 12, 42, 54, 279, DateTimeKind.Local).AddTicks(1429), 2L, 2L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail4@mail.com", "Contact 4", "ImageUrl", "Street Name", 2465, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, new DateTime(1914, 9, 3, 12, 42, 54, 279, DateTimeKind.Local).AddTicks(1393), 2L, 2L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail3@mail.com", "Contact 3", "ImageUrl", "Street Name", 1211, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(1931, 2, 20, 12, 42, 54, 279, DateTimeKind.Local).AddTicks(1289), 1L, 1L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail2@mail.com", "Contact 2", "ImageUrl", "Street Name", 1453, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19L, new DateTime(1982, 6, 21, 12, 42, 54, 279, DateTimeKind.Local).AddTicks(1906), 10L, 10L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail19@mail.com", "Contact 19", "ImageUrl", "Street Name", 657, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20L, new DateTime(1936, 12, 24, 12, 42, 54, 279, DateTimeKind.Local).AddTicks(1932), 10L, 10L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail20@mail.com", "Contact 20", "ImageUrl", "Street Name", 125, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "ID", "ContactID", "CreatedAt", "DeletedAt", "Number", "PhoneTypeID", "Prefix", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "13734999", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12L, 12L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "69226462", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32L, 12L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "74386497", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13L, 13L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "93573875", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33L, 13L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "15776042", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14L, 14L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "17369239", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34L, 14L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "73264909", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15L, 15L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "60698586", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31L, 11L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "68385440", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35L, 15L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "51334055", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36L, 16L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "15499190", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17L, 17L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "19684141", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37L, 17L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "75899170", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18L, 18L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "57936918", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38L, 18L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "58551422", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19L, 19L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "68676005", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39L, 19L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "69207382", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16L, 16L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "79901067", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11L, 11L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "54790487", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30L, 10L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "12598548", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10L, 10L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "49100529", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21L, 1L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "98047322", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, 2L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "79097884", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22L, 2L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "68472666", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, 3L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "96494823", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23L, 3L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "52178564", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, 4L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "56596996", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24L, 4L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "99050265", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, 5L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "20905987", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25L, 5L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "44409188", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6L, 6L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "58248277", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26L, 6L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "44905766", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7L, 7L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "48832024", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27L, 7L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "35613259", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8L, 8L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "56680530", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28L, 8L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "66995080", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9L, 9L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "53217546", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29L, 9L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "32389566", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20L, 20L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "44173582", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40L, 20L, new DateTime(2020, 3, 29, 12, 42, 54, 274, DateTimeKind.Local).AddTicks(5067), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "65255083", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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
