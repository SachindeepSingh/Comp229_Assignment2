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
    public class VegfoodController : Controller
    {
        private IndianRestaurentContext db = new IndianRestaurentContext();
        // GET: Vegfood
        
        public ActionResult Index()
        {
            return View(db.Vegfood.ToList());
        }
        [Authorize(Roles = "Admin")]
        // GET: Appetizers for Admin
        public ActionResult Admin()
        {
            return View(db.Vegfood.ToList());
        }
        // GET: Appetizers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vegfood vegfood = db.Vegfood.Find(id);
            if (vegfood == null)
            {
                return HttpNotFound();
            }
            return View(vegfood);
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
        public ActionResult Create([Bind(Include = "Id,Name,ShortDescription,LongDescription,Price,Image")] Vegfood vegfood)
        {
            if (ModelState.IsValid)
            {
                db.Vegfood.Add(vegfood);
                db.SaveChanges();
                return RedirectToAction("Admin");
            }

            return View(vegfood);
        }

        // GET: AdminAppetizers/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vegfood vegfood = db.Vegfood.Find(id);
            if (vegfood == null)
            {
                return HttpNotFound();
            }
            return View(vegfood);
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
             Vegfood vegfood = db.Vegfood.Find(id);
             if (vegfood == null)
             {
                 return HttpNotFound();
             }
             return View(vegfood);
         }
         
        //POST: AdminAppetizers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vegfood vegfood = db.Vegfood.Find(id);
            db.Vegfood.Remove(vegfood);
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