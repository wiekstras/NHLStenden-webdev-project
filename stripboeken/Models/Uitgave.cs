namespace stripboeken.Models;

public class Uitgave
{
    public string ISBN { get; set; }
    
    public int jaar { get; set; }
    
    public string druk { get; set; }
    
    public string taal { get; set; }
    
    public int aantalBladzijden { get; set; }
    
    public float dikte { get; set; }
    
    public string cover { get; set; }
    
    public float gewicht { get; set; }
    
    public float hoogte { get; set; }

    public string afbeeldingspad { get; set; }
    
    public string wistJeDat { get; set; }
    
    public string beschrijving { get; set; }
    
    public int boekId { get; set; }
    
    public int uitgeversId { get; set; }
}