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

    public Boek Get(int boekId)
    {
        string sql = @"select *
                from boek
                where boekId = @boekId";

        using var connection = GetConnection();
        var boek = connection.QuerySingle<Boek>(sql, new { boekId });
        return boek;
    }
}
