using Homework.Models.ProductView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Homework.Models.InterFaces
{
    public interface IProductRepository<RequestModel, DbModel>
    {
        Task<IEnumerable<DbModel>> GetAsync();
        Task<DbModel> GetAsync(int Id);
        Task<DbModel> PostAsync(RequestModel postProduct);
        Task<DbModel> PutAsync(RequestModel postProduct);
        Task<DbModel> DeleteAsync(int Id);
    }
}