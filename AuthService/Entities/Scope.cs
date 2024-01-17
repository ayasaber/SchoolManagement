namespace AuthService.Entities
{
    public class Scope
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<UserScope> UserScopes { get; set; }
    }
}
