namespace AuthService.Entities
{
    public class UserScope
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ScopeId { get; set; }
        public virtual User User { get; set; }
        public virtual Scope Scope { get; set; }
    }
}
