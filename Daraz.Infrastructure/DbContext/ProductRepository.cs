using Daraz.Application.Common.Interfaces;
using Daraz.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Daraz.Infrastructure.DbContext
{
    public class ProductRepository: Repository<Product>, IProductRepository
    {
        public DbSet<Product> _dbSet { get; set; }
        public ProductRepository(DarazDbContext context): base(context)
        {
            _dbSet = context.Products;
        }
        public void UpdateProduct(Product product)
        {
            _dbSet.Update(product);
        }
    }
}
