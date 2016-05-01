using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aprendizado.Models
{
    public class Visita
    {
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public string RazaoVisita { get; set; }

        public string Saida { get; set; }

        public int PacienteId { get; set; }
    }
}