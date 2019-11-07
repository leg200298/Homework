using Homework.Models;
using Homework.Models.InterFaces;
using Homework.Models.ProductView;
using Homework.Repositories;
using Homework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Homework.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository<Products> _productRepository;
        private readonly ProductService _productService;
        public ProductController()
        {
            _productRepository = new ProductRepository();
            _productService = new ProductService();
        }
        // GET: Product
        public async Task<ActionResult> Index()
        {
            var result = await _productRepository.GetAsync();
            List<ProductsResponse> data = new List<ProductsResponse>();
            if (result != null)
            {
                data = _productService.GetAllService(result).ToList();
            }
            return View(data);
        }

        // GET: Product/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public async Task<ActionResult> Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
