using System.Data;
using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace stripboeken
{
    public class DbUtils : IDbUtils
    {
        public IDbConnection GetDbConnection()
        {
            string connectionString = "Server=127.0.0.1;Port=3306;Database=wevdev;Uid=root;Pwd=;";
            return new MySqlConnection(connectionString);
        }
    }

    public interface IDbUtils
    {
        IDbConnection GetDbConnection();
    }
}