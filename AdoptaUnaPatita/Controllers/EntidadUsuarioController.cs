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
    public class EntidadUsuarioController : Controller
    {
        private AdoptaUnaPatitaEntities db = new AdoptaUnaPatitaEntities();

        // GET: EntidadUsuario
        public ActionResult Index()
        {
            var entidadUsuario = db.EntidadUsuario.Include(e => e.Entidad).Include(e => e.Usuario);
            return View(entidadUsuario.ToList());
        }

        // GET: EntidadUsuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntidadUsuario entidadUsuario = db.EntidadUsuario.Find(id);
            if (entidadUsuario == null)
            {
                return HttpNotFound();
            }
            return View(entidadUsuario);
        }

        // GET: EntidadUsuario/Create
        public ActionResult Create()
        {
            ViewBag.IdEntidad = new SelectList(db.Entidad, "Id", "Nombres");
            ViewBag.IdUsuario = new SelectList(db.Usuario, "Id", "Nombre");
            return View();
        }

        // POST: EntidadUsuario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdEntidad,IdUsuario")] EntidadUsuario entidadUsuario)
        {
            if (ModelState.IsValid)
            {
                db.EntidadUsuario.Add(entidadUsuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEntidad = new SelectList(db.Entidad, "Id", "Nombres", entidadUsuario.IdEntidad);
            ViewBag.IdUsuario = new SelectList(db.Usuario, "Id", "Nombre", entidadUsuario.IdUsuario);
            return View(entidadUsuario);
        }

        // GET: EntidadUsuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntidadUsuario entidadUsuario = db.EntidadUsuario.Find(id);
            if (entidadUsuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEntidad = new SelectList(db.Entidad, "Id", "Nombres", entidadUsuario.IdEntidad);
            ViewBag.IdUsuario = new SelectList(db.Usuario, "Id", "Nombre", entidadUsuario.IdUsuario);
            return View(entidadUsuario);
        }

        // POST: EntidadUsuario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdEntidad,IdUsuario")] EntidadUsuario entidadUsuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entidadUsuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEntidad = new SelectList(db.Entidad, "Id", "Nombres", entidadUsuario.IdEntidad);
            ViewBag.IdUsuario = new SelectList(db.Usuario, "Id", "Nombre", entidadUsuario.IdUsuario);
            return View(entidadUsuario);
        }

        // GET: EntidadUsuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntidadUsuario entidadUsuario = db.EntidadUsuario.Find(id);
            if (entidadUsuario == null)
            {
                return HttpNotFound();
            }
            return View(entidadUsuario);
        }

        // POST: EntidadUsuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EntidadUsuario entidadUsuario = db.EntidadUsuario.Find(id);
            db.EntidadUsuario.Remove(entidadUsuario);
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
