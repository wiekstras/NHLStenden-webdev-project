using System.Data;
using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace stripboeken
{
    public class DbUtils : IDbUtils
    {
        public IDbConnection GetDbConnection()
        {
<<<<<<< HEAD
            string connectionString = "Server=127.0.0.1;Port=3306;Database=wevdev;Uid=root;Pwd=;";
=======
            string connectionString = "Server=127.0.0.1;Port=3306;Database=comicstore;Uid=root;Pwd=;";
>>>>>>> 1bacf5ee0d69010099fbd5a6507a5b49e5fe43e8
            return new MySqlConnection(connectionString);
        }
    }

    public interface IDbUtils
    {
        IDbConnection GetDbConnection();
    }
}