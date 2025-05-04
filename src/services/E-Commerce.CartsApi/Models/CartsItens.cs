using DeveloperEvaluation.Core.Domain;

namespace E_Commerce.CartsApi.Models
{
    public class CartsItens : BaseEntity
    {
        public int Quantity { get; set; }
        public decimal UnitPrices { get; set; }
        public decimal? Discounts { get; set; }
        public long ProductId { get; set; }
        public virtual Products Product { get; set; }
        public long CartsId { get; set; }
        public virtual Carts Carts { get; set; }
        public DateTime DateAdd { get; set; }
        public DateTime? DateUpdated { get; set; }

        public CartsItens()
        {
            DateAdd = DateTime.Now;
        }
    }
}
