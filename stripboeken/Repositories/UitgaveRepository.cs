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
                inner join boek b on u.boekId = b.boekId
                order by b.reeksId";

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
    public Uitgave GetOne(int uitgaveId)
    {
        string sql = @"select *
                from uitgave
                where uitgaveId = @uitgaveId";

        using var connection = GetConnection();
        var uitgave = connection.QuerySingle<Uitgave>(sql, new {uitgaveId});
        return uitgave;
    }


    public DetailUitgave Get(int uitgaveId)
    {
        string sql = @"select *
                from detailuitgave
                where uitgaveId = @uitgaveId";

        using var connection = GetConnection();
        var uitgave = connection.QuerySingle<DetailUitgave>(sql, new {uitgaveId});
        return uitgave;
    }
    public void Update(Uitgave uitgaveInfo, Boek boekInfo)
    {
        string sqluitgave = @"UPDATE `uitgave` SET 
                    ISBN = @ISBN, 
                    afbeeldingsPad = @afbeeldingsPad, 
                    jaar = @jaar, 
                    uitgever = @uitgever,
                    druk = @druk,
                    cover = @cover,
                    taal = @taal,
                    aantalBladzijden = @aantalBladzijden,
                    breedte = @breedte,
                    hoogte = @hoogte,
                    beschrijving = @beschrijving,
                    weetjes = @weetjes 
                    WHERE uitgaveId = @uitgaveId";
        
        string sqlboek = @"UPDATE `boek` SET
                    titel = @titel,
                    weblink = @weblink
                    WHERE boekId = @boekId";    

        using var connection = GetConnection();
        var uitgave = connection.Query<Uitgave>(sqluitgave,  uitgaveInfo);
        var uitgave2 = connection.Query<Boek>(sqlboek, boekInfo);
    }
    public Uitgave Add(Uitgave uitgave)
    {
        string sql = @"
                INSERT INTO Uitgave(
                    ISBN, 
                    jaar, 
                    uitgever, 
                    druk, 
                    cover, 
                    taal, 
                    aantalBladzijden, 
                    hoogte, 
                    breedte,
                    afbeeldingsPad,
                    beschrijving,
                    weetjes,
                    boekId) 
                VALUES (
                    @ISBN,
                    @Jaar,
                    @Uitgever,
                    @Druk,
                    @Cover,
                    @Taal,
                    @AantalBladzijden,
                    @Hoogte,
                    @Breedte,
                    @AfbeeldingsPad,
                    @Beschrijving,
                    @Weetjes,
                    @BoekId); 
                SELECT * FROM Uitgave WHERE UitgaveId = LAST_INSERT_ID()";

        using var connection = GetConnection();
        var addedUitgave = connection.QuerySingle<Uitgave>(sql, uitgave);
        return addedUitgave;
    }

}