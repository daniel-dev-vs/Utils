using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aprendizado.Models
{
    public class Paciente
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime Aniversario { get; set; }

        public TipoAnimal TipoAnimal { get; set; }

        public List<Visita> Visitas { get; set; }

        public Paciente() 
        {
            Visitas = new List<Visita>();
        }

    }
}