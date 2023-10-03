using PocBancoAPI.Enums;

namespace PocBancoAPI.ViewModels
{
    public class AccountViewModel
    {
        public int IdAccount { get; set; }
        public int IdUser { get; set; }
        public UserViewModel UserViewModel { get; set; }
        public List<FinancialOperationViewModel> FinancialOperationViewModels { get; set; }
        public decimal Balance { get; set; }
        public AccountTypeEnum AccountType { get; set; }
    }
}
