using PocBancoAPI.DTOs;

namespace PocBancoAPI.Business.Interfaces
{
    public interface IUserBusiness
    {
        Task<UserDTO> GetByEmail(string email);

        Task<int> Insert(UserDTO userDTO);

        Task<UserDTO> Update(UserDTO userDTO);
    }
}
