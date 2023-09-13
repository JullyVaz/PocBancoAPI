using Microsoft.EntityFrameworkCore;
using PocBancoAPI.Data.Context;
using PocBancoAPI.Data.Interfaces;
using PocBancoAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocBancoAPI.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<User> GetByEmail(string email)

        {
            User user = await _appDbContext.Set<User>().FirstOrDefaultAsync(x => x.Email == email);
            return user;
        }

        public async Task<int> Insert(User user)
        {
            await _appDbContext.Set<User>().AddAsync(user);
            await _appDbContext.SaveChangesAsync();
            return user.IdUser;
        }

        public async Task<User> Update(User user)
        {
            _appDbContext.Set<User>().Update(user);
            await _appDbContext.SaveChangesAsync();
            User updatedUser = await _appDbContext.Set<User>().FirstOrDefaultAsync(x => x.IdUser == user.IdUser);
            return updatedUser;
        }
    }
}

