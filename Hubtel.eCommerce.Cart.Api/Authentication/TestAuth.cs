using Hubtel.eCommerce.Cart.Api.HelperMtds;
using Hubtel.eCommerce.Cart.Api.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace Hubtel.eCommerce.Cart.Api.Authentication
{
    public class TestAuth
    (
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ICartDbHelperMethods helperMtds
        
    ):AuthenticationHandler<AuthenticationSchemeOptions>(options,logger,encoder)
    {
        ICartDbHelperMethods _helpers = helperMtds;
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Unauthorized");
            
            string authHeader = Request.Headers.Authorization!;
            
            if (string.IsNullOrEmpty(authHeader))
                return AuthenticateResult.Fail("Unauthorized");
            
            if (!authHeader.StartsWith("Basic ", StringComparison.OrdinalIgnoreCase))
                return AuthenticateResult.Fail("Unauthorized");
            
            var token = authHeader[6..];
            var credentialString = Encoding.UTF8.GetString(Convert.FromBase64String(token));
            var credentials = credentialString.Split(":");
            
            if (credentials.Length != 2)
                return AuthenticateResult.Fail("Unauthorized");
            
            var username = credentials[0];
            var password = credentials[1];
            
            //adding users from here for test purposes only
            _helpers.AddUser("isaac", "4526", role: "User");
            var user = _helpers.GetUser(username);
            
            if (!username.Equals(user?.Username) && !password.Equals(user?.Password))
                return AuthenticateResult.Fail("Unauthorized");
            
            
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,username),
                new Claim(ClaimTypes.Role, "User")
            };
            var claimsIdentity = new ClaimsIdentity(claims, "Basic");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
           
            
            return AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, Scheme.Name));

        }
        
    }
}
