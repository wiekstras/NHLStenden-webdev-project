using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace stripboeken.Models;

public class Bezit
{
    
    public int Waardering { get; set; }

    public string Staat { get; set; }
    
    [Display(Name = "Staat beschrijving")]

    public string StaatBeschrijving { get; set; }
    
    [Display(Name = "Inkoop prijs")]

    public decimal InkoopPrijs  { get; set; }
    
    [Display(Name = "Is te koop")]

    public int IsTeKoop { get; set; }
    
    [Display(Name = "Verkoop prijs")]

    public decimal VerkoopPrijs { get; set; }
    
    
    [Display(Name = "Afbeeldings pad")]

    public string AfbeeldingsPad { get; set; }
    
    public string Id { get; set; }
    
    public int UitgaveId { get; set; }
    
    public int BezitId { get; set; }
    
}