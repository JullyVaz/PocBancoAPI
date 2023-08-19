using PocBancoAPI.Business.Interfaces;
using PocBancoAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocBancoAPI.Business
{
    public class UserBusiness : IUserBusiness
    {
        public Task<UserDTO> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<int> Insert(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> Update(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }
    }
}
