using _3DGence.Core;
using _3DGence.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _3DGence.Pages.Printers
{
    public class DetailModel : PageModel
    {
        private readonly I3DGenceData i3DGence;
        [TempData]
        public string Message { get; set; }
        public Printer printer { get; set; }
        public IActionResult OnGet(int printerId)
        {

            printer = i3DGence.GetById(printerId);
            if(printer == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
        public DetailModel(I3DGenceData i3DGence)
        {
            this.i3DGence = i3DGence;
        }
    }
}
