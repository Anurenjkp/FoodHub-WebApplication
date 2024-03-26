using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FoodHub.Models;

namespace FoodHub.Controllers
{
    public class FoodOrderController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FoodOrder
        public ActionResult Index()
        {
            var foodOrders = db.FoodOrders.Include(f => f.customer);
            return View(foodOrders.ToList());
        }

        // GET: FoodOrder/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodOrder foodOrder = db.FoodOrders.Find(id);
            if (foodOrder == null)
            {
                return HttpNotFound();
            }
            return View(foodOrder);
        }

        // GET: FoodOrder/Create
        public ActionResult Create()
        {
            ViewBag.Cid = new SelectList(db.Customers, "Cid", "CName");
            return View();
        }

        // POST: FoodOrder/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Oid,Cid,date,totalPrice,orderType,paymentStatus,orderStatus,Token")] FoodOrder foodOrder)
        {
            if (ModelState.IsValid)
            {
                db.FoodOrders.Add(foodOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cid = new SelectList(db.Customers, "Cid", "CName", foodOrder.Cid);
            return View(foodOrder);
        }

        // GET: FoodOrder/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodOrder foodOrder = db.FoodOrders.Find(id);
            if (foodOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cid = new SelectList(db.Customers, "Cid", "CName", foodOrder.Cid);
            return View(foodOrder);
        }

        // POST: FoodOrder/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Oid,Cid,date,totalPrice,orderType,paymentStatus,orderStatus,Token")] FoodOrder foodOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foodOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cid = new SelectList(db.Customers, "Cid", "CName", foodOrder.Cid);
            return View(foodOrder);
        }

        // GET: FoodOrder/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodOrder foodOrder = db.FoodOrders.Find(id);
            if (foodOrder == null)
            {
                return HttpNotFound();
            }
            return View(foodOrder);
        }

        // POST: FoodOrder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FoodOrder foodOrder = db.FoodOrders.Find(id);
            db.FoodOrders.Remove(foodOrder);
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
