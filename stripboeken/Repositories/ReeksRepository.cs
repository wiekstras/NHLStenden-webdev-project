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

    //Selecteert de reeks van het bijbehorende reeksId.
    public Reeks GetSingle(int reeksId)
    {
        string sql = @"select *
                from Reeks
                where reeksId = @reeksId";

        using var connection = GetConnection();
        var reeks = connection.QuerySingle<Reeks>(sql, new { reeksId });
        return reeks;
    }

    //Selecteert alle reeksen uit de database.
    public IEnumerable<Reeks> Get()
    {
        string sql = @"select *
                from Reeks";

        using var connection = GetConnection();
        var reeks = connection.Query<Reeks>(sql);
        return reeks;
    }

    //Voegt een nieuwe reeks toe.
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