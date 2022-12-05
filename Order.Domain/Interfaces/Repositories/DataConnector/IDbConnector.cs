using System.Data;

namespace Order.Domain.Interfaces.Repositories.DataConnector
{
    public interface IDbConnector : IDisposable
    {
        IDbConnection dbConnection { get; set; }
        IDbTransaction dbTransaction { get; set; }
    }
}
