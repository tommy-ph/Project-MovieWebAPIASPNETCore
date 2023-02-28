using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project_MovieWebAPIASPNETCore.Migrations
{
    /// <inheritdoc />
    public partial class SeedDatas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "CharacterId", "Alias", "FullName", "Gender", "Picture" },
                values: new object[,]
                {
                    { 1, "HBO", "David Swax", "Male", "PicturLink" },
                    { 2, "HBO", "Sven Swax", "Female", "PicturLink" }
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
                columns: new[] { "MovieId", "Director", "Genre", "Picture", "Title", "Trailer", "Year" },
                values: new object[,]
                {
                    { 1, "David", "Action", "Link", "The momory", "YouTubeLink", "2021" },
                    { 2, "John", "Action", "Link", "Bat Man", "YouTubeLink", "2020" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "CharacterId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "CharacterId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Franchises",
                keyColumn: "FranchiseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Franchises",
                keyColumn: "FranchiseId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 2);
        }
    }
}
