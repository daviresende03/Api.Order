namespace Order.Application.DataContract.Response.Product
{
    public sealed class ProductResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal SellValue { get; set; }
        public int Stock { get; set; }
    }
}
