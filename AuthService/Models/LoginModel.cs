namespace AuthService.Models
{
    public class AuthenticationResponse
    {
        public string Username { get; set; }
        public int ExpiresIn { get; set; }
        public string JwtToken { get; set; }
    }

    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
