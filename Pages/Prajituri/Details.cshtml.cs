using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Aplicatie_web.Data;
using Aplicatie_web.Models;

namespace Aplicatie_web.Pages.Prajituri
{
    public class DetailsModel : PageModel
    {
        private readonly Aplicatie_web.Data.Aplicatie_webContext _context;

        public DetailsModel(Aplicatie_web.Data.Aplicatie_webContext context)
        {
            _context = context;
        }

        public Prajitura Prajitura { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Prajitura = await _context.Prajitura.FirstOrDefaultAsync(m => m.ID == id);

            if (Prajitura == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
