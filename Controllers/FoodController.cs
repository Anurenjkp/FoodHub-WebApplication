using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FoodHub.Models;
using Microsoft.AspNet.Identity;

namespace FoodHub.Controllers
{
    public class FoodController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Food
        public ActionResult Index()
        {

            string adminId = User.Identity.GetUserId();
            ApplicationUser admin = db.Users.Find(adminId);
            var foods = db.Foods.Where(f => f.Rid == admin.fhID).ToList();
            Restaurant rest = db.Restaurants.Where(f => f.Rid == admin.fhID).SingleOrDefault();
            if(rest != null)
            ViewBag.restname = rest.RName;
            
            return View(foods);
        }

        // GET: Food/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food food = db.Foods.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            return View(food);
        }

        // GET: Food/Create
        public ActionResult Create()
        {
            ViewBag.Rid = new SelectList(db.Restaurants, "Rid", "RName");
            return View();
        }

        // POST: Food/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Fid,FName,price,image,veg,foodCount,Rid")] Food food)
        {
            if (ModelState.IsValid)
            {
                db.Foods.Add(food);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Rid = new SelectList(db.Restaurants, "Rid", "RName", food.Rid);
            return View(food);
        }

        // GET: Food/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food food = db.Foods.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            ViewBag.Rid = new SelectList(db.Restaurants, "Rid", "RName", food.Rid);
            return View(food);
        }

        // POST: Food/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Fid,FName,price,image,veg,foodCount,Rid")] Food food)
        {
            if (ModelState.IsValid)
            {
                db.Entry(food).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Rid = new SelectList(db.Restaurants, "Rid", "RName", food.Rid);
            return View(food);
        }

        // GET: Food/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food food = db.Foods.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            return View(food);
        }

        // POST: Food/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Food food = db.Foods.Find(id);
            db.Foods.Remove(food);
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
