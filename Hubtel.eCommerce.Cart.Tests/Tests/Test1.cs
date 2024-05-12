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
using Hubtel.eCommerce.Cart.Tests.Tests.TestServices;

namespace Hubtel.eCommerce.Cart.Tests.Tests
{
    public class Test1
    {
        [Fact]
        public void CartDatabaseService_increments_quantity_if_item_Added_More_than_once()
        {
            //Arrange
            var dbcontext = TestDbContext.GetDbContext();
            var helpers = new CartDbHelperMethods(dbcontext);
            var service = new CartDatabaseService(dbcontext, helpers);
            var cartitem = CartItemTestObj.GetForTest1();



            // act and assert
            service.AddItem(cartitem);
            var item = service.GetById(2);
            item.Quantity.Should().Be(2);

            service.AddItem(cartitem);
            var item2 = service.GetById(2);
            item2.Quantity.Should().Be(4);

        }
    }
}
