namespace Order.Domain.Models
{
    public class ClientModel : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string phoneNumber { get; set; }
        public string Adress { get; set; }
    }
}
