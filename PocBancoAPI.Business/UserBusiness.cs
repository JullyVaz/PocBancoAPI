using AutoMapper;
using PocBancoAPI.Business.Interfaces;
using PocBancoAPI.Data.Interfaces;
using PocBancoAPI.DTOs;
using PocBancoAPI.Entities;
using System.Text;


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
            Validate(userDTO);
            User user = _mapper.Map<User>(userDTO);
            int userId = await _userRepository.Insert(user);
            return userId;
        }
        private void Validate(UserDTO UserDTO)
        {
            List<string> validationErrors = new List<string>();

            if (string.IsNullOrWhiteSpace(UserDTO.FirstName))
            {
                validationErrors.Add("O campo 'FirstName' é obrigatório.");
            }

            if (string.IsNullOrWhiteSpace(UserDTO.MiddleName))
            {
                validationErrors.Add("O campo 'MiddleName' é obrigatório.");
            }

            if (string.IsNullOrWhiteSpace(UserDTO.LastName))
            {
                validationErrors.Add("O campo 'LastName' é obrigatório.");

            if (string.IsNullOrWhiteSpace(UserDTO.Email))
            {
                validationErrors.Add("O campo 'Email' é obrigatório.");
            }

            if (string.IsNullOrWhiteSpace(UserDTO.Document))
            {
                validationErrors.Add("O campo 'Document' é obrigatório.");
            }

            }


            if (validationErrors.Count > 0)
            {
                StringBuilder errorMessage = new StringBuilder("Erros de validação encontrados:");

                foreach (string error in validationErrors)
                {
                    errorMessage.AppendLine();
                    errorMessage.AppendLine(error);
                }

                throw new ArgumentException(errorMessage.ToString());
            }

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
