namespace stripboeken.Models;

public class Boek
{
    public int boekId { get; set; }
    
    public string titel { get; set; }
    
    public string webLink { get; set; }
    
    public int is18Plus { get; set; }
    
    public int reeksId { get; set; }

}