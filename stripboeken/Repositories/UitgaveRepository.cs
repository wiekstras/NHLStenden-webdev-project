using System.Data;

namespace stripboeken.Repositories;

public class UitgaveRepository
{
    private IDbConnection GetConnection()
    {
        return new DbUtils().GetDbConnection();
    }
}