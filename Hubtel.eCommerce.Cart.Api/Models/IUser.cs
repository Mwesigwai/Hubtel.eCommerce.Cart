namespace Hubtel.eCommerce.Cart.Api.Models
{
    public interface IUser
    {
        string Password { get; set; }
        string Username { get; set; }
        string Role { get; set; }
    }
}