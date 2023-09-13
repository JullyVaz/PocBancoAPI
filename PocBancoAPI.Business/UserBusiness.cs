using AutoMapper;
using PocBancoAPI.Business.Interfaces;
using PocBancoAPI.Data.Interfaces;
using PocBancoAPI.DTOs;
using PocBancoAPI.Entities;

namespace PocBancoAPI.Business
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserBusiness(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDTO> GetByEmail(string email)
        {
            User user = await _userRepository.GetByEmail(email);
            UserDTO userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }

        public async Task<int> Insert(UserDTO userDTO)
        {
            User user = _mapper.Map<User>(userDTO);
            int userId = await _userRepository.Insert(user);
            return userId;
        }

        public async Task<UserDTO> Update(UserDTO userDTO)
        {
            User user = _mapper.Map<User>(userDTO);
            user = await _userRepository.Update(user);
            userDTO = _mapper.Map<UserDTO>(user);

            return userDTO;
        }
    }
}
