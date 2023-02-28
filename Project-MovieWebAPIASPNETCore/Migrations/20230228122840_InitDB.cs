using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project_MovieWebAPIASPNETCore.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Alias = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(2055)", maxLength: 2055, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.CharacterId);
                });

            migrationBuilder.CreateTable(
                name: "Franchises",
                columns: table => new
                {
                    FranchiseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Franchises", x => x.FranchiseId);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Year = table.Column<int>(type: "int", nullable: true),
                    Director = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Trailer = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    FranchiseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_Movies_Franchises_FranchiseId",
                        column: x => x.FranchiseId,
                        principalTable: "Franchises",
                        principalColumn: "FranchiseId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "CharacterMovie",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterMovie", x => new { x.MovieId, x.CharacterId });
                    table.ForeignKey(
                        name: "FK_CharacterMovie_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterMovie_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "CharacterId", "Alias", "FullName", "Gender", "Picture" },
                values: new object[,]
                {
                    { 1, "David", "David Swax", "Male", "PicturLink" },
                    { 2, "Leo", "Leonardo Di Caprio", "Male", "PicturLink" }
                });

            migrationBuilder.InsertData(
                table: "Franchises",
                columns: new[] { "FranchiseId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Welcome to GothenburgBIO", "HBOGothernburg" },
                    { 2, "Welcome to StockholmBIO", "HBOStockholm" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Director", "FranchiseId", "Genre", "Picture", "Title", "Trailer", "Year" },
                values: new object[,]
                {
                    { 1, "David", 1, "Action", "Link", "The memory", "YouTubeLink", 2021 },
                    { 2, "John", 2, "Action", "Link", "Bat Man", "YouTubeLink", 2020 },
                    { 3, "John", 2, "Action", "Link", "Spider Man", "YouTubeLink", 2020 },
                    { 4, "John", 1, "Action", "Link", "Maze Runner", "YouTubeLink", 2018 }
                });

            migrationBuilder.InsertData(
                table: "CharacterMovie",
                columns: new[] { "CharacterId", "MovieId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterMovie_CharacterId",
                table: "CharacterMovie",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_FranchiseId",
                table: "Movies",
                column: "FranchiseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterMovie");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Franchises");
        }
    }
}
