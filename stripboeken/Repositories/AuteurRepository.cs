using System.Data;

namespace stripboeken.Repositories;

public class AuteurRepository
{
    private IDbConnection GetConnection()
    {
        return new DbUtils().GetDbConnection();
    }
}