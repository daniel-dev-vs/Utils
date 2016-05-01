using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aprendizado.Models
{
    public class PessoaModel
    {
        [Key]
        public int PessoaID { get; set; }

        [Display(Name="Name")]
        public string Nome { get; set; }

        [Display(Name="Last Name")]
        public string SobreNome { get; set; }
    }
}