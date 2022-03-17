using System.Data;

namespace stripboeken.Repositories;

public class BoekRepository
{
    private IDbConnection GetConnection()
    {
        return new DbUtils().GetDbConnection();
    }
}