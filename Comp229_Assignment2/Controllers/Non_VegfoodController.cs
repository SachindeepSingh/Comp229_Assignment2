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
    public class Non_VegfoodController : Controller
    {
        private IndianRestaurentContext db = new IndianRestaurentContext();

        // GET: Vegfood
        public ActionResult Index()
        {
            return View(db.Non_Vegfood.ToList());
        }
        [Authorize(Roles = "Admin")]
        // GET: Appetizers for Admin
        public ActionResult Admin()
        {
            return View(db.Non_Vegfood.ToList());
        }
        // GET: Appetizers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Non_Vegfood non_vegfood = db.Non_Vegfood.Find(id);
            if (non_vegfood == null)
            {
                return HttpNotFound();
            }
            return View(non_vegfood);
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
        public ActionResult Create([Bind(Include = "Id,Name,ShortDescription,LongDescription,Price,Image")] Non_Vegfood non_vegfood)
        {
            if (ModelState.IsValid)
            {
                db.Non_Vegfood.Add(non_vegfood);
                db.SaveChanges();
                return RedirectToAction("Admin");
            }

            return View(non_vegfood);
        }

        // GET: AdminAppetizers/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Non_Vegfood non_vegfood = db.Non_Vegfood.Find(id);
            if (non_vegfood == null)
            {
                return HttpNotFound();
            }
            return View(non_vegfood);
        }

        // POST: AdminAppetizers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ShortDescription,LongDescription,Price,Image")] Non_Vegfood non_vegfood)
        {
            if (ModelState.IsValid)
            {
                db.Entry(non_vegfood).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Admin");
            }
            return View(non_vegfood);
        }

        // GET: AdminAppetizers/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
        if (id == null)
        {
         return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
         }
         Non_Vegfood Non_Vegfood = db.Non_Vegfood.Find(id);
        if (Non_Vegfood == null)
        {
         return HttpNotFound();
        }
        return View(Non_Vegfood);
        }

        // POST: AdminAppetizers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Non_Vegfood Non_vegfood = db.Non_Vegfood.Find(id);
            db.Non_Vegfood.Remove(Non_vegfood);
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
