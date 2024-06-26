﻿using Hubtel.eCommerce.Cart.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubtel.eCommerce.Cart.Tests.Tests.TestServices
{
    public class CartItemTestObj
    {
        static public ICartItem GetForTest1()
        {
            var cartitem = new CartItem
            {
                ItemId = 2,
                Quantity = 2,
                ItemName = "soap",
                UnitPrice = 200,
                PhoneNumber = "jdjdjdjdjdj"
            };
            return cartitem;
        }
        
        static public ICartItem GetForTest2()
        {
            var cartitem = new CartItem
            {
                ItemId = 1,
                Quantity = 2,
                ItemName = "soap",
                UnitPrice = 200,
                PhoneNumber = "jdjdjdjdjdj"
            };
            return cartitem;
        }

        static public IEnumerable<ICartItem> GetForTest4()
        {
            return new List<ICartItem>
            {
                new CartItem
                {
                    PhoneNumber = "lflflflflf",
                    ItemId = 5,
                    ItemName = "Fish",
                    UnitPrice=200,
                    Quantity = 3
                },
                new CartItem
                {
                    PhoneNumber = "lflflflflf",
                    ItemId = 6,
                    ItemName = "Eggs",
                    UnitPrice=200,
                    Quantity = 3
                },
                new CartItem
                {
                    PhoneNumber = "lflflflflf",
                    ItemId = 7,
                    ItemName = "Meat",
                    UnitPrice=200,
                    Quantity = 3
                }
            };
        }

        static public ICartItem GetInvalid()
        {
            var cartitem = new CartItem
            {
                ItemId = 0,
                Quantity = 0,
                ItemName = "",
                UnitPrice = 0,
                PhoneNumber = ""
            };
            return cartitem;
        }
    }
}
