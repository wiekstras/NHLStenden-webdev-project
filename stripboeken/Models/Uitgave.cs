namespace stripboeken.Models;

public class Uitgave
{
    public int uitgaveId { get; set; }
    
    public string ISBN { get; set; }
    
    public int jaar { get; set; }
    
    public string uitgever { get; set; }
    
    public string druk { get; set; }
    
    public string taal { get; set; }

    public enum cover
    {
        Onbekend ,
        Hardcover,
        Softcover,
        Digitaal,
    }
    
    public int aantalBladzijden { get; set; }
    
    public decimal breedte { get; set; }
    
    public decimal hoogte { get; set; }

    public string afbeeldingspad { get; set; }
    
    public string weetjes { get; set; }
    
    public string beschrijving { get; set; }
    
    public int boekId { get; set; }

}