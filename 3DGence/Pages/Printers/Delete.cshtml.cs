using _3DGence.Core;
using _3DGence.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _3DGence.Pages.Printers
{
    public class DeleteModel : PageModel
    {
        private readonly I3DGenceData genceData;
        public Printer Printer { get; set; }
        public DeleteModel(I3DGenceData genceData)
        {
            this.genceData = genceData;
        }
        public IActionResult OnGet(int printerId)
        {
            Printer = genceData.GetById(printerId);
            if (Printer == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
        public IActionResult OnPost(int printerId)
        {
        var printer=    genceData.Delete(printerId);
            genceData.Commit();
            if(printer == null)
            {
                return RedirectToPage("./NotFound");
            }
            TempData["Message"] = $"{printer.Name} deleted";
            return RedirectToPage("./List");
        }
    }

}
