using Microsoft.AspNetCore.Authentication;

namespace Diligent.MinimalAPI.Auth
{
    public class ApiKeyAuthSchemeOptions : AuthenticationSchemeOptions
    {
        public string ApiKey { get; set; } = "VerySecret";
    }
}
