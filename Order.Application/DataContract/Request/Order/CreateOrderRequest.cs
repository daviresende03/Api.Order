namespace Order.Application.DataContract.Request.Order
{
    public sealed class CreateOrderRequest
    {
        public int ClientId { get; set; }
        public int UserId { get; set; }
        public List<CreateOrderItemRequest> Items { get; set; }
    }
}
