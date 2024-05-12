using Hubtel.eCommerce.Cart.Api.Data;
using Hubtel.eCommerce.Cart.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Hubtel.eCommerce.Cart.Api.HelperMtds
{
    public class CartDbHelperMethods(CartDbContext context) 
        : ICartDbHelperMethods
    {
        CartDbContext _context = context;
        public object AddToCart(ICartItem item)
        {
            _context
                .Cart
                .Add(new CartItem
                {
                    ItemId = item.ItemId,
                    PhoneNumber = item.PhoneNumber,
                    ItemName = item.ItemName,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice
                });
            _context.SaveChanges();
            return true;
        }

        public object IncrementQuantity(ICartItem item)
        {
            var existingItem =
               _context
                .Cart.Find(item.ItemId);
            if (existingItem is not null)
            {
                existingItem.Quantity += item.Quantity;
                _context.SaveChanges();
                return existingItem.Quantity;
            }
            return null!;

        }

        public bool ItemExists(ICartItem? itemFromDatabase)
        {
            return itemFromDatabase is not null;
        }

        public ICartItem LookForItem(int itemId)
        {
            return _context
                    .Cart
                    .FirstOrDefault
                    (i => i.ItemId == itemId)!;
        }

        public bool IsValid(ICartItem item)
        {
            return item.ItemId > 0
                && item.ItemName is not null
                && item.Quantity is > 0
                && item.PhoneNumber is not null
                && item.UnitPrice > 0;
        }

        public IEnumerable<ICartItem> LookForItemByQty(int quantity)
        {
            if (quantity > 0)
                return _context
                    .Cart
                    .Where
                    (item => item.Quantity == quantity);
            return null!;
        }

        public (string status,bool itemRemoved) RemoveItem(int itemId)
        {
            var item = _context
                .Cart
                .FirstOrDefault
                (i => i.ItemId == itemId);
            if (item is not null)
            {
                _context.Remove(item);
                _context.SaveChanges();
                return ("Item removed",true);
            }
            return ("Item not found",false);
        }
    }
}
