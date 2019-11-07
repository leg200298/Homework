using Homework.Models.ProductView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Homework.Models.InterFaces
{
    public interface IProductRepository<DbModel>
    {
        Task<IEnumerable<DbModel>> GetAsync();
        Task<DbModel> GetAsync(int Id);
        Task<bool> PostAsync(DbModel postProduct);
        Task<bool> PutAsync(DbModel postProduct);
        Task<bool> DeleteAsync(int Id);
    }
}