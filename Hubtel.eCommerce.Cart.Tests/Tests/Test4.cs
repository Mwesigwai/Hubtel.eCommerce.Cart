using FluentAssertions;
using Hubtel.eCommerce.Cart.Api.HelperMtds;
using Hubtel.eCommerce.Cart.Api.Services;
using Hubtel.eCommerce.Cart.Tests.Tests.TestServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubtel.eCommerce.Cart.Tests.Tests
{
    public class Test4
    {
        [Fact]
        public void CartDbHelperMethods_GetByQty_returns_only_items_with_same_qty()
        {
            //arrange
            var dbcontext = TestDbContext.GetDbContext();
            var helpers = new CartDbHelperMethods(dbcontext);
            var service = new CartDatabaseService(dbcontext, helpers);
            var cartitems = CartItemTestObj.GetForTest4();
            var testQty = 3;
            foreach (var item in cartitems)
            {
                service.AddItem(item);
            }



            // Act and assert
            var items = service.GetByQuantity(testQty);
            foreach (var item in items)
            {
                item.Quantity.Should().Be(testQty);
            }
        }
    }
}
