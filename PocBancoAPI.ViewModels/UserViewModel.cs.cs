﻿namespace PocBancoAPI.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public string FirstName { get; set; } = default!;
        public string MiddleName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;

    }
}
