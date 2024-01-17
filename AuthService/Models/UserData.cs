namespace AuthService.Models
{
    public record UserData(string Username, string Password, string Role, string[] Scopes);

}
