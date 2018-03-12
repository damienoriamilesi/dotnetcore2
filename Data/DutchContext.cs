using coreapp.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class DutchContext : IdentityDbContext<StoreUser>
{
    private IConfigurationRoot _config { get; }

    public DutchContext(DbContextOptions<DutchContext> options) : base(options)
    {
        
    }
    public DutchContext(IConfigurationRoot config, DbContextOptions options) 
        : base(options)
        {
            _config = config;
        }


    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
}