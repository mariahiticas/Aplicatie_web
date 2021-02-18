using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicatie_web.Models
{
    public class Client
    {
        public int ID { get; set; }
        public string ClientNume { get; set; }
        public ICollection<Prajitura> Prajituri { get; set; }

    }
}
