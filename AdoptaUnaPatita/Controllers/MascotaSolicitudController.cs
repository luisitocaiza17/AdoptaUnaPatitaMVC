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
    public class MascotaSolicitudController : Controller
    {
        private AdoptaUnaPatitaEntities db = new AdoptaUnaPatitaEntities();

        // GET: MascotaSolicitud
        public ActionResult Index()
        {
            var mascotaSolicitud = db.MascotaSolicitud.Include(m => m.Mascota).Include(m => m.Solicitud);
            return View(mascotaSolicitud.ToList());
        }

        // GET: MascotaSolicitud/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MascotaSolicitud mascotaSolicitud = db.MascotaSolicitud.Find(id);
            if (mascotaSolicitud == null)
            {
                return HttpNotFound();
            }
            return View(mascotaSolicitud);
        }

        // GET: MascotaSolicitud/Create
        public ActionResult Create()
        {
            ViewBag.IdMascota = new SelectList(db.Mascota, "Id", "Nombre");
            ViewBag.IDSolicitud = new SelectList(db.Solicitud, "Id", "Numero");
            return View();
        }

        // POST: MascotaSolicitud/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdMascota,IDSolicitud")] MascotaSolicitud mascotaSolicitud)
        {
            if (ModelState.IsValid)
            {
                db.MascotaSolicitud.Add(mascotaSolicitud);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdMascota = new SelectList(db.Mascota, "Id", "Nombre", mascotaSolicitud.IdMascota);
            ViewBag.IDSolicitud = new SelectList(db.Solicitud, "Id", "Numero", mascotaSolicitud.IDSolicitud);
            return View(mascotaSolicitud);
        }

        // GET: MascotaSolicitud/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MascotaSolicitud mascotaSolicitud = db.MascotaSolicitud.Find(id);
            if (mascotaSolicitud == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdMascota = new SelectList(db.Mascota, "Id", "Nombre", mascotaSolicitud.IdMascota);
            ViewBag.IDSolicitud = new SelectList(db.Solicitud, "Id", "Numero", mascotaSolicitud.IDSolicitud);
            return View(mascotaSolicitud);
        }

        // POST: MascotaSolicitud/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdMascota,IDSolicitud")] MascotaSolicitud mascotaSolicitud)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mascotaSolicitud).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdMascota = new SelectList(db.Mascota, "Id", "Nombre", mascotaSolicitud.IdMascota);
            ViewBag.IDSolicitud = new SelectList(db.Solicitud, "Id", "Numero", mascotaSolicitud.IDSolicitud);
            return View(mascotaSolicitud);
        }

        // GET: MascotaSolicitud/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MascotaSolicitud mascotaSolicitud = db.MascotaSolicitud.Find(id);
            if (mascotaSolicitud == null)
            {
                return HttpNotFound();
            }
            return View(mascotaSolicitud);
        }

        // POST: MascotaSolicitud/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MascotaSolicitud mascotaSolicitud = db.MascotaSolicitud.Find(id);
            db.MascotaSolicitud.Remove(mascotaSolicitud);
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
