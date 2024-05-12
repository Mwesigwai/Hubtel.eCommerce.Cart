using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Hubtel.eCommerce.Cart.Api.Models;
using FakeItEasy;
using Hubtel.eCommerce.Cart.Api.Services;
using Hubtel.eCommerce.Cart.Api.Data;
using Hubtel.eCommerce.Cart.Api.HelperMtds;
using Microsoft.EntityFrameworkCore;

namespace Hubtel.eCommerce.Cart.Tests
{
    public class Test1
    {

        [Fact]
        public void CartDatabaseService_increments_quantity_if_item_Added_More_than_once()
        {
            var options = new DbContextOptionsBuilder<CartDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            var dbcontext = new CartDbContext(options);
            dbcontext.Database.EnsureCreated();


        }
    }
}
