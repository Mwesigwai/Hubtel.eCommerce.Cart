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
    public class Test2
    {
        [Fact]
        public void CartDbHelperMethods_IncrementQty_Properly()
        {
            var context = TestDbContext.GetDbContext();
            var item = CartItemTestObj.GetForTest2();
            var helper = new CartDbHelperMethods(context);
            var service = new CartDatabaseService(context, helper);

            service.AddItem(item);

            var qty1 = helper.IncrementQuantity(item);
            qty1.Should().Be(4);

            service.AddItem(item);
            var qty2 = helper.IncrementQuantity(item);
            qty2.Should().Be(8);
        }
    }
}
