using Microsoft.EntityFrameworkCore.Storage;
using PocBancoAPI.Data.Context;

namespace PocBancoAPI.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appdbcontext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appdbcontext = appDbContext;
            _appdbcontext.Database.BeginTransaction();
        }

        public async Task CommitAsync()
        {
            await _appdbcontext.Database.CommitTransactionAsync();
        }

        public async Task RollBackAsync()
        {
            await _appdbcontext.Database.RollbackTransactionAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _appdbcontext.SaveChangesAsync();
        }
    }
}