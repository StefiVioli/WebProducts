using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProducts.Data;
using WebProducts.Models;

namespace WebProducts.Controllers
{
    public class ProductController : Controller
    {
       
        //Crear instancia del dbcontext

        private ProductDbContext context = new ProductDbContext();

        // GET: Product
        //public ActionResult Index()
        //{

        //    var products = context.Products.ToList();

        //    return View("Index", products);
        //}

        //public ActionResult Index(string category = "")
        //{
        //    if(string.IsNullOrEmpty(category))
        //    { 
        //        return View(context.Products.ToList()); 
        //    }
        //    else
        //    {
        //        return View((from product in context.Products
        //                     where product.Category == category
        //                     select product).ToList<Product>());
        //    }
        //}

        public ActionResult Index(string category, string name)
        {
            int cat = String.IsNullOrEmpty(category) ? 0 : 2;
            int nam = String.IsNullOrEmpty(name) ? 0 : 1;
            int val = cat | nam;
            switch(val)
            {
                case 0:
                    return View(context.Products.ToList());
                case 2:
                    return View((from product in context.Products
                                 where product.Category == category
                                 select product).ToList<Product>());

                case 1:
                    return View((from product in context.Products
                                 where product.ProductName == name
                                 select product).ToList<Product>());
                case 3:
                    return View((from product in context.Products
                                 where product.Category == category &&
                                 product.ProductName == name
                                 select product).ToList<Product>());

                default:
                    return View();
            }
        }
       
        [HttpGet]
        public ActionResult Create()
        {
            
            Product product = new Product();

            return View("Create", product);
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                context.Products.Add(product);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Create", product);
        }

     
        [HttpGet]

        public ActionResult Detail(int id)
        {
            Product product = context.Products.Find(id);

            if (product != null)
            {
                return View("Detail", product);
            }
            else
            {
                return HttpNotFound();
            }



        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Product product = context.Products.Find(id);

            if (product != null)
            {
                return View("Delete", product);
            }
            else
            {
                return HttpNotFound();
            }

        }

     
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = context.Products.Find(id);

            context.Products.Remove(product);
            context.SaveChanges();

            return RedirectToAction("Index");

        }
     
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Product product = context.Products.Find(id);

            if (product != null)
            {
                return View("Edit", product);
            }
            else
            {
                return HttpNotFound();
            }

        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditConfirmed(Product product)
        {

            if (ModelState.IsValid)
            {
                context.Entry(product).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Edit", product);

        }
    }
}
