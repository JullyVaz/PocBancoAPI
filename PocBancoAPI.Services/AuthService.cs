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
using System.Net;
using System.Security.Claims;
using System.Text;

namespace PocBancoAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserBusiness _userBusiness;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(IUserBusiness userBusiness, IConfiguration configuration, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userBusiness = userBusiness;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponseViewModel<string>> Login(UserLoginViewModel userLoginViewModel)
        {
            ServiceResponseViewModel<string> serviceResponseViewModel = new ServiceResponseViewModel<string>();
            try
            {
                UserDTO userOnDatabase = await _userBusiness.GetByEmail(userLoginViewModel.Email);
                if (userOnDatabase.IdUser == 0)
                {
                    serviceResponseViewModel.IsSucess = false;
                    serviceResponseViewModel.Message = ConstantMessages.UserNotFound;
                    return serviceResponseViewModel;
                }
                else if (!PasswordHashUtility.CheckHash(userLoginViewModel.Password, userOnDatabase.PasswordHash, userOnDatabase.PasswordSalt))
                {
                    serviceResponseViewModel.IsSucess = false;
                    serviceResponseViewModel.Message = ConstantMessages.UserOrPasswordInvalid;
                    return serviceResponseViewModel;
                }

                string token = CreateToken(userOnDatabase);
                serviceResponseViewModel.Data = token;
                serviceResponseViewModel.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                serviceResponseViewModel.IsSucess = false;
                serviceResponseViewModel.Message = ex.GetBaseException().Message;
            }

            return serviceResponseViewModel;
        }

        public async Task<ServiceResponseViewModel<UserViewModel>> Register(UserToInsertViewModel userToInsertViewModel)
        {
            ServiceResponseViewModel<UserViewModel> serviceResponseViewModel = new ServiceResponseViewModel<UserViewModel>();
            try
            {
                UserDTO userOnDatabase = await _userBusiness.GetByEmail(userToInsertViewModel.Email);
                if (userOnDatabase != null)
                {
                    serviceResponseViewModel.IsSucess = false;
                    serviceResponseViewModel.Message = ConstantMessages.UserAlreadyExists;
                    return serviceResponseViewModel;
                }

                UserDTO userDTO = _mapper.Map<UserDTO>(userToInsertViewModel);
                PasswordHashUtility.CreateHash(userToInsertViewModel.Password, out byte[] passwordHash, out byte[] passwordSalt);
                userDTO.PasswordHash = passwordHash;
                userDTO.PasswordSalt = passwordSalt;
                userDTO.IdUser = await _userBusiness.Insert(userDTO);
                serviceResponseViewModel.StatusCode = HttpStatusCode.Created;
                serviceResponseViewModel.Data = _mapper.Map<UserViewModel>(userDTO);
            }
            catch (Exception ex)
            {
                serviceResponseViewModel.IsSucess = false;
                serviceResponseViewModel.Message = ex.GetBaseException().Message;
                await _unitOfWork.RollBackAsync();
            }
            finally
            {
                await _unitOfWork.CommitAsync();
            }

            return serviceResponseViewModel;
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


