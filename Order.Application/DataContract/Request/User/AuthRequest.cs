namespace Order.Application.DataContract.Request.User
{
    public sealed class AuthRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
