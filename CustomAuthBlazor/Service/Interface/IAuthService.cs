using CustomAuthBlazor.Models;

namespace CustomAuthBlazor.Service.Interface
{
    public interface IAuthService
    {
        Task<UserDetails?> GetUserDetails(LoginModel loginModel);
    }
}
