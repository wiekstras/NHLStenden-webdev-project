namespace stripboeken.Models;

public class Bezit
{
    public int waardering { get; set; }

    public enum staat
    {
        OnBekend,
        Gebruikt,
        AlsNieuw,
        Nieuw,
    }

    public string staatBeschrijving { get; set; }
    
    public decimal inkoopPrijs  { get; set; }
    
    public int isTeKoop { get; set; }
    
    public decimal verkoopPrijs { get; set; }
    
    public string afbeeldingsPad { get; set; }
    
    public int gebruikerId { get; set; }
    
    public int uitgaveId { get; set; }
    
}