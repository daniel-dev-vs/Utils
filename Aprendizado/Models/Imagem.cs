using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aprendizado.Models
{
    public class Imagem
    {
        public int IdImagem { get; set; }

        public HttpPostedFileBase NomeArquivo { get; set; }
    }
}