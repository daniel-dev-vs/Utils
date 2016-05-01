using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Aprendizado.Models
{
    public class VetContext : DbContext
    {
        public VetContext() : base("name=Vet"){}

        public DbSet<Visita> Visitas { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
    }
}