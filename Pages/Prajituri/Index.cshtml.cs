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
    public class IndexModel : PageModel
    {
        private readonly Aplicatie_web.Data.Aplicatie_webContext _context;

        public IndexModel(Aplicatie_web.Data.Aplicatie_webContext context)
        {
            _context = context;
        }

        public IList<Prajitura> Prajitura { get; set; }
        public PrajituraData PrajituraD { get; set; }
        public int PrajituraID { get; set; }
        public int CategorieID { get; set; }
        public async Task OnGetAsync(int? id, int? categorieID)
        {
            PrajituraD = new PrajituraData();

            PrajituraD.Prajituri = await _context.Prajitura
            .Include(b => b.Client)
            .Include(b => b.PrajituraCategorii)
            .ThenInclude(b => b.Categorie)
            .AsNoTracking()
            .OrderBy(b => b.Denumire)
            .ToListAsync();
            if (id != null)
            {
                PrajituraID = id.Value;
                Prajitura prajitura = PrajituraD.Prajituri
                .Where(i => i.ID == id.Value).Single();
                PrajituraD.Categorii = prajitura.PrajituraCategorii.Select(s => s.Categorie);
            }
        }

    }
}