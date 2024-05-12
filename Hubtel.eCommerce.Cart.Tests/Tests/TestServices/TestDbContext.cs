using Hubtel.eCommerce.Cart.Api.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubtel.eCommerce.Cart.Tests.Tests.TestServices
{
    public class TestDbContext
    {
        static public CartDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<CartDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            var dbcontext = new CartDbContext(options);
            dbcontext.Database.EnsureCreated();
            return dbcontext;
        }
    }
}
