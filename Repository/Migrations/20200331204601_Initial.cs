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
                        .Annotation("Npgsql:IdentitySequenceOptions", "'3', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
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
                        .Annotation("Npgsql:IdentitySequenceOptions", "'6', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
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
                        .Annotation("Npgsql:IdentitySequenceOptions", "'11', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
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
                        .Annotation("Npgsql:IdentitySequenceOptions", "'11', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
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
                        .Annotation("Npgsql:IdentitySequenceOptions", "'21', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
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
                        .Annotation("Npgsql:IdentitySequenceOptions", "'41', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
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
                columns: new[] { "ID", "Active", "CreatedAt", "DeletedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, true, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "work", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, true, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "personal", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "ID", "Active", "CreatedAt", "DeletedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, true, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "State 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, true, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "State 2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, true, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "State 3", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, true, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "State 4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, true, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "State 5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "ID", "Active", "CreatedAt", "DeletedAt", "Name", "StateID", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, true, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City 1", 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, true, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City 2", 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, true, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City 3", 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, true, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City 4", 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, true, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City 5", 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6L, true, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City 6", 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7L, true, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City 7", 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8L, true, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City 8", 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9L, true, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City 9", 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10L, true, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "City 10", 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "ID", "Active", "CityID", "CreatedAt", "DeletedAt", "Name", "StreetName", "StreetNumber", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, true, 1L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Company 1", "Street Name", 634, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, true, 2L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Company 2", "Street Name", 1202, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, true, 3L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Company 3", "Street Name", 1501, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, true, 4L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Company 4", "Street Name", 1968, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, true, 5L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Company 5", "Street Name", 855, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6L, true, 6L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Company 6", "Street Name", 4355, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7L, true, 7L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Company 7", "Street Name", 147, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8L, true, 8L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Company 8", "Street Name", 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9L, true, 9L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Company 9", "Street Name", 3410, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10L, true, 10L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Company 10", "Street Name", 4998, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ID", "Active", "BirthDate", "CityID", "CompanyID", "CreatedAt", "DeletedAt", "Email", "Name", "ProfileImage", "StreetName", "StreetNumber", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, false, new DateTime(1995, 2, 24, 17, 46, 0, 826, DateTimeKind.Local).AddTicks(7971), 1L, 1L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail1@mail.com", "Contact 1", "ImageUrl", "Street Name", 740, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18L, false, new DateTime(1985, 2, 19, 17, 46, 0, 827, DateTimeKind.Local).AddTicks(3609), 9L, 9L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail18@mail.com", "Contact 18", "ImageUrl", "Street Name", 3900, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17L, false, new DateTime(1917, 2, 6, 17, 46, 0, 827, DateTimeKind.Local).AddTicks(3566), 9L, 9L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail17@mail.com", "Contact 17", "ImageUrl", "Street Name", 3624, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16L, false, new DateTime(1987, 3, 9, 17, 46, 0, 827, DateTimeKind.Local).AddTicks(3525), 8L, 8L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail16@mail.com", "Contact 16", "ImageUrl", "Street Name", 4380, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15L, false, new DateTime(1995, 9, 18, 17, 46, 0, 827, DateTimeKind.Local).AddTicks(3482), 8L, 8L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail15@mail.com", "Contact 15", "ImageUrl", "Street Name", 4572, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14L, false, new DateTime(1958, 11, 5, 17, 46, 0, 827, DateTimeKind.Local).AddTicks(3441), 7L, 7L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail14@mail.com", "Contact 14", "ImageUrl", "Street Name", 1692, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13L, false, new DateTime(1952, 7, 6, 17, 46, 0, 827, DateTimeKind.Local).AddTicks(3399), 7L, 7L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail13@mail.com", "Contact 13", "ImageUrl", "Street Name", 737, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12L, false, new DateTime(1940, 7, 1, 17, 46, 0, 827, DateTimeKind.Local).AddTicks(3357), 6L, 6L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail12@mail.com", "Contact 12", "ImageUrl", "Street Name", 2231, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11L, false, new DateTime(1911, 11, 8, 17, 46, 0, 827, DateTimeKind.Local).AddTicks(3316), 6L, 6L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail11@mail.com", "Contact 11", "ImageUrl", "Street Name", 2274, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10L, false, new DateTime(1976, 7, 15, 17, 46, 0, 827, DateTimeKind.Local).AddTicks(3273), 5L, 5L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail10@mail.com", "Contact 10", "ImageUrl", "Street Name", 392, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9L, false, new DateTime(1917, 6, 27, 17, 46, 0, 827, DateTimeKind.Local).AddTicks(3225), 5L, 5L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail9@mail.com", "Contact 9", "ImageUrl", "Street Name", 1212, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8L, false, new DateTime(1977, 6, 20, 17, 46, 0, 827, DateTimeKind.Local).AddTicks(3177), 4L, 4L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail8@mail.com", "Contact 8", "ImageUrl", "Street Name", 1011, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7L, false, new DateTime(1947, 3, 3, 17, 46, 0, 827, DateTimeKind.Local).AddTicks(3111), 4L, 4L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail7@mail.com", "Contact 7", "ImageUrl", "Street Name", 4115, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6L, false, new DateTime(1944, 7, 27, 17, 46, 0, 827, DateTimeKind.Local).AddTicks(3063), 3L, 3L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail6@mail.com", "Contact 6", "ImageUrl", "Street Name", 4949, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, false, new DateTime(1948, 7, 21, 17, 46, 0, 827, DateTimeKind.Local).AddTicks(3009), 3L, 3L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail5@mail.com", "Contact 5", "ImageUrl", "Street Name", 670, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, false, new DateTime(1957, 9, 29, 17, 46, 0, 827, DateTimeKind.Local).AddTicks(2961), 2L, 2L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail4@mail.com", "Contact 4", "ImageUrl", "Street Name", 1464, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, false, new DateTime(1913, 12, 14, 17, 46, 0, 827, DateTimeKind.Local).AddTicks(2904), 2L, 2L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail3@mail.com", "Contact 3", "ImageUrl", "Street Name", 3729, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, false, new DateTime(1971, 7, 24, 17, 46, 0, 827, DateTimeKind.Local).AddTicks(2695), 1L, 1L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail2@mail.com", "Contact 2", "ImageUrl", "Street Name", 4623, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19L, false, new DateTime(2004, 2, 2, 17, 46, 0, 827, DateTimeKind.Local).AddTicks(3656), 10L, 10L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail19@mail.com", "Contact 19", "ImageUrl", "Street Name", 3863, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20L, false, new DateTime(2002, 3, 30, 17, 46, 0, 827, DateTimeKind.Local).AddTicks(3698), 10L, 10L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ContactEmail20@mail.com", "Contact 20", "ImageUrl", "Street Name", 2161, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "ID", "Active", "ContactID", "CreatedAt", "DeletedAt", "Number", "PhoneTypeID", "Prefix", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, true, 1L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "80780086", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12L, true, 12L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "19989928", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32L, true, 12L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "30359321", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13L, true, 13L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "93093592", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33L, true, 13L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "55326444", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14L, true, 14L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "43881031", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34L, true, 14L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "14076770", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15L, true, 15L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "59544842", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31L, true, 11L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "58309453", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35L, true, 15L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "58178676", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36L, true, 16L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "43407572", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17L, true, 17L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "70920751", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37L, true, 17L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "22579408", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18L, true, 18L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "32032322", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38L, true, 18L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "58955993", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19L, true, 19L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "30488697", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39L, true, 19L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "58493032", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16L, true, 16L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "25297858", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11L, true, 11L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "67004468", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30L, true, 10L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "98104239", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10L, true, 10L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "88212963", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21L, true, 1L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "66943274", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, true, 2L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "19243518", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22L, true, 2L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "81764730", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, true, 3L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "87493964", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23L, true, 3L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "63986100", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, true, 4L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "91818087", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24L, true, 4L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "12960444", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5L, true, 5L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "25007644", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25L, true, 5L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "75940413", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6L, true, 6L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "53756815", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26L, true, 6L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "81128033", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7L, true, 7L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "48203061", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27L, true, 7L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "93068847", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8L, true, 8L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "71592285", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28L, true, 8L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "90179787", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9L, true, 9L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "28124488", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29L, true, 9L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "85756115", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20L, true, 20L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "27271806", 1L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40L, true, 20L, new DateTime(2020, 3, 31, 17, 46, 0, 817, DateTimeKind.Local).AddTicks(2924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "70442163", 2L, "549", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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
