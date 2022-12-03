namespace Order.Domain.Models
{
    public class ProductModel : BaseEntity
    {
        public string Description { get; set; }
        public decimal SellValue { get; set; }
        public int Stock { get; set; }
    }
}
