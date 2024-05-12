using Hubtel.eCommerce.Cart.Api.Data;
using Hubtel.eCommerce.Cart.Api.HelperMtds;
using Hubtel.eCommerce.Cart.Api.Models;
using Microsoft.AspNetCore.Mvc.Razor;

namespace Hubtel.eCommerce.Cart.Api.Services
{
    public class CartDatabaseService
        (CartDbContext cartDbContext,ICartDbHelperMethods cartDbHelperMethods)
        : ICartDatabaseService
    {
        ICartDbHelperMethods cartHelpers = cartDbHelperMethods;
        CartDbContext _context = cartDbContext;
        
        public bool AddItem(ICartItem item)
        {
            if (cartHelpers.IsValid(item))
            {
                var itemFromDatabase = cartHelpers.LookForItem(item.ItemId);
                _ = cartHelpers.ItemExists(itemFromDatabase) ?
                    cartHelpers.IncrementQuantity(item) :
                    cartHelpers.AddToCart(item);
                return (true);
            }
            return (false);
        }
        public IEnumerable<ICartItem> GetItems()
        {
            var items = new List<ICartItem>();
            var storedItems = _context.Cart;
            //items = storedItems.ToList<ICartItem>();
            foreach (var item in storedItems)
            {
                items.Add(item);
            }
            return items;
        }

        public ICartItem GetByPhoneNumber(string phoneNumber)
        {
            if(_context.Cart.Any(item => item.PhoneNumber == phoneNumber))
            {
                return
                    _context
                    .Cart
                    .FirstOrDefault(item => item.PhoneNumber == phoneNumber)!;
            }
            return null!;
        }

        public IEnumerable<ICartItem> GetByQuantity(int quantity)
        {
            if(quantity > 0)
                return cartHelpers.LookForItemByQty(quantity);

            return null!;
        }

        public ICartItem GetById(int id)
        {
            if(id > 0)
                return cartHelpers.LookForItem(id);

            return null!;
        }

        public (string status, bool itemRemoved) Remove(int itemId)
        {          
            return cartHelpers.RemoveItem(itemId);
        }
    }
}
