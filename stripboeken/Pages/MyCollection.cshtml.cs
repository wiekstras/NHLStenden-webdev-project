<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
=======
using Microsoft.AspNetCore.Identity;
>>>>>>> 1bacf5ee0d69010099fbd5a6507a5b49e5fe43e8
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using stripboeken.Models;
using stripboeken.Repositories;

namespace stripboeken.Pages;

<<<<<<< HEAD
public class PrivacyModel : PageModel

=======
public class MyCollection : PageModel
>>>>>>> 1bacf5ee0d69010099fbd5a6507a5b49e5fe43e8
{

    private readonly UserManager<IdentityUser> userManager;

    public MyCollection(UserManager<IdentityUser> userManager)
    {
        this.userManager = userManager;
    }
    public IEnumerable<DetailBezit> Bezit
    {
        //De lijst van producten wordt via een query opgehaald als deze onder de juiste category vallen.
        get
        {
            return new DetailBezitRepository().Get(userManager.GetUserId(User));
        }
    }
    public void OnGet()
    {
        
    }

    public void OnGetRemoveFromCollection(int bezitId)
    {
        new BezitRepository().RemoveFromCollection(bezitId);
    }
}