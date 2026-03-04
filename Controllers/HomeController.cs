using System.Linq;
using System.Web.Mvc;
using GlowShop.Models;

namespace GlowShop.Controllers
{
    public class HomeController : Controller
    {
        private GlowShopDbContext db = new GlowShopDbContext();

        // GET: /
        public ActionResult Index()
        {
            var featuredProducts = db.Products
                .Where(p => p.IsFeatured && p.Stock > 0)
                .OrderByDescending(p => p.Rating)
                .Take(8)
                .ToList();

            var categories = db.Categories.ToList();

            ViewBag.FeaturedProducts = featuredProducts;
            ViewBag.Categories = categories;
            return View();
        }

        // GET: /Home/About
        public ActionResult About()
        {
            return View();
        }

        // GET: /Home/Contact
        public ActionResult Contact()
        {
            return View(new ContactMessage());
        }

        // POST: /Home/Contact
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactMessage model)
        {
            if (ModelState.IsValid)
            {
                db.ContactMessages.Add(model);
                db.SaveChanges();
                TempData["Success"] = "Thank you! Your message has been sent. 💌";
                return RedirectToAction("Contact");
            }
            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}
