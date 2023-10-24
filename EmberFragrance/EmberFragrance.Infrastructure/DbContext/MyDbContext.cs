using Ember.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Ember.Infrastructure;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions options) 
        : base(options)
    {
    }

    public DbSet<Fragrance> Fragrances { get; set; }
    
}