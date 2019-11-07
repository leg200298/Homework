using Homework.Models;
using Homework.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework.Repositories;

namespace Homework.Tests.Tools
{
    [TestClass]
    public class DapperToolTest
    {
        [TestMethod]
        public async Task ExecuteAsyncTest()
        {
            using (DapperTool dapperTool = new DapperTool())
            {
                await dapperTool.OpenConnection();

                Products products = new Products()
                {
                    ProductName = "Test ProductName",
                    SupplierID = 1,
                    CategoryID = 2,
                    QuantityPerUnit = "Test QuantityPerUnit",
                    UnitPrice = 3,
                    UnitsInStock = 4,
                    UnitsOnOrder = 5,
                    ReorderLevel = 6,
                    Discontinued = false
                };

                var InsertResult = await dapperTool.ExecuteAsync("insert into Products (ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued) VALUES " +
                    "(@ProductName,@SupplierID,@CategoryID,@QuantityPerUnit,@UnitPrice,@UnitsInStock,@UnitsOnOrder,@ReorderLevel,@Discontinued)", products);

                Assert.IsTrue(InsertResult.Success);

                var deleteResult = await dapperTool.ExecuteAsync("delete Products where ProductName = @ProductName and QuantityPerUnit = @QuantityPerUnit", products);

                Assert.IsTrue(deleteResult.Success);

            }
        }
        [TestMethod]
        public async Task QueryAsyncTest()
        {
            using (DapperTool dapperTool = new DapperTool())
            {
                await dapperTool.OpenConnection();
                var result = await dapperTool.QueryAsync<Products>("select * from Products");
                Assert.IsTrue(result.Success);
            }
        }
        [TestMethod]
        public async Task QueryFirstOrDefaultAsyncTest()
        {
            using (DapperTool dapperTool = new DapperTool())
            {
                await dapperTool.OpenConnection();
                var result = await dapperTool.QueryFirstOrDefaultAsync<Products>("select * from Products");
                Assert.IsTrue(result.Success);
            }
        }
        [TestMethod]
        public async Task GetOneData()
        {
            ProductRepository productRepository = new ProductRepository();
            var data = await productRepository.GetAsync(12);
            Assert.IsNotNull(data);
        }
    }
}
