using Daraz.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daraz.Application.Common.Interfaces
{
    public interface IProductRepository: IRepository<Product>
    {
        void UpdateProduct(Product product);
    }
}
