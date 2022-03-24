using Dapper;
using stripboeken.Models;
using System.Data;

namespace stripboeken.Repositories;

public class BoekRepository
{
    private IDbConnection GetConnection()
    {
        return new DbUtils().GetDbConnection();
    }

    public Boek GetSingle(int boekId)
    {
        string sql = @"select *
                from boek
                where boekId = @boekId";

        using var connection = GetConnection();
        var boek = connection.QuerySingle<Boek>(sql, new { boekId });
        return boek;
    }

    public IEnumerable<Boek> Get(int reeksid)
    {
        string sql = @"select *
                from Boek
                where ReeksId = @ReeksId";

        using var connection = GetConnection();
        var boeken = connection.Query<Boek>(sql, new {reeksid});
        return boeken;
    }

    public Boek Add(Boek boek)
    {
        string sql = @"
                INSERT INTO Boek (titel, reeksId) 
                VALUES (@Titel, @ReeksId); 
                SELECT * FROM Boek WHERE BoekId = LAST_INSERT_ID()";

        using var connection = GetConnection();
        var addedBoek = connection.QuerySingle<Boek>(sql, boek);
        return addedBoek;
    }

}
