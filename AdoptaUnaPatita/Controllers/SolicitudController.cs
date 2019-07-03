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
    public class SolicitudController : Controller
    {
        private AdoptaUnaPatitaEntities db = new AdoptaUnaPatitaEntities();

        // GET: Solicitud
        public ActionResult Index()
        {
            var solicitud = db.Solicitud.Include(s => s.Entidad).Include(s => s.Entidad1);
            return View(solicitud.ToList());
        }

        // GET: Solicitud/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitud solicitud = db.Solicitud.Find(id);
            if (solicitud == null)
            {
                return HttpNotFound();
            }
            return View(solicitud);
        }

        // GET: Solicitud/Create
        public ActionResult Create()
        {
            ViewBag.IdSolicitante = new SelectList(db.Entidad, "Id", "Nombres");
            ViewBag.IdColaborador = new SelectList(db.Entidad, "Id", "Nombres");
            return View();
        }

        // POST: Solicitud/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdSolicitante,IdColaborador,Numero,Razon,AceptoTerminos")] Solicitud solicitud)
        {
            if (ModelState.IsValid)
            {
                db.Solicitud.Add(solicitud);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdSolicitante = new SelectList(db.Entidad, "Id", "Nombres", solicitud.IdSolicitante);
            ViewBag.IdColaborador = new SelectList(db.Entidad, "Id", "Nombres", solicitud.IdColaborador);
            return View(solicitud);
        }

        // GET: Solicitud/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitud solicitud = db.Solicitud.Find(id);
            if (solicitud == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdSolicitante = new SelectList(db.Entidad, "Id", "Nombres", solicitud.IdSolicitante);
            ViewBag.IdColaborador = new SelectList(db.Entidad, "Id", "Nombres", solicitud.IdColaborador);
            return View(solicitud);
        }

        // POST: Solicitud/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdSolicitante,IdColaborador,Numero,Razon,AceptoTerminos")] Solicitud solicitud)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solicitud).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdSolicitante = new SelectList(db.Entidad, "Id", "Nombres", solicitud.IdSolicitante);
            ViewBag.IdColaborador = new SelectList(db.Entidad, "Id", "Nombres", solicitud.IdColaborador);
            return View(solicitud);
        }

        // GET: Solicitud/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitud solicitud = db.Solicitud.Find(id);
            if (solicitud == null)
            {
                return HttpNotFound();
            }
            return View(solicitud);
        }

        // POST: Solicitud/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Solicitud solicitud = db.Solicitud.Find(id);
            db.Solicitud.Remove(solicitud);
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
