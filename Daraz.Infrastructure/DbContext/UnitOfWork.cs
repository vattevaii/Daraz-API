using Daraz.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daraz.Infrastructure.DbContext
{
    internal class UnitOfWork : IUnitOfWork
    {
        public IProductRepository Products { get; private set; }
        public DarazDbContext _context { get; private set; }
        public UnitOfWork(DarazDbContext context)
        {
            Products = new ProductRepository(context);
            _context = context;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
