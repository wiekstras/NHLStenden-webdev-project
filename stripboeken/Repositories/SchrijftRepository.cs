using System.Data;

namespace stripboeken.Repositories;

public class SchrijftRepository
{
    private IDbConnection GetConnection()
    {
        return new DbUtils().GetDbConnection();
    }
}