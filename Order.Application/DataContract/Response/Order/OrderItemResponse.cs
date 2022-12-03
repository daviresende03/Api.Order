﻿namespace Order.Application.DataContract.Response.Order
{
    public sealed class OrderItemResponse
    {
        public int ProductId { get; set; }
        public decimal SellValue { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
