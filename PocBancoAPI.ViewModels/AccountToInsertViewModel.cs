using PocBancoAPI.Enums;

namespace PocBancoAPI.ViewModels
{
    public class AccountToInsertViewModel
    {
        public int IdUser { get; set; }
        public AccountTypeEnum AccountType { get; set; }

    }
}
