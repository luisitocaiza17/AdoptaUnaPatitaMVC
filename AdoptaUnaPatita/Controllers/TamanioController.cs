﻿using System;
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
    public class TamanioController : Controller
    {
        private AdoptaUnaPatitaEntities db = new AdoptaUnaPatitaEntities();

        // GET: Tamanio
        public ActionResult Index()
        {
            return View(db.Tamanio.ToList());
        }

        // GET: Tamanio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tamanio tamanio = db.Tamanio.Find(id);
            if (tamanio == null)
            {
                return HttpNotFound();
            }
            return View(tamanio);
        }

        // GET: Tamanio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tamanio/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre")] Tamanio tamanio)
        {
            if (ModelState.IsValid)
            {
                db.Tamanio.Add(tamanio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tamanio);
        }

        // GET: Tamanio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tamanio tamanio = db.Tamanio.Find(id);
            if (tamanio == null)
            {
                return HttpNotFound();
            }
            return View(tamanio);
        }

        // POST: Tamanio/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre")] Tamanio tamanio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tamanio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tamanio);
        }

        // GET: Tamanio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tamanio tamanio = db.Tamanio.Find(id);
            if (tamanio == null)
            {
                return HttpNotFound();
            }
            return View(tamanio);
        }

        // POST: Tamanio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tamanio tamanio = db.Tamanio.Find(id);
            db.Tamanio.Remove(tamanio);
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
