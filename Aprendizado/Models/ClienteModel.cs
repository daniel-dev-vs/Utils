using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aprendizado.Models
{
    public class ClienteModel
    {
        [Key]
        public int ClienteID { get; set; }

        [Required]
        [Display(Name="Digite seu nome:")]
        public string Nome { get; set; }

        [Display(Name="Digite seu sobre nome")]
        public string SobreNome { get; set; }

        
        [DataType(DataType.PhoneNumber)]
        [Display(Name="Digite seu telefone:")]      
        public string Telefone { get; set; }
    }
}