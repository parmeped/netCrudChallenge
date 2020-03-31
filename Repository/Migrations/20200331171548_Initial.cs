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
                    { 1L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "work", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "personal", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "ID", "CreatedAt", "DeletedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "State 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "State 2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "State 3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "State 4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "State 5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "ID", "CreatedAt", "DeletedAt", "Name", "StateID", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City 1", 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City 2", 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City 3", 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City 4", 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City 5", 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City 6", 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City 7", 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City 8", 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City 9", 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City 10", 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "ID", "CityID", "CreatedAt", "DeletedAt", "Name", "StreetName", "StreetNumber", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Company 1", "Street Name", 667, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, 2L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Company 2", "Street Name", 3659, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, 3L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Company 3", "Street Name", 1675, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, 4L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Company 4", "Street Name", 4454, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, 5L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Company 5", "Street Name", 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6L, 6L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Company 6", "Street Name", 1235, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7L, 7L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Company 7", "Street Name", 687, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8L, 8L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Company 8", "Street Name", 2850, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9L, 9L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Company 9", "Street Name", 1554, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10L, 10L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Company 10", "Street Name", 4053, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ID", "BirthDate", "CityID", "CompanyID", "CreatedAt", "DeletedAt", "Email", "Name", "ProfileImage", "StreetName", "StreetNumber", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(1973, 10, 19, 14, 15, 47, 494, DateTimeKind.Local).AddTicks(6126), 1L, 1L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail1@mail.com", "Contact 1", "ImageUrl", "Street Name", 4725, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18L, new DateTime(2000, 9, 18, 14, 15, 47, 495, DateTimeKind.Local).AddTicks(1986), 9L, 9L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail18@mail.com", "Contact 18", "ImageUrl", "Street Name", 4803, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17L, new DateTime(1991, 2, 9, 14, 15, 47, 495, DateTimeKind.Local).AddTicks(1916), 9L, 9L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail17@mail.com", "Contact 17", "ImageUrl", "Street Name", 2086, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16L, new DateTime(1969, 4, 22, 14, 15, 47, 495, DateTimeKind.Local).AddTicks(1856), 8L, 8L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail16@mail.com", "Contact 16", "ImageUrl", "Street Name", 4199, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15L, new DateTime(1963, 10, 2, 14, 15, 47, 495, DateTimeKind.Local).AddTicks(1774), 8L, 8L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail15@mail.com", "Contact 15", "ImageUrl", "Street Name", 284, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14L, new DateTime(1971, 1, 2, 14, 15, 47, 495, DateTimeKind.Local).AddTicks(1718), 7L, 7L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail14@mail.com", "Contact 14", "ImageUrl", "Street Name", 4553, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13L, new DateTime(1970, 8, 27, 14, 15, 47, 495, DateTimeKind.Local).AddTicks(1626), 7L, 7L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail13@mail.com", "Contact 13", "ImageUrl", "Street Name", 534, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12L, new DateTime(1945, 11, 17, 14, 15, 47, 495, DateTimeKind.Local).AddTicks(1468), 6L, 6L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail12@mail.com", "Contact 12", "ImageUrl", "Street Name", 3199, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11L, new DateTime(1965, 8, 21, 14, 15, 47, 495, DateTimeKind.Local).AddTicks(1385), 6L, 6L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail11@mail.com", "Contact 11", "ImageUrl", "Street Name", 1273, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10L, new DateTime(1930, 3, 18, 14, 15, 47, 495, DateTimeKind.Local).AddTicks(1317), 5L, 5L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail10@mail.com", "Contact 10", "ImageUrl", "Street Name", 4335, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9L, new DateTime(1934, 8, 23, 14, 15, 47, 495, DateTimeKind.Local).AddTicks(1249), 5L, 5L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail9@mail.com", "Contact 9", "ImageUrl", "Street Name", 576, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8L, new DateTime(1983, 9, 26, 14, 15, 47, 495, DateTimeKind.Local).AddTicks(1181), 4L, 4L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail8@mail.com", "Contact 8", "ImageUrl", "Street Name", 71, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7L, new DateTime(1994, 4, 16, 14, 15, 47, 495, DateTimeKind.Local).AddTicks(1118), 4L, 4L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail7@mail.com", "Contact 7", "ImageUrl", "Street Name", 1254, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6L, new DateTime(1960, 1, 13, 14, 15, 47, 495, DateTimeKind.Local).AddTicks(1049), 3L, 3L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail6@mail.com", "Contact 6", "ImageUrl", "Street Name", 3896, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, new DateTime(1971, 12, 20, 14, 15, 47, 495, DateTimeKind.Local).AddTicks(971), 3L, 3L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail5@mail.com", "Contact 5", "ImageUrl", "Street Name", 1458, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, new DateTime(1938, 6, 20, 14, 15, 47, 495, DateTimeKind.Local).AddTicks(902), 2L, 2L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail4@mail.com", "Contact 4", "ImageUrl", "Street Name", 864, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, new DateTime(2000, 3, 31, 14, 15, 47, 495, DateTimeKind.Local).AddTicks(828), 2L, 2L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail3@mail.com", "Contact 3", "ImageUrl", "Street Name", 3345, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(1976, 9, 11, 14, 15, 47, 495, DateTimeKind.Local).AddTicks(629), 1L, 1L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail2@mail.com", "Contact 2", "ImageUrl", "Street Name", 2387, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19L, new DateTime(1928, 1, 6, 14, 15, 47, 495, DateTimeKind.Local).AddTicks(2051), 10L, 10L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail19@mail.com", "Contact 19", "ImageUrl", "Street Name", 709, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20L, new DateTime(1981, 8, 6, 14, 15, 47, 495, DateTimeKind.Local).AddTicks(2117), 10L, 10L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail20@mail.com", "Contact 20", "ImageUrl", "Street Name", 1261, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "ID", "ContactID", "CreatedAt", "DeletedAt", "Number", "PhoneTypeID", "Prefix", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "13082308", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12L, 12L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "45487436", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32L, 12L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "37371293", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13L, 13L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "73596150", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33L, 13L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "55408796", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14L, 14L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "56806799", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34L, 14L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "65031818", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15L, 15L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "60544866", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31L, 11L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "19678837", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35L, 15L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "79963571", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36L, 16L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "88737029", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17L, 17L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "73517982", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37L, 17L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "61155058", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18L, 18L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "86143261", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38L, 18L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "57174704", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19L, 19L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "29327710", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39L, 19L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "34710001", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16L, 16L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "57155732", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11L, 11L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "22838497", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30L, 10L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "95826519", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10L, 10L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "79525416", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21L, 1L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "24914982", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, 2L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "45006772", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22L, 2L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "82379261", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, 3L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "87915621", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23L, 3L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "69237232", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, 4L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "21918660", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24L, 4L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "86203476", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, 5L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "43800520", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25L, 5L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "57437936", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6L, 6L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "68697270", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26L, 6L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "45813684", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7L, 7L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "53883108", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27L, 7L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "17181636", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8L, 8L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "29505464", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28L, 8L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "19066743", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9L, 9L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "89049982", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29L, 9L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "25984454", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20L, 20L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "37268810", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40L, 20L, new DateTime(2020, 3, 31, 14, 15, 47, 487, DateTimeKind.Local).AddTicks(9526), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "51898963", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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
