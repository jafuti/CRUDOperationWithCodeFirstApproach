using CRUD_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_Demo.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        ApplicationDbContext _context = new ApplicationDbContext();
        public ActionResult Index()
        {
          var product =  _context.Products.ToList();
            return View(product);
        }
        public ActionResult Details(int id)
        {
            var product = _context.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
            return View(product);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("index");
            } else
            {
                return View();
            }
        }
        public ActionResult Edit(long id)
        {
            var exsitingProduct = _context.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
            return View(exsitingProduct);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var exstitngProduct = _context.Products.Where(temp => temp.ProductID == product.ProductID).FirstOrDefault();
                exstitngProduct.ProductName = product.ProductName;
                exstitngProduct.Price = product.Price;
                exstitngProduct.DateOfPurchase = product.DateOfPurchase;
                exstitngProduct.AvailabilityStatus = product.AvailabilityStatus;
                exstitngProduct.CategoryID = product.CategoryID;
                exstitngProduct.BrandID = product.BrandID;
                exstitngProduct.Active = product.Active;
                _context.SaveChanges();
                return RedirectToAction("index");
            } else
            {
                return View();
            }
            
        }

        public ActionResult Delete(long id)
        {
            var product = _context.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

    }
}