using _3DGence.Core;
using _3DGence.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Collections.Generic;

namespace _3DGence.Pages.Printers
{
    public class EditModel : PageModel
    {
        private readonly I3DGenceData _3DGenceData;

        [BindProperty]
        public Printer printer { get; set; }
        public IEnumerable<SelectListItem>  Models { get; set; }
        public IHtmlHelper htmlHelper { get; }

        public EditModel(I3DGenceData _3DGenceData, IHtmlHelper htmlHelper)
        {
            this._3DGenceData = _3DGenceData;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? printerId )
        {
            Models = htmlHelper.GetEnumSelectList<PrinterType>();
            if (printerId.HasValue)
            {
                printer = _3DGenceData.GetById(printerId.Value);
               
            }
            else
            {
                printer = new Printer();
                
            }
            
            if(printer==null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                Models = htmlHelper.GetEnumSelectList<PrinterType>();

                return Page();
                
            }

            if (printer.Id > 0)
            {
                _3DGenceData.Update(printer);
            }else
            {
                _3DGenceData.Add(printer);
            }
            _3DGenceData.Commit();
            TempData["Message"] = "Printer saved!";
            return RedirectToPage("./Detail", new { printerId = printer.Id });
        }
    }
}
