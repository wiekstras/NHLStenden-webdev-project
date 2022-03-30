using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using stripboeken.Models;
using stripboeken.Repositories;

namespace stripboeken.Pages;

public class MyCollection : PageModel

    {

        private readonly UserManager<IdentityUser> userManager;

        public MyCollection(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        public IEnumerable<DetailBezit> Bezit
        {
            //De lijst van producten wordt via een query opgehaald als deze onder de juiste category vallen.
            get { return new DetailBezitRepository().Get(userManager.GetUserId(User)); }
        }

        public void OnGet()
        {

        }

        public void OnGetRemoveFromCollection(int bezitId)
        {
            new BezitRepository().RemoveFromCollection(bezitId);
        }
    }
