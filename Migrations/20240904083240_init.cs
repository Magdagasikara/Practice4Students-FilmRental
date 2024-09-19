using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FilmRental.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_UserId = table.Column<int>(type: "int", nullable: false),
                    FK_MovieId = table.Column<int>(type: "int", nullable: false),
                    LoanDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rentals_Movies_FK_MovieId",
                        column: x => x.FK_MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rentals_Users_FK_UserId",
                        column: x => x.FK_UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "ReleaseYear", "Title" },
                values: new object[,]
                {
                    { 1, 2013, "The Conjuring" },
                    { 2, 2001, "The Others" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "Tobias@gmail.com", "Tobias" },
                    { 2, "Johan@gmail.com", "Johan" }
                });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "FK_MovieId", "FK_UserId", "LoanDate", "ReturnDate" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, 2, new DateTime(2024, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, 1, 2, new DateTime(2024, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_FK_MovieId",
                table: "Rentals",
                column: "FK_MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_FK_UserId",
                table: "Rentals",
                column: "FK_UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
