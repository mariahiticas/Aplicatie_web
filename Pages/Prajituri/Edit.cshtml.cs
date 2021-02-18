using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aplicatie_web.Data;
using Aplicatie_web.Models;

namespace Aplicatie_web.Pages.Prajituri
{
    public class EditModel : PrajituraCategoriiPaginaModel
    {
        private readonly Aplicatie_web.Data.Aplicatie_webContext _context;

        public EditModel(Aplicatie_web.Data.Aplicatie_webContext context)
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
            Prajitura = await _context.Prajitura
                .Include(b => b.Client)
                .Include(b => b.PrajituraCategorii).ThenInclude(b => b.Categorie)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

          

            if (Prajitura == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Prajitura);
            ViewData["ClientID"] = new SelectList(_context.Set<Client>(), "ID", "ClientNume");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult>
        OnPostAsync(int? id, string[]
selectedCategorii)
        {
            if (id == null)
            {
                return NotFound();
            }
            var prajituraToUpdate = await _context.Prajitura
            .Include(i => i.Client)
            .Include(i => i.PrajituraCategorii)
            .ThenInclude(i => i.Categorie)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (prajituraToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Prajitura>(
            prajituraToUpdate,
            "Prajitura",
            i => i.Denumire, i => i.Cofetar,
            i => i.Pret, i => i.DataPrepararii, i => i.Client))
            {
                UpdatePrajituraCategorii(_context, selectedCategorii, prajituraToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdatePrajituraCategorii pentru a aplica informatiile din checkboxuri la entitatea Prajituri care
            //este editata
            UpdatePrajituraCategorii(_context, selectedCategorii, prajituraToUpdate);
            PopulateAssignedCategoryData(_context, prajituraToUpdate);
            return Page();
        }
    }
}
            