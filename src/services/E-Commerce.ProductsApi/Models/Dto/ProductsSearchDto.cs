namespace E_Commerce.ProductsApi.Models.Dto
{
    public class ProductsSearchDto
    {
        public long Id { get; set; }

        public string? Name { get; set; } 

        public string? Image { get; set; }

        public string? Description { get; set; } 

        public decimal? Price { get; set; }
    }
}
