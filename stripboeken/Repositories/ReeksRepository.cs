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
}