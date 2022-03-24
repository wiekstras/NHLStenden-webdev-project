using Dapper;
using stripboeken.Models;
using System.Data;

namespace stripboeken.Repositories;

public class ReeksRepository
{
    private IDbConnection GetConnection()
    {
        return new DbUtils().GetDbConnection();
    }

    public Reeks Get(int reeksId)
    {
        string sql = @"select *
                from Reeks
                where reeksId = @reeksId";

        using var connection = GetConnection();
        var reeks = connection.QuerySingle<Reeks>(sql, new { reeksId });
        return reeks;
    }

    public IEnumerable<Reeks> Get()
    {
        string sql = @"select *
                from Reeks";

        using var connection = GetConnection();
        var reeks = connection.Query<Reeks>(sql);
        return reeks;
    }

    public Reeks Add(string titel)
    {
        string sql = @"
                INSERT INTO Reeks (Titel) 
                VALUES (@Titel); 
                SELECT * FROM Reeks WHERE ReeksId = LAST_INSERT_ID()";

        using var connection = GetConnection();
        var addedReeks = connection.QuerySingle<Reeks>(sql, new {titel});
        return addedReeks;
    }
}