using System.Linq;
using System.Web.Mvc;
using GlowShop.Models;

namespace GlowShop.Controllers
{
    public class ProductsController : Controller
    {
        private GlowShopDbContext db = new GlowShopDbContext();

        // GET: /Products
        public ActionResult Index(int? categoryId, string search, string sort)
        {
            var products = db.Products.Include("Category").AsQueryable();

            // Filter by category
            if (categoryId.HasValue)
                products = products.Where(p => p.CategoryId == categoryId);

            // Filter by search
            if (!string.IsNullOrEmpty(search))
                products = products.Where(p =>
                    p.Name.Contains(search) || p.Description.Contains(search));

            // Sort
            if (string.Equals(sort, "price_asc"))
            {
                products = products.OrderBy(p => p.Price);
            }
            else if (string.Equals(sort, "price_desc"))
            {
                products = products.OrderByDescending(p => p.Price);
            }
            else if (string.Equals(sort, "rating"))
            {
                products = products.OrderByDescending(p => p.Rating);
            }
            else if (string.Equals(sort, "newest"))
            {
                products = products.OrderByDescending(p => p.CreatedAt);
            }
            else
            {
                products = products.OrderBy(p => p.Name);
            }

            ViewBag.Categories = db.Categories.ToList();
            ViewBag.CategoryId = categoryId;
            ViewBag.Search = search;
            ViewBag.Sort = sort;

            return View(products.ToList());
        }

        // GET: /Products/Details/5
        public ActionResult Details(int id)
        {
            var product = db.Products
                .Include("Category")
                .FirstOrDefault(p => p.ProductId == id);

            if (product == null) return HttpNotFound();

            // Related products (same category)
            ViewBag.Related = db.Products
                .Where(p => p.CategoryId == product.CategoryId && p.ProductId != id)
                .Take(4).ToList();

            return View(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}
