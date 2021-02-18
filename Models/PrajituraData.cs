using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicatie_web.Models
{
    public class PrajituraData
    {
        public IEnumerable<Prajitura> Prajituri { get; set; }
        public IEnumerable<Categorie> Categorii { get; set; }
        public IEnumerable<PrajituraCategorie> PrajituraCategorii { get; set; }
    }
}
