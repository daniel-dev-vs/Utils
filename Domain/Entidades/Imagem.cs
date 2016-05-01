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
    [Table("IMAGEM")]
    public class Imagem
    {
        public int ImagemId { get; set; }

        public string Nome { get; set; }

        public int DiretorioId { get; set; }

        public bool IsExcluido { get; set; }
                
        public int UsuarioId { get; set; }

        public string Extensao { get; set; }

    }
}
