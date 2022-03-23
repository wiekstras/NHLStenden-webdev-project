using System.Net.Mime;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using stripboeken.Models;

namespace stripboeken;

public class AuthDbUtils : IdentityDbContext
{
    public AuthDbUtils(DbContextOptions<AuthDbUtils> options): base(options )
    {
        
    }
    
  
}