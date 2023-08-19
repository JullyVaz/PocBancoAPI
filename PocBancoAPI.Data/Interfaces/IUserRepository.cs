using PocBancoAPI.Entities;

namespace PocBancoAPI.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<int> Insert(User user);

        Task<User> Update(User user);

        Task<User> GetByEmail(string email);

    }

}
