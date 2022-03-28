using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using stripboeken.Models;

namespace stripboeken.Pages
{
    public class TestModel : PageModel
    {
        [BindProperty]
        public List<DetailAuteur> DetailAuteur { get; set; }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            int test = 0;
        }
    }
}
