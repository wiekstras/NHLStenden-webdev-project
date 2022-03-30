using System.ComponentModel.DataAnnotations;

namespace stripboeken.Models;

public class Bezit
{
    
    public int Waardering { get; set; }

    public string Staat { get; set; }
    
    public string StaatBeschrijving { get; set; }
    
    public decimal InkoopPrijs  { get; set; }
    
    public int IsTeKoop { get; set; }
    
    public decimal VerkoopPrijs { get; set; }
    
    public string AfbeeldingsPad { get; set; }
    
    public string Id { get; set; }
    
    public int UitgaveId { get; set; }
    
    public int BezitId { get; set; }
    
}