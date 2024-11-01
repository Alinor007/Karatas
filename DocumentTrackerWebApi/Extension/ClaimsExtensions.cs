using System.Security.Claims;

namespace DocumentTrackerWebApi.Extension
{
    public static class ClaimsExtensions
    {
        public static string GetUsername(this ClaimsPrincipal user)
        {
            // Check if the user has the 'givenname' claim and return it
            var givenNameClaim = user.Claims.SingleOrDefault(x => x.Type == ClaimTypes.GivenName);
            if (givenNameClaim != null)
            {
                return givenNameClaim.Value;
            }

            // Fall back to name or other identifiers if 'givenname' doesn't exist
            var nameClaim = user.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Name);
            if (nameClaim != null)
            {
                return nameClaim.Value;
            }

            // Fall back to a default value (optional)
            return string.Empty; // Or handle according to your requirements
        }
    }
}
