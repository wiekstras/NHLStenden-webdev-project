using System.Data;

namespace stripboeken.Repositories;

public class GebruikerRepository
{
    private IDbConnection GetConnection()
    {
        return new DbUtils().GetDbConnection();
    }
}