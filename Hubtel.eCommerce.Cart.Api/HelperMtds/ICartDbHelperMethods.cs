using Hubtel.eCommerce.Cart.Api.Models;

namespace Hubtel.eCommerce.Cart.Api.HelperMtds
{
    public interface ICartDbHelperMethods
    {
        object AddToCart(ICartItem item);
        void AddUser(string username, string password, string role);
        IUser GetUser(string username);
        object IncrementQuantity(ICartItem item);
        bool IsValid(ICartItem item);
        bool ItemExists(ICartItem? itemFromDatabase);
        ICartItem LookForItem(int itemId);
        IEnumerable<ICartItem> LookForItemByQty(int quantity);
        (string status, bool itemRemoved) RemoveItem(int itemId);
    }
}   