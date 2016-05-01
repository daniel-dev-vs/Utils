using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Aprendizado.Models
{
    public class Diretorio
    {
        public string Nome { get; set; }

        public DirectoryInfo Directorio { get; set; }

        public List<FileInfo> ListFileInfo { get; set; }

        public int QuantidadeFotos { get; set; }
    }
}