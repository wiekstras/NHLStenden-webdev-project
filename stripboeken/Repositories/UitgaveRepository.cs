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

    //Ophalen van alle uitgaven in de database.
    public IEnumerable<DetailUitgave> Get()
    {
        string sql = @"select *
                from detailuitgave";

        using var connection = GetConnection();

        var uitgave = connection.Query<DetailUitgave>(sql);
        return uitgave;
    }

    //Ophalen van een enkele uitgave met het opgegeven Id uit de database.
    public DetailUitgave Get(int uitgaveId)
    {
        string sql = @"select *
                from detailuitgave
                where uitgaveId = @uitgaveId";

        using var connection = GetConnection();

        var uitgave = connection.QuerySingle<DetailUitgave>(sql, new { uitgaveId });
        return uitgave;
    }

    //Ophalen van alle uitgaven die overeenkomen met de zoekterm van de reekstitel.
    public IEnumerable<DetailUitgave> SearchReeks(Filter filter)
    {
        string sql = @"select *
                from detailuitgave
                where reeksTitel LIKE CONCAT('%',@Value,'%')";

        using var connection = GetConnection();

        var uitgave = connection.Query<DetailUitgave>(sql, filter);
        return uitgave;
    }

    //Ophalen van alle uitgaven die overeenkomen met de zoekterm van de boektitel.
    public IEnumerable<DetailUitgave> SearchBoek(Filter filter)
    {
        string sql = @"select *
                from detailuitgave
                where boekTitel LIKE CONCAT('%',@Value,'%')";

        using var connection = GetConnection();

        var uitgave = connection.Query<DetailUitgave>(sql, filter);
        return uitgave;
    }

    //Ophalen van alle uitgaven die overeenkomen met de zoekterm van het ISBN nummer.
    public IEnumerable<DetailUitgave> SearchISBN(Filter filter)
    {
        string sql = @"select *
                from detailuitgave
                where ISBN LIKE CONCAT('%',@Value,'%')";

        using var connection = GetConnection();

        var uitgave = connection.Query<DetailUitgave>(sql, filter);
        return uitgave;
    }

    //Ophalen van 3 uitgaven die in dezelfde reeks zitten als de getoonde uitgave.
    //to do: vervangen met de detailuitgave view
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

    //Updaten van de uitgave
    public Uitgave Update(Uitgave uitgave)
    {
        string sql =@"UPDATE detailuitgave 
                    SET
                    ISBN = @ISBN, 
                    afbeeldingsPad = @AfbeeldingsPad, 
                    Jaar = @Jaar, 
                    uitgever = @Uitgever,
                    druk = @Druk,
                    cover = @Cover,
                    taal = @Taal,
                    aantalBladzijden = @AantalBladzijden,
                    breedte = @Breedte,
                    hoogte = @Hoogte,
                    beschrijving = @Beschrijving,
                    weetjes = @Weetjes 
                    WHERE uitgaveId = @UitgaveId;
                    
                    SELECT *
                    FROM uitgave
                    WHERE uitgaveId = @UitgaveId;";
        
        using var connection = GetConnection();
        var updatedUitgave = connection.QuerySingle<Uitgave>(sql,  uitgave);
        return updatedUitgave;
    }

    //Toevoegen van een nieuwe uitgave
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

    //Verouderd door gebruik van de view detailuitgave. Geen joins meer nodig.
    //public IEnumerable<Uitgave> Get()
    //{
    //    string sql = @"select u.*, b.boekId As Id, b.*
    //            from uitgave u
    //            inner join boek b on u.boekId = b.boekId
    //            order by b.reeksId asc, b.titel asc";

    //    using var connection = GetConnection();

    //    var uitgaves = connection.Query<Uitgave, Boek, Uitgave>(sql, (uitgave, boek) =>
    //    {
    //        uitgave.Boek = boek;
    //        return uitgave;
    //    });
    //    return uitgaves;

    //}

}