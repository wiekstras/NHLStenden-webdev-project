using System.Data;

namespace stripboeken.Repositories;

public class BezitRepository
{
    private IDbConnection GetConnection()
    {
        return new DbUtils().GetDbConnection();
    }
}