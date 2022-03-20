using Dapper;
using stripboeken.Models;
using System.Data;

namespace stripboeken.Repositories;

public class UitgaveRepository
{
    private IDbConnection GetConnection()
    {
        return new DbUtils().GetDbConnection();
    }

    public IEnumerable<Uitgave> Get()
    {
        string sql = @"select u.*, b.boekId As Id, b.*
                from uitgave u
                inner join boek b on u.boekId = b.boekId";

        using var connection = GetConnection();

        var uitgaves = connection.Query<Uitgave, Boek, Uitgave>(sql, (uitgave, boek) =>
        {
            uitgave.Boek = boek;
            return uitgave;
        });
        return uitgaves;

    }

    public IEnumerable<Uitgave> GetThree(int uitgaveId, int reeksId)
    {
        string sql = @"select u.*, b.boekId As Id, b.*
                from uitgave u
                inner join boek b on u.boekId = b.boekId
                where u.uitgaveId != @uitgaveId and b.reeksId = @reeksId
                limit 3";

        using var connection = GetConnection();

        var uitgaves = connection.Query<Uitgave, Boek, Uitgave>(sql, (uitgave, boek) =>
        {
            uitgave.Boek = boek;
            return uitgave;
        }, new {uitgaveId, reeksId});
        return uitgaves;

    }

    public Uitgave Get(int uitgaveId)
    {
        string sql = @"select *
                from uitgave
                where uitgaveId = @uitgaveId";

        using var connection = GetConnection();
        var uitgave = connection.QuerySingle<Uitgave>(sql, new {uitgaveId});
        return uitgave;
    }

}