namespace Order.Application.DataContract.Response.Order
{
    public sealed class OrderResponse
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int UserId { get; set; }
        public List<OrderItemResponse> Items { get; set; }
    }
}
