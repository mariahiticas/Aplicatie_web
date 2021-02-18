using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicatie_web.Models
{
    public class Categorie
    {
        public int ID { get; set; }
        public string CategorieNume { get; set; }
        public ICollection<PrajituraCategorie> PrajituraCategorii { get; set; }
    }
}
