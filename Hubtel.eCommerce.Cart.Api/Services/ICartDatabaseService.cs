using Hubtel.eCommerce.Cart.Api.Models;

namespace Hubtel.eCommerce.Cart.Api.Services
{
    public interface ICartDatabaseService
    {
        bool  AddItem(ICartItem item);
        ICartItem GetById(int id);
        ICartItem GetByPhoneNumber(string phoneNumber);
        IEnumerable<ICartItem> GetByQuantity(int quantity);
        IEnumerable<ICartItem> GetItems();
        (string status, bool itemRemoved) Remove(int itemId);
    }
}