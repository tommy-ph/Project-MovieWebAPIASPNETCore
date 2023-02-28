using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project_MovieWebAPIASPNETCore.Migrations
{
    /// <inheritdoc />
    public partial class InitDataSeedUpdateLink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CharacterMovie",
                columns: new[] { "CharacterId", "MovieId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 }
                });

            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "CharacterId",
                keyValue: 1,
                columns: new[] { "Alias", "FullName", "Picture" },
                values: new object[] { "Newt", "Thomas Brodie", "https://flxt.tmsimg.com/assets/294818_v9_bc.jpg" });

            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "CharacterId",
                keyValue: 2,
                columns: new[] { "Alias", "FullName", "Picture" },
                values: new object[] { "Minho", "Ki Hong Lee", "https://static.wikia.nocookie.net/vsbattles/images/a/a7/Minho.jpg/revision/latest?cb=20191010095625" });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "CharacterId", "Alias", "FullName", "Gender", "Picture" },
                values: new object[,]
                {
                    { 3, "Aragorn", "Aragorn II Elessar", "Male", "https://static.wikia.nocookie.net/jadensadventures/images/4/43/Aragorn3.jpg/revision/latest?cb=20140114165013" },
                    { 4, "Galadriel", "Galadriel Stineman", "Male", "https://cdn.vox-cdn.com/thumbor/o9vHcxXd56YpUuoysEaC3YsVKco=/1400x1050/filters:format(jpeg)/cdn.vox-cdn.com/uploads/chorus_asset/file/23981590/RPAZ_S1_UT_210709_GRAMAT_00291_R2.jpg" }
                });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 1,
                columns: new[] { "Director", "Picture", "Title", "Trailer", "Year" },
                values: new object[] { "Peter Jackson", "https://nosomosnonos.com/wp-content/uploads/2022/08/A7A70911-8905-4347-BE36-387C8E2E094B.jpeg", "The Lords of the Ring", "https://www.youtube.com/watch?v=uYnQDsaxHZU", 2022 });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 2,
                columns: new[] { "Director", "Picture", "Trailer" },
                values: new object[] { "Matt Reeves", "https://www.thebatman.com/images/share.jpg", "https://www.youtube.com/watch?v=lpeeXtsATYo" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 3,
                columns: new[] { "Director", "Picture", "Trailer" },
                values: new object[] { "Sam Raimi", "https://m.media-amazon.com/images/M/MV5BYTk3MDljOWQtNGI2My00OTEzLTlhYjQtOTQ4ODM2MzUwY2IwXkEyXkFqcGdeQXVyNTIzOTk5ODM@._V1_FMjpg_UX1000_.jpg", "https://www.youtube.com/watch?v=iaD2f2O9wGk" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 4,
                columns: new[] { "Director", "Picture", "Trailer" },
                values: new object[] { "Wes Ball", "https://d2iltjk184xms5.cloudfront.net/uploads/photo/file/327788/7560e35531bfc0aedca67ebde8156d6b-cure-poster.jpg", "https://www.youtube.com/watch?v=FPZ3cWWnB_g" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "CharacterMovie",
                keyColumns: new[] { "CharacterId", "MovieId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "CharacterId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "CharacterId",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "CharacterId",
                keyValue: 1,
                columns: new[] { "Alias", "FullName", "Picture" },
                values: new object[] { "David", "David Swax", "PicturLink" });

            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "CharacterId",
                keyValue: 2,
                columns: new[] { "Alias", "FullName", "Picture" },
                values: new object[] { "Leo", "Leonardo Di Caprio", "PicturLink" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 1,
                columns: new[] { "Director", "Picture", "Title", "Trailer", "Year" },
                values: new object[] { "David", "Link", "The memory", "YouTubeLink", 2021 });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 2,
                columns: new[] { "Director", "Picture", "Trailer" },
                values: new object[] { "John", "Link", "YouTubeLink" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 3,
                columns: new[] { "Director", "Picture", "Trailer" },
                values: new object[] { "John", "Link", "YouTubeLink" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 4,
                columns: new[] { "Director", "Picture", "Trailer" },
                values: new object[] { "John", "Link", "YouTubeLink" });
        }
    }
}
