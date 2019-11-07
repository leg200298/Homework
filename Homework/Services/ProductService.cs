using Homework.Models;
using Homework.Models.ProductView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework.Services
{
    public class ProductService
    {
        public IEnumerable<ProductsResponse> GetAllService(IEnumerable<Products> products)
        {
            var productsResponse = products.Select(x => new ProductsResponse
            {
                ProductID = x.ProductID,
                ProductName = x.ProductName,
                SupplierID = x.SupplierID,
                CategoryID = x.CategoryID,
                QuantityPerUnit = x.QuantityPerUnit,
                UnitPrice = x.UnitPrice,
                UnitsInStock = x.UnitsInStock,
                UnitsOnOrder = x.UnitsOnOrder,
                ReorderLevel = x.ReorderLevel,
                Discontinued = x.Discontinued,
            });
            return productsResponse;
        }

        public ProductsResponse GetService(Products products)
        {
            var productsResponse =  new ProductsResponse()
            {
                ProductID = products.ProductID,
                ProductName = products.ProductName,
                SupplierID = products.SupplierID,
                CategoryID = products.CategoryID,
                QuantityPerUnit = products.QuantityPerUnit,
                UnitPrice = products.UnitPrice,
                UnitsInStock = products.UnitsInStock,
                UnitsOnOrder = products.UnitsOnOrder,
                ReorderLevel = products.ReorderLevel,
                Discontinued = products.Discontinued,
            };
            return productsResponse;
        }

        public Products PostService(ProductRequest postProduct)
        {
            Products products = new Products()
            {
                ProductName = postProduct.ProductName,
                SupplierID = postProduct.SupplierID,
                CategoryID = postProduct.CategoryID,
                QuantityPerUnit = postProduct.QuantityPerUnit,
                UnitPrice = postProduct.UnitPrice,
                UnitsInStock = postProduct.UnitsInStock,
                UnitsOnOrder = postProduct.UnitsOnOrder,
                ReorderLevel = postProduct.ReorderLevel,
                Discontinued = postProduct.Discontinued
            };
            return products;
        }

        public Products PutService(ProductRequest postProduct)
        {
            Products products = new Products()
            {
                ProductName = postProduct.ProductName,
                SupplierID = postProduct.SupplierID,
                CategoryID = postProduct.CategoryID,
                QuantityPerUnit = postProduct.QuantityPerUnit,
                UnitPrice = postProduct.UnitPrice,
                UnitsInStock = postProduct.UnitsInStock,
                UnitsOnOrder = postProduct.UnitsOnOrder,
                ReorderLevel = postProduct.ReorderLevel,
                Discontinued = postProduct.Discontinued
            };
            return products;
        }
    }
}