using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.ProductsApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var now = DateTime.UtcNow;

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[]
                {
                    "Id", "Name", "Image", "Description", "Price",
                    "DateCreated", "IdUserInserted", "Active"
                },
                values: new object[,]
                {
                    { 1L, "Brahma", "brahma.jpg", "Cerveja Pilsen da Ambev", 5.99m, now, 1L, true },
                    { 2L, "Skol", "skol.jpg", "Cerveja leve e refrescante", 4.99m, now, 1L, true },
                    { 3L, "Bohemia", "bohemia.jpg", "Cerveja de puro malte", 6.99m, now, 1L, true },
                    { 4L, "Antarctica", "antarctica.jpg", "Cerveja tradicional do Brasil", 5.49m, now, 1L, true },
                    { 5L, "Budweiser", "budweiser.jpg", "Cerveja Premium da Ambev", 6.49m, now, 1L, true },
                    { 6L, "Stella Artois", "stella.jpg", "Cerveja Belga da Ambev", 7.49m, now, 1L, true },
                    { 7L, "Corona", "corona.jpg", "Cerveja mexicana da Ambev", 8.49m, now, 1L, true },
                    { 8L, "Beck's", "becks.jpg", "Cerveja de sabor marcante", 7.29m, now, 1L, true },
                    { 9L, "Caracu", "caracu.jpg", "Cerveja escura e encorpada", 6.99m, now, 1L, true },
                    { 10L, "Polar", "polar.jpg", "Cerveja do Sul do Brasil", 5.79m, now, 1L, true },
                    { 11L, "Franziskaner", "franziskaner.jpg", "Cerveja de trigo premium", 9.99m, now, 1L, true },
                    { 12L, "Hoegaarden", "hoegaarden.jpg", "Cerveja belga de trigo", 9.49m, now, 1L, true },
                    { 13L, "Leffe", "leffe.jpg", "Cerveja belga de abadia", 10.99m, now, 1L, true },
                    { 14L, "Quilmes", "quilmes.jpg", "Cerveja argentina da Ambev", 7.99m, now, 1L, true },
                    { 15L, "Wäls", "wals.jpg", "Cerveja artesanal brasileira", 11.49m, now, 1L, true },
                    { 16L, "Colorado", "colorado.jpg", "Cerveja artesanal com toque de mel", 10.99m, now, 1L, true },
                    { 17L, "Goose Island", "goose.jpg", "Cerveja artesanal americana", 12.99m, now, 1L, true },
                    { 18L, "Serramalte", "serramalte.jpg", "Cerveja encorpada e maltada", 7.49m, now, 1L, true },
                    { 19L, "Spaten", "spaten.jpg", "Cerveja puro malte alemã", 8.99m, now, 1L, true },
                    { 20L, "Eisenbahn", "eisenbahn.jpg", "Cerveja artesanal brasileira", 6.95m, now, 1L, true },
                    { 21L, "Devassa", "devassa.jpg", "Cerveja leve e tropical", 7.47m, now, 1L, true },
                    { 22L, "Cusqueña", "cusqueña.jpg", "Cerveja premium do Peru", 9.25m, now, 1L, true },
                    { 23L, "Baltika", "baltika.jpg", "Cerveja russa forte e saborosa", 8.88m, now, 1L, true },
                    { 24L, "Löwenbräu", "lowenbrau.jpg", "Cerveja tradicional alemã", 10.42m, now, 1L, true },
                    { 25L, "Itaipava", "itaipava.jpg", "Cerveja popular do Brasil", 6.45m, now, 1L, true },
                    { 26L, "Zillertal", "zillertal.jpg", "Cerveja uruguaia premium", 10.32m, now, 1L, true },
                    { 27L, "Baden Baden", "badenbaden.jpg", "Cerveja gourmet nacional", 12.10m, now, 1L, true },
                    { 28L, "Kaiser", "kaiser.jpg", "Cerveja leve do Brasil", 4.50m, now, 1L, true },
                    { 29L, "Heineken", "heineken.jpg", "Cerveja premium holandesa", 8.29m, now, 1L, true },
                    { 30L, "Amstel", "amstel.jpg", "Cerveja pilsen holandesa", 6.99m, now, 1L, true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
               table: "Products",
               keyColumn: "Id",
               keyValues: new object[]
               {
                    1L, 2L, 3L, 4L, 5L,
                    6L, 7L, 8L, 9L, 10L,
                    11L, 12L, 13L, 14L, 15L,
                    16L, 17L, 18L, 19L, 20L,
                    21L, 22L, 23L, 24L, 25L,
                    26L, 27L, 28L, 29L, 30L
               });
        }
    }
}
