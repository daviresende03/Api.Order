namespace Order.Application.DataContract.Request.Order
{
    public sealed class CreateOrderItemRequest
    {
        public int ProductId { get; set; }
        public decimal SellValue { get; set; }
        public int Quantity { get; set; }
    }
}
