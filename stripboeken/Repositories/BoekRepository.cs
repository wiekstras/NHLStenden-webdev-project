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

    //Selecteert een enkele stripboek uit de database met het meegegeven boekId.
    public Boek GetSingle(int boekId)
    {
        string sql = @"select *
                from boek
                where boekId = @boekId";

        using var connection = GetConnection();
        var boek = connection.QuerySingle<Boek>(sql, new { boekId });
        return boek;
    }

    //Selecteert alle boeken die onderdeel zijn van de meegegeven reeks.
    public IEnumerable<Boek> Get(int reeksid)
    {
        string sql = @"select *
                from Boek
                where ReeksId = @ReeksId";

        using var connection = GetConnection();
        var boeken = connection.Query<Boek>(sql, new { reeksid });
        return boeken;
    }

    //Voegt een boek toe aan de database.
    public Boek Add(Boek boek)
    {
        string sql = @"
                INSERT INTO Boek (titel, weblink, reeksId, is18Plus) 
                VALUES (@Titel, @Weblink, @ReeksId, @is18Plus); 
                SELECT * FROM Boek WHERE BoekId = LAST_INSERT_ID()";

        using var connection = GetConnection();
        var addedBoek = connection.QuerySingle<Boek>(sql, boek);
        return addedBoek;
    }

    //Past een bestaand boek aan.
    public Boek Update(Boek boek)
    {
        string sql = @"
                UPDATE Boek SET 
                    titel = @Titel,
                    weblink = @Weblink
                WHERE boekId = @BoekId;
                SELECT * FROM Boek WHERE BoekId = @BoekId";

        using var connection = GetConnection();
        var updatedBoek = connection.QuerySingle<Boek>(sql, boek);
        return updatedBoek;
    }

}
