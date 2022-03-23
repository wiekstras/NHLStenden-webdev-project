using System.ComponentModel.DataAnnotations;

namespace stripboeken.Models;

public class LoginModel
{
    
    [Required]
    [DataType(DataType.Text)]
    public string gebruikersNaam { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public string wachtwoord { get; set; }

}