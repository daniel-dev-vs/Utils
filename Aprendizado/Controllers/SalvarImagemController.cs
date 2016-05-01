using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aprendizado.Models;
using System.IO;

namespace Aprendizado.Controllers
{
    public class SalvarImagemController : Controller
    {

        private static void CreateNewPatient()
        {
            var dog = new TipoAnimal { NomeTipo = "Dog" };
            var patient = new Paciente
            {
                Nome = "Sampson",
                Aniversario = new DateTime(2008, 1, 28),
                TipoAnimal = dog,
                Visitas = new List<Visita>
                {
                    new Visita
                    {
                    Data = new DateTime(2011, 9, 1)
                    }
                }
            };
            using (var context = new VetContext())
            {
                context.Pacientes.Add(patient);
                context.SaveChanges();
            }
        }
        //
        // GET: /SalvarImagem/

        public ActionResult Salvar()
        {

            CreateNewPatient();
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Salvar(Imagem model)
        {


            if (model.NomeArquivo != null)
            {
                string foto = Path.GetFileName(model.NomeArquivo.FileName);
                string path = Path.Combine(Server.MapPath("~/Content/Imagens/Doces"), foto);

                model.NomeArquivo.SaveAs(path);
            }

            return View();
        }

        public ActionResult MostrarDiretorio()
        {
            DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/Content/Imagens"));

            List<Diretorio> listDiretorio = new List<Diretorio>();
            foreach (var dir in di.GetDirectories())
            {
                listDiretorio.Add(new Diretorio() { Nome = dir.Name, Directorio = dir, QuantidadeFotos = dir.GetFiles().Count() });
            }


            return View(listDiretorio.ToList());
        }

        public ActionResult EditarDiretorio(Diretorio diretorio)
        {
            if (diretorio != null)
            {
                DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/Content/Imagens/" + diretorio.Nome));
                diretorio.ListFileInfo = new List<FileInfo>(di.GetFiles());
            }
            return View(diretorio);
        }

        //[HttpPost]
        //public ActionResult EditarDiretorio(Diretorio diretorio)
        //{
        //    if (diretorio != null)
        //    {
        //        DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/Content/Imagens/" + diretorio.Nome));
        //        diretorio.ListFileInfo = new List<FileInfo>(di.GetFiles());
        //    }
        //    return View();
        //}

    }
}
