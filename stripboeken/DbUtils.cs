using System.Data;
using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace stripboeken
{
    public class DbUtils : IDbUtils
    {
        public IDbConnection GetDbConnection()
        {
            string connectionString = "Server=localhost;Port=8889;Database=comicstore;Uid=root;Pwd=root;";
            return new MySqlConnection(connectionString);
        }
    }

    public interface IDbUtils
    {
        IDbConnection GetDbConnection();
    }
}