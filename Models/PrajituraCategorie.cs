using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicatie_web.Models
{
    public class PrajituraCategorie
    {
        public int ID { get; set; }
        public int PrajituraID { get; set; }
        public Prajitura Prajitura { get; set; }
        public int CategorieID { get; set; }
        public Categorie Categorie { get; set; }
    }
}
