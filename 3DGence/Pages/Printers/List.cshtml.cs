using _3DGence.Core;
using _3DGence.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace _3DGence.Pages.Printers
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        public readonly I3DGenceData genceData;

        public IEnumerable<Printer> printers { get; set; }
        [BindProperty(SupportsGet =true)]
        public string  SearchTerm { get; set; }
        public ListModel(IConfiguration config, I3DGenceData genceData)
        {
            this.config = config;
            this.genceData = genceData;
        }
        public void OnGet()
        {
            
            printers = genceData.GetPrinterByName(SearchTerm);
        }
    }
}
