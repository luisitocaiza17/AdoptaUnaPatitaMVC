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
    public class MascotaController : Controller
    {
        private AdoptaUnaPatitaEntities db = new AdoptaUnaPatitaEntities();

        // GET: Mascota
        public ActionResult Index()
        {
            var mascota = db.Mascota.Include(m => m.Sexo).Include(m => m.Tamanio).Include(m => m.TipoAnimal);
            return View(mascota.ToList());
        }

        // GET: Mascota/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mascota mascota = db.Mascota.Find(id);
            if (mascota == null)
            {
                return HttpNotFound();
            }
            return View(mascota);
        }

        // GET: Mascota/Create
        public ActionResult Create()
        {
            ViewBag.IdSexo = new SelectList(db.Sexo, "Id", "Nombre");
            ViewBag.IdTamanio = new SelectList(db.Tamanio, "Id", "Nombre");
            ViewBag.IdTipoAnimal = new SelectList(db.TipoAnimal, "Id", "Nombre");
            return View();
        }

        // POST: Mascota/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdTipoAnimal,IdSexo,IdTamanio,Nombre,Color,FechaNacimiento,Raza,Detalle")] Mascota mascota)
        {
            if (ModelState.IsValid)
            {
                db.Mascota.Add(mascota);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdSexo = new SelectList(db.Sexo, "Id", "Nombre", mascota.IdSexo);
            ViewBag.IdTamanio = new SelectList(db.Tamanio, "Id", "Nombre", mascota.IdTamanio);
            ViewBag.IdTipoAnimal = new SelectList(db.TipoAnimal, "Id", "Nombre", mascota.IdTipoAnimal);
            return View(mascota);
        }

        // GET: Mascota/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mascota mascota = db.Mascota.Find(id);
            if (mascota == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdSexo = new SelectList(db.Sexo, "Id", "Nombre", mascota.IdSexo);
            ViewBag.IdTamanio = new SelectList(db.Tamanio, "Id", "Nombre", mascota.IdTamanio);
            ViewBag.IdTipoAnimal = new SelectList(db.TipoAnimal, "Id", "Nombre", mascota.IdTipoAnimal);
            return View(mascota);
        }

        // POST: Mascota/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdTipoAnimal,IdSexo,IdTamanio,Nombre,Color,FechaNacimiento,Raza,Detalle")] Mascota mascota)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mascota).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdSexo = new SelectList(db.Sexo, "Id", "Nombre", mascota.IdSexo);
            ViewBag.IdTamanio = new SelectList(db.Tamanio, "Id", "Nombre", mascota.IdTamanio);
            ViewBag.IdTipoAnimal = new SelectList(db.TipoAnimal, "Id", "Nombre", mascota.IdTipoAnimal);
            return View(mascota);
        }

        // GET: Mascota/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mascota mascota = db.Mascota.Find(id);
            if (mascota == null)
            {
                return HttpNotFound();
            }
            return View(mascota);
        }

        // POST: Mascota/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mascota mascota = db.Mascota.Find(id);
            db.Mascota.Remove(mascota);
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
