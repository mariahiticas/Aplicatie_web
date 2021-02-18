using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Aplicatie_web.Data;

namespace Aplicatie_web.Models
{ 
        public class PrajituraCategoriiPaginaModel : PageModel
        {
            public List<AssignedCategoryData> AssignedCategoryDataList;
            public void PopulateAssignedCategoryData(Aplicatie_webContext context,
            Prajitura prajitura)
            {
                var allCategorii = context.Categorie;
                var prajituraCategorii = new HashSet<int>(
                prajitura.PrajituraCategorii.Select(c => c.PrajituraID));
                AssignedCategoryDataList = new List<AssignedCategoryData>();
                foreach (var cat in allCategorii)
                {
                    AssignedCategoryDataList.Add(new AssignedCategoryData
                    {
                        CategorieID = cat.ID,
                        Nume = cat.CategorieNume,
                        Atribuire = prajituraCategorii.Contains(cat.ID)
                    });
                }
            }
            public void UpdatePrajituraCategorii(Aplicatie_webContext context,
            string[] selectedCategorii, Prajitura prajituraToUpdate)
            {
                if (selectedCategorii == null)
                {
                    prajituraToUpdate.PrajituraCategorii = new List<PrajituraCategorie>();
                    return;
                }
                var selectedCategoriiHS = new HashSet<string>(selectedCategorii);
                var prajituraCategorii = new HashSet<int>
                (prajituraToUpdate.PrajituraCategorii.Select(c => c.Categorie.ID));
                foreach (var cat in context.Categorie)
                {
                    if (selectedCategoriiHS.Contains(cat.ID.ToString()))
                    {
                        if (!prajituraCategorii.Contains(cat.ID))
                        {
                            prajituraToUpdate.PrajituraCategorii.Add(
                            new PrajituraCategorie
                            {
                                PrajituraID = prajituraToUpdate.ID,
                                CategorieID = cat.ID
                            });
                        }
                    }
                    else
                    {
                        if (prajituraCategorii.Contains(cat.ID))
                        {
                            PrajituraCategorie courseToRemove
                            = prajituraToUpdate
                            .PrajituraCategorii
                            .SingleOrDefault(i => i.CategorieID == cat.ID);
                            context.Remove(courseToRemove);
                        }
                    }
                }
            }
    
    }
}

