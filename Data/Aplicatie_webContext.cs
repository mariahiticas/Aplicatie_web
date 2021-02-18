using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Aplicatie_web.Models;

namespace Aplicatie_web.Data
{
    public class Aplicatie_webContext : DbContext
    {
        public Aplicatie_webContext (DbContextOptions<Aplicatie_webContext> options)
            : base(options)
        {
        }

        public DbSet<Aplicatie_web.Models.Prajitura> Prajitura { get; set; }

        public DbSet<Aplicatie_web.Models.Client> Client { get; set; }

        public DbSet<Aplicatie_web.Models.Categorie> Categorie { get; set; }
    }
}
