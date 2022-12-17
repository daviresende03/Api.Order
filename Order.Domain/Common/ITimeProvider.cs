namespace Order.Domain.Common
{
    public interface ITimeProvider
    {
        public DateTime utcDate();
    }
}
