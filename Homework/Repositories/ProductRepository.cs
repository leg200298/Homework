using Homework.Models;
using Homework.Models.InterFaces;
using Homework.Models.ProductView;
using Homework.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Homework.Repositories
{
    public class ProductRepository : IProductRepository<ProductRequest, Products>
    {
        public Task<Products> DeleteAsync(int Id)
        {
            throw new NotImplementedException();
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

        public Task<Products> PostAsync(ProductRequest postProduct)
        {
            throw new NotImplementedException();
        }

        public Task<Products> PutAsync(ProductRequest postProduct)
        {
            throw new NotImplementedException();
        }
    }
}