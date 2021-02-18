using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Aplicatie_web.Data;
using Aplicatie_web.Models;

namespace Aplicatie_web.Pages.Prajituri
{
    public class CreateModel : PrajituraCategoriiPaginaModel
    {
        private readonly Aplicatie_web.Data.Aplicatie_webContext _context;

        public CreateModel(Aplicatie_web.Data.Aplicatie_webContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ClientID"] = new SelectList(_context.Set<Client>(), "ID", "ClientNume");
            var prajitura = new Prajitura();
            prajitura.PrajituraCategorii = new List<PrajituraCategorie>();
            PopulateAssignedCategoryData(_context, prajitura);
            return Page();
        }

        [BindProperty]
        public Prajitura Prajitura { get; set; }


        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategorii)
        {
            var newPrajitura = new Prajitura();
            if (selectedCategorii != null)
            {
                newPrajitura.PrajituraCategorii = new List<PrajituraCategorie>();
                foreach (var cat in selectedCategorii)
                {
                    var catToAdd = new PrajituraCategorie
                    {
                        CategorieID = int.Parse(cat)
                    };
                    newPrajitura.PrajituraCategorii.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Prajitura>(
            newPrajitura,
            "Prajitura",
            i => i.Denumire, i => i.Cofetar,
            i => i.Pret, i => i.DataPrepararii, i => i.ClientID))
            {
                _context.Prajitura.Add(newPrajitura);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newPrajitura);
            return Page();
        }
    }
}