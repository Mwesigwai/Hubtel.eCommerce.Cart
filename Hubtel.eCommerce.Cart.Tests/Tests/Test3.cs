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
    public class Test3
    {
        [Fact]
        public void HelperMethods_IsValid_Returns_False_with_Invalid_CartItem()
        {
            var context = TestDbContext.GetDbContext();
            var item = CartItemTestObj.GetInvalid();
            var helper = new CartDbHelperMethods(context);

            var testResult = helper.IsValid(item);
            testResult.Should().Be(false);

        }
    }
}
