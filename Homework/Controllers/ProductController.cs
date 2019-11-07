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
            ProductsResponse productsResponse = new ProductsResponse();
            var result = await _productRepository.GetAsync(id);
            if (result != null)
            {
                productsResponse = _productService.GetService(result);
            }
            return View(productsResponse);
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
                ProductRequest productRequest = new ProductRequest();
                TryUpdateModel(productRequest, collection);
                // TODO: Add insert logic here
                var data = _productService.PostService(productRequest);
                var result = await _productRepository.PostAsync(data);
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
            var result = await _productRepository.GetAsync(id);
            ProductRequest productRequest = new ProductRequest();
            if (result != null)
            {
                productRequest = _productService.GetService(result);
            }
            return View(productRequest);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, FormCollection collection)
        {
            try
            {
                ProductRequest productRequest = new ProductRequest();
                TryUpdateModel(productRequest, collection);
                // TODO: Add update logic here
                var data = _productService.PutService(id, productRequest);
                var result = await _productRepository.PutAsync(data);
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
            var result = await _productRepository.GetAsync(id);
            ProductRequest productRequest = new ProductRequest();
            if (result != null)
            {
                productRequest = _productService.GetService(result);
            }
            return View(productRequest);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var result = await _productRepository.DeleteAsync(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
