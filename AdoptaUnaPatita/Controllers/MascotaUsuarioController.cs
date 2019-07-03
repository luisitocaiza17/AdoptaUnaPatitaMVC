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
    public class MascotaUsuarioController : Controller
    {
        private AdoptaUnaPatitaEntities db = new AdoptaUnaPatitaEntities();

        // GET: MascotaUsuario
        public ActionResult Index()
        {
            var mascotaUsuario = db.MascotaUsuario.Include(m => m.Mascota).Include(m => m.Usuario);
            return View(mascotaUsuario.ToList());
        }

        // GET: MascotaUsuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MascotaUsuario mascotaUsuario = db.MascotaUsuario.Find(id);
            if (mascotaUsuario == null)
            {
                return HttpNotFound();
            }
            return View(mascotaUsuario);
        }

        // GET: MascotaUsuario/Create
        public ActionResult Create()
        {
            ViewBag.IdMascota = new SelectList(db.Mascota, "Id", "Nombre");
            ViewBag.IdUsuario = new SelectList(db.Usuario, "Id", "Nombre");
            return View();
        }

        // POST: MascotaUsuario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdUsuario,IdMascota")] MascotaUsuario mascotaUsuario)
        {
            if (ModelState.IsValid)
            {
                db.MascotaUsuario.Add(mascotaUsuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdMascota = new SelectList(db.Mascota, "Id", "Nombre", mascotaUsuario.IdMascota);
            ViewBag.IdUsuario = new SelectList(db.Usuario, "Id", "Nombre", mascotaUsuario.IdUsuario);
            return View(mascotaUsuario);
        }

        // GET: MascotaUsuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MascotaUsuario mascotaUsuario = db.MascotaUsuario.Find(id);
            if (mascotaUsuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdMascota = new SelectList(db.Mascota, "Id", "Nombre", mascotaUsuario.IdMascota);
            ViewBag.IdUsuario = new SelectList(db.Usuario, "Id", "Nombre", mascotaUsuario.IdUsuario);
            return View(mascotaUsuario);
        }

        // POST: MascotaUsuario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdUsuario,IdMascota")] MascotaUsuario mascotaUsuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mascotaUsuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdMascota = new SelectList(db.Mascota, "Id", "Nombre", mascotaUsuario.IdMascota);
            ViewBag.IdUsuario = new SelectList(db.Usuario, "Id", "Nombre", mascotaUsuario.IdUsuario);
            return View(mascotaUsuario);
        }

        // GET: MascotaUsuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MascotaUsuario mascotaUsuario = db.MascotaUsuario.Find(id);
            if (mascotaUsuario == null)
            {
                return HttpNotFound();
            }
            return View(mascotaUsuario);
        }

        // POST: MascotaUsuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MascotaUsuario mascotaUsuario = db.MascotaUsuario.Find(id);
            db.MascotaUsuario.Remove(mascotaUsuario);
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
