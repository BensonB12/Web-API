using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoardGames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    MinPlayers = table.Column<int>(type: "int", nullable: false),
                    MaxPlayers = table.Column<int>(type: "int", nullable: false),
                    PlayTime = table.Column<int>(type: "int", nullable: false),
                    MinAge = table.Column<int>(type: "int", nullable: false),
                    UsersRated = table.Column<int>(type: "int", nullable: false),
                    ComplexityAverage = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: false),
                    OwnedUsers = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Domains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domains", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mechanic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mechanic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BoardGames_Domains",
                columns: table => new
                {
                    BoardgameId = table.Column<int>(type: "int", nullable: false),
                    DomainId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGames_Domains", x => new { x.BoardgameId, x.DomainId });
                    table.ForeignKey(
                        name: "FK_BoardGames_Domains_BoardGames_BoardgameId",
                        column: x => x.BoardgameId,
                        principalTable: "BoardGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoardGames_Domains_Domains_DomainId",
                        column: x => x.DomainId,
                        principalTable: "Domains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoardGames_Mechanics",
                columns: table => new
                {
                    BoardgameId = table.Column<int>(type: "int", nullable: false),
                    MechanicId = table.Column<int>(type: "int", nullable: false),
                    DomainId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MechanicId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGames_Mechanics", x => new { x.BoardgameId, x.MechanicId });
                    table.ForeignKey(
                        name: "FK_BoardGames_Mechanics_BoardGames_MechanicId",
                        column: x => x.MechanicId,
                        principalTable: "BoardGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoardGames_Mechanics_Domains_DomainId",
                        column: x => x.DomainId,
                        principalTable: "Domains",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BoardGames_Mechanics_Mechanic_MechanicId1",
                        column: x => x.MechanicId1,
                        principalTable: "Mechanic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoardGames_Domains_DomainId",
                table: "BoardGames_Domains",
                column: "DomainId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardGames_Mechanics_DomainId",
                table: "BoardGames_Mechanics",
                column: "DomainId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardGames_Mechanics_MechanicId",
                table: "BoardGames_Mechanics",
                column: "MechanicId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardGames_Mechanics_MechanicId1",
                table: "BoardGames_Mechanics",
                column: "MechanicId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoardGames_Domains");

            migrationBuilder.DropTable(
                name: "BoardGames_Mechanics");

            migrationBuilder.DropTable(
                name: "BoardGames");

            migrationBuilder.DropTable(
                name: "Domains");

            migrationBuilder.DropTable(
                name: "Mechanic");
        }
    }
}
