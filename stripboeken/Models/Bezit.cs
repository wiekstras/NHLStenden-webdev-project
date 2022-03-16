namespace stripboeken.Models;

public class Bezit
{
    public int bezitId { get; set; }
    
    public int waardering { get; set; }
    
    public int staat { get; set; }
    
    public string staatBeschrijving { get; set; }
    
    public float prijsBetaald  { get; set; }
    
    public string isTeKoop { get; set; }
    
    public float verkoopprijs { get; set; }
    
    public int gebruikerId { get; set; }
    
    public string ISBN { get; set; }
    
}