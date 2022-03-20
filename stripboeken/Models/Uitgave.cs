namespace stripboeken.Models;

public class Uitgave
{
    public int UitgaveId { get; set; }
    
    public string ISBN { get; set; }
    
    public int Jaar { get; set; }
    
    public string Uitgever { get; set; }
    
    public string Druk { get; set; }
    
    public string Taal { get; set; }

    public string Cover { get; set; }
    
    public int AantalBladzijden { get; set; }
    
    public decimal Breedte { get; set; }
    
    public decimal Hoogte { get; set; }

    public string AfbeeldingsPad { get; set; }
    
    public string Weetjes { get; set; }
    
    public string Beschrijving { get; set; }
    
    public int BoekId { get; set; }

    public Boek Boek { get; set; }  

}