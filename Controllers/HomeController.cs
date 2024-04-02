using FoodHub.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using FoodHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FoodHub.Controllers
{
    /*public class NewOrderItem
    {
        public int Rid { get; set; }
        public float totalPrice { get; set; }
        public string orderType { get; set; }
        public int[] quantity { get; set; }
        public int[] FoodList { get; set; }
        public int Token { get; set; }
    }*/
    public class HomeController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        public List<Food> FoodList = new List<Food>();
        public ActionResult Index()
        {
            if (User.IsInRole("RestaurantManager"))
            {
                return RedirectToAction("Index", "Food");
            }
            return View(_context.Restaurants.ToList());
        }
        [AllowAnonymous]
        public ActionResult About()
        {
            return View();
        }


        public ActionResult Menu(int? restaurantId)
        {
            var rest = _context.Restaurants.Where(f => f.Rid == restaurantId).Single();
            ViewBag.restName = rest.RName;
            ViewBag.logo = rest.logo;
            var foodContext = _context.Foods.Where(f => f.Rid == restaurantId);
            return View(foodContext.ToList());
        }

        [HttpPost]
        public ActionResult Cart(string flist)
        {
            string[] idStrings = flist.Trim('[', ']').Split(',');
            List<int> FoodIds = idStrings.Select(int.Parse).ToList();
            List<Food> cartItems = _context.Foods.Where(food => FoodIds.Contains(food.Fid)).ToList();
            return View(cartItems);
        }

        public ActionResult History()
        {
            string adminId = User.Identity.GetUserId();
            ApplicationUser admin = _context.Users.Find(adminId);
            if (User.IsInRole("RestaurantManager"))
                return RedirectToAction("Index", "FoodOrder");
            var HistoryContext = _context.FoodOrders.Where(f => f.Cid == admin.fhID).OrderByDescending(f => f.Oid);
            return View(HistoryContext.ToList());
        }

        public ActionResult RepeatOrder(int id)
        {
            List<int> fids = _context.OrderItems.Where(o => o.Oid == id).Select(item => item.Fid).ToList();
            List<Food> cartItems = _context.Foods.Where(food => fids.Contains(food.Fid)).ToList();
            return View("Cart", cartItems);
        }

        public ActionResult ConfirmPage(int id)
        {
            FoodOrder foodOrder = _context.FoodOrders.Find(id);
            if (foodOrder == null)
            {
                return HttpNotFound();
            }
            return View(foodOrder);
        }
        [HttpPost]
        public ActionResult getfooditems(int Orderid)
        {
            List<ItemViewModel> items = new List<ItemViewModel>();

            List<int> Fids = _context.OrderItems.Where(a => a.Oid == Orderid).Select(a => a.Fid).ToList();
            List<int> quantity = _context.OrderItems.Where(oi => oi.Oid == Orderid).Select(oi => oi.quantity).ToList();
            List<string> FoodName = _context.Foods.Where(food => Fids.Contains(food.Fid)).Select(oi => oi.FName).ToList();
            for (int i = 0; i < FoodName.Count; i++)
            {
                items.Add(new ItemViewModel
                {
                    FoodName = FoodName[i],
                    Quantity = quantity[i]
                });
            }
            string json = JsonConvert.SerializeObject(items);
            return Content(json, "application/json");

        }

        [HttpPost]
        public ActionResult confirmOrder(FoodViewModel orderitem)
        {

            var NewOrder = new FoodOrder();

            //getting present datetime
            DateTime dateValue = DateTime.Today;
            TimeSpan timeValue = DateTime.Now.TimeOfDay;
            DateTime combinedDateTime = dateValue.Date.Add(timeValue);
            string adminId = User.Identity.GetUserId();
            ApplicationUser admin = _context.Users.Find(adminId);
            NewOrder.Cid = admin.fhID;
            NewOrder.Rid = orderitem.Rid;
            NewOrder.date = combinedDateTime;
            NewOrder.totalPrice = orderitem.totalPrice;
            NewOrder.orderType = orderitem.orderType;
            NewOrder.paymentStatus = "Cash";
            NewOrder.orderStatus = "pending";
            NewOrder.Token = orderitem.Token;
            try
            {
                _context.FoodOrders.Add(NewOrder);
                _context.SaveChanges();
                int cartSize = orderitem.FoodList.Length;
                for (int i = 0; i < cartSize; i++)
                {
                    var NewItem = new OrderItem();
                    NewItem.Oid = NewOrder.Oid;
                    NewItem.Fid = orderitem.FoodList[i];
                    NewItem.quantity = orderitem.quantity[i];
                    _context.OrderItems.Add(NewItem);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred while adding the order" });
            }

            //return View("ConfirmPage", NewOrder);
            return Json(new { success = true, message = "Order placed" ,data=NewOrder.Oid});
            //return RedirectToAction("ConfirmPage", NewOrder.Oid);
        }
    }
}