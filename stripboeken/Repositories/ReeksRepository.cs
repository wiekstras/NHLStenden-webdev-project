using System.Data;

namespace stripboeken.Repositories;

public class ReeksRepository
{
    private IDbConnection GetConnection()
    {
        return new DbUtils().GetDbConnection();
    }
}