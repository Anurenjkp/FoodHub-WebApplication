using FoodHub.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodHub.Controllers
{
    public class NewOrderItem
    {
        public int Rid { get; set; }
        public float totalPrice { get; set; }
        public string orderType { get; set; }
        public int[] quantity { get; set; }
        public int[] FoodList { get; set; }
        public int Token { get; set; }
    }
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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Menu(int? restaurantId)
        {
            var rest = _context.Restaurants.Where(f => f.Rid == restaurantId).Single();
            ViewBag.restName = rest.RName;
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

        public ActionResult ConfirmPage() { return View(); }


        [HttpPost]
        public ActionResult confirmOrder(NewOrderItem orderitem)
        {

            if (orderitem != null)
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

                return Json(new { success = true, message = "Order placed successfully" });
            }
            else
            {
                return Json(new { success = false, message = "An error occurred while confirming the order" });
            }
        }
    }
}