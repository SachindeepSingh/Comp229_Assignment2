using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Comp229_Assignment2.Models;

namespace Comp229_Assignment2.Controllers
{

    public class DessertsController : Controller
    { 
    private IndianRestaurentContext db = new IndianRestaurentContext();
    
        public ActionResult Index()
        {
            return View(db.Desserts.ToList());
        }

        //Get:Desserts/Admin
        [Authorize(Roles = "Admin")]
        public ActionResult Admin()
        {
            return View(db.Desserts.ToList());
        }

        // GET: Desserts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dessert dessert = db.Desserts.Find(id);
            if (dessert == null)
            {
                return HttpNotFound();
            }
            return View(dessert);
        }

        // GET: AdminDesserts/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminDesserts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DessertId,DessertName,DessertShortDescription,DessertLongDescription,DessertPrice,DessertImage")] Dessert dessert)
        {
            if (ModelState.IsValid)
            {
                db.Desserts.Add(dessert);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dessert);
        }

        // GET: AdminDesserts/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dessert dessert = db.Desserts.Find(id);
            if (dessert == null)
            {
                return HttpNotFound();
            }
            return View(dessert);
        }

        // POST: AdminDesserts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DessertId,DessertName,DessertShortDescription,DessertLongDescription,DessertPrice,DessertImage")] Dessert dessert)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dessert).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dessert);
        }

        // GET: AdminDesserts/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dessert dessert = db.Desserts.Find(id);
            if (dessert == null)
            {
                return HttpNotFound();
            }
            return View(dessert);
        }

        // POST: AdminDesserts/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dessert dessert = db.Desserts.Find(id);
            db.Desserts.Remove(dessert);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]
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
