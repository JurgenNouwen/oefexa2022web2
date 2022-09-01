
using IdentityModel;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using IdentityServer4;

namespace IdentityServerHost.Quickstart.UI
{
    public class TestUsers
    {
        public static List<TestUser> Users
        {
            get
            {
                var address = new
                {
                    street_address = "One Hacker Way",
                    locality = "Hasselt",
                    postal_code = 3500,
                    country = "Belgium"
                };
                
                return new List<TestUser>
                {
                    new TestUser
                    {
                        SubjectId = "818727",
                        Username = "Kristof",
                        Password = "Kristof",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "Kristof Palmaers"),
                            new Claim(JwtClaimTypes.GivenName, "Kristof"),
                            new Claim(JwtClaimTypes.FamilyName, "Palmaers"),
                            new Claim(JwtClaimTypes.Email, "kristof@pxl.be"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.WebSite, "http://kristof.com"),
                            new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json)
                        }
                    },
                    new TestUser
                    {
                        SubjectId = "88421113",
                        Username = "Wesley",
                        Password = "Wesley",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "Wesley Hendrikx"),
                            new Claim(JwtClaimTypes.GivenName, "Wesley"),
                            new Claim(JwtClaimTypes.FamilyName, "Hendrikx"),
                            new Claim(JwtClaimTypes.Email, "wesley@pxl.be"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.WebSite, "http://wesley.com"),
                            new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json)
                        }
                    }
                };
            }
        }
    }
}