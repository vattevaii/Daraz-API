using Daraz.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Daraz.Infrastructure.DbContext;

public class DarazDbContext: IdentityDbContext
{
    public DarazDbContext(DbContextOptions options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        //builder.Seed();
    }
    public DbSet<Product> Products { get; set; }
}
