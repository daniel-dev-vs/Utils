using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Aprendizado.Models
{
    public class ClienteContext : DbContext
    {
        public ClienteContext () : base ("name=DB_CLIENTE"){}

        public DbSet<ClienteModel> ClienteModels { get; set; }
    }
}