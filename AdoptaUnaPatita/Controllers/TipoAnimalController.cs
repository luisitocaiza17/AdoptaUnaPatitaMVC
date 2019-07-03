using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdoptaUnaPatita.DataAccess;

namespace AdoptaUnaPatita.Controllers
{
    public class TipoAnimalController : Controller
    {
        private AdoptaUnaPatitaEntities db = new AdoptaUnaPatitaEntities();

        // GET: TipoAnimal
        public ActionResult Index()
        {
            return View(db.TipoAnimal.ToList());
        }

        // GET: TipoAnimal/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAnimal tipoAnimal = db.TipoAnimal.Find(id);
            if (tipoAnimal == null)
            {
                return HttpNotFound();
            }
            return View(tipoAnimal);
        }

        // GET: TipoAnimal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoAnimal/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre")] TipoAnimal tipoAnimal)
        {
            if (ModelState.IsValid)
            {
                db.TipoAnimal.Add(tipoAnimal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoAnimal);
        }

        // GET: TipoAnimal/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAnimal tipoAnimal = db.TipoAnimal.Find(id);
            if (tipoAnimal == null)
            {
                return HttpNotFound();
            }
            return View(tipoAnimal);
        }

        // POST: TipoAnimal/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre")] TipoAnimal tipoAnimal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoAnimal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoAnimal);
        }

        // GET: TipoAnimal/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAnimal tipoAnimal = db.TipoAnimal.Find(id);
            if (tipoAnimal == null)
            {
                return HttpNotFound();
            }
            return View(tipoAnimal);
        }

        // POST: TipoAnimal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoAnimal tipoAnimal = db.TipoAnimal.Find(id);
            db.TipoAnimal.Remove(tipoAnimal);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
