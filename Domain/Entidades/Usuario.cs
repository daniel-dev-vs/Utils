using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entidades
{
    [Table("USUARIO")]
    public class Usuario
    {
        public int UsuarioId { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

    }
}
