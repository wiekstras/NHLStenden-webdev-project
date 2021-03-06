using System.Data;
using Dapper;
using Microsoft.AspNetCore.Identity;
using stripboeken.Models;

namespace stripboeken.Repositories;

public class BezitRepository
{
    private IDbConnection GetConnection()
    {
        return new DbUtils().GetDbConnection();
    }

    public IEnumerable<Bezit> Get(string Id)
    {
        using var connection = GetConnection();
        var sql = @"SELECT * FROM bezit WHERE Id = @Id";
        return connection.Query<Bezit>(sql, new {Id});
    }
    public Bezit GetFromBezitId(int Id)
    {
        using var connection = GetConnection();
        var sql = @"SELECT * FROM bezit WHERE bezitId = @Id";
        return connection.QuerySingle<Bezit>(sql, new {Id});
    }
    public void AddToCollection(string Id, int uitgaveId, string afbeeldingsPad)
    {
        using var connection = GetConnection();
        var sql = @"INSERT INTO Bezit(waardering, staat, staatBeschrijving, inkoopPrijs, isTeKoop, verkoopPrijs, afbeeldingsPad, Id, uitgaveId)
        VALUES (@waardering, @staat, @staatBeschrijving, @inkoopPrijs, @isTeKoop, @verkoopPrijs, @afbeeldingsPad, @Id, @uitgaveId)";
        connection.Query<Bezit>(sql, new{uitgaveId, staat = "Gebruikt", waardering = 1, afbeeldingsPad, Id, inkoopPrijs = 10.00, staatBeschrijving = "Test", verkoopPrijs = "10.00", isTeKoop = 1});
    }

    public void RemoveFromCollection(int bezitId)
    {
        using var connection = GetConnection();
        var sql = @"DELETE FROM `bezit` WHERE `bezit`.`bezitId` = @bezitId";
        connection.Query(sql, new {bezitId});
    }
    public Bezit Update(Bezit bezit)
    {
        string sql = @"
                UPDATE bezit SET 
                    staat = @staat,
                    staatBeschrijving = @staatBeschrijving,
                    waardering = @waardering,
                    afbeeldingsPad = @afbeeldingsPad,
                    inkoopPrijs = @inkoopPrijs,
                    verkoopPrijs = @verkoopPrijs,
                    isTeKoop = @isTeKoop
                WHERE bezitId = @bezitId;
                SELECT * FROM bezit WHERE bezitId = @bezitId";

        using var connection = GetConnection();
        var updatedBezit = connection.QuerySingle<Bezit>(sql, bezit);
        return updatedBezit;
    }
}