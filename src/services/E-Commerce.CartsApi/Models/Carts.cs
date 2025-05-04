using DeveloperEvaluation.Core.Domain;

namespace E_Commerce.CartsApi.Models
{
    public enum StatusCartsEn
    {
        InSale = 1,
        Sold = 2,   
    }
    public class Carts : BaseEntity
    {
        public virtual List<CartsItens> CartItens { get; set; }
        public DateTime? DateOfSale { get; set; }
        public StatusCartsEn StatusCartsEn { get; set; }

        public Carts()
        {
            StatusCartsEn = StatusCartsEn.InSale;
        }
    }
}
