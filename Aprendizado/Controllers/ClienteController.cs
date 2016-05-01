using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aprendizado.Models;

namespace Aprendizado.Controllers
{
    public class ClienteController : Controller
    {
        private ClienteContext db = new ClienteContext();

        //
        // GET: /Cliente/

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(ClienteModel cliente)
        {
            if (ModelState.IsValid)
            {
                db.ClienteModels.Add(cliente);
                db.SaveChanges();

                return RedirectToAction("Cadastrar");
            }

            return View(cliente);
        }

        public ActionResult Editar()
        {
            return View();
        }


        public ActionResult Consultar()
        {            
            return View(db.ClienteModels.ToList());
        }

        public ActionResult Apagar()
        {
            return View();
        }

    }
}
