using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aprendizado.Models;

namespace Aprendizado.Controllers
{
    public class PessoaController : Controller
    {
        private AprendizadoContext db = new AprendizadoContext();

        //
        // GET: /Pessoa/

        public ActionResult Index()
        {
            return View(db.PessoaModels.ToList());
        }

        //
        // GET: /Pessoa/Details/5

        public ActionResult Details(int id = 0)
        {
            PessoaModel pessoamodel = db.PessoaModels.Find(id);
            if (pessoamodel == null)
            {
                return HttpNotFound();
            }
            return View(pessoamodel);
        }

        //
        // GET: /Pessoa/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Pessoa/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PessoaModel pessoamodel)
        {
            if (ModelState.IsValid)
            {
                db.PessoaModels.Add(pessoamodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pessoamodel);
        }

        //
        // GET: /Pessoa/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PessoaModel pessoamodel = db.PessoaModels.Find(id);
            if (pessoamodel == null)
            {
                return HttpNotFound();
            }
            return View(pessoamodel);
        }

        //
        // POST: /Pessoa/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PessoaModel pessoamodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pessoamodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pessoamodel);
        }

        //
        // GET: /Pessoa/Delete/5
        
        public ActionResult Delete(int id = 0)
        {
            PessoaModel pessoamodel = db.PessoaModels.Find(id);
            if (pessoamodel == null)
            {
                return HttpNotFound();
            }
            return View(pessoamodel);
        }

        //
        // POST: /Pessoa/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PessoaModel pessoamodel = db.PessoaModels.Find(id);
            db.PessoaModels.Remove(pessoamodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}