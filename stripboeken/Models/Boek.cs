namespace stripboeken.Models;

public class Boek
{
    public int BoekId { get; set; }
    
    public string Titel { get; set; }
    
    public string WebLink { get; set; }
    
    public int Is18Plus { get; set; }
    
    public int ReeksId { get; set; }

}