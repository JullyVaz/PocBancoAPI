using System.Collections.Generic;

namespace PocBancoAPI.DTOs
{
    public class UserDTO : BaseDTO
    {
        public int IdUser { get; set; }
        public string FirstName { get; set; } = default!;
        public string MiddleName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Document { get; set; }
        public byte[] PasswordHash { get; set; } = default!;
        public byte[] PasswordSalt { get; set; } = default!;

        //public virtual List<Account> Accounts { get; set; }

    }
}
