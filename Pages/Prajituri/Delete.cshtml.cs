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
    public class DeleteModel : PageModel
    {
        private readonly Aplicatie_web.Data.Aplicatie_webContext _context;

        public DeleteModel(Aplicatie_web.Data.Aplicatie_webContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Prajitura = await _context.Prajitura.FindAsync(id);

            if (Prajitura != null)
            {
                _context.Prajitura.Remove(Prajitura);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
