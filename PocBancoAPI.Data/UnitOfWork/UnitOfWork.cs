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

        public async Task RollbackAsync()
        {
            await _appdbcontext.Database.RollbackTransactionAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _appdbcontext.SaveChangesAsync();
        }

        Task IUnitOfWork.RollbackAscync()
        {
            throw new NotImplementedException();
        }

        Task IUnitOfWork.RollBackAsync()
        {
            throw new NotImplementedException();
        }
    }
}