using Homework.Models;
using Homework.Models.InterFaces;
using Homework.Models.ProductView;
using Homework.Services;
using Homework.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Homework.Repositories
{
    public class ProductRepository : IProductRepository<Products>
    {
        public async Task<bool> DeleteAsync(int Id)
        {
            using (DapperTool dapperTool = new DapperTool())
            {
                await dapperTool.OpenConnection();
                var result = await dapperTool.ExecuteAsync("delete Products where ProductID = @ProductID", new { ProductID = Id });
                return result.Success;
            }
        }

        public async Task<IEnumerable<Products>> GetAsync()
        {
            using (DapperTool dapperTool = new DapperTool())
            {
                await dapperTool.OpenConnection();
                var result = await dapperTool.QueryAsync<Products>("select * from Products");
                return result.Data;
            }
        }

        public async Task<Products> GetAsync(int Id)
        {
            using (DapperTool dapperTool = new DapperTool())
            {
                await dapperTool.OpenConnection();
                var result = await dapperTool.QueryFirstOrDefaultAsync<Products>("select * from Products where ProductID = @ProductID", new { ProductID = Id });
                return result.Data;
            }
        }

        public async Task<bool> PostAsync(Products product)
        {
            using (DapperTool dapperTool = new DapperTool())
            {
                await dapperTool.OpenConnection();
                var result = await dapperTool.ExecuteAsync("insert into Products (ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued) VALUES " +
     "(@ProductName,@SupplierID,@CategoryID,@QuantityPerUnit,@UnitPrice,@UnitsInStock,@UnitsOnOrder,@ReorderLevel,@Discontinued)", product);

                return result.Success;
            }
        }

        public async Task<bool> PutAsync(Products product)
        {
            using (DapperTool dapperTool = new DapperTool())
            {
                await dapperTool.OpenConnection();
                var result = await dapperTool.ExecuteAsync("update Products set ProductName = @ProductName, SupplierID = @SupplierID, CategoryID = @CategoryID ,QuantityPerUnit = @QuantityPerUnit ,UnitPrice = @UnitPrice, UnitsInStock = @UnitsInStock, UnitsOnOrder = @UnitsOnOrder, ReorderLevel = @ReorderLevel, Discontinued =@Discontinued where ProductID = @ProductID ", product);

                return result.Success;
            }
        }
    }
}