using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using FoodHub.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using FoodHub.Models;

namespace FoodHub.Controllers
{
    public class Item
    {
        public string FoodName { get; set; }
        public int Quantity { get; set; }
    }
    [Authorize(Roles = "RestaurantManager")]
    public class FoodOrderController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FoodOrder
        public ActionResult Index()
        {
            string adminId = User.Identity.GetUserId();
            ApplicationUser admin = db.Users.Find(adminId);
            var foodOrders = db.FoodOrders.Where(f => f.Rid == admin.fhID).Include(f => f.customer).OrderByDescending(f => f.Oid);
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

        [HttpPost]
        public ActionResult getfooditems(int Orderid)
        {
            List<Item> items = new List<Item>();

            List<int> Fids = db.OrderItems.Where(a => a.Oid == Orderid).Select(a => a.Fid).ToList();
            List<int> quantity = db.OrderItems.Where(oi => oi.Oid == Orderid).Select(oi => oi.quantity).ToList();
            List<string> FoodName = db.Foods.Where(food => Fids.Contains(food.Fid)).Select(oi => oi.FName).ToList();
            for (int i = 0; i < FoodName.Count; i++)
            {
                items.Add(new Item
                {
                    FoodName = FoodName[i],
                    Quantity = quantity[i]
                });
            }
            string json = JsonConvert.SerializeObject(items);
            return Content(json, "application/json");

        }

        [HttpPost]
        public ActionResult acceptOrder(int orderId)
        {
            var orderToUpdate = db.FoodOrders.Find(orderId);
            if (orderToUpdate != null)
            {
                orderToUpdate.orderStatus = "accepted";
                db.SaveChanges();
                return Json(new { success = true, message = "Order Accepted" });
            }
            return Json(new { success = false, message = "Error while accepting Order" });
        }

        [HttpPost]
        public ActionResult orderReady(int orderId)
        {
            var orderToUpdate = db.FoodOrders.Find(orderId);
            if (orderToUpdate != null)
            {
                orderToUpdate.orderStatus = "done";
                db.SaveChanges();
                return Json(new { success = true, message = "Order Ready to  PickUp" });
            }
            return Json(new { success = false, message = "Error while accepting Order" });
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
