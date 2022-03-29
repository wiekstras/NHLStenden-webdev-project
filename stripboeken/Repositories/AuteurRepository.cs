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

    //Toont een lijst van auteurs die meegewerkt hebben aan de uitgave met het bijbehorende uitgaveid.
    public IEnumerable<DetailAuteur> GetFromUitgave(int uitgaveId)
    {
        using var connection = GetConnection();
        var sql = @"SELECT * 
                     FROM DetailAuteur
                     WHERE uitgaveId = @uitgaveId;";
        var auteur = connection.Query<DetailAuteur>(sql, new { uitgaveId });
        return auteur;
    }

    //Toont een lijst van alle auteurs in de database.
    public IEnumerable<Auteur> Get()
    {
        using var connection = GetConnection();
        var sql = @"SELECT * 
                     FROM Auteur;";
        var auteur = connection.Query<Auteur>(sql);
        return auteur;
    }

    //Query voor het koppelen van een auteur met een uitgave. Schrijft is een associatieklasse.
    public void Add(Schrijft schrijft)
    {
        string sql = @"
                INSERT INTO Schrijft (AuteurId, UitgaveId, Functie) 
                VALUES (@AuteurId, @UitgaveId, @Functie); ";

        using var connection = GetConnection();
        var addedSchrijft = connection.Execute(sql, schrijft);
    }

    //Toevoegen van een auteur aan de database.
    public Auteur AddAuteur(Auteur auteur)
    {
        string sql = @"
                INSERT INTO Auteur (auteurId, voornaam, achternaam, weblink) 
                VALUES (@auteurId, @voornaam, @achternaam, @weblink); 
                SELECT * FROM Auteur WHERE AuteurId = LAST_INSERT_ID()";

        using var connection = GetConnection();
        var addedAuteur = connection.QuerySingle<Auteur>(sql, auteur);
        return addedAuteur;
    }

    //Oude queries zijn vervangen door de view detailauteur.
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
}