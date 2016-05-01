using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.Entidades;

namespace Data.DataContext
{
    public class DataContext : DbContext
    {
        
        
        public DataContext() : base("DMBISCOITO") { }


        public DbSet<Diretorio> Diretorios { get; set; }

        public DbSet<Imagem> Imagens { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

    }
}
