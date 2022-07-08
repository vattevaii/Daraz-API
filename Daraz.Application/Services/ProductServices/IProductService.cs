using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daraz.Application.Services.ProductServices
{
    public interface IProductService
    {
        int AddProduct(string Name, string Description, double MarkedPrice, double Discount, int userId);
        bool DeleteProduct(int ProductId, int userId);
        ProductResult GetItem(int ProductId);
        ProductResult UpdateProduct(int id, string Name, string Description, double MarkedPrice, double Discount, int userId);
        ProductResult[] GetAll();
    }
}
