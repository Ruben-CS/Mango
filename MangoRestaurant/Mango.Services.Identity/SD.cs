using Duende.IdentityServer.Models;

namespace Mango.Services.Identity;

public static class SD
{
    public const string Admin    = "Admin";
    public const string Customer = "Customer";

    public static IEnumerable<IdentityResource> IdentityResources => new
        List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

    public static IEnumerable<ApiScope> ApiScopes => new List<ApiScope>
    {
        new ApiScope("MangoAdmin", "Mango Server"),
        new ApiScope(name: "read", displayName: "Read your data"),
        new ApiScope(name: "write", displayName: "Write your data"),
        new ApiScope(name: "delete", displayName: "Delete your data")
    };

    //Represents the applications that will connect to our identity server
    public static IEnumerable<Client> Clients => new List<Client>
    {
        new Client()
        {
            ClientId          = "client",
            ClientSecrets     = { new Secret("Secret".Sha256()) },
            AllowedGrantTypes = GrantTypes.ClientCredentials,
            AllowedScopes     = { "read", "write", "profile" }
        },
        
    };
}