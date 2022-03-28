using System.Data;
using Dapper;
using stripboeken.Models;

namespace stripboeken.Repositories;

public class DetailBezitRepository
{
    private IDbConnection GetConnection()
    {
        return new DbUtils().GetDbConnection();
    }

    public IEnumerable<DetailBezit> Get(string Id)
    {
        using var connection = GetConnection();
        var sql = @"SELECT * FROM detailbezit WHERE Id = @Id";
        var boeken = connection.Query<DetailBezit>(sql, new{Id});
        return boeken;
    }
}