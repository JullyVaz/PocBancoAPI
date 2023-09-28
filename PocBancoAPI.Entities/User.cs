namespace PocBancoAPI.Entities
{
    public class User
    {
        public int IdUser { get; set; }
        public bool IsActive { get; set; }
        public string FirstName { get; set; } = default!;
        public string MiddleName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Document { get; set; } = default!;
        public string Email { get; set; } = default!;
        public byte[] PasswordHash { get; set; } = default!;
        public byte[] PasswordSalt { get; set; } = default!;
        public virtual List<Account> Accounts { get; set; }

    }
}
