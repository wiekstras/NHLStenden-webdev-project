namespace stripboeken.Models;

public class DetailBezit
{
    public string titel { get; set; }
    
    public int is18plus { get; set; }
    
    public string jaar { get; set; }
    
    public string ISBN { get; set; }
    
    public int Aantal { get; set; }
    
    public int waardering { get; set; }
    
    public string staat { get; set; }
    
    public string staatBeschrijving { get; set; }
    
    public decimal inkoopPrijs { get; set; }
    
    public int isTeKoop { get; set; }
    
    public decimal verkoopPrijs { get; set; }
    
    public string afbeeldingsPad { get; set; }
    
    public string Id { get; set; }
    
    public int uitgaveId { get; set; }
    
    public int bezitId { get; set; }
}