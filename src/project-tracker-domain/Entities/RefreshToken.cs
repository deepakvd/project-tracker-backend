namespace project_tracker_domain.Entities
{
    public class RefreshToken : BaseEntity
    {
        public Guid UserId { get; set; }

        public User User { get; set; }

        public string Token { get; set; }        // the actual token value

        public DateTime ExpiresAt { get; set; }  // long-lived, 7-30 days

        public DateTime? RevokedAt { get; set; } // set on logout or rotation

        public bool IsUsed { get; set; }         // reuse detection

        public string? ReplacedByToken { get; set; } // which token replaced this one
    }
}