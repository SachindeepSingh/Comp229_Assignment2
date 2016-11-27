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
    public class SnacksController : Controller

    {

        private IndianRestaurentContext db = new IndianRestaurentContext();
        // GET: Vegfood

        public ActionResult Index()
        {
            return View(db.Snacks.ToList());
        }
        [Authorize(Roles = "Admin")]
        // GET: Appetizers for Admin
        public ActionResult Admin()
        {
            return View(db.Snacks.ToList());
        }
        // GET: Appetizers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Snack snack = db.Snacks.Find(id);
            if (snack == null)
            {
                return HttpNotFound();
            }
            return View(snack);
        }


        // GET: AdminAppetizers/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminAppetizers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ShortDescription,LongDescription,Price,Image")] Snack snack)
        {
            if (ModelState.IsValid)
            {
                db.Snacks.Add(snack);
                db.SaveChanges();
                return RedirectToAction("Admin");
            }

            return View(snack);
        }

        // GET: AdminAppetizers/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Snack snack = db.Snacks.Find(id);
            if (snack == null)
            {
                return HttpNotFound();
            }
            return View(snack);
        }

        // POST: AdminAppetizers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ShortDescription,LongDescription,Price,Image")] Vegfood vegfood)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vegfood).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Admin");
            }
            return View(vegfood);
        }

        //GET: AdminVegfood/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Snack snack = db.Snacks.Find(id);
            if (snack == null)
            {
                return HttpNotFound();
            }
            return View(snack);
        }

        //POST: AdminAppetizers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Snack snack = db.Snacks.Find(id);
            db.Snacks.Remove(snack);
            db.SaveChanges();
            return RedirectToAction("Admin");
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