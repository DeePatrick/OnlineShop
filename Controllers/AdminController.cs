using OnlineShop.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext db;
        public AdminController()
        {
            db = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return View(db.Products);
        }

        public ViewResult Edit(int id)
        {
            Product product = db.Products
                .SingleOrDefault(p => p.ProductId == id);
            var model = new Product
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Category = product.Category,
                Genre = product.Genre,
                BrandImage = product.BrandImage
            };

            return View("Edit", model);
        }



        [HttpPost]
        public ActionResult Edit(Product model, HttpPostedFileBase image1)
        {

            if (!ModelState.IsValid)
            {
                if (image1 != null)
                {
                    model.BrandImage = new byte[image1.ContentLength];
                    image1.InputStream.Read(model.BrandImage, 0, image1.ContentLength);
                }
                return View("Edit", model);
            }
            var product = db.Products
               .Single(p => p.ProductId == model.ProductId);
            product.Modify( model.Name, model.Description, model.Price, model.Category, model.Genre

            );
            db.SaveChanges();
            return RedirectToAction("Index");
        }




        public ActionResult AddProduct()
        {
            Product b1 = new Product();
            return View(b1);
        }

        [HttpPost]
        public ActionResult AddProduct(Product model, HttpPostedFileBase image1)
        {
            var db = new ApplicationDbContext();
            if (image1 != null)
            {
                model.BrandImage = new byte[image1.ContentLength];
                image1.InputStream.Read(model.BrandImage, 0, image1.ContentLength);
            }

            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Category = model.Category,
                Genre = model.Genre,
                BrandImage = model.BrandImage
            };

            db.Products.Add(product);
            db.SaveChanges();
            TempData["message"] = string.Format("{0} has been saved", product.Name);
            return View("Index");
        }

        [HttpPost]
        [Authorize]
        public ActionResult Delete(int Id)
        {
            var viewModel = db.Products
                .SingleOrDefault(g => g.ProductId == Id);

            db.Products.Remove(viewModel);
            db.SaveChanges();
            return View(viewModel);
        }


    }
}

