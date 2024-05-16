using Hubtel.eCommerce.Cart.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Hubtel.eCommerce.Cart.Api.Data
{
    public class CartDbContext(DbContextOptions<CartDbContext> options)
        :DbContext(options)
    {
        public DbSet<CartItem> Cart { get; set; }
        public DbSet<User> Users { get; set; }
    }
}   
