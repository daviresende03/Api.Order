namespace Order.Domain.Models
{
    public class ProductModel : BaseEntity
    {
        public string Description { get; set; }
        public string SellValue { get; set; }
        public int Stock { get; set; }
    }
}
