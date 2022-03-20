using Dapper;
using stripboeken.Models;
using System.Data;

namespace stripboeken.Repositories;

public class AuteurRepository
{
    private IDbConnection GetConnection()
    {
        return new DbUtils().GetDbConnection();
    }

    //public int GetAuteurId(int uitgaveId)
    //{
    //    using var connection = GetConnection();
    //    var sql = "select auteurId from schrijft where uitgaveId = @uitgaveId";
    //    var auteurId = connection.ExecuteScalar<int>(sql, new { uitgaveId });
    //    return auteurId;
    //}

    //public Auteur Get(int auteurId)
    //{
    //    using var connection = GetConnection();
    //    var sql = "select * from auteur where auteurId = @auteurId";
    //    var auteur = connection.QuerySingle<Auteur>(sql, new { auteurId });
    //    return auteur;
    //}

    public IEnumerable<Auteur> Get(int uitgaveId)
    {
        using var connection = GetConnection();
        var sql = @"SELECT a.* 
                     FROM Auteur a 
                     INNER JOIN Schrijft s ON a.auteurId = s.auteurId 
                     INNER JOIN Uitgave u ON s.uitgaveId = u.uitgaveId 
                     WHERE u.uitgaveId = @uitgaveId;";
        var auteur = connection.Query<Auteur>(sql, new{uitgaveId});
        return auteur;
    }
}