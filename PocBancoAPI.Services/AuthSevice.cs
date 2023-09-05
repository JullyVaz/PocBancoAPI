using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PocBancoAPI.Business.Interfaces;
using PocBancoAPI.Data.UnitOfWork;
using PocBancoAPI.DTOs;
using PocBancoAPI.Services.Interfaces;
using PocBancoAPI.Shared.Messages;
using PocBancoAPI.Shared.PasswordUtility;
using PocBancoAPI.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PocBancoAPI.Services
{
    public class AuthSevice : IAuthService
    {
        private readonly IUserBusiness _userBusiness;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AuthSevice(IUserBusiness userBusiness, IConfiguration configuration, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userBusiness = userBusiness;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponseViewModel<string>> Login(UserViewModel userLoginViewModel)
        {
            ServiceResponseViewModel<string> serviceResponseDTO = new ServiceResponseViewModel<string>();
            try
            {
                UserDTO userOnDatabase = await _userBusiness.GetByEmail(userLoginViewModel.Email);
                if (userOnDatabase.IdUser == 0)
                {
                    serviceResponseDTO.IsSucess = false;
                    serviceResponseDTO.Message = ConstantMessages.UserNotFound;
                    return serviceResponseDTO;
                }
                else if (!PasswordHashUtility.CheckHash(userLoginViewModel.Password, userOnDatabase.PasswordHash, userOnDatabase.PasswordSalt))
                {
                    serviceResponseDTO.IsSucess = false;
                    serviceResponseDTO.Message = ConstantMessages.UserNotFound;
                    return serviceResponseDTO;
                }

                string token = CreateToken(userOnDatabase);
                serviceResponseDTO.Data = token;
            }
            catch (Exception ex)
            {
                serviceResponseDTO.IsSucess = false;
                serviceResponseDTO.Message = ex.GetBaseException().Message;
            }

            return serviceResponseDTO;
        }

        public async Task<ServiceResponseViewModel<UserViewModel>> Register(UserToInsertViewModel userToInsertViewModel)
        {
            ServiceResponseViewModel<UserViewModel> serviceResponseDTO = new ServiceResponseViewModel<UserViewModel>();
            try
            {
                UserDTO userOnDatabase = await _userBusiness.GetByEmail(userToInsertViewModel.Email);
                if (userOnDatabase != null)
                {
                    serviceResponseDTO.IsSucess = false;
                    serviceResponseDTO.Message = ConstantMessages.UserAlreadyExists;
                    return serviceResponseDTO;
                }

                UserDTO userDTO = _mapper.Map<UserDTO>(userToInsertViewModel);
                PasswordHashUtility.CreateHash(userToInsertViewModel.Password, out byte[] passwordHash, out byte[] passwordSalt);
                userDTO.PasswordHash = passwordHash;
                userDTO.PasswordSalt = passwordSalt;
                userDTO.IdUser = await _userBusiness.Insert(userDTO);
                await _unitOfWork.CommitAsync();
                serviceResponseDTO.Data = _mapper.Map<UserViewModel>(userDTO);
            }
            catch (Exception ex)
            {
                serviceResponseDTO.IsSucess = false;
                serviceResponseDTO.Message = ex.GetBaseException().Message;
                await _unitOfWork.RollbackAscync();
            }

            return serviceResponseDTO;
        }

        public string CreateToken(UserDTO userDTO)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, userDTO.IdUser.ToString()),
                new Claim(ClaimTypes.Name, userDTO.Email)
            };

            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = signingCredentials
            };

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);

            return jwtSecurityTokenHandler.WriteToken(securityToken);
        }
    }
}

   
