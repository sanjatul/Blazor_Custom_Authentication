using System.Security.Claims;

namespace CustomAuthBlazor
{
    public record LoggedInUserModel(int Id,string Name,string Email)
    {
        public Claim[] ToClaims() => [
            new Claim(ClaimTypes.NameIdentifier, Id.ToString()),
            new Claim(ClaimTypes.Name, Name),
            new Claim(ClaimTypes.Email, Email)
            ];
    };
}
