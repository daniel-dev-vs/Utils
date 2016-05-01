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
    [Table("DIRETORIO")]
    public class Diretorio
    {
        public int DiretorioId { get; set; }

        public string Nome { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime DataUltimaAlteracao { get; set; }

        public bool IsExcluido { get; set; }

        public int UsuarioId { get; set; }

    }
}
