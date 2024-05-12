namespace Hubtel.eCommerce.Cart.Api.Models
{
    public interface ICartItem
    {
        int ItemId { get; set; }
        string ItemName { get; set; }
        string PhoneNumber { get; set; }
        int Quantity { get; set; }
        int UnitPrice { get; set; }
    }
}