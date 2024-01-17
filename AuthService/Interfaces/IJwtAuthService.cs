using AuthService.Models;

namespace AuthService.Interfaces
{
    
    public interface IJwtAuthService
    {
        Task<Response<string>> GetToken(LoginModel userModel);
    }
}
